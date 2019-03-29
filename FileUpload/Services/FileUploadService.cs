using FileUpload.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FileUpload.Services
{
    public class FileUploadService : IFileUploadService
    {
        public async Task<bool> FileUploadSave(FileUploadViewModel model)
        {
            if (model.UploadedFile == null || model.UploadedFile.Length == 0)
            {
                return false;
            }

            string path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot", "images",
                string.Concat("a", new Guid().ToString()));

            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (var stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                await model.UploadedFile.CopyToAsync(stream);
            }

            return true;
        }
    }
}