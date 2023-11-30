using System;
using ArtHub.Models;

namespace ArtHub.Services
{
    public interface UserPreferenceService
    {
        UserPreference CreateUserPreference(UserPreference createdUserPreference);
        UserPreference GetUserPreferenceById(int id);
        List<UserPreference> GetUserPreferencesByUserId(int id);
    }
}

