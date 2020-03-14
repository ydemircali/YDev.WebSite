﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ImageMagick;
using YDev.Admin.Utilities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SkiaSharp;
using System.Drawing;

namespace YDev.Admin.Models.FileUpload
{
    public class FileUploadUpload
    {
        public class Command : IRequest<CommandResult>
        {
            [BindNever]
            public HttpContext HttpContext { get; set; }

            public List<IFormFile> Files { get; private set; } = new List<IFormFile>();
        }

        public class CommandResult
        {
            public List<ViewDataUploadFilesResult> FileResults { get; private set; } = new List<ViewDataUploadFilesResult>();
        }


        public class CommandHandler : IRequestHandler<Command, CommandResult>
        {
            private readonly FilesHelper _filesHelper;

            public CommandHandler(FilesHelper filesHelper)
            {
                _filesHelper = filesHelper;
            }

            public async Task<CommandResult> Handle(Command message, CancellationToken cancellationToken)
            {
                var result = new CommandResult();

                var partialFileName = message.HttpContext.Request.Headers["X-File-Name"];
                if (string.IsNullOrWhiteSpace(partialFileName))
                {
                    await UploadWholeFileAsync(message, result);
                }
                else
                {
                    UploadPartialFile(message, partialFileName);
                }

                return result;
            }

            private static readonly HashSet<string> _allowedExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                ".gif",
                ".jpeg",
                ".jpg",
                ".png",
                ".mp4"
            };

            private async Task UploadWholeFileAsync(Command message, CommandResult result)
            {
                // Ensure the storage root exists.
                Directory.CreateDirectory(_filesHelper.StorageRootPath);

                foreach (var file in message.Files)
                {
                    var extension = Path.GetExtension(file.FileName);
                    if (!_allowedExtensions.Contains(extension))
                    {
                        // This is not a supported image type.
                        throw new InvalidOperationException($"Unsupported image type: {extension}. The supported types are: {string.Join(", ", _allowedExtensions)}");
                    }

                    if (file.Length > 0L)
                    {
                        var fullPath = Path.Combine(_filesHelper.StorageRootPath, Path.GetFileName(file.FileName));
                        using (var fs = new FileStream(fullPath, FileMode.Create))
                        {
                            await file.CopyToAsync(fs);
                        }

                        if (!file.ContentType.Contains("video") || !file.ContentType.Contains("mp4"))
                        {
                            await createThumb(file, extension, fullPath);
                        }

                    }

                    result.FileResults.Add(UploadResult(file.FileName, file.Length));
                }
            }

            private async Task createThumb(IFormFile file, string extension, string fullPath)
            {
                const int THUMB_WIDTH = 80;
                const int THUMB_HEIGHT = 80;
                const string THUMBS_FOLDER_NAME = "thumbs";

                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);
                var thumbName = $"{fileNameWithoutExtension}{THUMB_WIDTH}x{THUMB_HEIGHT}{extension}";
                var thumbPath = Path.Combine(_filesHelper.StorageRootPath, THUMBS_FOLDER_NAME, thumbName);
                var thumbPathRoot = Path.Combine(_filesHelper.StorageRootPath, THUMBS_FOLDER_NAME);

                // Create the thumnail directory if it doesn't exist.
                Directory.CreateDirectory(Path.GetDirectoryName(thumbPathRoot));

                // For GIFs, we have to use MagickNET. For JPEGs and PNGs, we can use SkiaSharp.
                if (IsGif(extension))
                {
                    using (var thumbStream = MagickNetResizeImage(fullPath, destWidthPx: 80, destHeightPx: 80))
                    using (var thumbFileStream = File.OpenWrite(thumbPath))
                    {
                        await thumbStream.CopyToAsync(thumbFileStream);
                    }
                }
                else
                {
                    using (var thumbStream = SkiaSharpResizeImage(fullPath, destWidthPx: 80, destHeightPx: 80))
                    using (var thumbFileStream = File.OpenWrite(thumbPath))
                    {
                        await thumbStream.CopyToAsync(thumbFileStream);
                    }
                }
            }

            private MemoryStream SkiaSharpResizeImage(string localTempFilePath, int destWidthPx, int destHeightPx)
            {
                try
                {
                    using var originalBmp = SKBitmap.Decode(localTempFilePath);
                    using var scaledBmp = originalBmp.Resize(new SKImageInfo(destWidthPx, destHeightPx), SKFilterQuality.High);
                    using var scaledImg = SKImage.FromBitmap(scaledBmp);

                    SKEncodedImageFormat encodedImageFormat;
                    int quality;

                    var extension = Path.GetExtension(localTempFilePath).ToLower();
                    switch (extension)
                    {
                        case ".jpg":
                        case ".jpeg":
                            encodedImageFormat = SKEncodedImageFormat.Jpeg;
                            quality = 90;
                            break;

                        case ".png":
                            encodedImageFormat = SKEncodedImageFormat.Png;
                            quality = 100;
                            break;

                        // Skia doesn't support resizing GIFs. We use Magick.NET for that.
                        //case ".gif":
                        //    break;

                        default:
                            throw new NotSupportedException($"Unable to resize file: unsupported image type \"{extension}\"");
                    }

                    using var scaledImgData = scaledImg.Encode(encodedImageFormat, quality);

                    var thumbnailStream = new MemoryStream();
                    scaledImgData.SaveTo(thumbnailStream);
                    thumbnailStream.Position = 0L;

                    return thumbnailStream;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Unhandled error trying to resize local image '{localTempFilePath}' to Width={destWidthPx}px, Height={destHeightPx}px", ex);
                }
            }

            private MemoryStream MagickNetResizeImage(string localTempFilePath, int destWidthPx, int destHeightPx)
            {
                try
                {
                    // Read from file
                    using (var collection = new MagickImageCollection(localTempFilePath))
                    {
                        // This will remove the optimization and change the image to how it looks at that point
                        // during the animation. More info here: http://www.imagemagick.org/Usage/anim_basics/#coalesce
                        collection.Coalesce();

                        // Resize each image in the collection to a width of 200. When zero is specified for the height
                        // the height will be calculated with the aspect ratio.
                        foreach (MagickImage image in collection)
                        {
                            image.Resize(width: destWidthPx, height: destHeightPx);
                        }

                        // Save the result
                        var resizedImgStream = new MemoryStream();
                        collection.Write(resizedImgStream);
                        resizedImgStream.Position = 0L;

                        return resizedImgStream;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Unhandled error trying to resize local image '{localTempFilePath}' to Width={destWidthPx}px, Height={destHeightPx}px", ex);
                }
            }

            /// <summary>
            /// Looks at the file's extension and returns true if this is a GIF; false otherwise.
            /// </summary>
            /// <param name="extension"></param>
            /// <returns></returns>
            private bool IsGif(string extension) => ".gif".Equals(extension, StringComparison.OrdinalIgnoreCase);


            private void UploadPartialFile(Command message, string partialFileName)
            {
                throw new NotImplementedException();
            }

            private ViewDataUploadFilesResult UploadResult(string fileName, long fileSizeInBytes)
            {
                var getType = MimeMapping.GetMimeMapping(fileName);

                var result = new ViewDataUploadFilesResult()
                {
                    name = fileName,
                    size = fileSizeInBytes,
                    type = getType,
                    url = _filesHelper.UrlBase + fileName,
                    deleteUrl = _filesHelper.DeleteUrl + fileName,
                    thumbnailUrl = _filesHelper.CheckThumb(getType, fileName),
                    deleteType = _filesHelper.DeleteType
                };

                return result;
            }
        }
    }
}
