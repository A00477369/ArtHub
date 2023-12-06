using System;
using System.Security.Cryptography;
using ArtHub.Models;

namespace ArtHub.Services.ServicesImpl
{
	public class UserPreferenceServiceImpl : UserPreferenceService
	{
        private readonly IServiceScopeFactory _scopeFactory;

        public UserPreferenceServiceImpl(IServiceScopeFactory scopeFactory, ArtworkService artworkService)
        {
            _scopeFactory = scopeFactory;
        }
        public UserPreference CreateUserPreference(UserPreference createdUserPreference)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                createdUserPreference = context.UserPreferences.Add(createdUserPreference).Entity;

                return createdUserPreference;
            }
                 
        }

        public UserPreference GetUserPreferenceById(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                UserPreference userPreference = context.UserPreferences.Find(id);

                return userPreference;

            }
        }

        public List<UserPreference> GetUserPreferencesByUserId(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var userPreferences = context.UserPreferences.Where(up => up.UserId == id).ToList();

                return userPreferences;

            }
        }
    }
}

