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
    public class UserPayrollSalaryController : BaseController
    { 
        // GET: /UserPayrollSalary/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET UserPayrollSalary/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.UserPayrollSalarys.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.User_UserId.UserName), 
            Convert.ToString(c.HouseRentAllowance), 
            Convert.ToString(c.MedicalAllowance), 
            Convert.ToString(c.TravellingAllowance), 
            Convert.ToString(c.DearnessAllowance), 
            Convert.ToString(c.Basic), 
            Convert.ToString(c.SpecialAllowance), 
            Convert.ToString(c.Bonus), 
            Convert.ToString(c.ProvidentFund), 
            Convert.ToString(c.ProfessionalTax), 
            Convert.ToString(c.LunchRecovery), 
            Convert.ToString(c.TransportRecovery), 
            Convert.ToString(c.IncomeTax), 
            Convert.ToString(c.TotalAmount), 
            Convert.ToString(c.TotalDeduction), 
            Convert.ToString(c.NetAmount), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /UserPayrollSalary/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /UserPayrollSalary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPayrollSalary ObjUserPayrollSalary = db.UserPayrollSalarys.Find(id);
            if (ObjUserPayrollSalary == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserPayrollSalary);
        }
        // GET: /UserPayrollSalary/Create
        public ActionResult Create()
        {
             ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");

             return View();
        }

        // POST: /UserPayrollSalary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(UserPayrollSalary ObjUserPayrollSalary )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                {

                    ObjUserPayrollSalary = calculateSalary(ObjUserPayrollSalary);
                    db.UserPayrollSalarys.Add(ObjUserPayrollSalary);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserPayrollSalaryController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "UserPayrollSalary", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Assign Payroll Salary to user sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "UserPayrollSalary - Create",
                                ErrorFrom = "UserPayrollSalaryController.Create",
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
                    ErrorFor = "UserPayrollSalary - Create",
                    ErrorFrom = "UserPayrollSalaryController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
            return Content(sb.ToString());
             
        }
        // GET: /UserPayrollSalary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPayrollSalary ObjUserPayrollSalary = db.UserPayrollSalarys.Find(id);
            if (ObjUserPayrollSalary == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserPayrollSalary.UserId);

            return View(ObjUserPayrollSalary);
        }

        // POST: /UserPayrollSalary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(UserPayrollSalary ObjUserPayrollSalary )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                {

                    ObjUserPayrollSalary = calculateSalary(ObjUserPayrollSalary);
                    db.Entry(ObjUserPayrollSalary).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserPayrollSalaryController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserPayrollSalary", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Payroll Salary to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserPayrollSalary Edit",
                                ErrorFrom = "UserPayrollSalaryController.Edit",
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
                    ErrorFor = "UserPayrollSalary Edit",
                    ErrorFrom = "UserPayrollSalaryController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
 
             
            return Content(sb.ToString());

        }
        // GET: /UserPayrollSalary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPayrollSalary ObjUserPayrollSalary = db.UserPayrollSalarys.Find(id);
            if (ObjUserPayrollSalary == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserPayrollSalary);
        }

        // POST: /UserPayrollSalary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    UserPayrollSalary ObjUserPayrollSalary = db.UserPayrollSalarys.Find(id);
                    db.UserPayrollSalarys.Remove(ObjUserPayrollSalary);
                    db.SaveChanges();

                    Utility.WriteAuditLog(new AuditLog()
                    {
                        ActionFrom = "UserPayrollSalaryController.Delete",
                        Action = (int)AuditAction.Delete,
                        ModuleName = "UserPayrollSalary", // Module name
                        SubModuleName = "Delete", // Sub module name if any
                                                  //UserId = userId, // Id from Current User
                        ActionMessage = "Delete Payroll Salary to user sucessfull." // Message if any
                    });

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                 
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "UserPayrollSalary Delete",
                    ErrorFrom = "UserPayrollSalaryController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
            return Content(sb.ToString());
  
        }
        // GET: /UserPayrollSalary/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            UserPayrollSalary ObjUserPayrollSalary = db.UserPayrollSalarys.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserPayrollSalary.UserId);

            }
            
            return View(ObjUserPayrollSalary);
        }

        // POST: /UserPayrollSalary/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(UserPayrollSalary ObjUserPayrollSalary )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjUserPayrollSalary).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserPayrollSalaryController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserPayrollSalary", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Payroll Salary to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserPayrollSalary MultiViewIndex",
                                ErrorFrom = "UserPayrollSalaryController.MultiViewIndex",
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
                    ErrorFor = "UserPayrollSalary MultiViewIndex",
                    ErrorFrom = "UserPayrollSalaryController.MultiViewIndex",
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

        public UserPayrollSalary calculateSalary(UserPayrollSalary ObjUserPayrollSalary)
        {
            ObjUserPayrollSalary.DearnessAllowance = Convert.ToDecimal(ObjUserPayrollSalary.DearnessAllowance);
            ObjUserPayrollSalary.HouseRentAllowance = Convert.ToDecimal(ObjUserPayrollSalary.HouseRentAllowance);
            ObjUserPayrollSalary.MedicalAllowance = Convert.ToDecimal(ObjUserPayrollSalary.MedicalAllowance);
            ObjUserPayrollSalary.TravellingAllowance = Convert.ToDecimal(ObjUserPayrollSalary.TravellingAllowance);
            ObjUserPayrollSalary.Basic = Convert.ToDecimal(ObjUserPayrollSalary.Basic);
            ObjUserPayrollSalary.SpecialAllowance = Convert.ToDecimal(ObjUserPayrollSalary.SpecialAllowance);
            ObjUserPayrollSalary.Bonus = Convert.ToDecimal(ObjUserPayrollSalary.Bonus);
            ObjUserPayrollSalary.ProvidentFund = Convert.ToDecimal(ObjUserPayrollSalary.ProvidentFund);
            ObjUserPayrollSalary.LunchRecovery = Convert.ToDecimal(ObjUserPayrollSalary.LunchRecovery);
            ObjUserPayrollSalary.TransportRecovery = Convert.ToDecimal(ObjUserPayrollSalary.TransportRecovery);
            decimal? professionaltax = Convert.ToDecimal((ObjUserPayrollSalary.ProfessionalTax / 100));
            professionaltax = professionaltax * ObjUserPayrollSalary.Basic;
            decimal? incometax = Convert.ToDecimal((ObjUserPayrollSalary.IncomeTax / 100));
            incometax = incometax * ObjUserPayrollSalary.Basic;
            decimal totalAmount = (ObjUserPayrollSalary.HouseRentAllowance.Value + ObjUserPayrollSalary.MedicalAllowance.Value + ObjUserPayrollSalary.SpecialAllowance.Value + ObjUserPayrollSalary.TravellingAllowance.Value + ObjUserPayrollSalary.Basic.Value + ObjUserPayrollSalary.Bonus.Value + ObjUserPayrollSalary.DearnessAllowance.Value);
            decimal? totalDeduction = (ObjUserPayrollSalary.ProvidentFund.Value + ObjUserPayrollSalary.LunchRecovery.Value + ObjUserPayrollSalary.TransportRecovery.Value + incometax + professionaltax);
            ObjUserPayrollSalary.TotalAmount = totalAmount;
            ObjUserPayrollSalary.TotalDeduction = totalDeduction.Value;
            ObjUserPayrollSalary.NetAmount = totalAmount - totalDeduction.Value;
            return ObjUserPayrollSalary;
        }
    }
}

