namespace MarsBackEnd.Utilities
{
    public class PhotoHelper
    {
        private readonly IWebHostEnvironment _environment;
        private readonly string _uploadPath;
        public PhotoHelper(IWebHostEnvironment environment)
        {
            _environment = environment;
            _uploadPath = Path.Combine(_environment.WebRootPath, "uploads");
        }
        public async Task<string> SendSettingsForSavePhoto()
        {
            try
            {
                var result = await _photoService.SevePhoto(_uploadPath);
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
