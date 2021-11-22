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
    public class UserLeaveApplicationController : BaseController
    { 
        // GET: /UserLeaveApplication/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET UserLeaveApplication/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.UserLeaveApplications.ToArray();

            var result = from c in tak select new string[] { c.Id.ToString(),
                //Convert.ToString(c.Id), 
                Convert.ToString(c.User_UserId.UserName), 
                Convert.ToString(c.LeaveType_LeaveTypeId.Name), 
                //Convert.ToString(c.LeaveActiveFrom), 
                //Convert.ToString(c.LeaveActiveTo),
                string.Format("{0:dd-MMM-yyyy}",c.LeaveActiveFrom),
                string.Format("{0:dd-MMM-yyyy}",c.LeaveActiveTo),
                //Convert.ToString(c.StartingTime),
                string.Format("{0:HH:mm}",c.StartTime),
                //HH:mm: ss
                //Convert.ToString(c.EndingTime),
                string.Format("{0:HH:mm}",c.EndTime),
                Convert.ToString(c.ShortLeaveHours),
                Convert.ToString(c.ApprovedBy!=null?db.Users.FirstOrDefault(i=>i.Id==c.ApprovedBy).UserName:""),
                Convert.ToString(c.ForwardedTo!=null?db.Users.FirstOrDefault(i=>i.Id==c.ForwardedTo).UserName:""),
                Convert.ToString(c.IsApproved!=null?c.IsApproved==true?"Yes":"No":""), 
                Convert.ToString(c.Year), 
			    Convert.ToString(c.Month), 
			    //Convert.ToString(c.ApplicationDate),
                string.Format("{0:dd-MMM-yyyy}",c.ApplicationDate),
                Convert.ToString(c.NoOfDays),
			    Convert.ToString(c.LeavePurpose),
			    Convert.ToString(c.ApplicationStatus_ApplicationStatusId.Name),
                //Convert.ToString(c.DateAdded),
                string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
                string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /UserLeaveApplication/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /UserLeaveApplication/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLeaveApplication ObjUserLeaveApplication = db.UserLeaveApplications.Find(id);
            if (ObjUserLeaveApplication == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserLeaveApplication);
        }
        // GET: /UserLeaveApplication/Create
        public ActionResult Create()
        {
             ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");
             ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "Id", "Name");
             ViewBag.ApprovedBy = new SelectList(db.Users,"Id","UserName");
             ViewBag.ForwardedTo = new SelectList(db.Users, "Id", "UserName");
             ViewBag.ApplicationStatusId = new SelectList(db.ApplicationStatuss, "Id", "Name");
             return View();
        }

        // POST: /UserLeaveApplication/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(UserLeaveApplication ObjUserLeaveApplication )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.UserLeaveApplications.Add(ObjUserLeaveApplication);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserLeaveApplicationController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "UserLeaveApplication", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Add Leave Application to user sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "UserLeaveApplication - Create",
                                ErrorFrom = "UserLeaveApplicationController.Create",
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
                    ErrorFor = "UserLeaveApplication - Create",
                    ErrorFrom = "UserLeaveApplicationController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
            ViewBag.ApprovedBy = new SelectList(db.Users, "Id", "UserName",ObjUserLeaveApplication.ApprovedBy);
            return Content(sb.ToString());
             
        }
        // GET: /UserLeaveApplication/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLeaveApplication ObjUserLeaveApplication = db.UserLeaveApplications.Find(id);
            if (ObjUserLeaveApplication == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserLeaveApplication.UserId);
            ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "Id", "Name", ObjUserLeaveApplication.LeaveTypeId);
            ViewBag.ApprovedBy = new SelectList(db.Users, "Id", "UserName");
            ViewBag.ForwardedTo = new SelectList(db.Users, "Id", "UserName");
            ViewBag.ApplicationStatusId = new SelectList(db.ApplicationStatuss, "Id", "Name", ObjUserLeaveApplication.ApplicationStatusId);
            return View(ObjUserLeaveApplication);
        }

        // POST: /UserLeaveApplication/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(UserLeaveApplication ObjUserLeaveApplication )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjUserLeaveApplication).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserLeaveApplicationController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserLeaveApplication", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Leave Application to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserLeaveApplication Edit",
                                ErrorFrom = "UserLeaveApplicationController.Edit",
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
                    ErrorFor = "UserLeaveApplication Edit",
                    ErrorFrom = "UserLeaveApplicationController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            ViewBag.ApprovedBy = new SelectList(db.Users, "Id", "UserName", ObjUserLeaveApplication.ApprovedBy);
            ViewBag.ApplicationStatusId = new SelectList(db.ApplicationStatuss, "Id", "Name", ObjUserLeaveApplication.ApplicationStatusId);
            return Content(sb.ToString());

        }
        // GET: /UserLeaveApplication/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLeaveApplication ObjUserLeaveApplication = db.UserLeaveApplications.Find(id);
            if (ObjUserLeaveApplication == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserLeaveApplication);
        }

        // POST: /UserLeaveApplication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    UserLeaveApplication ObjUserLeaveApplication = db.UserLeaveApplications.Find(id);
                    db.UserLeaveApplications.Remove(ObjUserLeaveApplication);
                    db.SaveChanges();

                    Utility.WriteAuditLog(new AuditLog()
                    {
                        ActionFrom = "UserLeaveApplicationController.Delete",
                        Action = (int)AuditAction.Delete,
                        ModuleName = "UserLeaveApplication", // Module name
                        SubModuleName = "Delete", // Sub module name if any
                                                  //UserId = userId, // Id from Current User
                        ActionMessage = "Delete Leave Application to user sucessfull." // Message if any
                    });

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                 
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "UserLeaveApplication Delete",
                    ErrorFrom = "UserLeaveApplicationController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
            return Content(sb.ToString());
  
        }
        // GET: /UserLeaveApplication/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            UserLeaveApplication ObjUserLeaveApplication = db.UserLeaveApplications.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserLeaveApplication.UserId);
                ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "Id", "Name", ObjUserLeaveApplication.LeaveTypeId);
                ViewBag.ApprovedBy = new SelectList(db.Users, "Id", "UserName", ObjUserLeaveApplication.ApprovedBy);
                ViewBag.ForwardedTo = new SelectList(db.Users, "Id", "UserName");
                ViewBag.ApplicationStatusId = new SelectList(db.ApplicationStatuss, "Id", "Name", ObjUserLeaveApplication.ApplicationStatusId);
            }
            
            return View(ObjUserLeaveApplication);
        }

        // POST: /UserLeaveApplication/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(UserLeaveApplication ObjUserLeaveApplication )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjUserLeaveApplication).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserLeaveApplicationController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserLeaveApplication", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Leave Application to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserLeaveApplication MultiViewIndex",
                                ErrorFrom = "UserLeaveApplicationController.MultiViewIndex",
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
                    ErrorFor = "UserLeaveApplication MultiViewIndex",
                    ErrorFrom = "UserLeaveApplicationController.MultiViewIndex",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
            ViewBag.ApprovedBy = new SelectList(db.Users, "Id", "UserName", ObjUserLeaveApplication.ApprovedBy);
            ViewBag.ApplicationStatusId = new SelectList(db.ApplicationStatuss, "Id", "Name", ObjUserLeaveApplication.ApplicationStatusId);
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

