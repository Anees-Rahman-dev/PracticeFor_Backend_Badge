using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PracticeFor_B_Review.Models;
using PracticeFor_B_Review.Setting;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace PracticeFor_B_Review.JwtServices
{

    //public class TokenService
    //{
    //    private readonly JwtSettings _jwtSettings;
    //    public TokenService(IOptions<JwtSettings> options) //Why a separate service?
    //                                                       //Imagine your application has 10 protected endpoints.We don't want to write JWT-generation logic inside every controller.
    //    {
    //        _jwtSettings = options.Value; //IOptions<JwtSettings> gives our service access to those values. values we stored in appsettings.json. We can use them to generate JWT tokens.
    //    }

    //    public string GenerateToken(User user)
    //    {
    //        var claims = new[]
    //        {
    //            new Claim  (ClaimTypes.NameIdentifier, user.Id.ToString()), //why toString()? Because the Id is an integer, but the Claim constructor expects a string.
    //            new Claim  (ClaimTypes.Name,user.Name), //Stores the user's name.
    //            new Claim  (ClaimTypes.Email, user.Email),
    //            new Claim  (ClaimTypes.Role, user.Role)
    //        };

    //        //A security key is a secret value that your application uses to digitally sign the JWT.
    //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.key));

    //        var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

    //        var token = new JwtSecurityToken
    //        (
    //            issuer: _jwtSettings.issuer,
    //            audience: _jwtSettings.audience,
    //            claims: claims,
    //            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.durationInMinutes),
    //            signingCredentials : credentials
    //        );

    //        return new JwtSecurityTokenHandler().WriteToken(token); //This method serializes the token into a string format that can be sent to the client.

    //    }

    //}

    public class TokenService
    {

        private readonly JwtSettings _jwtSettings;

        public TokenService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public string GenerateToken(User user)
        {
            var claims = new[]
            {
             new Claim (ClaimTypes.NameIdentifier,user.Id.ToString()),
             new Claim (ClaimTypes.Name,user.Name),
             new Claim (ClaimTypes.Email,user.Email),
             new Claim (ClaimTypes.Role,user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.key));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(

                issuer: _jwtSettings.issuer,
                audience: _jwtSettings.audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.durationInMinutes),

                signingCredentials : credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);


        }
    }


}
