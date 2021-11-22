using HRMS.Common.Enums;
using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace HRMS.Controllers.Employee
{
    public class EmployeeTerminationController : Controller
    {

        // GET: /EmployeeTermination/
        public ActionResult Index()
        {
            return View();
        }

        // GET EmployeeTermination/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.EmployeeTerminations.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(),
                //Convert.ToString(c.Id),
                Convert.ToString(c.TerminationType_TerminationId.Name),
                Convert.ToString(c.Department_DepartmentId.Name),
                Convert.ToString(c.SectionId),
                Convert.ToString(c.User_UserId.UserName),
                Convert.ToString(c.User_UserId.CustomId),
                string.Format("{0:dd-MMM-yyyy}",c.OccuranceDate),
                string.Format("{0:dd-MMM-yyyy}",c.DetectionDate),
                string.Format("{0:dd-MMM-yyyy}",c.ShowcauseDate),
                Convert.ToString(c.Description),
                Convert.ToString(c.ReplyDay),
                string.Format("{0:dd-MMM-yyyy}",c.NotificationDay),
                string.Format("{0:dd-MMM-yyyy}",c.TerminationDate),
                Convert.ToString(c.Year),
                Convert.ToString(c.Month),
                Convert.ToString(c.IsPayable),
                Convert.ToString(c.PayableAmount),
                string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
                string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /EmployeeTermination/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /EmployeeTermination/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTermination ObjEmployeeTermination = db.EmployeeTerminations.Find(id);
            if (ObjEmployeeTermination == null)
            {
                return HttpNotFound();
            }
            return View(ObjEmployeeTermination);
        }

        // GET: /EmployeeTermination/Create
        public ActionResult Create()
        {
            ViewBag.TerminationId = new SelectList(db.TerminationTypes, "Id", "Name");
            ViewBag.DepartmentList = db.Departments.Where(c => c.ParentId == null);
            //ViewBag.DepartmentList = db.Departments;
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.CustomId = new SelectList(db.Users, "Id", "CustomId");
            return View();
        }


        // Ajax call: /EmployeeTermination/FillSection
        public ActionResult FillSection(int? dptId)
        {
            return Json(db.Departments.Where(c => c.ParentId == dptId).Select(x => new
            {
                SectionID = x.Id,
                SectionName = x.Name
            }).ToList(), JsonRequestBehavior.AllowGet);
        }

        // POST: /EmployeeTermination/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(EmployeeTermination ObjEmployeeTermination)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {

                    //ObjEmployeeTermination = calculateEmployeeTermination(ObjEmployeeTermination);
                    db.EmployeeTerminations.Add(ObjEmployeeTermination);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "EmployeeTerminationController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "EmployeeTermination", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Adding Termination to employee is sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "EmployeeTermination - Create",
                                ErrorFrom = "EmployeeTerminationController.Create",
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
                    ErrorFor = "EmployeeTermination - Create",
                    ErrorFrom = "EmployeeTerminationController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }
        // GET: /EmployeeTermination/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTermination ObjEmployeeTermination = db.EmployeeTerminations.Find(id);
            if (ObjEmployeeTermination == null)
            {
                return HttpNotFound();
            }
            ViewBag.TerminationId = new SelectList(db.TerminationTypes, "Id", "Name", ObjEmployeeTermination.TerminationId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", ObjEmployeeTermination.DepartmentId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjEmployeeTermination.UserId);
            ViewBag.CustomId = new SelectList(db.Users, "Id", "CustomId", ObjEmployeeTermination.CustomId);

            return View(ObjEmployeeTermination);
        }

        // POST: /EmployeeTermination/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(EmployeeTermination ObjEmployeeTermination)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {
                    //ObjEmployeeTermination = calculateEmployeeTermination(ObjEmployeeTermination);
                    db.Entry(ObjEmployeeTermination).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "EmployeeTerminationController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "EmployeeTermination", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Termination to  Employee is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "EmployeeTermination Edit",
                                ErrorFrom = "EmployeeTerminationController.Edit",
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
                    ErrorFor = "EmployeeTermination Edit",
                    ErrorFrom = "EmployeeTerminationController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }


            return Content(sb.ToString());

        }

        // GET: /EmployeeTermination/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTermination ObjEmployeeTermination = db.EmployeeTerminations.Find(id);
            if (ObjEmployeeTermination == null)
            {
                return HttpNotFound();
            }
            return View(ObjEmployeeTermination);
        }

        // POST: /EmployeeTermination/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                EmployeeTermination ObjEmployeeTermination = db.EmployeeTerminations.Find(id);
                db.EmployeeTerminations.Remove(ObjEmployeeTermination);
                db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "EmployeeTerminationController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "EmployeeTermination", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Deleting Termination to Employee is sucessfull." // Message if any
                });

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "EmployeeTermination Delete",
                    ErrorFrom = "EmployeeTerminationController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }
        // GET: /EmployeeTermination/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            EmployeeTermination ObjEmployeeTermination = db.EmployeeTerminations.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.TerminationId = new SelectList(db.TerminationTypes, "Id", "Name", ObjEmployeeTermination.TerminationId);
                ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", ObjEmployeeTermination.DepartmentId);
                ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjEmployeeTermination.UserId);
                ViewBag.CustomId = new SelectList(db.Users, "Id", "CustomId", ObjEmployeeTermination.CustomId);
            }

            return View(ObjEmployeeTermination);
        }

        // POST: /EmployeeTermination/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(EmployeeTermination ObjEmployeeTermination)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjEmployeeTermination).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "EmployeeTerminationController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "EmployeeTermination", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Termination to  Employee sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "EmployeeTermination MultiViewIndex",
                                ErrorFrom = "EmployeeTerminationController.MultiViewIndex",
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
                    ErrorFor = "EmployeeTermination MultiViewIndex",
                    ErrorFrom = "EmployeeTerminationController.MultiViewIndex",
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
