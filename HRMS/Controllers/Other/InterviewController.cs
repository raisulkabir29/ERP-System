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
using System.Globalization;

namespace HRMS.Controllers
{
    public class InterviewController : BaseController
    {
        // GET: /Interview/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InterviewsDn()
        {
            return View();
        }
        public ActionResult InterviewsPc()
        {
            return View();
        }

        // GET Interview/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.Interviews.ToArray();
              
            var result = from c in tak
                         select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.CandidateName), 
            Convert.ToString(c.Email), 
            Convert.ToString(c.Mobile), 
            Convert.ToString(c.Address), 
            Convert.ToString(c.JobTitle_JobTitleId.Name), 
            Convert.ToString(c.InterviewDate), 
            Convert.ToString(c.PlaceOfInterview), 
            Convert.ToString(c.InterviewTime), 
            Convert.ToString(db.Users.Where(i=>i.Id==c.InterviewBy).FirstOrDefault().UserName), 
            Convert.ToString(c.InterviewRemarks), 
            Convert.ToString(c.IsDone), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetGridDone()
        {
            var tak = db.Interviews.Where(i => i.IsDone.Value).ToArray();
            
            var result = from c in tak
                         select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.CandidateName), 
            Convert.ToString(c.Email), 
            Convert.ToString(c.Mobile), 
            Convert.ToString(c.Address), 
            Convert.ToString(c.JobTitle_JobTitleId.Name), 
            Convert.ToString(c.InterviewDate), 
            Convert.ToString(c.PlaceOfInterview), 
            Convert.ToString(c.InterviewTime), 
            Convert.ToString(db.Users.Where(i=>i.Id==c.InterviewBy).FirstOrDefault().UserName),
            Convert.ToString(c.DateAdded), 
            Convert.ToString(c.AddedBy), 
            Convert.ToString(c.ModifiedDate), 
            Convert.ToString(c.InterviewRemarks), 
            Convert.ToString(c.IsDone), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetGridProcess()
        {
            var tak = db.Interviews.Where(i => !i.IsDone.Value || i.IsDone == null).ToArray();
            var result = from c in tak
                         select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.CandidateName), 
            Convert.ToString(c.Email), 
            Convert.ToString(c.Mobile), 
            Convert.ToString(c.Address), 
            Convert.ToString(c.JobTitle_JobTitleId.Name), 
            Convert.ToString(c.InterviewDate), 
            Convert.ToString(c.PlaceOfInterview), 
            Convert.ToString(c.InterviewTime), 
            Convert.ToString(db.Users.Where(i=>i.Id==c.InterviewBy).FirstOrDefault().UserName), 
            Convert.ToString(c.DateAdded), 
            Convert.ToString(c.AddedBy), 
            Convert.ToString(c.ModifiedDate), 
            Convert.ToString(c.InterviewRemarks), 
            Convert.ToString(c.IsDone), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
            
        // GET: /Interview/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /Interview/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interview ObjInterview = db.Interviews.Find(id);
            if (ObjInterview == null)
            {
                return HttpNotFound();
            }
            return View(ObjInterview);
        }
        // GET: /Interview/Create
        public ActionResult Create()
        {
            ViewBag.JobTitleId = new SelectList(db.JobTitles, "Id", "Name");
            ViewBag.InterviewBy = new SelectList(db.Users.Where(i => db.RoleUsers.Where(j => j.RoleId != 3).Select(j => j.UserId).Contains(i.Id)), "Id", "UserName");
            return View();
        }

        // POST: /Interview/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Interview ObjInterview, string InterviewDate)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                ObjInterview.InterviewDate = DateTime.ParseExact(InterviewDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                if (ModelState.IsValid)
                {
                    
                    db.Interviews.Add(ObjInterview);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "InterviewController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "Interview", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Adding Interview is sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "Interview - Create",
                                ErrorFrom = "InterviewController.Create",
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
                    ErrorFor = "Interview - Create",
                    ErrorFrom = "InterviewController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }
        // GET: /Interview/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interview ObjInterview = db.Interviews.Find(id);
            if (ObjInterview == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobTitleId = new SelectList(db.JobTitles, "Id", "Name", ObjInterview.JobTitleId);
            ViewBag.InterviewBy = new SelectList(db.Users.Where(i => db.RoleUsers.Where(j => j.RoleId != 3).Select(j => j.UserId).Contains(i.Id)), "Id", "UserName",ObjInterview.InterviewBy);
            return View(ObjInterview);
        }

        // POST: /Interview/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Interview ObjInterview,string InterviewDate)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                ObjInterview.InterviewDate = DateTime.ParseExact(InterviewDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                if (ModelState.IsValid)
                {


                    db.Entry(ObjInterview).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "InterviewController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "Interview", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Interview is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "Interview Edit",
                                ErrorFrom = "InterviewController.Edit",
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
                    ErrorFor = "Interview Edit",
                    ErrorFrom = "InterviewController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }


            return Content(sb.ToString());

        }
        // GET: /Interview/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interview ObjInterview = db.Interviews.Find(id);
            if (ObjInterview == null)
            {
                return HttpNotFound();
            }
            return View(ObjInterview);
        }

        // POST: /Interview/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                Interview ObjInterview = db.Interviews.Find(id);
                db.Interviews.Remove(ObjInterview);
                db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "InterviewController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "Interview", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Deleting Interview is sucessfull." // Message if any
                });

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "Interview Delete",
                    ErrorFrom = "InterviewController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }
        // GET: /Interview/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            Interview ObjInterview = db.Interviews.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.JobTitleId = new SelectList(db.JobTitles, "Id", "Name", ObjInterview.JobTitleId);

            }

            return View(ObjInterview);
        }

        // POST: /Interview/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(Interview ObjInterview)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjInterview).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "InterviewController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "Interview", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Interview is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "Interview MultiViewIndex",
                                ErrorFrom = "InterviewController.MultiViewIndex",
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
                    ErrorFor = "Interview MultiViewIndex",
                    ErrorFrom = "InterviewController.MultiViewIndex",
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

