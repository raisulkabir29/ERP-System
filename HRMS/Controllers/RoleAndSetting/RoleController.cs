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
	public class RoleController : BaseController
	{ 
		// GET: /Role/
		public ActionResult Index()
		{
			return View();
		}
		
		// GET Role/GetGrid
		public ActionResult GetGrid()
		{
			var tak = db.Roles.ToArray();
			 
			var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
			Convert.ToString(c.RoleName), 
			Convert.ToString(c.IsActive), 
			 };
			return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
		}
		// GET: /Role/ModelBindIndex
		public ActionResult ModelBindIndex()
		{
			return View();
		}
		// GET: /Role/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Role ObjRole = db.Roles.Find(id);
			if (ObjRole == null)
			{
				return HttpNotFound();
			}
			return View(ObjRole);
		}
		// GET: /Role/Create
		public ActionResult Create()
		{
			 
			 return View();
		}

		// POST: /Role/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Create(Role ObjRole )
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					

					db.Roles.Add(ObjRole);
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "RoleController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "Role", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Assign Role to user sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "Role - Create",
                                ErrorFrom = "RoleController.Create",
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
                    ErrorFor = "Role - Create",
                    ErrorFrom = "RoleController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
			return Content(sb.ToString());
			 
		}
		// GET: /Role/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Role ObjRole = db.Roles.Find(id);
			if (ObjRole == null)
			{
				return HttpNotFound();
			}
			
			return View(ObjRole);
		}

		// POST: /Role/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Edit(Role ObjRole )
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					

					db.Entry(ObjRole).State = EntityState.Modified;
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "RoleController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "Role", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Role to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "Role Edit",
                                ErrorFrom = "RoleController.Edit",
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
                    ErrorFor = "Role Edit",
                    ErrorFrom = "RoleController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
 
			 
			return Content(sb.ToString());

		}
		// GET: /Role/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Role ObjRole = db.Roles.Find(id);
			if (ObjRole == null)
			{
				return HttpNotFound();
			}
			return View(ObjRole);
		}

		// POST: /Role/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				  
					Role ObjRole = db.Roles.Find(id);
					db.Roles.Remove(ObjRole);
					db.SaveChanges();

                    Utility.WriteAuditLog(new AuditLog()
                    {
                        ActionFrom = "RoleController.Delete",
                        Action = (int)AuditAction.Delete,
                        ModuleName = "Role", // Module name
                        SubModuleName = "Delete", // Sub module name if any
                                                  //UserId = userId, // Id from Current User
                        ActionMessage = "Delete Role to user sucessfull." // Message if any
                    });

                    sb.Append("Sumitted");
					return Content(sb.ToString());
				 
			}
			catch (Exception ex)
			{
				sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "Role Delete",
                    ErrorFrom = "RoleController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
			return Content(sb.ToString());
  
		}
		// GET: /Role/MultiViewIndex/5
		public ActionResult MultiViewIndex(int? id)
		{ 
			Role ObjRole = db.Roles.Find(id);
			ViewBag.IsWorking = 0;
			if (id > 0)
			{
				ViewBag.IsWorking = id;
				
			}
			
			return View(ObjRole);
		}

		// POST: /Role/MultiViewIndex/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult MultiViewIndex(Role ObjRole )
		{  
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					

					db.Entry(ObjRole).State = EntityState.Modified;
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "RoleController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "Role", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Role to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "Role MultiViewIndex",
                                ErrorFrom = "RoleController.MultiViewIndex",
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
                    ErrorFor = "Role MultiViewIndex",
                    ErrorFrom = "RoleController.MultiViewIndex",
                    ErrorMessage = "Exception: " + ex.Message
                });
            } 
			 
			return Content(sb.ToString());
 
		}
		 public ActionResult MenuPermissionGetGrid(int id=0)
		{
			var tak = db.MenuPermissions.Where(i=>i.RoleId==id).ToArray();
			 
			var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.IsCreate),
				Convert.ToString(c.IsRead),
				Convert.ToString(c.IsUpdate),
				Convert.ToString(c.IsDelete),
				Convert.ToString(c.Id),
				Convert.ToString(c.SortOrder),
				Convert.ToString(c.RoleId),
				Convert.ToString(c.User_UserId.UserName),Convert.ToString(c.Menu_MenuId.MenuText), };
			return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
		}
		 public ActionResult RoleUserGetGrid(int id=0)
		{
			var tak = db.RoleUsers.Where(i=>i.RoleId==id).ToArray();
			 
			var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
				Convert.ToString(c.RoleId),
				Convert.ToString(c.User_UserId.UserName), };
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

