using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using HRMS.Models;

namespace HRMS.Controllers
{
    public class OfficeEmailController : BaseController
    { 
        // GET: /OfficeEmail/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET OfficeEmail/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.OfficeEmails.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Office_OfficeId.Title), 
            Convert.ToString(c.UserEmail_EmailId.EmailAddress), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /OfficeEmail/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /OfficeEmail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeEmail ObjOfficeEmail = db.OfficeEmails.Find(id);
            if (ObjOfficeEmail == null)
            {
                return HttpNotFound();
            }
            return View(ObjOfficeEmail);
        }
        // GET: /OfficeEmail/Create
        public ActionResult Create()
        {
             ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title");
ViewBag.EmailId = new SelectList(db.UserEmails, "Id", "EmailAddress");

             return View();
        }

        // POST: /OfficeEmail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(OfficeEmail ObjOfficeEmail )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.OfficeEmails.Add(ObjOfficeEmail);
                    db.SaveChanges();

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                }
                else
                {
                    foreach (var key in this.ViewData.ModelState.Keys)
                    {
                        foreach (var err in this.ViewData.ModelState[key].Errors)
                        {
                            sb.Append(err.ErrorMessage + "<br/>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
            }
  
            return Content(sb.ToString());
             
        }
        // GET: /OfficeEmail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeEmail ObjOfficeEmail = db.OfficeEmails.Find(id);
            if (ObjOfficeEmail == null)
            {
                return HttpNotFound();
            }
            ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title", ObjOfficeEmail.OfficeId);
ViewBag.EmailId = new SelectList(db.UserEmails, "Id", "EmailAddress", ObjOfficeEmail.EmailId);

            return View(ObjOfficeEmail);
        }

        // POST: /OfficeEmail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(OfficeEmail ObjOfficeEmail )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjOfficeEmail).State = EntityState.Modified;
                    db.SaveChanges();

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                }
                else
                {
                    foreach (var key in this.ViewData.ModelState.Keys)
                    {
                        foreach (var err in this.ViewData.ModelState[key].Errors)
                        {
                            sb.Append(err.ErrorMessage + "<br/>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
            }
 
             
            return Content(sb.ToString());

        }
        // GET: /OfficeEmail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeEmail ObjOfficeEmail = db.OfficeEmails.Find(id);
            if (ObjOfficeEmail == null)
            {
                return HttpNotFound();
            }
            return View(ObjOfficeEmail);
        }

        // POST: /OfficeEmail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    OfficeEmail ObjOfficeEmail = db.OfficeEmails.Find(id);
                    db.OfficeEmails.Remove(ObjOfficeEmail);
                    db.SaveChanges();

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                 
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
            }
  
            return Content(sb.ToString());
  
        }
        // GET: /OfficeEmail/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            OfficeEmail ObjOfficeEmail = db.OfficeEmails.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title", ObjOfficeEmail.OfficeId);
ViewBag.EmailId = new SelectList(db.UserEmails, "Id", "EmailAddress", ObjOfficeEmail.EmailId);

            }
            
            return View(ObjOfficeEmail);
        }

        // POST: /OfficeEmail/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(OfficeEmail ObjOfficeEmail )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjOfficeEmail).State = EntityState.Modified;
                    db.SaveChanges();

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                }
                else
                {
                    foreach (var key in this.ViewData.ModelState.Keys)
                    {
                        foreach (var err in this.ViewData.ModelState[key].Errors)
                        {
                            sb.Append(err.ErrorMessage + "<br/>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
            } 
             
            return Content(sb.ToString());
 
        }

        private SIContext db = new SIContext();
		
		
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

