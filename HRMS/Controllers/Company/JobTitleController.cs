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
    public class JobTitleController : BaseController
    { 
        // GET: /JobTitle/
        public ActionResult Index()
        {
            return View();
        }

        // GET JobTitle/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.JobTitles.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(),
                          //Convert.ToString(c.Id), 
                            Convert.ToString(c.Name),
                            Convert.ToString(c.ParentId),
                            Convert.ToString(c.IsActive),
                            Convert.ToString(c.OfficeId),
                            string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
                            string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /JobTitle/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /JobTitle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobTitle ObjJobTitle = db.JobTitles.Find(id);
            if (ObjJobTitle == null)
            {
                return HttpNotFound();
            }
            return View(ObjJobTitle);
        }
        // GET: /JobTitle/Create
        public ActionResult Create()
        {
             ViewBag.ParentId = new SelectList(db.JobTitles, "Id", "Name");
             ViewBag.OfficeId = new SelectList(db.Offices,"Id","Title");
             return View();
        }

        // POST: /JobTitle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(JobTitle ObjJobTitle )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.JobTitles.Add(ObjJobTitle);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "JobTitleController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "JobTitle", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Adding JobTitle is sucessfull for field - " + key + " - " + currentKeyValue // Message if any
                        });

                    }

                    ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title");
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
                                ErrorFor = "JobTitle - Create",
                                ErrorFrom = "JobTitleController.Create",
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
                    ErrorFor = "JobTitle - Create",
                    ErrorFrom = "JobTitleController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
            return Content(sb.ToString());
             
        }
        // GET: /JobTitle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobTitle ObjJobTitle = db.JobTitles.Find(id);
            if (ObjJobTitle == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentId = new SelectList(db.JobTitles, "Id", "Name", ObjJobTitle.ParentId);

            return View(ObjJobTitle);
        }

        // POST: /JobTitle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(JobTitle ObjJobTitle )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjJobTitle).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "JobTitleController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "JobTitle", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Job Title is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "JobTitle Edit",
                                ErrorFrom = "JobTitleController.Edit",
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
                    ErrorFor = "JobTitle Edit",
                    ErrorFrom = "JobTitleController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
 
             
            return Content(sb.ToString());

        }
        // GET: /JobTitle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobTitle ObjJobTitle = db.JobTitles.Find(id);
            if (ObjJobTitle == null)
            {
                return HttpNotFound();
            }
            return View(ObjJobTitle);
        }

        // POST: /JobTitle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    JobTitle ObjJobTitle = db.JobTitles.Find(id);
                    db.JobTitles.Remove(ObjJobTitle);
                    db.SaveChanges();

                    Utility.WriteAuditLog(new AuditLog()
                    {
                        ActionFrom = "JobTitleController.Delete",
                        Action = (int)AuditAction.Delete,
                        ModuleName = "JobTitle", // Module name
                        SubModuleName = "Delete", // Sub module name if any
                                                  //UserId = userId, // Id from Current User
                        ActionMessage = "Deleting Job Title is sucessfull." // Message if any
                    });

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                 
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "JobTitle Delete",
                    ErrorFrom = "JobTitleController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
            return Content(sb.ToString());
  
        }
        // GET: /JobTitle/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            JobTitle ObjJobTitle = db.JobTitles.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.ParentId = new SelectList(db.JobTitles, "Id", "Name", ObjJobTitle.ParentId);

            }
            
            return View(ObjJobTitle);
        }

        // POST: /JobTitle/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(JobTitle ObjJobTitle )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjJobTitle).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "JobTitleController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "JobTitle", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Job Title is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "JobTitle MultiViewIndex",
                                ErrorFrom = "JobTitleController.MultiViewIndex",
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
                    ErrorFor = "JobTitle MultiViewIndex",
                    ErrorFrom = "JobTitleController.MultiViewIndex",
                    ErrorMessage = "Exception: " + ex.Message
                });
            } 
             
            return Content(sb.ToString());
 
        }
         public ActionResult InterviewGetGrid(int id=0)
        {
            var tak = db.Interviews.Where(i=>i.JobTitleId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.InterviewBy),
                Convert.ToString(c.PlaceOfInterview),
                Convert.ToString(c.CandidateName),
                Convert.ToString(c.Email),
                Convert.ToString(c.Mobile),
                Convert.ToString(c.IsDone),
                Convert.ToString(c.InterviewRemarks),
                Convert.ToString(c.InterviewDate),
                Convert.ToString(c.Address),
                Convert.ToString(c.InterviewTime),
                Convert.ToString(c.ModifiedDate),
                Convert.ToString(c.DateAdded),
                Convert.ToString(c.AddedBy),
                Convert.ToString(c.Id),
                Convert.ToString(c.JobTitleId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
         public ActionResult UserAllocationGetGrid(int id=0)
        {
            var tak = db.UserAllocations.Where(i=>i.JobTitleId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.AllocationFrom),
                Convert.ToString(c.AllocationTo),
                Convert.ToString(c.Id),
                Convert.ToString(c.User_UserId.UserName),Convert.ToString(c.User_SuperiorUserId.UserName),Convert.ToString(c.Office_OfficeId.Title),Convert.ToString(c.JobTitleId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
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

