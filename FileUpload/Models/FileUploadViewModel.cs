using System;
using Microsoft.AspNetCore.Http;

namespace FileUpload.Models
{
    public class FileUploadViewModel
    {
        public string FileName {get;set;}
        public IFormFile UploadedFile{get;set;}
    }
}