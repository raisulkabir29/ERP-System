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
    public class EmployeeLoanApplicationController : BaseController
    {
        // GET: /EmployeeLoanApplication/
        public ActionResult Index()
        {
            return View();
        }

        // GET EmployeeLoanApplication/GetGrid
        public ActionResult GetGrid()
        {
            var userId = Convert.ToInt32(Env.GetUserInfo("userid"));
            var tak = db.UserLoanApplications.ToArray();

            var result = from c in tak
                         where c.UserId == userId
                         select new string[] { c.Id.ToString(), Convert.ToString(c.Id),
                Convert.ToString(c.User_UserId.UserName),
                Convert.ToString(c.LoanType_LoanTypeId.Name),
                Convert.ToString(c.ApplicationStatus_LoanStatusId.Name),
                Convert.ToString(c.ApplicationDate),
                Convert.ToString(c.PossibleDisburseDate),
                Convert.ToString(c.MaxAmountAllowed),
                Convert.ToString(c.LoanAmountApplied),
                Convert.ToString(c.NoOfInstallment),
                Convert.ToString(c.InstallmentAmount),
                Convert.ToString(c.Description),
                Convert.ToString(c.AddedBy),
                Convert.ToString(c.DateAdded),
            };

            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }


        // GET: /EmployeeLoanApplication/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /EmployeeLoanApplication/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLoanApplication ObjUserLoanApplication = db.UserLoanApplications.Find(id);
            if (ObjUserLoanApplication == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserLoanApplication);
        }
        // GET: /EmployeeLoanApplication/Create
        public ActionResult Create()
        {
            var userId = Convert.ToInt32(Env.GetUserInfo("userid"));
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", userId);
            ViewBag.LoanTypeId = new SelectList(db.LoanTypes, "Id", "Name");
            ViewBag.LoanStatusId = new SelectList(db.ApplicationStatuss, "Id", "Name", 2);

            return View();
        }

        // POST: /EmployeeLoanApplication/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(UserLoanApplication ObjUserLoanApplication)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {

                    var userId = Convert.ToInt32(Env.GetUserInfo("userid"));
                    ObjUserLoanApplication.UserId = userId;
                    ObjUserLoanApplication.LoanStatusId = 2;
                    db.UserLoanApplications.Add(ObjUserLoanApplication);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "EmployeeLoanApplicationController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "EmployeeLoanApplication", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Assign Loan Application to user is sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "EmployeeLoanApplication - Create",
                                ErrorFrom = "EmployeeLoanApplicationController.Create",
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
                    ErrorFor = "EmployeeLoanApplication - Create",
                    ErrorFrom = "EmployeeLoanApplicationController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /EmployeeLoanApplication/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLoanApplication ObjUserLoanApplication = db.UserLoanApplications.Find(id);
            if (ObjUserLoanApplication == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserLoanApplication.UserId);
            ViewBag.LoanTypeId = new SelectList(db.LoanTypes, "Id", "Name", ObjUserLoanApplication.LoanTypeId);
            ViewBag.LoanStatusId = new SelectList(db.ApplicationStatuss, "Id", "Name", ObjUserLoanApplication.LoanStatusId);

            return View(ObjUserLoanApplication);
        }

        // POST: /EmployeeLoanApplication/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(UserLoanApplication ObjUserLoanApplication)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjUserLoanApplication).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "EmployeeLoanApplicationController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "EmployeeLoanApplication", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Loan Application to user is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "EmployeeLoanApplication Edit",
                                ErrorFrom = "EmployeeLoanApplicationController.Edit",
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
                    ErrorFor = "EmployeeLoanApplication Edit",
                    ErrorFrom = "EmployeeLoanApplicationController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }


            return Content(sb.ToString());

        }

        // GET: /EmployeeLoanApplication/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLoanApplication ObjUserLoanApplication = db.UserLoanApplications.Find(id);
            if (ObjUserLoanApplication == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserLoanApplication);
        }

        // POST: /EmployeeLoanApplication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                UserLoanApplication ObjUserLoanApplication = db.UserLoanApplications.Find(id);
                db.UserLoanApplications.Remove(ObjUserLoanApplication);
                db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "EmployeeLoanApplicationController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "EmployeeLoanApplication", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Deleting Loan Application to user is sucessfull." // Message if any
                });

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "EmployeeLoanApplication Delete",
                    ErrorFrom = "EmployeeLoanApplicationController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /EmployeeLoanApplication/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            UserLoanApplication ObjUserLoanApplication = db.UserLoanApplications.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserLoanApplication.UserId);
                ViewBag.LoanTypeId = new SelectList(db.LoanTypes, "Id", "Name", ObjUserLoanApplication.LoanTypeId);
                ViewBag.LoanStatusId = new SelectList(db.ApplicationStatuss, "Id", "Name", ObjUserLoanApplication.LoanStatusId);

            }

            return View(ObjUserLoanApplication);
        }

        // POST: /EmployeeLoanApplication/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(UserLoanApplication ObjUserLoanApplication)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjUserLoanApplication).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "EmployeeLoanApplicationController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "EmployeeLoanApplication", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Loan Application to user is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "EmployeeLoanApplication MultiViewIndex",
                                ErrorFrom = "EmployeeLoanApplicationController.MultiViewIndex",
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
                    ErrorFor = "EmployeeLoanApplication MultiViewIndex",
                    ErrorFrom = "EmployeeLoanApplicationController.MultiViewIndex",
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
