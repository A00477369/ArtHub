using System;
using ArtHub.dto;
using ArtHub.Models;

namespace ArtHub.Services
{

    public interface UserService
    {
        // Retrieve a user by ID
        User GetUserById(int id);

        // Retrieve all users
        List<User> GetAllUsers();

        // Create a new user
        User CreateUser(User newUser);

        // Update an existing user
        User UpdateUser(UpdateUserDto userDto, User oldUser);

        // Delete a user by ID
        void DeleteUser(int id);
        User FindUserByIdentity(string identity);
    }

}

