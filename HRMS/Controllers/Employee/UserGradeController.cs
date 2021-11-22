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

namespace HRMS.Controllers.Employee
{
    public class UserGradeController : Controller
    {

        // GET: /UserGrade/
        public ActionResult Index()
        {
            return View();
        }

        // GET UserGrade/GetGrid
        public ActionResult GetGrid()
        {

            //var tak = db.UserGrades.ToArray();

            //var result = from c in tak
            //             select new string[] { c.Id.ToString(),
            //                Convert.ToString(c.Id),
            //                Convert.ToString(c.Grade_GradeId.Id),
            //                Convert.ToString(c.User_UserId.UserName),
            // };

            var UserGrade = db.UserGrades.ToArray();
            var Grade = db.Grades.ToArray();

            var result = from ug in UserGrade
                         join g in Grade on ug.GradeId equals g.Id
                         select new string[] { ug.Id.ToString(),
                           // Convert.ToString(ug.Id),
                            //Convert.ToString(ug.Grade_GradeId.Id),
                            Convert.ToString(g.Tofsil),
                            Convert.ToString(g.GradeNo),
                            Convert.ToString(g.TofsilWGradeNo),
                            Convert.ToString(ug.User_UserId.UserName),
                            string.Format("{0:dd-MMM-yyyy}",ug.DateAdded),
                            string.Format("{0:dd-MMM-yyyy}",ug.ModifiedDate),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /UserGrade/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }

        // GET: /UserGrade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserGrade ObjUserGrade = db.UserGrades.Find(id);
            if (ObjUserGrade == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserGrade);
        }

        // GET: /UserGrade/Create
        public ActionResult Create()
        {
            ViewBag.GradeId = new SelectList(db.Grades, "Id", "TofsilWGradeNo");
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");

            return View();
        }

        // POST: /UserGrade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(UserGrade ObjUserGrade)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.UserGrades.Add(ObjUserGrade);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserGradeController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "UserGrade", // Module name
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
                                ErrorFor = "UserGrade - Create",
                                ErrorFrom = "UserGradeController.Create",
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
                    ErrorFor = "UserGrade - Create",
                    ErrorFrom = "UserGradeController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /UserGrade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserGrade ObjUserGrade = db.UserGrades.Find(id);
            if (ObjUserGrade == null)
            {
                return HttpNotFound();
            }
            ViewBag.GradeId = new SelectList(db.Grades, "Id", "TofsilWGradeNo", ObjUserGrade.GradeId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserGrade.UserId);

            return View(ObjUserGrade);
        }

        // POST: /UserGrade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(UserGrade ObjUserGrade)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjUserGrade).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserGradeController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserGrade", // Module name
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
                                ErrorFor = "UserGrade Edit",
                                ErrorFrom = "UserGradeController.Edit",
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
                    ErrorFor = "UserGrade Edit",
                    ErrorFrom = "UserGradeController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }


            return Content(sb.ToString());

        }

        // GET: /UserGrade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserGrade ObjUserGrade = db.UserGrades.Find(id);
            if (ObjUserGrade == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserGrade);
        }

        // POST: /UserGrade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                UserGrade ObjUserGrade = db.UserGrades.Find(id);
                db.UserGrades.Remove(ObjUserGrade);
                db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "UserGradeController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "UserGrade", // Module name
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
                    ErrorFor = "UserGrade Delete",
                    ErrorFrom = "UserGradeController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /UserGrade/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            UserGrade ObjUserGrade = db.UserGrades.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.GradeId = new SelectList(db.Grades, "Id", "TofsilWGradeNo", ObjUserGrade.GradeId);
                ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserGrade.UserId);

            }

            return View(ObjUserGrade);
        }

        // POST: /UserGrade/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(UserGrade ObjUserGrade)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjUserGrade).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserGradeController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserGrade", // Module name
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
                                ErrorFor = "UserGrade MultiViewIndex",
                                ErrorFrom = "UserGradeController.MultiViewIndex",
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
                    ErrorFor = "UserGrade MultiViewIndex",
                    ErrorFrom = "UserGradeController.MultiViewIndex",
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
