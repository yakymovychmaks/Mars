using Domain.Entity;
using Domain.Response;
using System.Security.Claims;

namespace BLL.Interface
{
    public interface IApointmentService
    {
        Task<IBaseResponse<Apointment>> Create(Apointment apointment, ClaimsPrincipal claimsPrincipal);
        Task<IBaseResponse<Apointment>> Update(Apointment apointment, ClaimsPrincipal claimsPrincipal);
        Task<IBaseResponse<bool>> Delete(int id,ClaimsPrincipal claimsPrincipal);
        Task<IBaseResponse<Apointment>> GetApointment(int id,ClaimsPrincipal claimsPrincipal);
        Task<IBaseResponse<IEnumerable<Apointment>>> GetAllApointments(ClaimsPrincipal claimsPrincipal);
    }
}
