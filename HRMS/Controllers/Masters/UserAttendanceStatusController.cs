using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRMS.Common.Enums;
using HRMS.Models;

namespace HRMS.Controllers.Masters
{
    public class UserAttendanceStatusController : Controller
    {
        // GET: /UserAttendanceStatus/
        public ActionResult Index()
        {
            return View();
        }

        // GET UserAttendanceStatus/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.UserAttendanceStatuss.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(),
                            //Convert.ToString(c.Id),
                            Convert.ToString(c.Code),
                            Convert.ToString(c.Name),
                            Convert.ToString(c.Description),
                            string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
                            string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /UserLeaveDetails/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }

        // GET: /UserAttendanceStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAttendanceStatus ObjUserAttendanceStatus = db.UserAttendanceStatuss.Find(id);
            if (ObjUserAttendanceStatus == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserAttendanceStatus);
        }

        // GET: /UserAttendanceStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /UserAttendanceStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(UserAttendanceStatus ObjUserAttendanceStatus)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.UserAttendanceStatuss.Add(ObjUserAttendanceStatus);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserAttendanceStatusController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "UserAttendanceStatus", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Adding Attendance Status to user is sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "UserAttendanceStatus - Create",
                                ErrorFrom = "UserAttendanceStatusController.Create",
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
                    ErrorFor = "UserAttendanceStatus - Create",
                    ErrorFrom = "UserAttendanceStatusController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /UserAttendanceStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAttendanceStatus ObjUserAttendanceStatus = db.UserAttendanceStatuss.Find(id);
            if (ObjUserAttendanceStatus == null)
            {
                return HttpNotFound();
            }

            return View(ObjUserAttendanceStatus);
        }

        // POST: /UserAttendanceStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(UserAttendanceStatus ObjUserAttendanceStatus)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjUserAttendanceStatus).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserAttendanceStatusController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserAttendanceStatus", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Attendance Status to user is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserAttendanceStatus Edit",
                                ErrorFrom = "UserAttendanceStatusController.Edit",
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
                    ErrorFor = "UserAttendanceStatus Edit",
                    ErrorFrom = "UserAttendanceStatusController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }


            return Content(sb.ToString());

        }

        // GET: /UserAttendanceStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAttendanceStatus ObjUserAttendanceStatus = db.UserAttendanceStatuss.Find(id);
            if (ObjUserAttendanceStatus == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserAttendanceStatus);
        }

        // POST: /UserAttendanceStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                UserAttendanceStatus ObjUserAttendanceStatus = db.UserAttendanceStatuss.Find(id);
                db.UserAttendanceStatuss.Remove(ObjUserAttendanceStatus);
                db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "UserAttendanceStatusController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "UserAttendanceStatus", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Deleting Attendance Status to user is sucessfull." // Message if any
                });

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "UserAttendanceStatus Delete",
                    ErrorFrom = "UserAttendanceStatusController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /UserAttendanceStatus/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            UserAttendanceStatus ObjUserAttendanceStatus = db.UserAttendanceStatuss.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;

            }

            return View(ObjUserAttendanceStatus);
        }

        // POST: /UserAttendanceStatus/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(UserAttendanceStatus ObjUserAttendanceStatus)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjUserAttendanceStatus).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserAttendanceStatusController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserAttendanceStatus", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Attendance Status to user is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserAttendanceStatus MultiViewIndex",
                                ErrorFrom = "UserAttendanceStatusController.MultiViewIndex",
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
                    ErrorFor = "UserAttendanceStatus MultiViewIndex",
                    ErrorFrom = "UserAttendanceStatusController.MultiViewIndex",
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