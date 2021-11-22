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

namespace HRMS.Controllers.Employee
{
    public class UserLeaveDetailsController : Controller
    {

        // GET: /UserLeaveDetails/
        public ActionResult Index()
        {
            return View();
        }

        // GET UserLeaveDetails/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.UserLeaveDetailss.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(), Convert.ToString(c.Id),
            Convert.ToString(c.User_UserId.UserName),
            Convert.ToString(c.LeaveType_LeaveTypeId.Name),
            Convert.ToString(c.ApplicationStatus_LeaveStatusId.Name),
            Convert.ToString(c.Year),
            Convert.ToString(c.Month),
            Convert.ToString(c.TotUsedLeavesInMonth),
            Convert.ToString(c.TotUsedLeavesPerYear),
            Convert.ToString(c.TotRemainingLeavesPerYear),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /UserLeaveDetails/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /UserLeaveDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLeaveDetails ObjUserLeaveDetails = db.UserLeaveDetailss.Find(id);
            if (ObjUserLeaveDetails == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserLeaveDetails);
        }

        // GET: /UserLeaveDetails/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "Id", "Name");
            ViewBag.LeaveStatusId = new SelectList(db.ApplicationStatuss, "Id", "Name");

            return View();
        }

        // POST: /UserLeaveDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(UserLeaveDetails ObjUserLeaveDetails)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.UserLeaveDetailss.Add(ObjUserLeaveDetails);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserLeaveDetailsController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "UserLeaveDetails", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Add Leave Details to user sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "UserLeaveDetails - Create",
                                ErrorFrom = "UserLeaveDetailsController.Create",
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
                    ErrorFor = "UserLeaveDetails - Create",
                    ErrorFrom = "UserLeaveDetailsController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /UserLeaveDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLeaveDetails ObjUserLeaveDetails = db.UserLeaveDetailss.Find(id);
            if (ObjUserLeaveDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserLeaveDetails.UserId);
            ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "Id", "Name", ObjUserLeaveDetails.LeaveTypeId);
            ViewBag.LeaveStatusId = new SelectList(db.ApplicationStatuss, "Id", "Name", ObjUserLeaveDetails.LeaveStatusId);

            return View(ObjUserLeaveDetails);
        }

        // POST: /UserLeaveDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(UserLeaveDetails ObjUserLeaveDetails)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjUserLeaveDetails).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserLeaveDetailsController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserLeaveDetails", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Leave Details to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserLeaveDetails Edit",
                                ErrorFrom = "UserLeaveDetailsController.Edit",
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
                    ErrorFor = "UserLeaveDetails Edit",
                    ErrorFrom = "UserLeaveDetailsController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }


            return Content(sb.ToString());

        }

        // GET: /UserLeaveDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLeaveDetails ObjUserLeaveDetails = db.UserLeaveDetailss.Find(id);
            if (ObjUserLeaveDetails == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserLeaveDetails);
        }

        // POST: /UserLeaveDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                UserLeaveDetails ObjUserLeaveDetails = db.UserLeaveDetailss.Find(id);
                db.UserLeaveDetailss.Remove(ObjUserLeaveDetails);
                db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "UserLeaveDetailsController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "UserLeaveDetails", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Delete Leave Details to user sucessfull." // Message if any
                });

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "UserLeaveDetails Delete",
                    ErrorFrom = "UserLeaveDetailsController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }
        // GET: /UserLeaveDetails/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            UserLeaveDetails ObjUserLeaveDetails = db.UserLeaveDetailss.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserLeaveDetails.UserId);
                ViewBag.RoleId = new SelectList(db.LeaveTypes, "Id", "Name", ObjUserLeaveDetails.LeaveTypeId);
                ViewBag.RoleId = new SelectList(db.ApplicationStatuss, "Id", "Name", ObjUserLeaveDetails.LeaveStatusId);

            }

            return View(ObjUserLeaveDetails);
        }

        // POST: /UserLeaveDetails/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(UserLeaveDetails ObjUserLeaveDetails)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjUserLeaveDetails).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserLeaveDetailsController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserLeaveDetails", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Leave Details to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserLeaveDetails MultiViewIndex",
                                ErrorFrom = "UserLeaveDetailsController.MultiViewIndex",
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
                    ErrorFor = "UserLeaveDetails MultiViewIndex",
                    ErrorFrom = "UserLeaveDetailsController.MultiViewIndex",
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