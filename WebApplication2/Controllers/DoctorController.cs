using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserFinder.Business.Abstract;
using UserFinder.Business.Concrete;
using UserFinder.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : Controller
    {
        private IDoctorService _doctorservice;

        public DoctorController()
        {
            _doctorservice = new DoctorManager();
        }

        [HttpGet]
        public List<DoctorWithUser> Get()
        {
            return _doctorservice.GetAllDoctors();
        }

        [HttpGet("{id}")]
        public Doctor Get(int id)
        {
            return _doctorservice.GetDoctorById(id);
        }

        [HttpGet("getwithuserid/{id}")]
        public Doctor GetWithUserId(int id)
        {
            return _doctorservice.GetDoctorByUserId(id);
        }

        [HttpPost("register")]
        public Doctor Post([FromBody]Doctor d)
        {
            return _doctorservice.CreateDoctor(d);
        }

        [HttpPost("update")]
        public Doctor PostUpdate([FromBody]Doctor d)
        {
            return _doctorservice.UpdateDoctor(d);
        }
    }
}
