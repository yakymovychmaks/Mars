using AutoMapper;
using BLL.Interface;
using BLL.ModelDTOs.AdminDTOs;
using BLL.ModelDTOs.UserDTOs;
using DLL.Models.AdminsModel;
using DLL.Models.UserModel;
using DLL.Repository;

namespace BLL.Services
{
    public class AdminService : IService<AdminDTO>
    {
        private AdminRepository _adminRepository;
        private PostRepository _postRepository;
        //private DoctorRepository _doctorRepository;
        //private PatientRepository _patientRepository;
        //private ApointmentRepository _apointmentRepository;
        //private OfficeRepository _officeRepository;

        private IMapper _mapper;
        public AdminService(/*ApointmentRepository apointmentRepository,*/ AdminRepository adminRepository,/* DoctorRepository doctorRepository, PatientRepository patientRepository, OfficeRepository officeRepository,*/ PostRepository postRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            //_apointmentRepository = apointmentRepository;
            //_doctorRepository = doctorRepository;
            //_officeRepository = officeRepository;
            //_patientRepository = patientRepository;
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public string Add(AdminDTO entity)
        {
            if (entity != null)
            {
                var adminModel =entity;
                _adminRepository.Add(_mapper.Map<Admin>(adminModel));
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
            if (entity != null)
            {
                _adminRepository.Update(_mapper.Map<Admin>(entity));
                return "Success";
            }
            else return "Incorect data";

        }
        #region Posts
        public string CreatePost(PostsDTO posts)
        {
            if (posts != null)
            {
                _postRepository.Add(_mapper.Map<Posts>(posts));
                return "Post created";
            }
            else return "Value can't be null";
        }
        public string DeletePost(int id)
        {
            var postToDelete = _postRepository.GetById(id);
            if (postToDelete != null)
            {
                _postRepository.Delete(id);
                return "Post was delete";
            }
            else return "Inckorekt id";
        }
        public string UpdatePost(PostsDTO post)
        {
            var postToUpdale = _postRepository.GetById(post.Id);
            if (postToUpdale != null)
            {
                _postRepository.Update(_mapper.Map<Posts>(post));
                return "Post was update";
            }
            else return "I can't find this post";
        }
        #endregion
        //#region Doctor
        //public string DeleteDoctor(int id)
        //{
        //    if (_doctorRepository.GetById(id) != null)
        //    {
        //        _doctorRepository.Delete(id);
        //        return "Doctor was delete";
        //    }
        //    else return "I can't find this Doctor";
        //}
        //public string UpdateDoctor(DoctorDTO doctor)
        //{
        //    var doctorToUpdate = _doctorRepository.GetById(doctor.Id);
        //    if (doctorToUpdate != null)
        //    {
        //        _doctorRepository.Update(_mapper.Map<Doctor>(doctor));
        //        return "Doctor was update";
        //    }
        //    else return "I can't find this Doctor";
        //}
        //#endregion
        //#region Office
        //public string AddOffice(OfficeDTO office)
        //{
        //    if (office == null)
        //    {
        //        _officeRepository.Add(_mapper.Map<Office>(office));
        //        return "office was added";
        //    }
        //    else return "All fields shouldn't be null";
        //}
        //public string DeleteOffice(int id)
        //{
        //    if (_officeRepository.GetById(id) != null)
        //    {
        //        _officeRepository.Delete(id);
        //        return "Office was delete";
        //    }
        //    else return "Office not found for Delete";
        //}
        //public string UpdateOffice(OfficeDTO office)
        //{
        //    if (office != null)
        //    {
        //        if (_officeRepository.GetById(office.Id) != null)
        //        {
        //            _officeRepository.Update(_mapper.Map<Office>(office));
        //            return "Office was update";
        //        }
        //        else return "Can't find this office";
        //    }
        //    else return "All fields shouldn't be null";
        //}
        //#endregion
        //#region Patient
        //public string DeletePatient(int id)
        //{
        //    if (_patientRepository.GetById(id) != null)
        //    {
        //        _patientRepository.Delete(id);
        //        return "Patient was deleted";
        //    }
        //    else return "I can't find this Patient";
        //}
        //public string UpdatePatient(PatientDTO patient)
        //{
        //    if (patient != null)
        //    {
        //        if (_patientRepository.GetById(patient.Id) != null)
        //        {
        //            _patientRepository.Update(_mapper.Map<Patient>(patient));
        //            return "Patient was update";
        //        }
        //        else return "I can't find this patient";
        //    }
        //    else return "It can't be null";
        //}
        //#endregion
        //#region Appointment
        //public string DelteApointment(int id)
        //{
        //    if (_apointmentRepository.GetById(id) != null)
        //    {
        //        _apointmentRepository.Delete(id);
        //        return "Apointment was delete";
        //    }
        //    else return "I can't find this apointment";
        //}
        //public string UpdateUpointment(ApointmentDTO apointment)
        //{
        //    if (apointment != null)
        //    {
        //        if (_apointmentRepository.GetById(apointment.Id) != null)
        //        {
        //            _apointmentRepository.Update(_mapper.Map<Apointment>(apointment));
        //            return "Apointment was update";
        //        }
        //        else return "I can't find this appointment";
        //    }
        //    else return "All fields souldn't be null";
        //}
        //#endregion

    }
}
