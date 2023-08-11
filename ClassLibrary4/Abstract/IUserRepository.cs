using System;
using System.Collections.Generic;
using System.Text;
using UserFinder.Entities;

namespace UserFinder.DataAccess.Abstract
{
    interface IUserRepository
    {
        List<User> GetAllUsers();

        User GetUserById(int id);

        User CreateUser(User u);
        User UpdateUser(User u);
        void DeleteUser(int id);


    }
}
