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
using HRMS.Common.Enums;
using System.Globalization;

namespace HRMS.Controllers
{
    public class UserAllocationController : BaseController
    {
        long userId = Convert.ToInt64(Env.GetUserInfo("userid"));
        // GET: /UserAllocation/
        public ActionResult Index()
        {
            return View();
        }

        // GET UserAllocation/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.UserAllocations.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(),
            //Convert.ToString(c.Id), 
            Convert.ToString(c.User_UserId.UserName),
            Convert.ToString(c.JobTitle_JobTitleId.Name),
            Convert.ToString(c.Office_OfficeId.Title),
            string.Format("{0:dd-MMM-yyyy}",c.AllocationFrom),
            string.Format("{0:dd-MMM-yyyy}",c.AllocationTo),
            Convert.ToString(c.User_SuperiorUserId.UserName),
            string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
            string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /UserAllocation/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /UserAllocation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAllocation ObjUserAllocation = db.UserAllocations.Find(id);
            if (ObjUserAllocation == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserAllocation);
        }
        // GET: /UserAllocation/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users.Where(i => i.Id != userId), "Id", "UserName");
            ViewBag.JobTitleId = new SelectList(db.JobTitles, "Id", "Name");
            ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title");
            ViewBag.SuperiorUserId = new SelectList(db.Users, "Id", "UserName");

             return View();
        }

        // POST: /UserAllocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(UserAllocation ObjUserAllocation)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                {
                    db.UserAllocations.Add(ObjUserAllocation);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserAllocationController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "UserAllocation", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Assign Designation to user sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "UserAllocation - Create",
                                ErrorFrom = "UserAllocationController.Create",
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
                    ErrorFor = "UserAllocation - Create",
                    ErrorFrom = "UserAllocationController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
            return Content(sb.ToString());
             
        }
        // GET: /UserAllocation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAllocation ObjUserAllocation = db.UserAllocations.Find(id);
            if (ObjUserAllocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users.Where(i => i.Id != userId), "Id", "UserName", ObjUserAllocation.UserId);
            ViewBag.JobTitleId = new SelectList(db.JobTitles, "Id", "Name", ObjUserAllocation.JobTitleId);
            ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title", ObjUserAllocation.OfficeId);
            ViewBag.SuperiorUserId = new SelectList(db.Users, "Id", "UserName", ObjUserAllocation.SuperiorUserId);

            return View(ObjUserAllocation);
        }

        // POST: /UserAllocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(UserAllocation ObjUserAllocation)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
                
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjUserAllocation).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserAllocationController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserAllocation", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Designation to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserAllocation Edit",
                                ErrorFrom = "UserAllocationController.Edit",
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
                    ErrorFor = "UserAllocation Edit",
                    ErrorFrom = "UserAllocationController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
 
             
            return Content(sb.ToString());

        }
        // GET: /UserAllocation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAllocation ObjUserAllocation = db.UserAllocations.Find(id);
            if (ObjUserAllocation == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserAllocation);
        }

        // POST: /UserAllocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                UserAllocation ObjUserAllocation = db.UserAllocations.Find(id);
                db.UserAllocations.Remove(ObjUserAllocation);
                db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "UserAllocationController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "UserAllocation", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Delete Designation to user sucessfull." // Message if any
                });

                sb.Append("Sumitted");
                   return Content(sb.ToString());
                 
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "UserAllocation Delete",
                    ErrorFrom = "UserAllocationController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
            return Content(sb.ToString());
  
        }
        // GET: /UserAllocation/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            UserAllocation ObjUserAllocation = db.UserAllocations.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.UserId = new SelectList(db.Users.Where(i=>i.Id!=userId), "Id", "UserName", ObjUserAllocation.UserId);
                ViewBag.JobTitleId = new SelectList(db.JobTitles, "Id", "Name", ObjUserAllocation.JobTitleId);
                ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title", ObjUserAllocation.OfficeId);
                ViewBag.SuperiorUserId = new SelectList(db.Users, "Id", "UserName", ObjUserAllocation.SuperiorUserId);

            }
            
            return View(ObjUserAllocation);
        }

        // POST: /UserAllocation/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(UserAllocation ObjUserAllocation)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                { 
                    
                    db.Entry(ObjUserAllocation).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserAllocationController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserAllocation", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Designation to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserAllocation MultiViewIndex",
                                ErrorFrom = "UserAllocationController.MultiViewIndex",
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
                    ErrorFor = "UserAllocation MultiViewIndex",
                    ErrorFrom = "UserAllocationController.MultiViewIndex",
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

