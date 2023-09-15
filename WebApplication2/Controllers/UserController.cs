using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserFinder.Business.Abstract;
using UserFinder.Business.Concrete;
using UserFinder.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUserService _userservice;

        public UserController()
        {
            _userservice = new UserManager();
        }

        [HttpGet]
        public List<User> Get()
        {
            return _userservice.GetAllUser();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userservice.GetUserById(id);
        }

        [HttpPost("register")]
        public User Post([FromBody]User u)
        {
            return _userservice.CreateUser(u);
        }

        [HttpPost("registerForDoctor")]
        public DoctorWithUser PostDoctor([FromBody]DoctorWithUser u)
        {
            return _userservice.CreateDoctor(u);
        }

        [HttpPost("login")]
        public User PostAndCheckUser([FromBody]User u)
        {
            //return _userservice.GetUserById(1);
            
            var user = _userservice.CheckUserByUsernameAndPassword(u.Name, u.Password);
            return user;
            
        }
    }
}