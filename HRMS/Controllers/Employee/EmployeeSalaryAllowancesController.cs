using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using HRMS.Common.Enums;
using System.Web.Mvc;
using HRMS.Models;

namespace HRMS.Controllers.Employee
{
    public class EmployeeSalaryAllowancesController : Controller
    {

        // GET: /EmployeeSalaryAllowances/
        public ActionResult Index()
        {
            return View();
        }

        // GET EmployeeSalaryAllowances/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.EmployeeSalaryAllowancess.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(), Convert.ToString(c.Id),
            Convert.ToString(c.User_UserId.UserName),
            Convert.ToString(c.Year),
            Convert.ToString(c.Month),
            Convert.ToString(c.OTNOT),
            Convert.ToString(c.Gross),
            //Convert.ToString(c.HRAllowanceOT),
            //Convert.ToString(c.HRAllowanceNOT),
            //Convert.ToString(c.MedAllowanceOT),
            //Convert.ToString(c.MedAllowanceNOT),
            //Convert.ToString(c.ConAllowanceOT),
            //Convert.ToString(c.ConAllowanceNOT),
            //Convert.ToString(c.FoodAllowanceOT),
            //Convert.ToString(c.FoodAllowanceNOT),
            //Convert.ToString(c.PerAllowanceOT),
            //Convert.ToString(c.PerAllowanceNOT),
            //Convert.ToString(c.AttendBonOT),
            //Convert.ToString(c.AttendBonNOT),
            //Convert.ToString(c.BasicOT),
            //Convert.ToString(c.BasicNOT),
            Convert.ToString(c.Basic),
            Convert.ToString(c.HouseRentAllowance),
            Convert.ToString(c.MedicalAllowance),
            Convert.ToString(c.ConveyanceAllowance),
            Convert.ToString(c.FoodAllowance),
            Convert.ToString(c.PerformanceAllowance),
            Convert.ToString(c.AttendanceBonus),
            Convert.ToString(c.SalaryPayableDate),
            Convert.ToString(c.Remarks),
            //Convert.ToString(c.DateAdded),
            //Convert.ToString(c.ModifiedDate),
             string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
             string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }

        // GET: /EmployeeSalaryAllowances/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }

