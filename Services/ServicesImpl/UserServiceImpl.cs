using System;
using ArtHub.dto;
using ArtHub.Models;

namespace ArtHub.Services.ServicesImpl
{
   
    public class UserServiceImpl : UserService
    {
        private readonly AppDbContext _context;
        public UserServiceImpl(AppDbContext context) {
            _context = context;
          }
        public User CreateUser(User newUser)
        {
            return null;
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}

