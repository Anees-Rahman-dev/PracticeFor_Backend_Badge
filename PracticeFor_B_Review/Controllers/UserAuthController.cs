using B_Review_Application.Interface;
using B_Review_Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PracticeFor_B_Review.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAuthController : ControllerBase
    {
        private readonly IUserForAuthService _userForAuthService;

        public UserAuthController(IUserForAuthService userForAuthService)
        {
            _userForAuthService = userForAuthService;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult?> GetEmail(string email)
        {
            var User =  await _userForAuthService.GetByEmail(email);

            if(User == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(User);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserForAuth userForAuth)
        {
            var User = await _userForAuthService.AddAsync(userForAuth);

            return User != null ? Ok(User) : BadRequest();
        }

    }
}
