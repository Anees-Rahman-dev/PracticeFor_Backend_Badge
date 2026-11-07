using B_Review_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Review_Application.Interface
{
    public interface IUserRepository
    {
        List<User> GetAll();

        User? GetById(int id);

        void Add(User user);

        bool Update(int id, User user);

        bool Delete(int id);
    }
}
