using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IncidentManagement.Models
{
    public class IncidentDetailsVM
    {
        [Key]
        public int ID { get; set; }
        public string ApplicationName { get; set; }
        public string Description { get; set; }
        public int IncidentID { get; set; }
        public int Severity { get; set; }
        public Priority Priority { get; set; }
        public string status { get; set; }
        public string IncidentCreateDate { get; set; }
        public string IncidentClosedOn { get; set; }
    }
}                               