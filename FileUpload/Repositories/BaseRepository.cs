using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileUpload.Data;
using FileUpload.Models;
using Microsoft.EntityFrameworkCore;

namespace FileUpload.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Save(FileUploadModel model)
        {
            _context.Set<FileUploadModel>().Add(model);
            _context.SaveChanges();

            return true;
        }

        public async Task<List<FileUploadModel>> GetAll()
        {
            return await _context.Set<FileUploadModel>().ToListAsync();
        }
    }
}
