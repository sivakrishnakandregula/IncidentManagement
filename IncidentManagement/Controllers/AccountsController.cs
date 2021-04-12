using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using IncidentManagement.Models;

namespace IncidentManagement.Controllers
{
    public class AccountsController : MyCommonController
    {
        // GET: Accounts
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult ChangeLanguage(string lang)
        {
            new LanguageManagement().SetLanguage(lang);
            return RedirectToAction("Index","IncidentDetails");
            
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            using (IncidentContext context = new IncidentContext())
            {
                string EncryptPassword = Helper.Encrypt(model.Password);
                model.Password = EncryptPassword;
                

                bool IsValidUser = context.Users.Any(user => user.UserName.ToLower() ==
                    model.UserName.ToLower() && user.Password == model.Password);
                
                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Default", "IncidentDetails");
                }

                ModelState.AddModelError("", "invalid Username or Password");
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}