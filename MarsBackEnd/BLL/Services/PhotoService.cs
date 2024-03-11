using DLL.Repository;
using Domain.Entity;
using Domain.Enum;
using Domain.Response;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BLL.Services
{
    public class PhotoService
    {
        private readonly PhotoRepository _photoRepository;
        public PhotoService(PhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }
        //public async Task<IBaseResponse<Photo>> SavePhotoAsync(string uploadPath,string name, Stream photoStream)
        //{
        //    try
        //    {
        //        var filePath = Path.Combine(uploadPath, name);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await photoStream.CopyToAsync(fileStream);
        //        }
        //        Photo photo = new Photo()
        //        {
        //            FileName = name,
        //            FilePath = filePath,
        //            UploadDate = DateTime.Now,
        //            Title = name
        //        };
        //        _photoRepository.Create(photo);
        //        return new BaseResponse<Photo>
        //        {
        //            Data = photo,
        //            Description = "Файл успішно створенно",
        //            StatusCode = Domain.Enum.StatusCode.OK
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new BaseResponse<Photo>
        //        {
        //            Data = null,
        //            Description = $"[PhotoService.SavePhotoAsync] error: {ex.Message}",
        //            StatusCode = Domain.Enum.StatusCode.InternalServerError
        //        };
        //    }
        //}
        //public async Task<IBaseResponse<Photo>> SavePhotoAsync(string uploadPath, string name, byte[] photoData)
        //{
        //    try
        //    {
        //        var filePath = Path.Combine(uploadPath, name);
        //        await File.WriteAllBytesAsync(filePath, photoData);

        //        // Тут можна додатково зберегти інформацію про фото в базі даних або виконати інші дії

        //        Photo photo = new Photo()
        //        {
        //            FileName = name,
        //            FilePath = filePath,
        //            UploadDate = DateTime.Now,
        //            Title = name
        //        };
        //        _photoRepository.Create(photo);

        //        return new BaseResponse<Photo>
        //        {
        //            Data = photo,
        //            Description = "Файл успішно створенно",
        //            StatusCode = Domain.Enum.StatusCode.OK
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new BaseResponse<Photo>
        //        {
        //            Data = null,
        //            Description = $"[PhotoService.SavePhotoAsync] error: {ex.Message}",
        //            StatusCode = Domain.Enum.StatusCode.InternalServerError
        //        };
        //    }
        //}
        public async Task<IBaseResponse<Photo>> SavePhotoAsync(ClaimsPrincipal claimsPrincipal, IFormFile photoFile)
        {
            try
            {

                string tempUploadPath = $"{claimsPrincipal.FindFirst(ClaimTypes.Role)}/{claimsPrincipal.FindFirst("UserId")}";
                var tempName = photoFile.FileName.ToString();
                var directoryPath = Path.Combine(tempUploadPath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                var filePath = Path.Combine(tempUploadPath, tempName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await photoFile.CopyToAsync(fileStream);
                }

                // Опційно, якщо вам потрібно отримати масив байтів з файлу
                using (var memoryStream = new MemoryStream())
                {
                    await photoFile.CopyToAsync(memoryStream);
                    byte[] photoData = memoryStream.ToArray();

                    // Тут ви можете використовувати photoData для подальших дій, якщо потрібно
                }

                // Тут можна додатково зберегти інформацію про фото в базі даних або виконати інші дії

                Photo photo = new Photo()
                {
                    FileName = tempName,
                    FilePath = tempUploadPath,
                    UploadDate = DateTime.Now,
                    Title = tempName
                };
                _photoRepository.Create(photo);

                return new BaseResponse<Photo>
                {
                    Data = photo,
                    Description = "Файл успішно створенно",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Photo>
                {
                    Data = null,
                    Description = $"[PhotoService.SavePhotoAsync] error: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }



        public async Task<Stream> GetIamgeAsync(string path, string imageName)
        {
            var imagepath = Path.Combine(path, imageName);
            if(!File.Exists(imagepath))
            {
                return null;
            }
            return new FileStream(imagepath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);
        }
    }
}
