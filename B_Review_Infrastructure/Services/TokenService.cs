using B_Review_Application.Interface;
using B_Review_Domain.Entities;
using B_Review_Infrastructure.Settings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace B_Review_Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;

        public TokenService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public string GenerateToken(UserForAuth user)
        {
            var claims = new[]
            {
                new Claim  (ClaimTypes.NameIdentifier, user.Id.ToString()), //why toString()? Because the Id is an integer, but the Claim constructor expects a string.
                new Claim  (ClaimTypes.Name,user.Name), //Stores the user's name.
                new Claim  (ClaimTypes.Email, user.Email),
                new Claim  (ClaimTypes.Role, user.Role)
            };

            //A security key is a secret value that your application uses to digitally sign the JWT.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.key));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: _jwtSettings.issuer,
                audience: _jwtSettings.audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.durationInMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token); //This method serializes the token into a string format that can be sent to the client.

        }
    }
}
