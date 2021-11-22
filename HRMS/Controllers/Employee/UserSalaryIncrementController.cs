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
    public class UserSalaryIncrementController : Controller
    {

        // GET: /UserSalaryIncrement/
        public ActionResult Index()
        {
            return View();
        }

        // GET UserSalaryIncrement/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.UserSalaryIncrements.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(),
                //Convert.ToString(c.Id),
                Convert.ToString(c.User_UserId.UserName),
                Convert.ToString(c.OTNOT),
                Convert.ToString(c.GrossSalary),
                Convert.ToString(c.BasicSalary),
                Convert.ToString(c.IncrementPercentage),
                Convert.ToString(c.YearOfIncrement),
                Convert.ToString(c.IncrementOnGrossOrBasic!=null?c.IncrementOnGrossOrBasic==1?"Gross":"Basic":""),
                Convert.ToString(c.NewGrossSalary),
                Convert.ToString(c.NewBasicSalary),
                Convert.ToString(c.OvertimeRate),
                Convert.ToString(c.Year),
                Convert.ToString(c.Month),
                string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
                string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /UserSalaryIncrement/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /UserSalaryIncrement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSalaryIncrement ObjUserSalaryIncrement = db.UserSalaryIncrements.Find(id);
            if (ObjUserSalaryIncrement == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserSalaryIncrement);
        }

        // GET: /UserSalaryIncrement/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");

            return View();
        }

        // POST: /UserSalaryIncrement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(UserSalaryIncrement ObjUserSalaryIncrement)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {

                    //ObjUserSalaryIncrement = calculateUserSalaryIncrement(ObjUserSalaryIncrement);
                    db.UserSalaryIncrements.Add(ObjUserSalaryIncrement);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserSalaryIncrementController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "UserSalaryIncrement", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Adding Salary Increment to user is sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "UserSalaryIncrement - Create",
                                ErrorFrom = "UserSalaryIncrementController.Create",
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
                    ErrorFor = "UserSalaryIncrement - Create",
                    ErrorFrom = "UserSalaryIncrementController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /UserSalaryIncrement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSalaryIncrement ObjUserSalaryIncrement = db.UserSalaryIncrements.Find(id);
            if (ObjUserSalaryIncrement == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserSalaryIncrement.UserId);

            return View(ObjUserSalaryIncrement);
        }

        // POST: /UserSalaryIncrement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(UserSalaryIncrement ObjUserSalaryIncrement)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {
                    //ObjUserSalaryIncrement = calculateUserSalaryIncrement(ObjUserSalaryIncrement);
                    db.Entry(ObjUserSalaryIncrement).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserSalaryIncrementController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserSalaryIncrement", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Salary Increment to user is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserSalaryIncrement Edit",
                                ErrorFrom = "UserSalaryIncrementController.Edit",
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
                    ErrorFor = "UserSalaryIncrement Edit",
                    ErrorFrom = "UserSalaryIncrementController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }


            return Content(sb.ToString());

        }

        // GET: /UserSalaryIncrement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSalaryIncrement ObjUserSalaryIncrement = db.UserSalaryIncrements.Find(id);
            if (ObjUserSalaryIncrement == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserSalaryIncrement);
        }

        // POST: /UserSalaryIncrement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                UserSalaryIncrement ObjUserSalaryIncrement = db.UserSalaryIncrements.Find(id);
                db.UserSalaryIncrements.Remove(ObjUserSalaryIncrement);
                db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "UserSalaryIncrementController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "UserSalaryIncrement", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Deleting Salary Increment to user is sucessfull." // Message if any
                });

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "UserSalaryIncrement Delete",
                    ErrorFrom = "UserSalaryIncrementController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /UserSalaryIncrement/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            UserSalaryIncrement ObjUserSalaryIncrement = db.UserSalaryIncrements.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserSalaryIncrement.UserId);

            }

            return View(ObjUserSalaryIncrement);
        }

        // POST: /UserSalaryIncrement/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(UserSalaryIncrement ObjUserSalaryIncrement)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjUserSalaryIncrement).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserSalaryIncrementController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserSalaryIncrement", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Salary Increment to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserSalaryIncrement MultiViewIndex",
                                ErrorFrom = "UserSalaryIncrementController.MultiViewIndex",
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
                    ErrorFor = "UserSalaryIncrement MultiViewIndex",
                    ErrorFrom = "UserSalaryIncrementController.MultiViewIndex",
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
