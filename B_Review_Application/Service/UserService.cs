using B_Review_Application.Interface;
using B_Review_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Review_Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAll();
        }

        public User? GetUserById(int id)
        {
            return _userRepo.GetById(id);
        }

        public void AddUser(User user)
        {
             _userRepo.Add(user);      
        }

        public bool UpdateUser(int id, User user)
        {
            return _userRepo.Update(id,user);
        }

        public bool DeleteUser(int id)
        {
            return _userRepo.Delete(id);
        }
    }
}
