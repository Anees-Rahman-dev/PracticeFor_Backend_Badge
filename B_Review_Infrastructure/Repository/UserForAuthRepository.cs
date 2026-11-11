using B_Review_Application.Interface;
using B_Review_Domain.Entities;
using B_Review_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Review_Infrastructure.Repository
{
    public class UserForAuthRepository : IUserForAuthRepository
    {
        private readonly ApplicationDBContext _context;

        public UserForAuthRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<UserForAuth?> GetEmail(string email)
        {
            return await _context.UserForAuth.FirstOrDefaultAsync(F => F.Email == email);
        }

        public async Task<UserForAuth> AddUser(UserForAuth userForAuth)
        {
            await _context.UserForAuth.AddAsync(userForAuth);

            await _context.SaveChangesAsync();

            return userForAuth;
        }
    }

    
}
