using FileUpload.Models;
using System.Threading.Tasks;

namespace FileUpload.Services
{
    public interface IFileUploadService
    {
        Task<bool> FileUploadSave(FileUploadViewModel model);
    }
}