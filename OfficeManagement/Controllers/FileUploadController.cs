using Microsoft.AspNetCore.Mvc;

namespace OfficeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded");

            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            Directory.CreateDirectory(uploadFolder);

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

            var filePath = Path.Combine(uploadFolder, uniqueFileName);

            // Save the file
            await using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);

            var fileUrl = $"/uploads/{uniqueFileName}";
            return Ok(new { fileUrl });
        }
    }
}
