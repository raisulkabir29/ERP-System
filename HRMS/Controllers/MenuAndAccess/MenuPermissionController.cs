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
	public class MenuPermissionController : BaseController
	{ 
		// GET: /MenuPermission/
		public ActionResult Index()
		{
			return View();
		}
		
		// GET MenuPermission/GetGrid
		public ActionResult GetGrid()
		{
			var tak = db.MenuPermissions.ToArray();
			 
			var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
			Convert.ToString(c.Menu_MenuId !=null?c.Menu_MenuId.MenuText:""), 
			Convert.ToString(c.Role_RoleId.RoleName), 
			Convert.ToString(c.User_UserId !=null?c.User_UserId.UserName:""), 
			Convert.ToString(c.SortOrder), 
			Convert.ToString(c.IsCreate), 
			Convert.ToString(c.IsRead), 
			Convert.ToString(c.IsUpdate), 
			Convert.ToString(c.IsDelete), 
			 };
			return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
		}
		// GET: /MenuPermission/ModelBindIndex
		public ActionResult ModelBindIndex()
		{
			return View();
		}
		// GET: /MenuPermission/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			MenuPermission ObjMenuPermission = db.MenuPermissions.Find(id);
			if (ObjMenuPermission == null)
			{
				return HttpNotFound();
			}
			return View(ObjMenuPermission);
		}
		// GET: /MenuPermission/Create
		public ActionResult Create()
		{
			 ViewBag.MenuId = new SelectList(db.Menus, "Id", "MenuText");
			 ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName");
			 ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");

			 return View();
		}

		// POST: /MenuPermission/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Create(MenuPermission ObjMenuPermission )
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					

					db.MenuPermissions.Add(ObjMenuPermission);
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "MenuPermissionController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "MenuPermission", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Assign Menu Permission to user sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "MenuPermission - Create",
                                ErrorFrom = "MenuPermissionController.Create",
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
                    ErrorFor = "MenuPermission - Create",
                    ErrorFrom = "MenuPermissionController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
			return Content(sb.ToString());
			 
		}
		// GET: /MenuPermission/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			MenuPermission ObjMenuPermission = db.MenuPermissions.Find(id);
			if (ObjMenuPermission == null)
			{
				return HttpNotFound();
			}
			ViewBag.MenuId = new SelectList(db.Menus, "Id", "MenuText", ObjMenuPermission.MenuId);
			ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName", ObjMenuPermission.RoleId);
			ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjMenuPermission.UserId);

			return View(ObjMenuPermission);
		}

		// POST: /MenuPermission/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Edit(MenuPermission ObjMenuPermission )
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					

					db.Entry(ObjMenuPermission).State = EntityState.Modified;
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "MenuPermissionController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "MenuPermission", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Menu Permission to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "MenuPermission Edit",
                                ErrorFrom = "MenuPermissionController.Edit",
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
                    ErrorFor = "MenuPermission Edit",
                    ErrorFrom = "MenuPermissionController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
 
			 
			return Content(sb.ToString());

		}
		// GET: /MenuPermission/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			MenuPermission ObjMenuPermission = db.MenuPermissions.Find(id);
			if (ObjMenuPermission == null)
			{
				return HttpNotFound();
			}
			return View(ObjMenuPermission);
		}

		// POST: /MenuPermission/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				  
					MenuPermission ObjMenuPermission = db.MenuPermissions.Find(id);
					db.MenuPermissions.Remove(ObjMenuPermission);
					db.SaveChanges();

                    Utility.WriteAuditLog(new AuditLog()
                    {
                        ActionFrom = "MenuPermissionController.Delete",
                        Action = (int)AuditAction.Delete,
                        ModuleName = "MenuPermission", // Module name
                        SubModuleName = "Delete", // Sub module name if any
                                                  //UserId = userId, // Id from Current User
                        ActionMessage = "Deleting Menu Permission to user is sucessfull." // Message if any
                    });

                    sb.Append("Sumitted");
					return Content(sb.ToString());
				 
			}
			catch (Exception ex)
			{
				sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "MenuPermission Delete",
                    ErrorFrom = "MenuPermissionController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
			return Content(sb.ToString());
  
		}
		// GET: /MenuPermission/MultiViewIndex/5
		public ActionResult MultiViewIndex(int? id)
		{ 
			MenuPermission ObjMenuPermission = db.MenuPermissions.Find(id);
			ViewBag.IsWorking = 0;
			if (id > 0)
			{
				ViewBag.IsWorking = id;
				ViewBag.MenuId = new SelectList(db.Menus, "Id", "MenuText", ObjMenuPermission.MenuId);
				ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName", ObjMenuPermission.RoleId);
				ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjMenuPermission.UserId);

			}
			
			return View(ObjMenuPermission);
		}

		// POST: /MenuPermission/MultiViewIndex/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult MultiViewIndex(MenuPermission ObjMenuPermission )
		{  
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					

					db.Entry(ObjMenuPermission).State = EntityState.Modified;
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "MenuPermissionController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "MenuPermission", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Menu Permission to user is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "MenuPermission MultiViewIndex",
                                ErrorFrom = "MenuPermissionController.MultiViewIndex",
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
                    ErrorFor = "MenuPermission MultiViewIndex",
                    ErrorFrom = "MenuPermissionController.MultiViewIndex",
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

