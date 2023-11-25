using System.ComponentModel.DataAnnotations;

namespace ArtHub.Models
{
    public class User
    {

        [Key] public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }

        public User(int id, string firstName, string lastName, string username, string email, string password,
                string mobile, string profilePictureUrl, string gender, string birthDate, DateTime createdOn, DateTime lastUpdatedOn)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Password = password;
            Mobile = mobile;
            ProfilePictureUrl = profilePictureUrl;
            Gender = gender;
            BirthDate = birthDate;
            CreatedOn = createdOn;
            LastUpdatedOn = lastUpdatedOn;
        }

    }

}