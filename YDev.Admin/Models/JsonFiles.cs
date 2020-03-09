using System.Collections.Generic;
using System.Linq;

namespace YDev.Admin.Models
{
    public class JsonFiles
    {
        public ViewDataUploadFilesResult[] files;
        public JsonFiles(List<ViewDataUploadFilesResult> filesList)
        {
            files = new ViewDataUploadFilesResult[filesList.Count];
            for (int i = 0; i < filesList.Count; i++)
            {
                files[i] = filesList.ElementAt(i);
            }

        }
    }

    public class MyJsonFile
    {
        public Result result;
        public MyJsonFile(Result result1)
        {
            var filesList = result1.files.ToList();

            result = new Result
            {
                files = new ViewDataUploadFilesResult[filesList.Count]
            };

            for (int i = 0; i < filesList.Count; i++)
            {
                result.files[i] = filesList.ElementAt(i);
            }

        }
    }
    public class Result
    {
        public ViewDataUploadFilesResult[] files;
    }
}
