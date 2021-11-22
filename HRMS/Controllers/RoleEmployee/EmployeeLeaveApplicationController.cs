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
    public class EmployeeLeaveApplicationController : BaseController
    {
        // GET: /EmployeeLeaveApplication/
        public ActionResult Index()
        {
            return View();
        }

        // GET EmployeeLeaveApplication/GetGrid
        public ActionResult GetGrid()
        {
            var userId = Convert.ToInt32(Env.GetUserInfo("userid"));
            var tak = db.UserLeaveApplications.ToArray();

            var result = from c in tak
                         where c.UserId == userId
                         select new string[] { c.Id.ToString(), Convert.ToString(c.Id),
                Convert.ToString(c.User_UserId.UserName),
                Convert.ToString(c.LeaveType_LeaveTypeId.Name),
                Convert.ToString(c.LeaveActiveFrom),
                Convert.ToString(c.LeaveActiveTo),
                Convert.ToString(c.DateAdded),
                Convert.ToString(c.Year),
                Convert.ToString(c.Month),
                Convert.ToString(c.ApplicationDate),
                Convert.ToString(c.NoOfDays),
                Convert.ToString(c.LeavePurpose),
                Convert.ToString(c.ApplicationStatus_ApplicationStatusId.Name),

             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /EmployeeLeaveApplication/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /EmployeeLeaveApplication/Details/5
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
        // GET: /EmployeeLeaveApplication/Create
        public ActionResult Create()
        {
            var userId = Convert.ToInt32(Env.GetUserInfo("userid"));
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", userId);
            ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "Id", "Name");
            ViewBag.ApplicationStatusId = new SelectList(db.ApplicationStatuss, "Id", "Name", 2);
            return View();
        }

        // POST: /EmployeeLeaveApplication/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(UserLeaveApplication ObjUserLeaveApplication)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = Convert.ToInt32(Env.GetUserInfo("userid"));
                    ObjUserLeaveApplication.UserId = userId;
                    ObjUserLeaveApplication.ApplicationStatusId = 2;
                    db.UserLeaveApplications.Add(ObjUserLeaveApplication);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "EmployeeLeaveApplicationController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "EmployeeLeaveApplication", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Adding Leave Application to user sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "EmployeeLeaveApplication - Create",
                                ErrorFrom = "EmployeeLeaveApplicationController.Create",
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
                    ErrorFor = "EmployeeLeaveApplication - Create",
                    ErrorFrom = "EmployeeLeaveApplicationController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
            return Content(sb.ToString());

        }
        // GET: /EmployeeLeaveApplication/Edit/5
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
            ViewBag.ApplicationStatusId = new SelectList(db.ApplicationStatuss, "Id", "Name", ObjUserLeaveApplication.ApplicationStatusId);
            return View(ObjUserLeaveApplication);
        }

        // POST: /EmployeeLeaveApplication/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(UserLeaveApplication ObjUserLeaveApplication)
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
                            ActionFrom = "EmployeeLeaveApplicationController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "EmployeeLeaveApplication", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Leave Application to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "EmployeeLeaveApplication Edit",
                                ErrorFrom = "EmployeeLeaveApplicationController.Edit",
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
                    ErrorFor = "EmployeeLeaveApplication Edit",
                    ErrorFrom = "EmployeeLeaveApplicationController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            ViewBag.ApplicationStatusId = new SelectList(db.ApplicationStatuss, "Id", "Name", ObjUserLeaveApplication.ApplicationStatusId);
            return Content(sb.ToString());

        }
        // GET: /EmployeeLeaveApplication/Delete/5
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

        // POST: /EmployeeLeaveApplication/Delete/5
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
                    ActionFrom = "EmployeeLeaveApplicationController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "EmployeeLeaveApplication", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Deleting Leave Application to user is sucessfull." // Message if any
                });

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "EmployeeLeaveApplication Delete",
                    ErrorFrom = "EmployeeLeaveApplicationController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }
        // GET: /EmployeeLeaveApplication/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            UserLeaveApplication ObjUserLeaveApplication = db.UserLeaveApplications.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserLeaveApplication.UserId);
                ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "Id", "Name", ObjUserLeaveApplication.LeaveTypeId);
                ViewBag.ApplicationStatusId = new SelectList(db.ApplicationStatuss, "Id", "Name", ObjUserLeaveApplication.ApplicationStatusId);
            }

            return View(ObjUserLeaveApplication);
        }

        // POST: /EmployeeLeaveApplication/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(UserLeaveApplication ObjUserLeaveApplication)
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
                            ActionFrom = "EmployeeLeaveApplicationController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "EmployeeLeaveApplication", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Leave Application to user is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "EmployeeLeaveApplication MultiViewIndex",
                                ErrorFrom = "EmployeeLeaveApplicationController.MultiViewIndex",
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
                    ErrorFor = "EmployeeLeaveApplication MultiViewIndex",
                    ErrorFrom = "EmployeeLeaveApplicationController.MultiViewIndex",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
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
