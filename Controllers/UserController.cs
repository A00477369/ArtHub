using System;
using ArtHub.dto;
using ArtHub.Models;
using ArtHub.Services;
using Microsoft.AspNetCore.Mvc;
namespace ArtHub.Controllers
{
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

        [HttpPost]
        public ActionResult CreateUser([FromBody] CreateUserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("Invalid user data");
            }

            User createdUser = new User(1, userDto.FirstName, userDto.LastName, userDto.Username,userDto.Email,userDto.Password,userDto.Mobile,userDto.ProfilePictureUrl,userDto.Gender,userDto.BirthDate,DateTime.Now,DateTime.Now);
            

            createdUser = _userService.CreateUser(createdUser);
            return CreatedAtAction(nameof(Get), new { id = createdUser.Id }, createdUser);
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

        [HttpGet]
        public ActionResult GetAll()
        {
            List<User> users = _userService.GetAllUsers();

            return Ok(users);
        }
    }
}

