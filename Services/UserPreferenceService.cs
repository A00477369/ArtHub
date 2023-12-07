using System;
using ArtHub.Models;

namespace ArtHub.Services
{
    public interface UserPreferenceService
    {
        UserPreference CreateUserPreference(UserPreference createdUserPreference);
        List<int> GetCategoryIdsByUserId(int id);
        UserPreference GetUserPreferenceById(int id);
        List<UserPreference> GetUserPreferencesByUserId(int id);
    }
}

