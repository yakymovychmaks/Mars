using BLL.Interface;
using DLL.Interface;
using Domain.Entity;
using Domain.Enum;
using Domain.Response;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ApointmentService : IApointmentService
    {
        private readonly IRepository<Apointment> _apointmentRepository;
        private readonly ILogger<ApointmentService> _logger;

        public ApointmentService(IRepository<Apointment> repository, ILogger<ApointmentService> logger)
        {
            _apointmentRepository = repository;
            _logger = logger;
        }
        public async Task<IBaseResponse<Apointment>> Create(Apointment apointment, ClaimsPrincipal claimsPrincipal)
        {
            try
            {
                if (claimsPrincipal.IsInRole("Admin") || claimsPrincipal.IsInRole("Moderator"))
                {
                    await _apointmentRepository.Create(apointment);
                    return new BaseResponse<Apointment>()
                    {
                        Data = apointment,
                        Description = "Апоінтмент успішно створенно",
                        StatusCode = StatusCode.OK
                    };
                }
                return new BaseResponse<Apointment>()
                {
                    Data = null,
                    Description = "У вас недостатгьо прав",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[ApointmentService.Create] error: {ex.Message}");
                return new BaseResponse<Apointment>()
                {
                    Data = null,
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public Task<IBaseResponse<bool>> Delete(int id, ClaimsPrincipal claimsPrincipal)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<IEnumerable<Apointment>>> GetAllApointments(ClaimsPrincipal claimsPrincipal)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<Apointment>> GetApointment(int id, ClaimsPrincipal claimsPrincipal)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<Apointment>> Update(Apointment apointment, ClaimsPrincipal claimsPrincipal)
        {
            throw new NotImplementedException();
        }
    }
}
