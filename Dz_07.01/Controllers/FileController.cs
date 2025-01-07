using System.Diagnostics;
using Dz_07._01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dz_07._01.Controllers
{
    public class FileController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public FileController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View(new FileModel());
        }

        [HttpPost]
        public IActionResult Upload(FileModel model)
        {
            if (model.File != null && model.File.Length > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".png", ".pdf", ".txt" };
                var fileExtension = Path.GetExtension(model.File.FileName);

                if (!allowedExtensions.Contains(fileExtension))
                {
                    model.IsSuccess = false;
                    model.Message = "Invalid file type. Allowed types: .jpg, .png, .pdf, .txt";
                    return View(model);
                }

                if (model.File.Length > 5 * 1024 * 1024)
                {
                    model.IsSuccess = false;
                    model.Message = "File size exceeds the 5 MB limit.";
                    return View(model);
                }

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileNameWithPath = Path.Combine(path, model.File.FileName);
                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    model.File.CopyTo(stream);
                }

                model.IsSuccess = true;
                model.Message = "File uploaded successfully.";
            }
            else
            {
                model.IsSuccess = false;
                model.Message = "Please select a file to upload.";
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Index()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var files = Directory.GetFiles(path).Select(f => Path.GetFileName(f)).ToList();
            return View(files);
        }

        [HttpGet]
        public IActionResult Download(string fileName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", fileName);
            if (!System.IO.File.Exists(path))
            {
                return NotFound("File not found");
            }

            string contentType = "application/octet-stream";
            var fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, contentType, fileName);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
