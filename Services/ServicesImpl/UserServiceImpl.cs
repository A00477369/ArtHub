using System;
using System.Collections.Generic;
using System.Linq;
using ArtHub.dto;
using ArtHub.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ArtHub.Services.ServicesImpl
{
    public class UserServiceImpl : UserService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public UserServiceImpl(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public User CreateUser(User newUser)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Users.Add(newUser);
                context.SaveChanges();
                return newUser;
            }
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        // ... (other methods similarly modified)

        public User UpdateUser(UpdateUserDto userDto, User oldUser)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

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
                    context.SaveChanges();
                }

                return oldUser;
            }
        }
    }
}
