using B_Review_Application.Interface;
using B_Review_Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PracticeFor_B_Review.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService user)
        {
            _userService = user;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var AllUsers = _userService.GetAllUsers();

            return Ok(AllUsers);
        }

        [HttpGet("{id}")] //{id} tells ASP.NET Core that the ID comes from the URL.
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUserById(id);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPost]

        public void Adduser(User user)
        {
            _userService.AddUser(user);

            //return Ok("user created succesfully");
        }

        [HttpPut("{id}")] //{id} tells ASP.NET Core that the ID comes from the URL.

        public IActionResult UpdateUsers(int id, User user)
        {
            var updatedUser = _userService.UpdateUser(id, user);

            if (updatedUser)
            {
                return Ok(updatedUser);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var DeletedUser = _userService.DeleteUser(id);

            if (DeletedUser)
            {
                return Ok(DeletedUser);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
