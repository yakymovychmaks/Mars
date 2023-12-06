﻿using AutoMapper;
using BLL.Interface;
using BLL.ModelDTOs.UserDTOs;
using DLL.Model.UserModel;
using DLL.Repository;

namespace BLL.Services
{
    public class UserService : IService<UserDTO>
    {
        private UserReposiyory _userRepository;
        private IMapper _mapper;
        public UserService(UserReposiyory userReposiyory, IMapper mapper)
        {
            _userRepository = userReposiyory;
            _mapper = mapper;
        }
        public string Add(UserDTO entity)
        {
            try
            {
                if(entity == null)
                    return "can't be null";
                return _userRepository.Add(_mapper.Map<User>(entity));
            }
            catch (Exception ex)
            {
                return "Exception on BLL layer "+ ex.Message;
            }
        }

        public string Delete(UserDTO entity)
        {
            try
            {
                if (entity == null)
                    return "can't be null";
                return _userRepository.Delete(entity.Id);
            }
            catch (Exception ex)
            {
                return "Exception on BLL layer " + ex.Message;
            }
        }

        public IEnumerable<UserDTO> GetAll()
        {
            try
            {
                return _mapper.Map<IEnumerable<UserDTO>>(_userRepository.GetAll());
            }
            catch { return Enumerable.Empty<UserDTO>(); }
        }

        public UserDTO GetById(int id)
        {
            try
            {
                return _mapper.Map<UserDTO>(_userRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return new UserDTO();
            }
        }

        public string Update(UserDTO entity)
        {
            try
            {
                if (entity == null)
                    return "can't be null";
                _userRepository.Update(_mapper.Map<User>(entity));
                return "Okey";
            }
            catch (Exception ex)
            {
                return "Exception on BLL layer " + ex.Message;
            }
        }
    }
}
