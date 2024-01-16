using BLL.Interface;
using DLL.Interface;
using Domain.Entity;
using Domain.Enum;
using Domain.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class ProfileService : IProfileService
    {

        private readonly IRepository<Profile> _profileRepository;
        private readonly ILogger<ProfileService> _profileLogger;

        public ProfileService(IRepository<Profile> profileRepository, ILogger<ProfileService> profileLogger)
        {
            _profileRepository = profileRepository;
            _profileLogger = profileLogger;
        }

        public async Task<BaseResponse<Profile>> GetProfile(int id)
        {
            try
            {
                var profile = await _profileRepository.GetAll()
                    .Select(x => new Profile()
                    {
                        Id = x.Id,
                        Address = x.Address,
                        Age = x.Age
                    })
                    .FirstOrDefaultAsync(x => x.Id == id);

                return new BaseResponse<Profile>()
                {
                    Data = profile,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _profileLogger.LogError(ex, $"[ProfileService.GetProfile] error: {ex.Message}");
                return new BaseResponse<Profile>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутрішня помилка: {ex.Message}"
                };
            }
        }

        public async Task<BaseResponse<Profile>> Save(Profile profile)
        {
            try
            {
                var profileUpdated = await _profileRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == profile.Id);

                profile.Address = profile.Address;
                profile.Age = profile.Age;

                await _profileRepository.Update(profile);

                return new BaseResponse<Profile>()
                {
                    Data = profile,
                    Description = "Данні оновлено.",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _profileLogger.LogError(ex, $"[ProfileService.Save] error: {ex.Message}");
                return new BaseResponse<Profile>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутрішня помилка: {ex.Message}"
                };
            }
        }
    }
}
