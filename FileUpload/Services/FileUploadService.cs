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

            Guid guid = new Guid();
            string path = Path.Combine(
                $"wwwroot\\images\\{guid.ToString()}", model.UploadedFile.FileName);

            if(!Directory.Exists($"wwwroot\\images\\{guid}"))
            {
                Directory.CreateDirectory($"wwwroot\\images\\{guid}");
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await model.UploadedFile.CopyToAsync(stream);
            }

            return true;
        }
    }
}