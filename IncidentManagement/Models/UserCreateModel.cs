using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IncidentManagement.Models
{
    public class UserCreateModel
    {
        //[Key]
        //public int ID { get; set; }

        [DisplayAttribute(Name = "UserName", ResourceType =typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "userNameRequired")]
        public string UserName { get; set; }

        [DisplayAttribute(Name = "Password", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "PasswordRequired")]
        public string Password { get; set; }
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resource))]
        [Compare("Password",ErrorMessageResourceType =typeof(Resource),ErrorMessageResourceName ="ConfirmPasswordMatch")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Resource))]
        public bool IsActive { get; set; }
        [Display(Name = "IsAdmin", ResourceType = typeof(Resource))]
        public bool IsAdmin { get; set; }
        [DisplayAttribute(Name = "CreatedBy", ResourceType = typeof(Resource))]
        public string CreatedBy { get; set; }
        [DisplayAttribute(Name = "CreatedOn", ResourceType = typeof(Resource))]
        public string CreatedDate { get; set; }
        [DisplayAttribute(Name = "LastModified", ResourceType = typeof(Resource))]
        public string ModifiedDate { get; set; }
  
    }

    
}
