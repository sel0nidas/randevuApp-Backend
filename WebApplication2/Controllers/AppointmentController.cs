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
    public class AppointmentController : ControllerBase
    {
        private IAppointmentService _appointmentservice;

        public AppointmentController()
        {
            _appointmentservice = new AppointmentManager();
        }

        [HttpGet]
        public List<Appointment> Get()
        {
            return _appointmentservice.GetAllAppointments();
        }

        [HttpGet("getcalendar/{receiverId}")]
        public List<Appointment> GetAppointmentsFromSelected(int receiverId)
        {
            return _appointmentservice.GetAppointmentsFromSelected(receiverId);
        }

        [HttpGet("{id}")]
        public Appointment Get(int id)
        {
            return _appointmentservice.GetAppointmentById(id);
        }

        

        [HttpPost("checkdate")]
        public Appointment GetWithDate([FromBody]Appointment a)
        {
            return _appointmentservice.GetAppointmentByDate(a.Date, a.Title, a.ReceiverId);
        }

        [HttpPost("checkdatelimit")]
        public bool GetWithDateLimit([FromBody]Appointment a)
        {
            return _appointmentservice.CheckAppointmentLimitByDate(a.Date, a.SenderId);
        }

        

        [HttpPost("create")]
        public Appointment Post([FromBody]Appointment a)
        {
            return _appointmentservice.CreateAppointment(a);
        }

        [HttpPost("accept")]
        public Appointment PostAccept([FromBody]Appointment a)
        {
            return _appointmentservice.AcceptAppointment(a);
        }

        [HttpPost("reject")]
        public Appointment PostReject([FromBody]Appointment a)
        {
            return _appointmentservice.RejectAppointment(a);
        }

        [HttpPost("update")]
        public Appointment PostUpdate([FromBody]Appointment a)
        {
            return _appointmentservice.UpdateAppointment(a);
        }

        [HttpPost("delete")]
        public Appointment PostDelete(int id)
        {
            return _appointmentservice.DeleteAppointment(id);
        }
    }
}