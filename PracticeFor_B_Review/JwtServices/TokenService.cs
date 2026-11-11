using B_Review_Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PracticeFor_B_Review.Setting;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace PracticeFor_B_Review.JwtServices
{

    public class TokenService
    {
        private readonly JwtSettings _jwtSettings;
        public TokenService(IOptions<JwtSettings> options) //Why a separate service?
                                                           //Imagine your application has 10 protected endpoints.We don't want to write JWT-generation logic inside every controller.
        {
            _jwtSettings = options.Value; //IOptions<JwtSettings> gives our service access to those values. values we stored in appsettings.json. We can use them to generate JWT tokens.
        }

      
    }
}