        // GET: /EmployeeSalaryAllowances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSalaryAllowances ObjEmployeeSalaryAllowances = db.EmployeeSalaryAllowancess.Find(id);
            if (ObjEmployeeSalaryAllowances == null)
            {
                return HttpNotFound();
            }
            return View(ObjEmployeeSalaryAllowances);
        }

        // GET: /EmployeeSalaryAllowances/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");

            return View();
        }

        // POST: /EmployeeSalaryAllowances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(EmployeeSalaryAllowances ObjEmployeeSalaryAllowances)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {

                    ObjEmployeeSalaryAllowances = calculateSalaryAllowances(ObjEmployeeSalaryAllowances);
                    db.EmployeeSalaryAllowancess.Add(ObjEmployeeSalaryAllowances);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "EmployeeSalaryAllowancesController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "EmployeeSalaryAllowances", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Adding Salary Allowances to user is sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "EmployeeSalaryAllowances - Create",
                                ErrorFrom = "EmployeeSalaryAllowancesController.Create",
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
                    ErrorFor = "EmployeeSalaryAllowances - Create",
                    ErrorFrom = "EmployeeSalaryAllowancesController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /EmployeeSalaryAllowances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSalaryAllowances ObjEmployeeSalaryAllowances = db.EmployeeSalaryAllowancess.Find(id);
            if (ObjEmployeeSalaryAllowances == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjEmployeeSalaryAllowances.UserId);

            return View(ObjEmployeeSalaryAllowances);
        }

        // POST: /EmployeeSalaryAllowances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(EmployeeSalaryAllowances ObjEmployeeSalaryAllowances)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {
                    ObjEmployeeSalaryAllowances = calculateSalaryAllowances(ObjEmployeeSalaryAllowances);
                    db.Entry(ObjEmployeeSalaryAllowances).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "EmployeeSalaryAllowancesController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "EmployeeSalaryAllowances", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Salary Allowances to user is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "EmployeeSalaryAllowances Edit",
                                ErrorFrom = "EmployeeSalaryAllowancesController.Edit",
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
                    ErrorFor = "EmployeeSalaryAllowances Edit",
                    ErrorFrom = "EmployeeSalaryAllowancesController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }


            return Content(sb.ToString());

        }

        // GET: /EmployeeSalaryAllowances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSalaryAllowances ObjEmployeeSalaryAllowances = db.EmployeeSalaryAllowancess.Find(id);
            if (ObjEmployeeSalaryAllowances == null)
            {
                return HttpNotFound();
            }
            return View(ObjEmployeeSalaryAllowances);
        }

        // POST: /EmployeeSalaryAllowances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                EmployeeSalaryAllowances ObjEmployeeSalaryAllowances = db.EmployeeSalaryAllowancess.Find(id);
                db.EmployeeSalaryAllowancess.Remove(ObjEmployeeSalaryAllowances);
                db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "EmployeeSalaryAllowancesController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "EmployeeSalaryAllowances", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Deleting Salary Allowances to user is sucessfull." // Message if any
                });

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "EmployeeSalaryAllowances Delete",
                    ErrorFrom = "EmployeeSalaryAllowancesController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /EmployeeSalaryAllowances/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            EmployeeSalaryAllowances ObjEmployeeSalaryAllowances = db.EmployeeSalaryAllowancess.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjEmployeeSalaryAllowances.UserId);

            }

            return View(ObjEmployeeSalaryAllowances);
        }

        // POST: /EmployeeSalaryAllowances/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(EmployeeSalaryAllowances ObjEmployeeSalaryAllowances)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjEmployeeSalaryAllowances).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "EmployeeSalaryAllowancesController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "EmployeeSalaryAllowances", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Salary Allowances to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "EmployeeSalaryAllowances MultiViewIndex",
                                ErrorFrom = "EmployeeSalaryAllowancesController.MultiViewIndex",
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
                    ErrorFor = "EmployeeSalaryAllowances MultiViewIndex",
                    ErrorFrom = "EmployeeSalaryAllowancesController.MultiViewIndex",
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
        public EmployeeSalaryAllowances calculateSalaryAllowances(EmployeeSalaryAllowances ObjEmployeeSalaryAllowances)
        {
            ObjEmployeeSalaryAllowances.Gross = Math.Round(Convert.ToDecimal(ObjEmployeeSalaryAllowances.Gross));
            if (ObjEmployeeSalaryAllowances.OTNOT == "OT")
            {
                string MedicalAllowanceOT = "600";
                ObjEmployeeSalaryAllowances.MedicalAllowance = Convert.ToDecimal(MedicalAllowanceOT);

                string ConveyanceAllowanceOT = "350";
                ObjEmployeeSalaryAllowances.ConveyanceAllowance = Convert.ToDecimal(ConveyanceAllowanceOT);

                string FoodAllowanceOT = "900";
                ObjEmployeeSalaryAllowances.FoodAllowance = Convert.ToDecimal(FoodAllowanceOT);

                decimal threeAllowances = Math.Round(Convert.ToDecimal(ObjEmployeeSalaryAllowances.MedicalAllowance + ObjEmployeeSalaryAllowances.ConveyanceAllowance + ObjEmployeeSalaryAllowances.FoodAllowance));

                ObjEmployeeSalaryAllowances.Basic = Math.Ceiling(Convert.ToDecimal((ObjEmployeeSalaryAllowances.Gross - threeAllowances) * 100) / 150);

                ObjEmployeeSalaryAllowances.HouseRentAllowance = Math.Round(Convert.ToDecimal((ObjEmployeeSalaryAllowances.Basic / 100) * 50));

            }
            else
            {
                ObjEmployeeSalaryAllowances.MedicalAllowance = Math.Round(Convert.ToDecimal((ObjEmployeeSalaryAllowances.Gross / 100) * 10));

                ObjEmployeeSalaryAllowances.ConveyanceAllowance = Math.Round(Convert.ToDecimal((ObjEmployeeSalaryAllowances.Gross / 100) * 10));

                ObjEmployeeSalaryAllowances.Basic = Math.Round(Convert.ToDecimal((ObjEmployeeSalaryAllowances.Gross / 100) * 50));

                ObjEmployeeSalaryAllowances.FoodAllowance = Convert.ToDecimal("0.0");

                ObjEmployeeSalaryAllowances.HouseRentAllowance = Math.Round(Convert.ToDecimal((ObjEmployeeSalaryAllowances.Gross / 100) * 30));
            }
            return ObjEmployeeSalaryAllowances;
        }
    }
}
