using AutoMapper;
using BLL.Interface;
using BLL.ModelDTOs.AdminDTOs;
using DLL.Models.AdminsModel;
using DLL.Models.UserModel;
using DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdminService : IService<AdminDTO>
    {
        private AdminRepository _adminRepository;
        private PostRepository _postRepository;
        private DoctorRepository _doctorRepository;
        private PatientRepository _patientRepository;
        private ApointmentRepository _apointmentRepository;
        private OfficeRepository _officeRepository;

        private IMapper _mapper;
        public void SetRepositories(ApointmentRepository apointmentRepository, AdminRepository adminRepository, DoctorRepository doctorRepository, PatientRepository patientRepository, OfficeRepository officeRepository, PostRepository postRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _apointmentRepository = apointmentRepository;
            _doctorRepository = doctorRepository;
            _officeRepository = officeRepository;
            _patientRepository = patientRepository;
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public string Add(AdminDTO entity)
        {
            if (entity == null)
            {
                var adminModel = _mapper.Map<Admin>(entity);
                _adminRepository.Add(adminModel);
                return "Created compleat";
            }
            else return "please write a corect data";
        }

        public string Delete(int id)
        {
            var admin = _adminRepository.GetById(id);
            if (admin == null)
            {
                return "Nothing to delete";

            }
            else
            {
                _adminRepository.Delete(admin.Id);
                return "Success";
            }
        }

        public IEnumerable<AdminDTO> GetAll()
        {
            var admins = _adminRepository.GetAll();
            var AdminDTOs = _mapper.Map<IEnumerable<AdminDTO>>(admins); 
            return AdminDTOs;
        }

        public AdminDTO GetById(int id)
        {
            var admin =_mapper.Map<AdminDTO>(_adminRepository.GetById(id));
            return admin;
        }

        public string Update(AdminDTO entity)
        {
            if (entity == null)
            {
                _adminRepository.Update(_mapper.Map<Admin>(entity));
                return "Success";
            }
            else return "Incorect data";

        }
    }
}
