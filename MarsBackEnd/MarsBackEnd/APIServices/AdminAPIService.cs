using AutoMapper;
using BLL.Services;
using MarsBackEnd.Models.Admin;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MarsBackEnd.APIServices
{
    public class AdminAPIService
    {
        private AdminService _adminService;
        //private IMapper _mapper;
        public AdminAPIService(AdminService adminService)
        {
            _adminService = adminService;
            //_mapper = mapper;
        }
        public string GetAllAdminAsJson()
        {
            var data = _adminService.GetAll();
            if (data == null)
            {
                return "Sorry nothing to found";
            }
            else
            {
                var jsonResult = _adminService.GetAll();
                return jsonResult.ToString();
            }
        }
    }
}
