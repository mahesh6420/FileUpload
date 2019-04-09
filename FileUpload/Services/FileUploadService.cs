using FileUpload.Models;
using FileUpload.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IBaseRepository _baseRepsitory;

        public FileUploadService(IBaseRepository baseRepsitory)
        {
            _baseRepsitory = baseRepsitory;
        }

        public async Task<bool> FileUploadSave(FileUploadViewModel model)
        {
            try
            {
                if (model.UploadedFile == null || model.UploadedFile.Length == 0)
                {
                    return false;
                }

                Guid guid = Guid.NewGuid();
                string directory = $"wwwroot\\images\\{guid.ToString()}";
                string path = Path.Combine(
                    $"wwwroot\\images\\{guid.ToString()}", model.UploadedFile.FileName);

                string imageUrl = Path.Combine($"images\\{ guid.ToString()}", model.UploadedFile.FileName);

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.UploadedFile.CopyToAsync(stream);
                }

                FileUploadModel m = new FileUploadModel
                {
                    FileName = model.FileName,
                    FilePath = imageUrl
                };

                _baseRepsitory.Save(m);

                return true;
            }
            catch(Exception ex)
            {

            }

            return false;
        }

        public async Task<List<FileUploadViewModel>> GetAll()
        {
            return (
                from m in await _baseRepsitory.GetAll()
                select new FileUploadViewModel
                {
                    FileName = m.FileName,
                    FilePath = m.FilePath
                }).ToList();
        }
    }
}