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
    public class UserLoanDetailsController : BaseController
    {

        // GET: /UserLoanDetails/
        public ActionResult Index()
        {
            return View();
        }

        // GET UserLoanDetails/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.UserLoanDetailss.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(), Convert.ToString(c.Id),
            Convert.ToString(c.User_UserId.UserName),
            Convert.ToString(c.LoanType_LoanTypeId.Name),
            Convert.ToString(c.UserLoanApplication_LoanApplicationId.LoanTypeId),
            Convert.ToString(c.ApplicationStatus_LoanStatusId.Name),
            Convert.ToString(c.LoanGivenDate),
            Convert.ToString(c.LoanGiven),
            Convert.ToString(c.Stamp),
            Convert.ToString(c.Year),
            Convert.ToString(c.Month),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }

        // GET: /UserLoanDetails/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /UserLoanDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLoanDetails ObjUserLoanDetails = db.UserLoanDetailss.Find(id);
            if (ObjUserLoanDetails == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserLoanDetails);
        }

        // GET: /UserLoanDetails/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.LoanTypeId = new SelectList(db.LoanTypes, "Id", "Name");
            ViewBag.LoanApplicationId = new SelectList(db.UserLoanApplications, "Id", "LoanTypeId");
            ViewBag.LoanStatusId = new SelectList(db.ApplicationStatuss, "Id", "Name");

            return View();
        }

        // POST: /UserLoanDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(UserLoanDetails ObjUserLoanDetails)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.UserLoanDetailss.Add(ObjUserLoanDetails);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserLoanDetailsController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "UserLoanDetails", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Add Loan Details to user sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "UserLoanDetails - Create",
                                ErrorFrom = "UserLoanDetailsController.Create",
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
                    ErrorFor = "UserLoanDetails - Create",
                    ErrorFrom = "UserLoanDetailsController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /UserLoanDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLoanDetails ObjUserLoanDetails = db.UserLoanDetailss.Find(id);
            if (ObjUserLoanDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserLoanDetails.UserId);
            ViewBag.LoanTypeId = new SelectList(db.LoanTypes, "Id", "Name", ObjUserLoanDetails.LoanTypeId);
            ViewBag.LoanApplicationId = new SelectList(db.UserLoanApplications, "Id", "LoanTypeId", ObjUserLoanDetails.LoanApplicationId);
            ViewBag.LoanStatusId = new SelectList(db.ApplicationStatuss, "Id", "Name", ObjUserLoanDetails.LoanStatusId);

            return View(ObjUserLoanDetails);
        }

        // POST: /UserLoanDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(UserLoanDetails ObjUserLoanDetails)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(ObjUserLoanDetails).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserLoanDetailsController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserLoanDetails", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Loan Details to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserLoanDetails Edit",
                                ErrorFrom = "UserLoanDetailsController.Edit",
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
                    ErrorFor = "UserLoanDetails Edit",
                    ErrorFrom = "UserLoanDetailsController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }


            return Content(sb.ToString());

        }

        // GET: /UserLoanDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLoanDetails ObjUserLoanDetails = db.UserLoanDetailss.Find(id);
            if (ObjUserLoanDetails == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserLoanDetails);
        }

        // POST: /UserLoanDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                UserLoanDetails ObjUserLoanDetails = db.UserLoanDetailss.Find(id);
                db.UserLoanDetailss.Remove(ObjUserLoanDetails);
                db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "UserLoanDetailsController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "UserLoanDetails", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Delete Loan Details to user sucessfull." // Message if any
                });

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "UserLoanDetails Delete",
                    ErrorFrom = "UserLoanDetailsController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }
        // GET: /UserLoanDetails/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            UserLoanDetails ObjUserLoanDetails = db.UserLoanDetailss.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserLoanDetails.UserId);
                ViewBag.LoanTypeId = new SelectList(db.LoanTypes, "Id", "Name", ObjUserLoanDetails.LoanTypeId);
                ViewBag.LoanApplicationId = new SelectList(db.UserLoanApplications, "Id", "LoanTypeId", ObjUserLoanDetails.LoanApplicationId);
                ViewBag.LoanStatusId = new SelectList(db.ApplicationStatuss, "Id", "Name", ObjUserLoanDetails.LoanStatusId);

            }

            return View(ObjUserLoanDetails);
        }

        // POST: /UserLoanDetails/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(UserLoanDetails ObjUserLoanDetails)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjUserLoanDetails).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserLoanDetailsController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserLoanDetails", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Loan Details to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserLoanDetails MultiViewIndex",
                                ErrorFrom = "UserLoanDetailsController.MultiViewIndex",
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
                    ErrorFor = "UserLoanDetails MultiViewIndex",
                    ErrorFrom = "UserLoanDetailsController.MultiViewIndex",
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
