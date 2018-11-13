using CloudAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CloudAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FileController : Controller
    {
        private readonly string _uploadPath;

        public FileController(IConfiguration _config)
        {
            _uploadPath = _config[Constants.FileUploadPath];
        }

        //GET api/file/download?name=file.ext
        [HttpGet]
        public async Task<IActionResult> Download([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(Path.GetExtension(name)))
            {
                return BadRequest();
            }

            var absPath = Path.Combine(_uploadPath, name);
            if (!System.IO.File.Exists(absPath))
                return NotFound();
            var stream = await GetMemoryStream(absPath);
            return File(stream, "image/png");
        }

        //POST api/file/upload (Should be send with 'files' form key)
        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] List<IFormFile> files)
        {
            if (!ValidateFiles(files))
            {
                return BadRequest();
            }

            var fileNames = await UploadAsync(files);


            return Ok(fileNames);
        }

        private async Task<List<string>> UploadAsync(List<IFormFile> files)
        {
            if (!Directory.Exists(Path.GetDirectoryName(_uploadPath)))
                throw new DirectoryNotFoundException($"Path: '{_uploadPath}' not found");

            List<string> fileNames = new List<string>();
            foreach (var file in files)
            {
                var ext = Path.GetExtension(file.FileName);
                ext = (ext == string.Empty || ext == null) ? ".png" : ext;
                var fileName = DateTime.UtcNow.ToBinary().ToString() + ext;
                var fileStream = System.IO.File.Create(_uploadPath + fileName);
                await file.CopyToAsync(fileStream);
                fileStream.Close();
                fileNames.Add(fileName);
            }
            return fileNames;
        }

        private async Task<MemoryStream> GetMemoryStream(string absPath)
        {
            var memoryStream = new MemoryStream();
            using (var stream = new FileStream(absPath, FileMode.Open))
            {
                await stream.CopyToAsync(memoryStream);
            }
            memoryStream.Position = 0;
            return memoryStream;
        }

        private bool ValidateFiles(List<IFormFile> files)
        {
            if (files.Count == 0)
            {
                return false;
            }

            foreach (var file in files)
            {
                if (file.Length == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
