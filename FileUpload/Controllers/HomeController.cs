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
    public class HomeController : Controller
    {
        private readonly IFileUploadService _service;
        public HomeController(IFileUploadService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm]FileUploadViewModel model)
        {
            if(ModelState.IsValid)
            {

            bool result = await _service.FileUploadSave(model);
                return View();
            }

            ModelState.AddModelError("", "Error Occurred on upload.");

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
