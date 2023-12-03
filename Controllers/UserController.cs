using ArtHub.dto;
using ArtHub.Models;
using ArtHub.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            User user = _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost, AllowAnonymous]
        public ActionResult CreateUser([FromBody] CreateUserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("Invalid user data");
            }

            User createdUser = new User( userDto.FirstName, userDto.LastName, userDto.Username, userDto.Email, userDto.Password, userDto.Mobile, userDto.ProfilePictureUrl, userDto.Gender, userDto.BirthDate, DateTime.Now, DateTime.Now, userDto.City, userDto.Province, userDto.Country, userDto.PostalCode);

            if (createdUser.Validate().isValid)
            {
                createdUser = _userService.CreateUser(createdUser);
                return Ok(createdUser);
            }
            else
            {
                return BadRequest(createdUser.Validate().errorMessage);
            }
        }

        [HttpPut]
        public ActionResult UpdateUser([FromBody] UpdateUserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("Invalid user data");
            }
            if (userDto.Id == 0)
            {
                return BadRequest("No Id Added");
            }

            User oldUser = _userService.GetUserById(userDto.Id);

            if (oldUser == null)
            {
                return NotFound("User not Found");
            }

            User newUser = _userService.UpdateUser(userDto, oldUser);

            return Ok(newUser);
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return Ok("User deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting user: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            List<User> users = _userService.GetAllUsers();
            return Ok(users);
        }
    }
}
