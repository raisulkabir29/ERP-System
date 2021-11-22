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
	public class UserWorkExperienceController : BaseController
	{ 
		// GET: /UserWorkExperience/
		public ActionResult Index()
		{
			return View();
		}

        // GET UserWorkExperience/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.UserWorkExperiences.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(),
                //Convert.ToString(c.Id), 
				Convert.ToString(c.User_UserId.UserName),
                Convert.ToString(c.CompanyName),
                Convert.ToString(c.Position), 
				//Convert.ToString(c.FromDate), 
				//Convert.ToString(c.ToDate),
                string.Format("{0:dd-MMM-yyyy}",c.FromDate),
                string.Format("{0:dd-MMM-yyyy}",c.ToDate),
                Convert.ToString(c.IsCurrent),
                Convert.ToString(c.DescribeJob),
                Convert.ToString(c.LastSalary),
                Convert.ToString(c.JobDuration),
                Convert.ToString(c.ReasonForLeave),
                string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
                string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /UserWorkExperience/ModelBindIndex
        public ActionResult ModelBindIndex()
		{
			return View();
		}
		// GET: /UserWorkExperience/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			UserWorkExperience ObjUserWorkExperience = db.UserWorkExperiences.Find(id);
			if (ObjUserWorkExperience == null)
			{
				return HttpNotFound();
			}
			return View(ObjUserWorkExperience);
		}
		// GET: /UserWorkExperience/Create
		public ActionResult Create()
		{
			 ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");

			 return View();
		}

		// POST: /UserWorkExperience/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Create(UserWorkExperience ObjUserWorkExperience )
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					

					db.UserWorkExperiences.Add(ObjUserWorkExperience);
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserWorkExperienceController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "UserWorkExperience", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Add Work Experience to user sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "UserWorkExperience - Create",
                                ErrorFrom = "UserWorkExperienceController.Create",
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
                    ErrorFor = "UserWorkExperience - Create",
                    ErrorFrom = "UserWorkExperienceController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
			return Content(sb.ToString());
			 
		}
		// GET: /UserWorkExperience/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			UserWorkExperience ObjUserWorkExperience = db.UserWorkExperiences.Find(id);
			if (ObjUserWorkExperience == null)
			{
				return HttpNotFound();
			}
			ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserWorkExperience.UserId);

			return View(ObjUserWorkExperience);
		}

		// POST: /UserWorkExperience/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Edit(UserWorkExperience ObjUserWorkExperience )
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					

					db.Entry(ObjUserWorkExperience).State = EntityState.Modified;
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserWorkExperienceController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserWorkExperience", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Work Experience to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserWorkExperience Edit",
                                ErrorFrom = "UserWorkExperienceController.Edit",
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
                    ErrorFor = "UserWorkExperience Edit",
                    ErrorFrom = "UserWorkExperienceController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
 
			 
			return Content(sb.ToString());

		}
		// GET: /UserWorkExperience/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			UserWorkExperience ObjUserWorkExperience = db.UserWorkExperiences.Find(id);
			if (ObjUserWorkExperience == null)
			{
				return HttpNotFound();
			}
			return View(ObjUserWorkExperience);
		}

		// POST: /UserWorkExperience/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				  
					UserWorkExperience ObjUserWorkExperience = db.UserWorkExperiences.Find(id);
					db.UserWorkExperiences.Remove(ObjUserWorkExperience);
					db.SaveChanges();

                    Utility.WriteAuditLog(new AuditLog()
                    {
                        ActionFrom = "UserWorkExperienceController.Delete",
                        Action = (int)AuditAction.Delete,
                        ModuleName = "UserWorkExperience", // Module name
                        SubModuleName = "Delete", // Sub module name if any
                                                  //UserId = userId, // Id from Current User
                        ActionMessage = "Delete Work Experience to user sucessfull." // Message if any
                    });

                    sb.Append("Sumitted");
					return Content(sb.ToString());
				 
			}
			catch (Exception ex)
			{
				sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "UserWorkExperience Delete",
                    ErrorFrom = "UserWorkExperienceController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
			return Content(sb.ToString());
  
		}
		// GET: /UserWorkExperience/MultiViewIndex/5
		public ActionResult MultiViewIndex(int? id)
		{ 
			UserWorkExperience ObjUserWorkExperience = db.UserWorkExperiences.Find(id);
			ViewBag.IsWorking = 0;
			if (id > 0)
			{
				ViewBag.IsWorking = id;
				ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserWorkExperience.UserId);

			}
			
			return View(ObjUserWorkExperience);
		}

		// POST: /UserWorkExperience/MultiViewIndex/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult MultiViewIndex(UserWorkExperience ObjUserWorkExperience )
		{  
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					

					db.Entry(ObjUserWorkExperience).State = EntityState.Modified;
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserWorkExperienceController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserWorkExperience", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Work Experience to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserWorkExperience MultiViewIndex",
                                ErrorFrom = "UserWorkExperienceController.MultiViewIndex",
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
                    ErrorFor = "UserWorkExperience MultiViewIndex",
                    ErrorFrom = "UserWorkExperienceController.MultiViewIndex",
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

