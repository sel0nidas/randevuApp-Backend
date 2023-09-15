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
        public List<AppointmentWithUser> Get()
        {
            return _appointmentservice.GetAllAppointments();
        }

        [HttpGet("getcalendar/{receiverId}")]
        public List<AppointmentWithUser> GetAppointmentsFromSelected(int receiverId)
        {
            return _appointmentservice.GetAppointmentsFromSelected(receiverId);
        }

        [HttpGet("getusercalendar/{senderId}")]
        public List<AppointmentWithUser> GetAppointmentsFromSelectedForUser(int senderId)
        {
            return _appointmentservice.GetAppointmentsFromSelectedForUser(senderId);
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
        public ActionResult<Appointment> Post([FromBody]Appointment a)
        {
            if (_appointmentservice.GetAppointmentByDate(a.Date, a.Title, a.ReceiverId) == null)
                return StatusCode(200, _appointmentservice.CreateAppointment(a));

            else
                return StatusCode(400);

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

        [HttpPost("cancel")]
        public ActionResult<Appointment> CancelDay(DateTime date, int receiverId)
        {
            if (DateTime.UtcNow.Date != date.Date)
                return StatusCode(200, _appointmentservice.CancelAppointmentForTheDate(date, receiverId));

            else
                return StatusCode(400);

        }

        [HttpPost("seen")]
        public void SeenAllNotifications(int senderId)
        {
            _appointmentservice.SeenAllNotifications(senderId);
        }
    }
}