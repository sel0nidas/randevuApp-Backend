using System;
using System.Collections.Generic;
using System.Text;

namespace UserFinder.Entities
{
    public class AppointmentWithUser
    {
        public int AppointmentId;
        public string Title { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public string DescriptionFromDoctor { get; set; }

        public string EventType { get; set; }

        public string Status { get; set; } = "pending";

        public int ReceiverId { get; set; }

        public Doctor ReceiverUser { get; set; }

        public int SenderId { get; set; }

        public DateTime Date { get; set; }

        public bool IsSeen { get; set; } = false;

        public DateTime OperationTime { get; set; }
    }
}
