using ArtHub.dto;
using ArtHub.Models;
using ArtHub.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ArtHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public UserController(UserService userService, IWebHostEnvironment hostEnvironment)
        {
            _userService = userService;
            this._hostEnvironment = hostEnvironment;
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

            User createdUser = new User( userDto.FirstName, userDto.LastName, userDto.Username, userDto.Email, userDto.Password, userDto.Mobile, userDto.ProfilePictureUrl, userDto.Gender, userDto.BirthDate, DateTime.Now, DateTime.Now, userDto.City, userDto.Province, userDto.Country, userDto.PostalCode,"true");

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

        [NonAction]
        public async Task<string> SaveImage(IFormFile image)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(image.FileName).Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(image.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return imageName;
        }
    }
}
