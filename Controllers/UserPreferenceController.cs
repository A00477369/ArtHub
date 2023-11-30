using System;
using ArtHub.dto;
using ArtHub.Models;
using ArtHub.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtHub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserPreferenceController : ControllerBase
    {
        private readonly UserPreferenceService _userPreferenceService;

        public UserPreferenceController(UserPreferenceService userPreferenceService)
        {
            _userPreferenceService = userPreferenceService;
        }

        [HttpPost]
        public ActionResult CreateUserPreference([FromBody] CreateUserPreferenceDto userPreferenceDto)
        {
            if (userPreferenceDto == null)
            {
                return BadRequest("Invalid user preference data");
            }

            UserPreference createdUserPreference = new UserPreference(userPreferenceDto.CategoryId, userPreferenceDto.UserId,DateTime.Now,DateTime.Now);

            createdUserPreference = _userPreferenceService.CreateUserPreference(createdUserPreference);

            return Ok(createdUserPreference);
        }

        [HttpGet("{id:int}")]
        public ActionResult GetUserPreference(int id)
        {
            UserPreference userPreference = _userPreferenceService.GetUserPreferenceById(id);

            if (userPreference == null)
            {
                return NotFound("User preference not found");
            }

            return Ok(userPreference);
        }

        [HttpGet("user/{id}")]
        public ActionResult GetAllUserPreferences(int id)
        {
            List<UserPreference> userPreferences = _userPreferenceService.GetUserPreferencesByUserId(id);

            return Ok(userPreferences);
        }
    }

    

    
}
