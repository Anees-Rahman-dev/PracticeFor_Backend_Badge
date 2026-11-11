using B_Review_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Review_Application.Interface
{
    public interface ITokenService
    {
        string GenerateToken(UserForAuth user);
    }
}
