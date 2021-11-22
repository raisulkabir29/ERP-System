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
    public class OfficeAddressController : BaseController
    { 
        // GET: /OfficeAddress/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET OfficeAddress/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.OfficeAddresss.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Office_OfficeId.Title), 
            Convert.ToString(c.UserAddress_AddressId.Line1), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /OfficeAddress/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /OfficeAddress/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeAddress ObjOfficeAddress = db.OfficeAddresss.Find(id);
            if (ObjOfficeAddress == null)
            {
                return HttpNotFound();
            }
            return View(ObjOfficeAddress);
        }
        // GET: /OfficeAddress/Create
        public ActionResult Create()
        {
             ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title");
ViewBag.AddressId = new SelectList(db.UserAddresss, "Id", "Line1");

             return View();
        }

        // POST: /OfficeAddress/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(OfficeAddress ObjOfficeAddress )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.OfficeAddresss.Add(ObjOfficeAddress);
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
        // GET: /OfficeAddress/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeAddress ObjOfficeAddress = db.OfficeAddresss.Find(id);
            if (ObjOfficeAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title", ObjOfficeAddress.OfficeId);
ViewBag.AddressId = new SelectList(db.UserAddresss, "Id", "Line1", ObjOfficeAddress.AddressId);

            return View(ObjOfficeAddress);
        }

        // POST: /OfficeAddress/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(OfficeAddress ObjOfficeAddress )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjOfficeAddress).State = EntityState.Modified;
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
        // GET: /OfficeAddress/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeAddress ObjOfficeAddress = db.OfficeAddresss.Find(id);
            if (ObjOfficeAddress == null)
            {
                return HttpNotFound();
            }
            return View(ObjOfficeAddress);
        }

        // POST: /OfficeAddress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    OfficeAddress ObjOfficeAddress = db.OfficeAddresss.Find(id);
                    db.OfficeAddresss.Remove(ObjOfficeAddress);
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
        // GET: /OfficeAddress/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            OfficeAddress ObjOfficeAddress = db.OfficeAddresss.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title", ObjOfficeAddress.OfficeId);
ViewBag.AddressId = new SelectList(db.UserAddresss, "Id", "Line1", ObjOfficeAddress.AddressId);

            }
            
            return View(ObjOfficeAddress);
        }

        // POST: /OfficeAddress/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(OfficeAddress ObjOfficeAddress )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjOfficeAddress).State = EntityState.Modified;
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

