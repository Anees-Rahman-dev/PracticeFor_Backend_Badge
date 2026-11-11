using B_Review_Application.Interface;
using B_Review_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Review_Application.Service
{
    public class UserForAuthService : IUserForAuthService
    {

        private readonly IUserForAuthRepository _userForAuthRepository;

        public UserForAuthService(IUserForAuthRepository userForAuthRepository)
        {
            _userForAuthRepository = userForAuthRepository;
        }

        public async Task<UserForAuth?> GetByEmail(string email)
        {
            return  await _userForAuthRepository.GetEmail(email);
        } 

        public async Task<UserForAuth> AddAsync(UserForAuth userForAuth)
        {
            return await _userForAuthRepository.AddUser(userForAuth);
        }
    }
}
