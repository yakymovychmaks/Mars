using System.IO;
using System.Threading.Tasks;
using BLL.Services;
using MarsBackEnd.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace MarsBackEnd.APIControllers
{
    [ApiController]
    [Route("api/photo")]
    public class PhotoController : ControllerBase
    {
        private readonly PhotoService _photoService;
        private readonly PhotoHelper _photoHelper;
        public PhotoController(PhotoService photoService, PhotoHelper photoHelper)
        {
            _photoService = photoService;
            _photoHelper = photoHelper;
        }

        [HttpPost("save")]
        public async Task<IActionResult> SavePhotoAsync(string uploadPath, string name, Stream photoStream)
        {
            var response = await _photoService.SavePhotoAsync(uploadPath, name, photoStream);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetImageAsync(string path, string imageName)
        {
            path = await _photoHelper.SendSettingsForSavePhoto();
            var imageStream = await _photoService.GetIamgeAsync(path, imageName);
            if (imageStream == null)
            {
                return NotFound();
            }
            return File(imageStream, "image/jpeg"); // Або інший тип MIME, залежно від типу зображення
        }
    }
}
