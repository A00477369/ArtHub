using System;
using ArtHub.Models;

namespace ArtHub.poco
{
    public class LoggedInUser : User
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }


        public LoggedInUser(User user)
            : base(
                user.Id,
                user.FirstName,
                user.LastName,
                user.Username,
                user.Email,
                user.Password,
                user.Mobile,
                user.ProfilePictureUrl,
                user.Gender,
                user.BirthDate,
                user.CreatedOn,
                user.LastUpdatedOn)
        {
        
        }
    }

}

