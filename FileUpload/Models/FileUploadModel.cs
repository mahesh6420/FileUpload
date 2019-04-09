using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace FileUpload.Models
{
    public class FileUploadModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string FileName {get;set;}

        [Required]
        public string FilePath {get;set;}
    }
}