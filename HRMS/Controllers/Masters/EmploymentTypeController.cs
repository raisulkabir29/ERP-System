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

namespace HRMS.Controllers.Masters
{
    public class EmploymentTypeController : Controller
    {

        // GET: /EmploymentType/
        public ActionResult Index()
        {
            return View();
        }

        // GET EmploymentType/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.EmploymentTypes.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(),
                            //Convert.ToString(c.Id),
                            Convert.ToString(c.Name),
                            string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
                            string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /EmploymentType/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /EmploymentType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmploymentType ObjEmploymentType = db.EmploymentTypes.Find(id);
            if (ObjEmploymentType == null)
            {
                return HttpNotFound();
            }
            return View(ObjEmploymentType);
        }
        // GET: /EmploymentType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /EmploymentType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(EmploymentType ObjEmploymentType)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.EmploymentTypes.Add(ObjEmploymentType);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "EmploymentTypeController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "EmploymentType", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Adding Employment Type is sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "EmploymentType - Create",
                                ErrorFrom = "EmploymentTypeController.Create",
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
                    ErrorFor = "EmploymentType - Create",
                    ErrorFrom = "EmploymentTypeController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /EmploymentType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmploymentType ObjEmploymentType = db.EmploymentTypes.Find(id);
            if (ObjEmploymentType == null)
            {
                return HttpNotFound();
            }

            return View(ObjEmploymentType);
        }

        // POST: /EmploymentType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(EmploymentType ObjEmploymentType)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjEmploymentType).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "EmploymentTypeController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "EmploymentType", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Employment Type is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "EmploymentType Edit",
                                ErrorFrom = "EmploymentTypeController.Edit",
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
                    ErrorFor = "EmploymentType Edit",
                    ErrorFrom = "EmploymentTypeController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }


            return Content(sb.ToString());

        }

        // GET: /EmploymentType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmploymentType ObjEmploymentType = db.EmploymentTypes.Find(id);
            if (ObjEmploymentType == null)
            {
                return HttpNotFound();
            }
            return View(ObjEmploymentType);
        }

        // POST: /EmploymentType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                EmploymentType ObjEmploymentType = db.EmploymentTypes.Find(id);
                db.EmploymentTypes.Remove(ObjEmploymentType);
                db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "EmploymentTypeController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "EmploymentType", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Deleting Employment Type is sucessfull." // Message if any
                });

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "EmploymentType Delete",
                    ErrorFrom = "EmploymentTypeController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }
        // GET: /EmploymentType/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            EmploymentType ObjEmploymentType = db.EmploymentTypes.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;

            }

            return View(ObjEmploymentType);
        }

        // POST: /EmploymentType/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(EmploymentType ObjEmploymentType)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjEmploymentType).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "EmploymentTypeController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "EmploymentType", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing EmploymentType is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "EmploymentType MultiViewIndex",
                                ErrorFrom = "EmploymentTypeController.MultiViewIndex",
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
                    ErrorFor = "EmploymentType MultiViewIndex",
                    ErrorFrom = "EmploymentTypeController.MultiViewIndex",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        public ActionResult UserGetGrid(int id = 0)
        {
            var tak = db.Users.Where(i => i.GenderId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.BloodGroup),
                Convert.ToString(c.Nationality),
                Convert.ToString(c.FirstName),
                Convert.ToString(c.LastName),
                Convert.ToString(c.UserName),
                Convert.ToString(c.Password),
                Convert.ToString(c.CanLogin),
                Convert.ToString(c.IsActive),
                Convert.ToString(c.ProfilePicture),
                Convert.ToString(c.DateOfBirth),
                Convert.ToString(c.Id),
                Convert.ToString(c.Office_OfficeId.Title),Convert.ToString(c.GenderId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
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
