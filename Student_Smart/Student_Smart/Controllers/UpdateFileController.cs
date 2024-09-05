using Database.Model;
using Microsoft.AspNetCore.Mvc;

namespace Student_Smart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateFileController : ControllerBase
    {
        private static IWebHostEnvironment _webHostEnvironment;
        public UpdateFileController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;


        }
        [HttpPost("updateFile")]
        public async Task<string> Post([FromForm] UpdateFile updateFile)
        {
            try
            {
                if (updateFile.Files.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + updateFile.Files.FileName))
                    {
                        updateFile.Files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "upload succcess";
                    }
                }
                else
                {
                    return "upload failed";
                }
            }
            catch
            {
                throw new Exception("update anh khong thanh cong");
            }
        }

        [HttpGet("getFile")]
        public async Task<IActionResult> Get([FromRoute] string fileName)
        {
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            var filePath = path + fileName + ".png";
            if (System.IO.File.Exists(filePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);
                return File(b, "image/png");

            }
            return Ok();
        }
    }
}
