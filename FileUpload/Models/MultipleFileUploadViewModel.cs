using System.Collections.Generic;

namespace FileUpload.Models
{
    public class MultipleFileUploadViewModel
    {
        public IList<FileUploadViewModel> File { get; set; }
    }
}