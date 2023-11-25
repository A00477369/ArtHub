using System;
using System.Collections.Generic;
using ArtHub.Models;

namespace ArtHub.TestData
{
    public class UserData
    {
        public static List<User> users = new List<User>();

        static UserData()
        {
            // Initialize users list
            var temp = new List<User>
            {
                new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Username = "john_doe",
                Email = "john.doe@example.com",
                Password = "securePassword123",
                Mobile = "123-456-7890",
                ProfilePictureUrl = "profile.jpg",
                Gender = "Male",
                BirthDate = "1990-01-01",
                CreatedOn = DateTime.Now
            },
            new User
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Username = "jane_doe",
                Email = "jane.doe@example.com",
                Password = "anotherPassword456",
                Mobile = "987-654-3210",
                ProfilePictureUrl = "avatar.jpg",
                Gender = "Female",
                BirthDate = "1995-05-15",
                CreatedOn = DateTime.Now
            },
            new User
            {
                Id = 3,
                FirstName = "Bob",
                LastName = "Smith",
                Username = "bob_smith",
                Email = "bob.smith@example.com",
                Password = "password789",
                Mobile = "555-123-4567",
                ProfilePictureUrl = "bob.jpg",
                Gender = "Male",
                BirthDate = "1985-08-20",
                CreatedOn = DateTime.Now
            },
            new User
            {
                Id = 4,
                FirstName = "Alice",
                LastName = "Johnson",
                Username = "alice_j",
                Email = "alice.j@example.com",
                Password = "alicePassword",
                Mobile = "444-789-0123",
                ProfilePictureUrl = "alice.jpg",
                Gender = "Female",
                BirthDate = "1992-12-10",
                CreatedOn = DateTime.Now
            },
            new User
            {
                Id = 5,
                FirstName = "Charlie",
                LastName = "Brown",
                Username = "charlie_b",
                Email = "charlie.b@example.com",
                Password = "charliePass",
                Mobile = "777-222-3333",
                ProfilePictureUrl = "charlie.jpg",
                Gender = "Male",
                BirthDate = "1978-06-25",
                CreatedOn = DateTime.Now
            }
                // Add more users as needed...
            };

            users.AddRange(temp);
        }

    }
}
