using ArtHub.dto;
using ArtHub.Models;

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
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var userToDelete = context.Users.Find(id);

                if (userToDelete != null)
                {
                    context.Users.Remove(userToDelete);
                    context.SaveChanges();
                }
            }
        }

        public User FindUserByIdentity(string identity)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                return context.Users.FirstOrDefault(u => u.Username == identity || u.Email == identity);
            }
        }

        public List<User> GetAllUsers()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                return context.Users.ToList();
            }
        }

        public User GetUserById(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                return context.Users.Find(id);
            }
        }

