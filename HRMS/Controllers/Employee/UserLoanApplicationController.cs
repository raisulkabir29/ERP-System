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
    public class UserLoanApplicationController : BaseController
    {

        // GET: /UserLoanApplication/
        public ActionResult Index()
        {
            return View();
        }

        // GET UserLoanApplication/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.UserLoanApplications.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(), Convert.ToString(c.Id),
            Convert.ToString(c.User_UserId.UserName),
            Convert.ToString(c.LoanType_LoanTypeId.Name),
            Convert.ToString(c.ApplicationStatus_LoanStatusId.Name),
            string.Format("{0:dd-MMM-yyyy}",c.ApplicationDate),
            //Convert.ToString(c.ApplicationDate),
            string.Format("{0:dd-MMM-yyyy}",c.PossibleDisburseDate),
            //Convert.ToString(c.PossibleDisburseDate),
            Convert.ToString(c.MaxAmountAllowed),
            Convert.ToString(c.LoanAmountApplied),
            Convert.ToString(c.NoOfInstallment),
            Convert.ToString(c.InstallmentAmount),
            Convert.ToString(c.Description),
            Convert.ToString(c.IsApproved),
            Convert.ToString(c.ApprovedBy),
            Convert.ToString(c.AddedBy),
            string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
            //Convert.ToString(c.DateAdded),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /UserLoanApplication/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /UserLoanApplication/Details/5
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

        // GET: /UserLoanApplication/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.LoanTypeId = new SelectList(db.LoanTypes, "Id", "Name");
            ViewBag.LoanStatusId = new SelectList(db.ApplicationStatuss, "Id", "Name");

            return View();
        }

        // POST: /UserLoanApplication/Create
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


                    db.UserLoanApplications.Add(ObjUserLoanApplication);
                    db.SaveChanges();

                    var ApplicationId = ObjUserLoanApplication.Id;
                    //var ApplicationId = db.UserLoanApplications.Single(d =>d.Id == ObjUserLoanApplication.Id);
                    var userDetails = db.UserDetailss.Single(c => c.UserId == ObjUserLoanApplication.UserId);
                    var user = db.Users.Single(c => c.Id == ObjUserLoanApplication.UserId);                                       

                    //var email = db.UserEmails.Single(c => c.Id == ObjUserLoanApplication.UserId);
                    EmailContact emailContact = new EmailContact();
                    emailContact.ControllerName = "UserLoanApplicationController";
                    emailContact.ActionName = "Create";
                    emailContact.TableName = "UserLoanApplication";
                    emailContact.ApplicationId = ApplicationId;
                    emailContact.ApplicantId = ObjUserLoanApplication.UserId;
                    //emailContact.ApplicantId = userDetails.UserId;
                    emailContact.ApplicantName = user.UserName;
                    emailContact.ApplicantEmail = userDetails.EmailAddress;
                    emailContact.ApplicantContactNo = userDetails.MbPhoneNo;
                    emailContact.AdminEmail = ConfigurationService.GetConfigurationValue(Utility.ADMIN_EMAIL_CONFIG_KEY_NAME);
                    emailContact.AddedBy = userDetails.UserId;
                    emailContact.DateAdded = DateTime.Now;

                    var ForwardedTo = ObjUserLoanApplication.ForwardedTo;
                    if (ForwardedTo != null)
                    {
                        var ForwardedToDetails = db.UserDetailss.Single(c => c.UserId == ObjUserLoanApplication.ForwardedTo);
                        emailContact.ForwardedToEmail = ForwardedToDetails.EmailAddress;
                    }

                    var RecommendedBy = ObjUserLoanApplication.RecommendedBy;
                    if (ForwardedTo != null)
                    {
                        var RecommendedByDetails = db.UserDetailss.Single(c => c.UserId == ObjUserLoanApplication.RecommendedBy);
                        emailContact.RecommendedByEmail = RecommendedByDetails.EmailAddress;
                    }

                    var ApprovedBy = ObjUserLoanApplication.ApprovedBy;
                    if (ForwardedTo != null)
                    {
                        var ApprovedByDetails = db.UserDetailss.Single(c => c.UserId == ObjUserLoanApplication.ApprovedBy);
                        emailContact.ApprovedByEmail = ApprovedByDetails.EmailAddress;
                    }

                    //if (emailContact.ApplicantEmail != null || emailContact.AdminEmail !=null )
                    if (emailContact.AdminEmail != null)
                        {
                        bool result = NotificationService.SendContactUsEmail(emailContact);
                        if (result)
                        {
                            db.EmailContacts.Add(emailContact);
                            db.SaveChanges();
                            //return RedirectToAction("Index");
                        }
                        //return View(emailContact);                       
                    }

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserLoanApplicationController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "UserLoanApplication", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Add Loan Application to user sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "UserLoanApplication - Create",
                                ErrorFrom = "UserLoanApplicationController.Create",
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
                    ErrorFor = "UserLoanApplication - Create",
                    ErrorFrom = "UserLoanApplicationController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /UserLoanApplication/Edit/5
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

        // POST: /UserLoanApplication/Edit/5
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
                            ActionFrom = "UserLoanApplicationController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserLoanApplication", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Loan Application to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserLoanApplication Edit",
                                ErrorFrom = "UserLoanApplicationController.Edit",
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
                    ErrorFor = "UserLoanApplication Edit",
                    ErrorFrom = "UserLoanApplicationController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }


            return Content(sb.ToString());

        }

        // GET: /UserLoanApplication/Delete/5
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

        // POST: /UserLoanApplication/Delete/5
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
                    ActionFrom = "UserLoanApplicationController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "UserLoanApplication", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Delete Loan Application to user sucessfull." // Message if any
                });

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "UserLoanApplication Delete",
                    ErrorFrom = "UserLoanApplicationController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /UserLoanApplication/MultiViewIndex/5
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

        // POST: /UserLoanApplication/MultiViewIndex/5
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
                            ActionFrom = "UserLoanApplicationController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserLoanApplication", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Loan Application to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserLoanApplication MultiViewIndex",
                                ErrorFrom = "UserLoanApplicationController.MultiViewIndex",
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
                    ErrorFor = "UserLoanApplication MultiViewIndex",
                    ErrorFrom = "UserLoanApplicationController.MultiViewIndex",
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
