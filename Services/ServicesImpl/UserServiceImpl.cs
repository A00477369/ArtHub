//using System;
//using ArtHub.Models;
//using ArtHub.TestData;

//namespace ArtHub.Services.ServicesImpl
//{
    
//    public class UserServiceImpl : UserService
//	{
      
        

//        public UserServiceImpl()
//		{

//        }

//        public User CreateUser(User newUser)
//        {
//            UserData.users.Append(newUser);
//            Console.Write(UserData.users);
//            return newUser;
//        }

//        public void DeleteUser(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<User> GetAllUsers()
//        {
//            throw new NotImplementedException();
//        }

//        public User GetUserById(int id)
//        {
//            Console.Write("Entered Here");
//            User user = UserData.users.FirstOrDefault(u => u.Id == id);

//            return user;

//        }

//        public User UpdateUser(int id, User updatedUser)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}

