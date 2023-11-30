using System;
using System.Collections.Generic;
using System.Linq;
using ArtHub.dto;
using ArtHub.Models;

namespace ArtHub.Services.ServicesImpl
{
    public class UserServiceImpl : UserService
    {
        private readonly AppDbContext _context;

        public UserServiceImpl(AppDbContext context)
        {
            _context = context;
        }

        public User CreateUser(User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        public void DeleteUser(int id)
        {
            User userToDelete = _context.Users.Find(id);

            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                _context.SaveChanges();
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> userList = _context.Users.ToList();
            return userList;
        }

        public User GetUserById(int id)
        {
            User user = _context.Users.Find(id);
            return user;
        }

        public User UpdateUser(UpdateUserDto userDto, User oldUser)
        {
            if (oldUser != null)
            {
                
                oldUser.FirstName = userDto.FirstName;
                oldUser.LastName = userDto.LastName;
                oldUser.Username = userDto.Username;
                oldUser.Email = userDto.Email;
                oldUser.Password = userDto.Password;
                oldUser.Mobile = userDto.Mobile;
                oldUser.ProfilePictureUrl = userDto.ProfilePictureUrl;
                oldUser.Gender = userDto.Gender;
                _context.SaveChanges();
            }

            return oldUser;
        }
    }
}
