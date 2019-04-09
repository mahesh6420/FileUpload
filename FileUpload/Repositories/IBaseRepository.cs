using FileUpload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Repositories
{
    public interface IBaseRepository
    {
        bool Save(FileUploadModel model);
        Task<List<FileUploadModel>> GetAll();
    }
}
