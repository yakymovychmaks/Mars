using AutoMapper;
using BLL.ModelDTOs.AdminDTOs;
using BLL.Services;
using MarsBackEnd.Models.Admin;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MarsBackEnd.APIServices
{
    public class AdminAPIService
    {
        private AdminService _adminService;
        public PostService _postService;

        private IMapper _mapper;
        public AdminAPIService(PostService postService,AdminService adminService, IMapper mapper)
        {
            _postService = postService;
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
        public string AddAdmin(AdminAPIModel model)
        {

            try
            {
                var adminAPIModel = model;
                _adminService.Add(_mapper.Map<AdminDTO>(adminAPIModel));
                return JsonConvert.SerializeObject(adminAPIModel);
            }
            catch (Exception ex) 
            { return "AdminAPIService error : " + ex.Message; }
        }
        public string GetAdminByIdJson(int id)
        {
            try
            {
                var result = _adminService.GetById(id);
                var serializedResult = JsonConvert.SerializeObject(result);
                return serializedResult;
            }catch (Exception ex) { return "AdminApiService error: "+ex.Message; }
        }
        public string UpdataAdmin(int id ,AdminAPIModel adminUpdate)
        {
            try
            {
                if(_adminService.GetById(id) != null)
                {
                    
                    _adminService.Delete(id); 
                    _adminService.Add(_mapper.Map<AdminDTO>(adminUpdate));
                    return "Success : " + JsonConvert.SerializeObject(adminUpdate);
                }
                return "Admin not found";
            }
            catch (Exception ex)
            {
                return "AdminAPIService" + ex.Message;
            }
        }

        public string AddPost(PostsAPIModel addPost)
        {
            try
            {
                return _adminService.CreatePost(_mapper.Map<PostsDTO>(addPost));
            }catch (Exception ex)
            {
                return "Sorry: " + ex.Message;
            }
        }
    }
}
