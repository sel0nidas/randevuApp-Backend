using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UserFinder.Entities
{
    public class Appointment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Description { get; set; }
        
        [StringLength(50)]
        public string EventType { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "pending";

        public int ReceiverId { get; set; }

        public int SenderId { get; set; }
        
        public DateTime Date { get; set; }
    }
}
