using DLL.Repository;
using Domain.Entity;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PhotoService
    {
        private readonly PhotoRepository _photoRepository;
        public PhotoService(PhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }
        public async Task<IBaseResponse<Photo>> SavePhotoAsync(string uploadPath,string name, Stream photoStream)
        {
            try
            {
                var filePath = Path.Combine(uploadPath, name);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await photoStream.CopyToAsync(fileStream);
                }
                Photo photo = new Photo()
                {
                    FileName = name,
                    FilePath = filePath,
                    UploadDate = DateTime.Now,
                    Title = name
                };
                _photoRepository.Create(photo);
                return new BaseResponse<Photo>
                {
                    Data = photo,
                    Description = "Файл успішно створенно",
                    StatusCode = Domain.Enum.StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Photo>
                {
                    Data = null,
                    Description = $"[PhotoService.SavePhotoAsync] error: {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }
        }
    }
}
