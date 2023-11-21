using AutoMapper;
using BLL.ModelDTOs.AdminDTOs;
using BLL.Services;
using MarsBackEnd.Models.Admin;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MarsBackEnd.APIServices
{
    public class AdminAPIService
    {
        private AdminService _adminService;
        private IMapper _mapper;
        public AdminAPIService(AdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }
        public string GetAllAdminAsJson()
        {
            try
            {
                var result = _adminService.GetAll();
                var serializedResult = JsonConvert.SerializeObject(result);
                return serializedResult;
            }catch (Exception ex)
            {
                return "Sorry " + ex.Message;
            }
        }
        public AdminAPIModel AddAdmin(AdminAPIModel model)
        {

            //var adminapimodel = new adminapimodel
            // {
            //     id = model.id,
            //     username = model.username.tostring(),
            //     email = model.email.tostring(),
            //     password = model.password.tostring(),
            //     //postsonsite = new list<postsapimodel>()
            // };
            var adminAPIModel = model;
            _adminService.Add(_mapper.Map<AdminDTO>(adminAPIModel));
            return adminAPIModel;
        }
    }
}
