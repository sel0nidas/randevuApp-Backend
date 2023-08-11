using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UserFinder.DataAccess.Abstract;
using UserFinder.Entities;

namespace UserFinder.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        public User CreateUser(User u)
        {
            using (var UserDbCtx = new UserDbContext())
            {
                using (var sha256 = SHA256.Create())
                {
                    // Send a sample text to hash.  
                    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(u.Password));
                    // Get the hashed string.  
                    var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                    // Print the string.   
                    Console.WriteLine(hash);

                    u.Password = hash.Substring(0, 50);
                }


                UserDbCtx.Users.Add(u);
                UserDbCtx.SaveChanges();

                return u;
            }
        }

        public void DeleteUser(int id)
        {
            using (var UserDbCtx = new UserDbContext())
            {
                var UsertoDelete = GetUserById(id);
                UserDbCtx.Users.Remove(UsertoDelete);
                UserDbCtx.SaveChanges();
            }
        }

        public List<User> GetAllUsers()
        {
            using (var UserDbCtx = new UserDbContext())
            {
                return UserDbCtx.Users.ToList();
            }
        }

        public User GetUserById(int id)
        {
            using (var UserDbCtx = new UserDbContext())
            {
                var user = UserDbCtx.Users.FirstOrDefault(u=>u.Id == id);

                return user;
            }
        }

        public User UpdateUser(User u)
        {
            using (var UserDbCtx = new UserDbContext())
            {
                UserDbCtx.Users.Update(u);
                return u;
            }
        }
        
        public User CheckUserByUsernameAndPassword(string name, string password)
        {
            using (var UserDbCtx = new UserDbContext())
            {
                string password2;
                using (var sha256 = SHA256.Create())
                {
                    // Send a sample text to hash.  
                    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    // Get the hashed string.  
                    var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                    // Print the string.   
                    Console.WriteLine(hash);

                    password2 = hash.Substring(0, 50);
                }

                var user = UserDbCtx.Users.FirstOrDefault(u => (u.Name == name && u.Password == password2));
                
                return user;
            }
        }
    }
}
