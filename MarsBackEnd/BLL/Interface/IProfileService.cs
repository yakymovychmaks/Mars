using Domain.Entity;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IProfileService
    {
        Task<BaseResponse<Profile>> GetProfile(int id);

        Task<BaseResponse<Profile>> Save(Profile profile);
    }
}
