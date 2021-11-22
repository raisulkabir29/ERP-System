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

namespace HRMS.Controllers.Employee
{
    public class UserPrAbsDetailsController : Controller
    {

        // GET: /UserPrAbsDetails/
        public ActionResult Index()
        {
            return View();
        }

        // GET UserPrAbsDetails/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.UserPrAbsDetailss.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(), Convert.ToString(c.Id),
                Convert.ToString(c.User_UserId.UserName),
                Convert.ToString(c.Year),
                Convert.ToString(c.Month),
                Convert.ToString(c.CalenderDay),
                Convert.ToString(c.TotalHoliDays),
                Convert.ToString(c.TotalWorkingDays),
                Convert.ToString(c.ADBJ),
                Convert.ToString(c.ADBJAmount),
                Convert.ToString(c.ADAJ),
                Convert.ToString(c.ADAJAmount),
                Convert.ToString(c.LWP),
                Convert.ToString(c.LWPAmount),
                Convert.ToString(c.TotalAbsentDays),
                Convert.ToString(c.TotalCasualLeaves),
                Convert.ToString(c.TotalSickLeaves),
                Convert.ToString(c.TotalEarnedLeaves),
                Convert.ToString(c.TotalPresentDays),
                Convert.ToString(c.TotalPayableDays),

             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }

        // GET: /UserPrAbsDetails/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /UserPrAbsDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPrAbsDetails ObjUserPrAbsDetails = db.UserPrAbsDetailss.Find(id);
            if (ObjUserPrAbsDetails == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserPrAbsDetails);
        }

        // GET: /UserPrAbsDetails/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: /UserPrAbsDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(UserPrAbsDetails ObjUserPrAbsDetails)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.UserPrAbsDetailss.Add(ObjUserPrAbsDetails);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserPrAbsDetailsController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "UserPrAbsDetails", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Add PrAbs Details to user sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "UserPrAbsDetails - Create",
                                ErrorFrom = "UserPrAbsDetailsController.Create",
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
                    ErrorFor = "UserPrAbsDetails - Create",
                    ErrorFrom = "UserPrAbsDetailsController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
            return Content(sb.ToString());

        }

        // GET: /UserPrAbsDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPrAbsDetails ObjUserPrAbsDetails = db.UserPrAbsDetailss.Find(id);
            if (ObjUserPrAbsDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserPrAbsDetails.UserId);
            return View(ObjUserPrAbsDetails);
        }

        // POST: /UserPrAbsDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(UserPrAbsDetails ObjUserPrAbsDetails)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjUserPrAbsDetails).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserPrAbsDetailsController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserPrAbsDetails", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Edit PrAbs Details to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserPrAbsDetails Edit",
                                ErrorFrom = "UserPrAbsDetailsController.Edit",
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
                    ErrorFor = "UserPrAbsDetails Edit",
                    ErrorFrom = "UserPrAbsDetailsController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /UserPrAbsDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPrAbsDetails ObjUserPrAbsDetails = db.UserPrAbsDetailss.Find(id);
            if (ObjUserPrAbsDetails == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserPrAbsDetails);
        }

        // POST: /UserPrAbsDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                UserPrAbsDetails ObjUserPrAbsDetails = db.UserPrAbsDetailss.Find(id);
                db.UserPrAbsDetailss.Remove(ObjUserPrAbsDetails);
                db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "UserPrAbsDetailsController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "UserPrAbsDetails", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Delete PrAbs Details to user sucessfull." // Message if any
                });

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "UserPrAbsDetails Delete",
                    ErrorFrom = "UserPrAbsDetailsController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /UserPrAbsDetails/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            UserPrAbsDetails ObjUserPrAbsDetails = db.UserPrAbsDetailss.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserPrAbsDetails.UserId);
            }

            return View(ObjUserPrAbsDetails);
        }

        // POST: /UserPrAbsDetails/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(UserPrAbsDetails ObjUserPrAbsDetails)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjUserPrAbsDetails).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserPrAbsDetailsController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserPrAbsDetails", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Edit PrAbs Details to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserPrAbsDetails MultiViewIndex",
                                ErrorFrom = "UserPrAbsDetailsController.MultiViewIndex",
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
                    ErrorFor = "UserPrAbsDetails MultiViewIndex",
                    ErrorFrom = "UserPrAbsDetailsController.MultiViewIndex",
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
