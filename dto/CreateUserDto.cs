using System;
namespace ArtHub.dto
{
	public class CreateUserDto
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
    }
}

