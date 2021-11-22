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
    public class GradeController : BaseController
    {

        // GET: /Grade/
        public ActionResult Index()
        {
            return View();
        }

        // GET Grade/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.Grades.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(),
                             //Convert.ToString(c.Id),
                             Convert.ToString(c.OTNOT),
                             Convert.ToString(c.Tofsil),
                             Convert.ToString(c.TofsilBN),
                             Convert.ToString(c.GradeNo),
                             Convert.ToString(c.GradeNoBN),
                             Convert.ToString(c.TofsilWGradeNo),
                             Convert.ToString(c.GrossSalary),
                             Convert.ToString(c.BasicSalary),
                             Convert.ToString(c.OvertimeRate),
                             string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
                             string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /Grade/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }

        // GET: /Grade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade ObjGrade = db.Grades.Find(id);
            if (ObjGrade == null)
            {
                return HttpNotFound();
            }
            return View(ObjGrade);
        }

        // GET: /Grade/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: /Grade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Grade ObjGrade)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {

                    ObjGrade = calculateGrade(ObjGrade);
                    db.Grades.Add(ObjGrade);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "GradeController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "Grade", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Assign Grade to user sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "Grade - Create",
                                ErrorFrom = "GradeController.Create",
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
                    ErrorFor = "Grade - Create",
                    ErrorFrom = "GradeController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /Grade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade ObjGrade = db.Grades.Find(id);
            if (ObjGrade == null)
            {
                return HttpNotFound();
            }

            return View(ObjGrade);
        }

        // POST: /Grade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Grade ObjGrade)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {

                    ObjGrade = calculateGrade(ObjGrade);
                    db.Entry(ObjGrade).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "GradeController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "Grade", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Grade to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "Grade Edit",
                                ErrorFrom = "GradeController.Edit",
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
                    ErrorFor = "Grade Edit",
                    ErrorFrom = "GradeController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }


            return Content(sb.ToString());

        }

        // GET: /Grade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade ObjGrade = db.Grades.Find(id);
            if (ObjGrade == null)
            {
                return HttpNotFound();
            }
            return View(ObjGrade);
        }

        // POST: /Grade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                Grade ObjGrade = db.Grades.Find(id);
                db.Grades.Remove(ObjGrade);
                db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "GradeController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "Grade", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Delete Grade to user sucessfull." // Message if any
                });

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "Grade Delete",
                    ErrorFrom = "GradeController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /Grade/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            Grade ObjGrade = db.Grades.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;

            }

            return View(ObjGrade);
        }
        // POST: /Grade/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(Grade ObjGrader)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjGrader).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "GradeController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "Grade", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Grade to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "Grade MultiViewIndex",
                                ErrorFrom = "GradeController.MultiViewIndex",
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
                    ErrorFor = "Grade MultiViewIndex",
                    ErrorFrom = "GradeController.MultiViewIndex",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        public Grade calculateGrade(Grade ObjGrade)
        {
            {
                ObjGrade.GrossSalary = Convert.ToDecimal(ObjGrade.GrossSalary);
                ObjGrade.TofsilWGradeNo = Convert.ToString(ObjGrade.Tofsil) + "-" + Convert.ToString(ObjGrade.GradeNo);
                //ObjGrade.BasicSalary = Convert.ToDecimal(ObjGrade.GrossSalary / 2);
                if (ObjGrade.OTNOT == "OT")
                {
                    decimal MedicalAllowanceOT = 600;

                    decimal ConveyanceAllowanceOT = 350;

                    decimal FoodAllowanceOT = 900;

                    decimal threeAllowances = Math.Round(Convert.ToDecimal(MedicalAllowanceOT + ConveyanceAllowanceOT + FoodAllowanceOT));

                    ObjGrade.BasicSalary = Math.Round(Convert.ToDecimal((ObjGrade.GrossSalary - threeAllowances) * 100) / 150);
                    ObjGrade.OvertimeRate = Math.Round(Convert.ToDecimal((ObjGrade.BasicSalary / 208) * 2));
                }
                else
                {
                    ObjGrade.BasicSalary = Math.Round(Convert.ToDecimal((ObjGrade.GrossSalary / 100) * 50));
                    ObjGrade.OvertimeRate = Convert.ToDecimal("0.0");
                }
                return ObjGrade;
            }
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