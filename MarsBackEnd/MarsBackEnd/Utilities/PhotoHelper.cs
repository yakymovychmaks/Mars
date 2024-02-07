using BLL.Services;

namespace MarsBackEnd.Utilities
{
    public class PhotoHelper
    {
        private readonly IWebHostEnvironment _environment;
        private string _uploadPath;
        public PhotoHelper(IWebHostEnvironment environment)
        {
            _environment = environment;
            //_uploadPath = Path.Combine(_environment.WebRootPath, "uploads");
            _uploadPath = "api/upload/files";
        }
        public async Task<string> SendSettingsForSavePhoto()
        {
            try
            {

                return _uploadPath;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
