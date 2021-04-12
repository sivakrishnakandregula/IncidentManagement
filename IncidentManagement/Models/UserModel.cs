using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IncidentManagement.Models
{
    public class UserModel
    {
        public int ID { get; set; }

        [DisplayAttribute(Name = "UserName", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "userNameRequired")]
        public string UserName { get; set; }

        [DisplayAttribute(Name = "Password", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "PasswordRequired")]
        public string Password { get; set; }

        //public SelectList UserList { get; set; }
    }
}