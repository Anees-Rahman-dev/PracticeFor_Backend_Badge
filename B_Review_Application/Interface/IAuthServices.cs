using B_Review.Application.DTOs.Auth;
using B_Review_Application.DTO.Auth;
using B_Review_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Review_Application.Interface
{
    public interface IAuthServices
    {
        public Task<AuthResponseDto> RegisterAsync(RegisterDTO registerDTO);

        public Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    }
}
