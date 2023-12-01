using System;
namespace ArtHub.dto
{
	public class CreateUserDto
	{
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Mobile { get; set; }
        public required string ProfilePictureUrl { get; set; }
        public required string Gender { get; set; }
        public required string BirthDate { get; set; }
        public required string City { get; set; }
        public required string Province { get; set; }
        public required string Country { get; set; }
        public required string PostalCode { get; set; }
    }
}

