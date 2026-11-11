using B_Review_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Review_Application.Interface
{
    public interface IUserForAuthRepository
    {
        public Task<UserForAuth?> GetEmail(string email);

        public Task<UserForAuth> AddUser(UserForAuth userForAuth);
    }
}
