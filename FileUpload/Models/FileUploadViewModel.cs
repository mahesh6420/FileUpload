using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace FileUpload.Models
{
    public class FileUploadViewModel
    {
        [Required]
        public string FileName {get;set;}

        [Required]
        public IFormFile UploadedFile{get;set;}

        public string FilePath {get;set;}
    }
}