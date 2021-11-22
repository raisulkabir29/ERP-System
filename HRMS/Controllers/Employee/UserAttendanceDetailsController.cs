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
    public class UserAttendanceDetailsController : BaseController
    {

        // GET: /UserAttendanceDetails/
        public ActionResult Index()
        {
            return View();
        }

        // GET UserAttendanceDetails/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.UserAttendanceDetailss.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(), Convert.ToString(c.Id),
            Convert.ToString(c.User_UserId.UserName),
            Convert.ToString(c.UserAttendanceStatus_UserAttndStatusId.Name),
            Convert.ToString(c.PresentDate),
            Convert.ToString(c.Year),
            Convert.ToString(c.Month),
            Convert.ToString(c.CalendarDay),
            Convert.ToString(c.TotalHoliDays),
            Convert.ToString(c.TotalWorkingDays),
            Convert.ToString(c.OvertimeHour),
            Convert.ToString(c.PreparedBy),
            Convert.ToString(c.CheckedBy),
            Convert.ToString(c.AuthorizedBy),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /UserAttendanceDetails/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }

        // GET: /UserAttendanceDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAttendanceDetails ObjUserAttendanceDetails = db.UserAttendanceDetailss.Find(id);
            if (ObjUserAttendanceDetails == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserAttendanceDetails);
        }

        // GET: /UserAttendanceDetails/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.UserAttndStatusId = new SelectList(db.UserAttendanceStatuss, "Id", "Code");
            ViewBag.PreparedBy = new SelectList(db.Users, "Id", "UserName");
            ViewBag.CheckedBy = new SelectList(db.Users, "Id", "UserName");
            ViewBag.AuthorizedBy = new SelectList(db.Users, "Id", "UserName");

            return View();
        }

        // POST: /UserAttendanceDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(UserAttendanceDetails ObjUserAttendanceDetails)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.UserAttendanceDetailss.Add(ObjUserAttendanceDetails);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserAttendanceDetailsController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "UserAttendanceDetails", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Add Attendance Details to user sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "UserAttendanceDetails - Create",
                                ErrorFrom = "UserAttendanceDetailsController.Create",
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
                    ErrorFor = "UserAttendanceDetails - Create",
                    ErrorFrom = "UserAttendanceDetailsController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /UserAttendanceDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAttendanceDetails ObjUserAttendanceDetails = db.UserAttendanceDetailss.Find(id);
            if (ObjUserAttendanceDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserAttendanceDetails.UserId);
            ViewBag.UserAttndStatusId = new SelectList(db.UserAttendanceStatuss, "Id", "Code", ObjUserAttendanceDetails.UserAttndStatusId);
            ViewBag.PreparedBy = new SelectList(db.Users, "Id", "UserName", ObjUserAttendanceDetails.PreparedBy);
            ViewBag.CheckedBy = new SelectList(db.Users, "Id", "UserName", ObjUserAttendanceDetails.CheckedBy);
            ViewBag.AuthorizedBy = new SelectList(db.Users, "Id", "UserName", ObjUserAttendanceDetails.AuthorizedBy);

            return View(ObjUserAttendanceDetails);
        }

        // POST: /UserAttendanceDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(UserAttendanceDetails ObjUserAttendanceDetails)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjUserAttendanceDetails).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserAttendanceDetailsController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserAttendanceDetails", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Attendance Details to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserAttendanceDetails Edit",
                                ErrorFrom = "UserAttendanceDetailsController.Edit",
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
                    ErrorFor = "UserAttendanceDetails Edit",
                    ErrorFrom = "UserAttendanceDetailsController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }


            return Content(sb.ToString());

        }

        // GET: /UserAttendanceDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAttendanceDetails ObjUserAttendanceDetails = db.UserAttendanceDetailss.Find(id);
            if (ObjUserAttendanceDetails == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserAttendanceDetails);
        }

        // POST: /UserAttendanceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                UserAttendanceDetails ObjUserAttendanceDetails = db.UserAttendanceDetailss.Find(id);
                db.UserAttendanceDetailss.Remove(ObjUserAttendanceDetails);
                db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "UserAttendanceDetailsController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "UserAttendanceDetails", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Delete Attendance Details to user sucessfull." // Message if any
                });

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "UserAttendanceDetails Delete",
                    ErrorFrom = "UserAttendanceDetailsController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /UserAttendanceDetails/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            UserAttendanceDetails ObjUserAttendanceDetails = db.UserAttendanceDetailss.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserAttendanceDetails.UserId);
                ViewBag.UserAttndStatusId = new SelectList(db.UserAttendanceStatuss, "Id", "Code", ObjUserAttendanceDetails.UserAttndStatusId);
                ViewBag.PreparedBy = new SelectList(db.Users, "Id", "UserName", ObjUserAttendanceDetails.PreparedBy);
                ViewBag.CheckedBy = new SelectList(db.Users, "Id", "UserName", ObjUserAttendanceDetails.CheckedBy);
                ViewBag.AuthorizedBy = new SelectList(db.Users, "Id", "UserName", ObjUserAttendanceDetails.AuthorizedBy);

            }

            return View(ObjUserAttendanceDetails);
        }

        // POST: /UserAttendanceDetails/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(UserAttendanceDetails ObjUserAttendanceDetails)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjUserAttendanceDetails).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserAttendanceDetailsController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserAttendanceDetails", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Attendance Details to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserAttendanceDetails MultiViewIndex",
                                ErrorFrom = "UserAttendanceDetailsController.MultiViewIndex",
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
                    ErrorFor = "UserAttendanceDetails MultiViewIndex",
                    ErrorFrom = "UserAttendanceDetailsController.MultiViewIndex",
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
