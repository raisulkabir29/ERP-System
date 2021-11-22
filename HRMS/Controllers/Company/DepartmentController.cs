using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using HRMS.Models;
using HRMS.Common.Enums;
using Newtonsoft.Json;

namespace HRMS.Controllers
{
	public class DepartmentController : BaseController
	{ 
		// GET: /Department/
		public ActionResult Index()
		{
			return View();
		}

        // GET Department/GetGrid
        public ActionResult GetGrid()
        {
            JsonSerializer js = new JsonSerializer();
            var tak = db.Departments.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(),
                            //Convert.ToString(c.Id), 
			                Convert.ToString(c.Name),
                            Convert.ToString(c.ParentId!=null?c.Department2.Name:""),
                            Convert.ToString(c.Office_OfficeId.Title),
                            string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
                            string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);

        }
        // GET: /Department/ModelBindIndex
        public ActionResult ModelBindIndex()
		{
			return View();
		}
		// GET: /Department/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Department ObjDepartment = db.Departments.Find(id);
			if (ObjDepartment == null)
			{
				return HttpNotFound();
			}
			return View(ObjDepartment);
		}
		// GET: /Department/Create
		public ActionResult Create()
		{
			 ViewBag.ParentId = new SelectList(db.Departments, "Id", "Name");
             ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title");

			 return View();
		}

		// POST: /Department/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Create(Department ObjDepartment )
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					

					db.Departments.Add(ObjDepartment);
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "DepartmentController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "Department", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Adding Department is sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "Department - Create",
                                ErrorFrom = "DepartmentController.Create",
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
                    ErrorFor = "Department - Create",
                    ErrorFrom = "DepartmentController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
			return Content(sb.ToString());
			 
		}
		// GET: /Department/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Department ObjDepartment = db.Departments.Find(id);
			if (ObjDepartment == null)
			{
				return HttpNotFound();
			}
			ViewBag.ParentId = new SelectList(db.Departments, "Id", "Name", ObjDepartment.ParentId);
            ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title", ObjDepartment.OfficeId);

			return View(ObjDepartment);
		}

		// POST: /Department/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Edit(Department ObjDepartment )
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					

					db.Entry(ObjDepartment).State = EntityState.Modified;
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "DepartmentController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "Department", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Department is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "Department Edit",
                                ErrorFrom = "DepartmentController.Edit",
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
                    ErrorFor = "Department Edit",
                    ErrorFrom = "DepartmentController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
 
			 
			return Content(sb.ToString());

		}
		// GET: /Department/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Department ObjDepartment = db.Departments.Find(id);
			if (ObjDepartment == null)
			{
				return HttpNotFound();
			}
			return View(ObjDepartment);
		}

		// POST: /Department/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				  
					Department ObjDepartment = db.Departments.Find(id);
					db.Departments.Remove(ObjDepartment);
					db.SaveChanges();

                    Utility.WriteAuditLog(new AuditLog()
                    {
                        ActionFrom = "DepartmentController.Delete",
                        Action = (int)AuditAction.Delete,
                        ModuleName = "Department", // Module name
                        SubModuleName = "Delete", // Sub module name if any
                                                  //UserId = userId, // Id from Current User
                        ActionMessage = "Deleting Department is sucessfull." // Message if any
                    });

                    sb.Append("Sumitted");
					return Content(sb.ToString());
				 
			}
			catch (Exception ex)
			{
				sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "Department Delete",
                    ErrorFrom = "DepartmentController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
			return Content(sb.ToString());
  
		}
		// GET: /Department/MultiViewIndex/5
		public ActionResult MultiViewIndex(int? id)
		{ 
			Department ObjDepartment = db.Departments.Find(id);
			ViewBag.IsWorking = 0;
			if (id > 0)
			{
				ViewBag.IsWorking = id;
				ViewBag.ParentId = new SelectList(db.Departments, "Id", "Name", ObjDepartment.ParentId);
                ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title", ObjDepartment.OfficeId);

			}
			
			return View(ObjDepartment);
		}

		// POST: /Department/MultiViewIndex/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult MultiViewIndex(Department ObjDepartment )
		{  
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					

					db.Entry(ObjDepartment).State = EntityState.Modified;
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "DepartmentController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "Department", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Department is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "Department MultiViewIndex",
                                ErrorFrom = "DepartmentController.MultiViewIndex",
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
                    ErrorFor = "Department MultiViewIndex",
                    ErrorFrom = "DepartmentController.MultiViewIndex",
                    ErrorMessage = "Exception: " + ex.Message
                });
            } 
			 
			return Content(sb.ToString());
 
		}
		 public ActionResult FileManagerGetGrid(int id=0)
		{
			var tak = db.FileManagers.Where(i=>i.DepartmentId==id).ToArray();
			 
			var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.FileExtension),
				Convert.ToString(c.FileSize),
				Convert.ToString(c.FileName),
				Convert.ToString(c.DateAdded),
				Convert.ToString(c.AddedBy),
				Convert.ToString(c.Id),
				Convert.ToString(c.Office_OfficeId.Title),Convert.ToString(c.DepartmentId),
				 };
			return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
		}
		 public ActionResult AnnouncementOrNoteGetGrid(int id=0)
		{
			var tak = db.AnnouncementOrNotes.Where(i=>i.DepartmentId==id).ToArray();
			 
			var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Summary),
				Convert.ToString(c.Title),
				Convert.ToString(c.IsNote),
				Convert.ToString(c.PostedDate),
				Convert.ToString(c.Description),
				Convert.ToString(c.DateAdded),
				Convert.ToString(c.AddedBy),
				Convert.ToString(c.Id),
				Convert.ToString(c.Office_OfficeId.Title),Convert.ToString(c.DepartmentId),
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

