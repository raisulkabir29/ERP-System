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
    public class UserEmploymentTypeController : Controller
    {

        // GET: /UserEmploymentType/
        public ActionResult Index()
        {
            return View();
        }

        // GET UserEmploymentType/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.UserEmploymentTypes.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(),
            //Convert.ToString(c.Id),
            Convert.ToString(c.EmploymentType_EmploymentTypeId.Name),
            Convert.ToString(c.Department_DepartmentId.Name),
            Convert.ToString(c.User_UserId.UserName),
            string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
            string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /UserEmploymentType/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }

        // GET: /UserEmploymentType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEmploymentType ObjUserEmploymentType = db.UserEmploymentTypes.Find(id);
            if (ObjUserEmploymentType == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserEmploymentType);
        }

        // GET: /UserEmploymentType/Create
        public ActionResult Create()
        {
            ViewBag.EmploymentTypeId = new SelectList(db.EmploymentTypes, "Id", "Name");
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");

            return View();
        }

        // POST: /UserEmploymentType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(UserEmploymentType ObjUserEmploymentType)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.UserEmploymentTypes.Add(ObjUserEmploymentType);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserEmploymentTypeController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "UserEmploymentType", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Assign Employment Type to user sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "UserEmploymentType - Create",
                                ErrorFrom = "UserEmploymentTypeController.Create",
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
                    ErrorFor = "UserEmploymentType - Create",
                    ErrorFrom = "UserEmploymentTypeController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /UserEmploymentType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEmploymentType ObjUserEmploymentType = db.UserEmploymentTypes.Find(id);
            if (ObjUserEmploymentType == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmploymentTypeId = new SelectList(db.EmploymentTypes, "Id", "Name", ObjUserEmploymentType.EmploymentTypeId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", ObjUserEmploymentType.DepartmentId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserEmploymentType.UserId);

            return View(ObjUserEmploymentType);
        }

        // POST: /UserEmploymentType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(UserEmploymentType ObjUserEmploymentType)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjUserEmploymentType).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserEmploymentTypeController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserEmploymentType", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Employment Type to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserEmploymentType Edit",
                                ErrorFrom = "UserEmploymentTypeController.Edit",
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
                    ErrorFor = "UserEmploymentType Edit",
                    ErrorFrom = "UserEmploymentTypeController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }


            return Content(sb.ToString());

        }

        // GET: /UserEmploymentType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEmploymentType ObjUserEmploymentType = db.UserEmploymentTypes.Find(id);
            if (ObjUserEmploymentType == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserEmploymentType);
        }

        // POST: /UserEmploymentType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                UserEmploymentType ObjUserEmploymentType = db.UserEmploymentTypes.Find(id);
                db.UserEmploymentTypes.Remove(ObjUserEmploymentType);
                db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "UserEmploymentTypeController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "UserEmploymentType", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Delete Employment Type to user sucessfull." // Message if any
                });

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "UserEmploymentType Delete",
                    ErrorFrom = "UserEmploymentTypeController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /UserEmploymentType/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            UserEmploymentType ObjUserEmploymentType = db.UserEmploymentTypes.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.EmploymentTypeId = new SelectList(db.EmploymentTypes, "Id", "Name", ObjUserEmploymentType.EmploymentTypeId);
                ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", ObjUserEmploymentType.DepartmentId);
                ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserEmploymentType.UserId);

            }

            return View(ObjUserEmploymentType);
        }

        // POST: /UserEmploymentType/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(UserEmploymentType ObjUserEmploymentType)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjUserEmploymentType).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserEmploymentTypeController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserEmploymentType", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Employment Type to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserEmploymentType MultiViewIndex",
                                ErrorFrom = "UserEmploymentTypeController.MultiViewIndex",
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
                    ErrorFor = "UserEmploymentType MultiViewIndex",
                    ErrorFrom = "UserEmploymentTypeController.MultiViewIndex",
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