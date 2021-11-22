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
    public class EmployeeAllowanceTypeController : BaseController
    {
        // GET: /EmployeeAllowanceType/
        public ActionResult Index()
        {
            return View();
        }

        // GET /EmployeeAllowanceType/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.EmployeeAllowanceTypes.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(),
                            //Convert.ToString(c.Id),
                            Convert.ToString(c.OTNOT),
                            Convert.ToString(c.Code),
                            Convert.ToString(c.Name),
                            Convert.ToString(c.Value),
                            Convert.ToString(c.Description),
                            string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
                            string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),
            };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }

        // GET: /EmployeeAllowanceType/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /EmployeeAllowanceType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAllowanceType ObjEmployeeAllowanceType = db.EmployeeAllowanceTypes.Find(id);
            if (ObjEmployeeAllowanceType == null)
            {
                return HttpNotFound();
            }
            return View(ObjEmployeeAllowanceType);
        }

        // GET: /EmployeeAllowanceType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /EmployeeAllowanceType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(EmployeeAllowanceType ObjEmployeeAllowanceType)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {
                    db.EmployeeAllowanceTypes.Add(ObjEmployeeAllowanceType);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "EmployeeAllowanceTypeController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "EmployeeAllowanceType", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Adding Employee AllowanceType is sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "EmployeeAllowanceType - Create",
                                ErrorFrom = "EmployeeAllowanceTypeController.Create",
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
                    ErrorFor = "EmployeeAllowanceType - Create",
                    ErrorFrom = "EmployeeAllowanceTypeController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /EmployeeAllowanceType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAllowanceType ObjEmployeeAllowanceType = db.EmployeeAllowanceTypes.Find(id);
            if (ObjEmployeeAllowanceType == null)
            {
                return HttpNotFound();
            }

            return View(ObjEmployeeAllowanceType);
        }

        // POST: /EmployeeAllowanceType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(EmployeeAllowanceType ObjEmployeeAllowanceType)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(ObjEmployeeAllowanceType).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "EmployeeAllowanceTypeController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "EmployeeAllowanceType", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Allowance Type is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "EmployeeAllowanceType Edit",
                                ErrorFrom = "EmployeeAllowanceTypeController.Edit",
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
                    ErrorFor = "EmployeeAllowanceType Edit",
                    ErrorFrom = "EmployeeAllowanceTypeController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }


            return Content(sb.ToString());

        }

        // GET: /EmployeeAllowanceType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAllowanceType ObjEmployeeAllowanceType = db.EmployeeAllowanceTypes.Find(id);
            if (ObjEmployeeAllowanceType == null)
            {
                return HttpNotFound();
            }
            return View(ObjEmployeeAllowanceType);
        }

        // POST: /EmployeeAllowanceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                EmployeeAllowanceType ObjEmployeeAllowanceType = db.EmployeeAllowanceTypes.Find(id);
                db.EmployeeAllowanceTypes.Remove(ObjEmployeeAllowanceType);
                db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "EmployeeAllowanceTypeController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "EmployeeAllowanceType", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Deleting Allowance Type is sucessfull." // Message if any
                });

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "EmployeeAllowanceType Delete",
                    ErrorFrom = "EmployeeAllowanceTypeController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /EmployeeAllowanceType/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            EmployeeAllowanceType ObjEmployeeAllowanceType = db.EmployeeAllowanceTypes.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;

            }

            return View(ObjEmployeeAllowanceType);
        }

        // POST: /EmployeeAllowanceType/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(EmployeeAllowanceType ObjEmployeeAllowanceType)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjEmployeeAllowanceType).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "EmployeeAllowanceTypeController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "EmployeeAllowanceType", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Allowance Type is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "EmployeeAllowanceType MultiViewIndex",
                                ErrorFrom = "EmployeeAllowanceTypeController.MultiViewIndex",
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
                    ErrorFor = "EmployeeAllowanceType MultiViewIndex",
                    ErrorFrom = "EmployeeAllowanceTypeController.MultiViewIndex",
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
