using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using IncidentManagement.Models;

namespace IncidentManagement.Controllers
{
    [Authorize]
    public class IncidentDetailsController : MyCommonController
    {
        private IncidentContext db = new IncidentContext();

        public ActionResult Default()
        {
            return View();
        }

        // GET: IncidentDetails
        public ActionResult Index()
        {
            //var incidentDetails = db.IncidentDetails;
            //return View(incidentDetails.ToList());
            IncidentDetailsVM incidentDetailsVM = new IncidentDetailsVM();
            var list = db.IncidentDetails.
                Join(db.SupportApplications,
                i => i.ApplicationID, sa => sa.ID,
                (i, sa) => new IncidentDetailsVM
                {
                    ApplicationName = sa.ApplicationName,
                    Description = i.Description,
                    IncidentID = (int)i.IncidentID,
                    Severity = (int)i.Severity,
                    Priority = (Priority)i.Priority,
                    status = i.Status,
                    IncidentCreateDate = i.IncidentCreateDate,
                    IncidentClosedOn = i.IncidentClosedOn
                }).ToList();
            //incidentDetailsVM.Add(list);
            return View(list);

        }

        public ActionResult Critical()
        {
           
                IncidentDetailsVM incidentDetailsVM = new IncidentDetailsVM();
                var list = db.IncidentDetails.
                    Join(db.SupportApplications,
                    i => i.ApplicationID, sa => sa.ID,
                    (i, sa) => new IncidentDetailsVM
                    {
                        ApplicationName = sa.ApplicationName,
                        Description = i.Description,
                        IncidentID = (int)i.IncidentID,
                        Severity = (int)i.Severity,
                        Priority = (Priority)i.Priority,
                        status = i.Status,
                        IncidentCreateDate = i.IncidentCreateDate,
                        IncidentClosedOn = i.IncidentClosedOn
                    }).Where(i=>i.Priority==Priority.critical). ToList();
                //incidentDetailsVM.Add(list);
                return View(list);
        }
        public ActionResult Medium()
        {
            IncidentDetailsVM incidentDetailsVM = new IncidentDetailsVM();
            var list = db.IncidentDetails.
                Join(db.SupportApplications,
                i => i.ApplicationID, sa => sa.ID,
                (i, sa) => new IncidentDetailsVM
                {
                    ApplicationName = sa.ApplicationName,
                    Description = i.Description,
                    IncidentID = (int)i.IncidentID,
                    Severity = (int)i.Severity,
                    Priority = (Priority)i.Priority,
                    status = i.Status,
                    IncidentCreateDate = i.IncidentCreateDate,
                    IncidentClosedOn = i.IncidentClosedOn
                }).Where(i => i.Priority == Priority.medium).ToList();
            //incidentDetailsVM.Add(list);
            return View(list);

        }

        public ActionResult Low()
        {
            IncidentDetailsVM incidentDetailsVM = new IncidentDetailsVM();
            var list = db.IncidentDetails.
                Join(db.SupportApplications,
                i => i.ApplicationID, sa => sa.ID,
                (i, sa) => new IncidentDetailsVM
                {
                    ApplicationName = sa.ApplicationName,
                    Description = i.Description,
                    IncidentID = (int)i.IncidentID,
                    Severity = (int)i.Severity,
                    Priority = (Priority)i.Priority,
                    status = i.Status,
                    IncidentCreateDate = i.IncidentCreateDate,
                    IncidentClosedOn = i.IncidentClosedOn
                }).Where(i => i.Priority == Priority.low).ToList();
            //incidentDetailsVM.Add(list);
            return View(list);
        }

        // GET: IncidentDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncidentDetail incidentDetail = db.IncidentDetails.Find(id);
            if (incidentDetail == null)
            {
                return HttpNotFound();
            }
            return View(incidentDetail);
        }

        // GET: IncidentDetails/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationID = new SelectList(db.Users, "ID", "UserName");
            return View();
        }

        // POST: IncidentDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ApplicationID,IncidentID,Description,Severity,Priority,Status,IncidentCreateDate,IncidentAnalysisStartDate,IncidentClosedOn")] IncidentDetail incidentDetail)
        {
            if (ModelState.IsValid)
            {
                db.IncidentDetails.Add(incidentDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationID = new SelectList(db.Users, "ID", "UserName", incidentDetail.ApplicationID);
            return View(incidentDetail);
        }

        // GET: IncidentDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncidentDetail incidentDetail = db.IncidentDetails.Find(id);
            if (incidentDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationID = new SelectList(db.Users, "ID", "UserName", incidentDetail.ApplicationID);
            return View(incidentDetail);
        }

        // POST: IncidentDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ApplicationID,IncidentID,Description,Severity,Priority,Status,IncidentCreateDate,IncidentAnalysisStartDate,IncidentClosedOn")] IncidentDetail incidentDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incidentDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationID = new SelectList(db.Users, "ID", "UserName", incidentDetail.ApplicationID);
            return View(incidentDetail);
        }

        // GET: IncidentDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncidentDetail incidentDetail = db.IncidentDetails.Find(id);
            if (incidentDetail == null)
            {
                return HttpNotFound();
            }
            return View(incidentDetail);
        }

        // POST: IncidentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IncidentDetail incidentDetail = db.IncidentDetails.Find(id);
            db.IncidentDetails.Remove(incidentDetail);
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
