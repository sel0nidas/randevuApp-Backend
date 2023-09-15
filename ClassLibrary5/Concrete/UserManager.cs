using System;
using System.Collections.Generic;
using System.Text;
using UserFinder.Business.Abstract;
using UserFinder.DataAccess.Concrete;
using UserFinder.Entities;

namespace UserFinder.Business.Concrete
{
    public class UserManager : IUserService
    {

        private UserRepository _userRepository;

        public UserManager()
        {
            _userRepository = new UserRepository();
        }

        public User CreateUser(User u)
        {
            return _userRepository.CreateUser(u);
        }
        public DoctorWithUser CreateDoctor(DoctorWithUser u)
        {
            return _userRepository.CreateDoctor(u);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public List<User> GetAllUser()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public User UpdateUser(User u)
        {
            return _userRepository.UpdateUser(u);
        }
        
        public User CheckUserByUsernameAndPassword(string name, string password)
        {
            return _userRepository.CheckUserByUsernameAndPassword(name, password);
        }
    }
}
