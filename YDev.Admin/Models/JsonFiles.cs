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

}
