using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using HRMS.Common.Enums;
using HRMS.Models;

namespace HRMS.Controllers
{
    public class AnnouncementOrNoteController : BaseController
    { 
        // GET: /AnnouncementOrNote/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Notes()
        {
            return View();
        }
        
        // GET AnnouncementOrNote/GetGrid
        public ActionResult GetGrid(bool note=true)
        {

            var tak =note?db.AnnouncementOrNotes.Where(i=>i.IsNote).ToArray():db.AnnouncementOrNotes.Where(i=>!i.IsNote).ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Title), 
            Convert.ToString(c.PostedDate), 
            Convert.ToString(c.Office_OfficeId !=null?c.Office_OfficeId.Title:""), 
            Convert.ToString(c.Department_DepartmentId !=null?c.Department_DepartmentId.Name:""), 
            Convert.ToString(c.Summary), 
            Convert.ToString(c.Description), 
            Convert.ToString(c.DateAdded), 
            Convert.ToString(c.AddedBy),
            Convert.ToString(c.IsNote)
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /AnnouncementOrNote/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /AnnouncementOrNote/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnnouncementOrNote ObjAnnouncementOrNote = db.AnnouncementOrNotes.Find(id);
            if (ObjAnnouncementOrNote == null)
            {
                return HttpNotFound();
            }
            return View(ObjAnnouncementOrNote);
        }
        // GET: /AnnouncementOrNote/Create
        public ActionResult Create()
        {
             ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title");
             ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");

             return View();
        }

        // POST: /AnnouncementOrNote/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(AnnouncementOrNote ObjAnnouncementOrNote )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                {
                    db.AnnouncementOrNotes.Add(ObjAnnouncementOrNote);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "AnnouncementOrNoteController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "AnnouncementOrNote", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Add Announcement or Note is sucessfull for field - " + key + " - " + currentKeyValue // Message if any
                        });

                    }

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
                            Utility.WriteErrorLog(new ErrorLog()
                            {
                                ErrorFor = "AnnouncementOrNote - Create",
                                ErrorFrom = "AnnouncementOrNoteController.Create",
                                ErrorMessage = "Exception: " + err.ErrorMessage
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "AnnouncementOrNote - Create",
                    ErrorFrom = "AnnouncementOrNoteController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
            return Content(sb.ToString());
             
        }
        // GET: /AnnouncementOrNote/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnnouncementOrNote ObjAnnouncementOrNote = db.AnnouncementOrNotes.Find(id);
            if (ObjAnnouncementOrNote == null)
            {
                return HttpNotFound();
            }
            ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title", ObjAnnouncementOrNote.OfficeId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", ObjAnnouncementOrNote.DepartmentId);

            return View(ObjAnnouncementOrNote);
        }

        // POST: /AnnouncementOrNote/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(AnnouncementOrNote ObjAnnouncementOrNote )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjAnnouncementOrNote).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "AnnouncementOrNoteController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "AnnouncementOrNote", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Announcement or Note is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
                        });

                    }

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
                            Utility.WriteErrorLog(new ErrorLog()
                            {
                                ErrorFor = "AnnouncementOrNote Edit",
                                ErrorFrom = "AnnouncementOrNoteController.Edit",
                                ErrorMessage = "Exception: " + err.ErrorMessage
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "AnnouncementOrNote Edit",
                    ErrorFrom = "AnnouncementOrNoteController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
 
             
            return Content(sb.ToString());

        }
        // GET: /AnnouncementOrNote/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnnouncementOrNote ObjAnnouncementOrNote = db.AnnouncementOrNotes.Find(id);
            if (ObjAnnouncementOrNote == null)
            {
                return HttpNotFound();
            }
            return View(ObjAnnouncementOrNote);
        }

        // POST: /AnnouncementOrNote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    AnnouncementOrNote ObjAnnouncementOrNote = db.AnnouncementOrNotes.Find(id);
                    db.AnnouncementOrNotes.Remove(ObjAnnouncementOrNote);
                    db.SaveChanges();

                    Utility.WriteAuditLog(new AuditLog()
                    {
                        ActionFrom = "AnnouncementOrNoteController.Delete",
                        Action = (int)AuditAction.Delete,
                        ModuleName = "AnnouncementOrNote", // Module name
                        SubModuleName = "Delete", // Sub module name if any
                                                  //UserId = userId, // Id from Current User
                        ActionMessage = "Delete Announcement or Note is sucessfull." // Message if any
                    });

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                 
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "AnnouncementOrNote Delete",
                    ErrorFrom = "AnnouncementOrNoteController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
            return Content(sb.ToString());
  
        }
        // GET: /AnnouncementOrNote/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            AnnouncementOrNote ObjAnnouncementOrNote = db.AnnouncementOrNotes.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title", ObjAnnouncementOrNote.OfficeId);
                ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", ObjAnnouncementOrNote.DepartmentId);

            }
            
            return View(ObjAnnouncementOrNote);
        }

        // POST: /AnnouncementOrNote/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(AnnouncementOrNote ObjAnnouncementOrNote )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjAnnouncementOrNote).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "AnnouncementOrNoteController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "AnnouncementOrNote", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Announcement or Note issucessfull for field - " + key + " - " + currentKeyValue// Message if any
                        });

                    }

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
                            Utility.WriteErrorLog(new ErrorLog()
                            {
                                ErrorFor = "AnnouncementOrNote MultiViewIndex",
                                ErrorFrom = "AnnouncementOrNoteController.MultiViewIndex",
                                ErrorMessage = "Exception: " + err.ErrorMessage
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "AnnouncementOrNote MultiViewIndex",
                    ErrorFrom = "AnnouncementOrNoteController.MultiViewIndex",
                    ErrorMessage = "Exception: " + ex.Message
                });
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

