using FileUpload.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileUpload.Services
{
    public interface IFileUploadService
    {
        Task<bool> FileUploadSave(FileUploadViewModel model);
        Task<List<FileUploadViewModel>> GetAll();
    }
}