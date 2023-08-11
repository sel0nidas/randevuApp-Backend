using System;
using System.Collections.Generic;
using System.Text;
using UserFinder.Entities;

namespace UserFinder.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAllUser();

        User GetUserById(int id);

        User CreateUser(User u);

        User UpdateUser(User u);

        void DeleteUser(int id);

        User CheckUserByUsernameAndPassword(string name, string password);
    }
}
