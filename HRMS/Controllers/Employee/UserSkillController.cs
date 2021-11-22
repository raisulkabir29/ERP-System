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
	public class UserSkillController : BaseController
	{ 
		// GET: /UserSkill/
		public ActionResult Index()
		{
			return View();
		}

        // GET UserSkill/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.UserSkills.ToArray();

            var result = from c in tak
                         select new string[] {
                c.Id.ToString(), 
				//Convert.ToString(c.Id), 
				Convert.ToString(c.User_UserId.UserName),
                Convert.ToString(c.SkillName),
                Convert.ToString(c.RateYourSelf),
                Convert.ToString(c.MachineName),
                Convert.ToString(c.Process),
                Convert.ToString(c.PerHourCapacity),
                string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
                string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),
            };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /UserSkill/ModelBindIndex
        public ActionResult ModelBindIndex()
		{
			return View();
		}
		// GET: /UserSkill/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			UserSkill ObjUserSkill = db.UserSkills.Find(id);
			if (ObjUserSkill == null)
			{
				return HttpNotFound();
			}
			return View(ObjUserSkill);
		}
		// GET: /UserSkill/Create
		public ActionResult Create()
		{
			 ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");

			 return View();
		}

		// POST: /UserSkill/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Create(UserSkill ObjUserSkill )
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					

					db.UserSkills.Add(ObjUserSkill);
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserSkillController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "UserSkill", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Assign Skill to user sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "UserSkill - Create",
                                ErrorFrom = "UserSkillController.Create",
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
                    ErrorFor = "UserSkill - Create",
                    ErrorFrom = "UserSkillController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
			return Content(sb.ToString());
			 
		}
		// GET: /UserSkill/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			UserSkill ObjUserSkill = db.UserSkills.Find(id);
			if (ObjUserSkill == null)
			{
				return HttpNotFound();
			}
			ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserSkill.UserId);

			return View(ObjUserSkill);
		}

		// POST: /UserSkill/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Edit(UserSkill ObjUserSkill )
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					

					db.Entry(ObjUserSkill).State = EntityState.Modified;
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserSkillController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserSkill", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Skill to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserSkill Edit",
                                ErrorFrom = "UserSkillController.Edit",
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
                    ErrorFor = "UserSkill Edit",
                    ErrorFrom = "UserSkillController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
 
			 
			return Content(sb.ToString());

		}
		// GET: /UserSkill/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			UserSkill ObjUserSkill = db.UserSkills.Find(id);
			if (ObjUserSkill == null)
			{
				return HttpNotFound();
			}
			return View(ObjUserSkill);
		}

		// POST: /UserSkill/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				  
					UserSkill ObjUserSkill = db.UserSkills.Find(id);
					db.UserSkills.Remove(ObjUserSkill);
					db.SaveChanges();

                    Utility.WriteAuditLog(new AuditLog()
                    {
                        ActionFrom = "UserSkillController.Delete",
                        Action = (int)AuditAction.Delete,
                        ModuleName = "UserSkill", // Module name
                        SubModuleName = "Delete", // Sub module name if any
                                                  //UserId = userId, // Id from Current User
                        ActionMessage = "Delete Skill to user sucessfull." // Message if any
                    });

                sb.Append("Sumitted");
					return Content(sb.ToString());
				 
			}
			catch (Exception ex)
			{
				sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "UserSkill Delete",
                    ErrorFrom = "UserSkillController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
			return Content(sb.ToString());
  
		}
		// GET: /UserSkill/MultiViewIndex/5
		public ActionResult MultiViewIndex(int? id)
		{ 
			UserSkill ObjUserSkill = db.UserSkills.Find(id);
			ViewBag.IsWorking = 0;
			if (id > 0)
			{
				ViewBag.IsWorking = id;
				ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserSkill.UserId);

			}
			
			return View(ObjUserSkill);
		}

		// POST: /UserSkill/MultiViewIndex/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult MultiViewIndex(UserSkill ObjUserSkill )
		{  
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					

					db.Entry(ObjUserSkill).State = EntityState.Modified;
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserSkillController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserSkill", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Skill to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserSkill MultiViewIndex",
                                ErrorFrom = "UserSkillController.MultiViewIndex",
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
                    ErrorFor = "UserSkill MultiViewIndex",
                    ErrorFrom = "UserSkillController.MultiViewIndex",
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

