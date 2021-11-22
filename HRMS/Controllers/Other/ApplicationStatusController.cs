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

namespace HRMS.Controllers
{
	public class ApplicationStatusController : BaseController
	{
		// GET: /ApplicationStatus/
		public ActionResult Index()
		{
			return View();
		}

        // GET ApplicationStatus/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.ApplicationStatuss.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(),
                            //Convert.ToString(c.Id), 
				            Convert.ToString(c.Name),
                            Convert.ToString(c.Description),
                            string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
                            string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /ApplicationStatus/ModelBindIndex
        public ActionResult ModelBindIndex()
		{
			return View();
		}
		// GET: /ApplicationStatus/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ApplicationStatus ObjApplicationStatus = db.ApplicationStatuss.Find(id);
			if (ObjApplicationStatus == null)
			{
				return HttpNotFound();
			}
			return View(ObjApplicationStatus);
		}
		// GET: /ApplicationStatus/Create
		public ActionResult Create()
		{

			return View();
		}

		// POST: /ApplicationStatus/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
        public ActionResult Create(ApplicationStatus ObjApplicationStatus)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			try
			{
				if (ModelState.IsValid)
				{
                    db.ApplicationStatuss.Add(ObjApplicationStatus);
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "ApplicationStatusController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "ApplicationStatus", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Adding Application Status is sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "ApplicationStatus - Create",
                                ErrorFrom = "ApplicationStatusController.Create",
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
                    ErrorFor = "ApplicationStatus - Create",
                    ErrorFrom = "ApplicationStatusController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

			return Content(sb.ToString());

		}
        // GET: /ApplicationStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationStatus ObjApplicationStatus = db.ApplicationStatuss.Find(id);
            if (ObjApplicationStatus == null)
            {
                return HttpNotFound();
            }

            return View(ObjApplicationStatus);
        }
        // POST: /ApplicationStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(ApplicationStatus ObjApplicationStatus)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(ObjApplicationStatus).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "ApplicationStatusController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "ApplicationStatus", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Application Status is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "ApplicationStatus Edit",
                                ErrorFrom = "ApplicationStatusController.Edit",
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
                    ErrorFor = "ApplicationStatus Edit",
                    ErrorFrom = "ApplicationStatusController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
            return Content(sb.ToString());
        }
        // GET: /ApplicationStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationStatus ObjApplicationStatus = db.ApplicationStatuss.Find(id);
            if (ObjApplicationStatus == null)
            {
                return HttpNotFound();
            }
            return View(ObjApplicationStatus);
        }
        // POST: /ApplicationStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                ApplicationStatus ObjApplicationStatus = db.ApplicationStatuss.Find(id);
                db.ApplicationStatuss.Remove(ObjApplicationStatus);
                db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "ApplicationStatusController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "ApplicationStatus", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Deleting Application Status is sucessfull." // Message if any
                });

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "ApplicationStatus Delete",
                    ErrorFrom = "ApplicationStatusController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }
        // GET: /ApplicationStatus/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            ApplicationStatus ObjApplicationStatus = db.ApplicationStatuss.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;

            }

            return View(ObjApplicationStatus);
        }
        // POST: /ApplicationStatus/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(ApplicationStatus ObjApplicationStatus)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(ObjApplicationStatus).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "ApplicationStatusController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "ApplicationStatus", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Application Status is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "ApplicationStatus MultiViewIndex",
                                ErrorFrom = "ApplicationStatusController.MultiViewIndex",
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
                    ErrorFor = "ApplicationStatus MultiViewIndex",
                    ErrorFrom = "ApplicationStatusController.MultiViewIndex",
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
