using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IncidentManagement.Models;

namespace IncidentManagement.Controllers
{
    [Authorize]
    public class UsersController : MyCommonController
    {
        private IncidentContext db = new IncidentContext();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
           return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( UserCreateModel userCreateModel)
        {
           string EncryptPassword = Helper.Encrypt(userCreateModel.Password);
           userCreateModel.Password = EncryptPassword;
            int idval = db.Users.Max(x => x.ID) + 1;
            User user = new User()
            {
                ID = idval,
                UserName = userCreateModel.UserName,
                Password = userCreateModel.Password,
                IsActive = userCreateModel.IsActive,
                IsAdmin = userCreateModel.IsAdmin,
                CreatedDate = userCreateModel.CreatedDate,
                CreatedBy = userCreateModel.CreatedBy,
                ModifiedDate = userCreateModel.ModifiedDate

            };

            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                try { 
                    db.SaveChanges(); 
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }

                return RedirectToAction("Index","IncidentDetails");
            }
           
            return View();
        }

        // GET: Users/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(id);
        //    ViewBag.Users = new SelectList(db.Users, "ID", "UserName");
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        // GET: Users/Edit/5
        public ActionResult Edit()
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //User user = db.Users.Find(id);
            ViewBag.Users = new SelectList(db.Users, "ID", "UserName");
            //if (user == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        public ActionResult GetUserData(string code)
        {
            int id1 = Convert.ToInt32(code);


            var data = db.Users.FirstOrDefault(e => e.ID == id1);
            
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( UserEditModel userEditModel)
        {
            
            int idval = Convert.ToInt32( Request.Form["Users"]);
            
            string uName = db.Users.FirstOrDefault(x=>x.ID==idval).UserName;

          
            User user = new User()
            {
                    ID = idval,
                    UserName = uName,
                    Password = userEditModel.Password,
                    IsActive = userEditModel.IsActive,
                    IsAdmin = userEditModel.IsAdmin,
                    CreatedDate = userEditModel.CreatedDate,
                    CreatedBy = userEditModel.CreatedBy,
                    ModifiedDate = userEditModel.ModifiedDate

            };
            

            if (ModelState.IsValid)
            {
                db.Set<User>().AddOrUpdate(user);
                //db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
                //return RedirectToAction("Index","IncidentDetails");
            }
            //ModelState.AddModelError("", "something went wrong");
            ViewBag.Users = new SelectList(db.Users, "ID", "UserName");
            return View();
           
        }

        // GET: Users/Delete/5
        public ActionResult Delete()
        {
            ViewBag.Users = new SelectList(db.Users, "ID", "UserName");
            //if (user == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed()
        {
            int idval = Convert.ToInt32(Request.Form["Users"]);

            //string uName = db.Users.FirstOrDefault(x => x.ID == idval).UserName;
            User user = db.Users.Find(idval);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
