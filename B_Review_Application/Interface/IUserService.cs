using B_Review_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Review_Application.Interface
{
    public interface IUserService
    {
        public List<User> GetAllUsers();

        public User? GetUserById (int id);

        public void AddUser(User user);

        public bool UpdateUser(int id, User user);

        public bool DeleteUser(int id);
    }
}
