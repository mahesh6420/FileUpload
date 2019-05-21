using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FileUpload.Models;
using FileUpload.Services;

namespace FileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFromApiController : ControllerBase
    {
        private readonly IFileUploadService _service;
        public UploadFromApiController(IFileUploadService service)
        {
            _service = service;
        }

         public IActionResult Create()
        {
            throw new NotImplementedException();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]FileUploadViewModel model)
        {
            if(ModelState.IsValid)
            {

                bool result = await _service.FileUploadSave(model);

                return Ok(200);
            }

            ModelState.AddModelError("", "Error Occurred on upload.");

            return Ok(false);
        }

        [HttpPost]
        public async Task<IActionResult> MultiCreate([FromForm]MultipleFileUploadViewModel model)
        {
            if(ModelState.IsValid)
            {

                bool result = await _service.FileUploadSave(model.File[0]);

                return Ok(200);
            }

            ModelState.AddModelError("", "Error Occurred on upload.");

            return Ok(false);
        }
    }
}