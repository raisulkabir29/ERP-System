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
	public class DepartmentUserController : BaseController
	{

		// GET: /DepartmentUser/
		public ActionResult Index()
		{
			return View();
		}

        // GET /DepartmentUser/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.DepartmentUsers.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(),
            //Convert.ToString(c.Id), 
			Convert.ToString(c.Department_DepartmentId.Name),
            Convert.ToString(c.User_UserId.UserName),
            string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
            string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }

        // GET: /DepartmentUser/ModelBindIndex
        public ActionResult ModelBindIndex()
		{
			return View();
		}

		// GET: /DepartmentUser/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			DepartmentUser ObjDepartmentUser = db.DepartmentUsers.Find(id);
			if (ObjDepartmentUser == null)
			{
				return HttpNotFound();
			}
			return View(ObjDepartmentUser);
		}

		// GET: /DepartmentUser/Create
		public ActionResult Create()
		{
			ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
			ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");

			return View();
		}

		// POST: /DepartmentUser/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Create(DepartmentUser ObjDepartmentUser)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			try
			{
				if (ModelState.IsValid)
				{
					db.DepartmentUsers.Add(ObjDepartmentUser);
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "DepartmentUserController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "DepartmentUser", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Assign Department to user sucessfull for field - " + key + " - " + currentKeyValue // Message if any
                        });

                    }

                    //Utility.WriteAuditLog(new AuditLog()
                    //{
                    //    ActionFrom = "DepartmentUserController.Create",
                    //    Action = (int)AuditAction.Create,
                    //    ModuleName = "DepartmentUser", // Module name
                    //    SubModuleName = "Create", // Sub module name if any
                    //    //UserId = userId, // Id from Current User
                    //    ActionMessage = "Assign Department to user sucessfull." // Message if any
                    //});

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
                                ErrorFor = "DepartmentUser - Create",
                                ErrorFrom = "DepartmentUserController.Create",
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
                    ErrorFor = "DepartmentUser - Create",
                    ErrorFrom = "DepartmentUserController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

			return Content(sb.ToString());

		}

		// GET: /DepartmentUser/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			DepartmentUser ObjDepartmentUser = db.DepartmentUsers.Find(id);
			if (ObjDepartmentUser == null)
			{
				return HttpNotFound();
			}
			ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", ObjDepartmentUser.DepartmentId);
			ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjDepartmentUser.UserId);

			return View(ObjDepartmentUser);
		}

		// POST: /DepartmentUser/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Edit(DepartmentUser ObjDepartmentUser)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			try
			{
				if (ModelState.IsValid)
				{
					db.Entry(ObjDepartmentUser).State = EntityState.Modified;
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "DepartmentUserController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "DepartmentUser", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Department to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
                        });

                    }

                    //Utility.WriteAuditLog(new AuditLog()
                    //{
                    //    ActionFrom = "DepartmentUserController.Edit",
                    //    Action = (int)AuditAction.Edit,
                    //    ModuleName = "DepartmentUser", // Module name
                    //    SubModuleName = "Edit", // Sub module name if any
                    //                            //UserId = userId, // Id from Current User
                    //    ActionMessage = "Edit Department to user sucessfull." // Message if any
                    //});

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
                                ErrorFor = "DepartmentUser Edit",
                                ErrorFrom = "DepartmentUserController.Edit",
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
                    ErrorFor = "DepartmentUser Edit",
                    ErrorFrom = "DepartmentUserController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }


			return Content(sb.ToString());

		}

		// GET: /DepartmentUser/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			DepartmentUser ObjDepartmentUser = db.DepartmentUsers.Find(id);
			if (ObjDepartmentUser == null)
			{
				return HttpNotFound();
			}
			return View(ObjDepartmentUser);
		}

		// POST: /DepartmentUser/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			try
			{

				DepartmentUser ObjDepartmentUser = db.DepartmentUsers.Find(id);
				db.DepartmentUsers.Remove(ObjDepartmentUser);
				db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "DepartmentUserController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "DepartmentUser", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Delete Department to user sucessfull." // Message if any
                });

                sb.Append("Sumitted");
				return Content(sb.ToString());

			}
			catch (Exception ex)
			{
				sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "DepartmentUser Delete",
                    ErrorFrom = "DepartmentUserController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

			return Content(sb.ToString());

		}

		// GET: /DepartmentUser/MultiViewIndex/5
		public ActionResult MultiViewIndex(int? id)
		{
			DepartmentUser ObjDepartmentUser = db.DepartmentUsers.Find(id);
			ViewBag.IsWorking = 0;
			if (id > 0)
			{
				ViewBag.IsWorking = id;
				ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", ObjDepartmentUser.DepartmentId);
				ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjDepartmentUser.UserId);

			}

			return View(ObjDepartmentUser);
		}

		// POST: /DepartmentUser/MultiViewIndex/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult MultiViewIndex(DepartmentUser ObjDepartmentUser)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			try
			{
				if (ModelState.IsValid)
				{
					db.Entry(ObjDepartmentUser).State = EntityState.Modified;
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "DepartmentUserController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "DepartmentUser", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Department to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
                        });

                    }

                    //Utility.WriteAuditLog(new AuditLog()
                    //{
                    //    ActionFrom = "DepartmentUserController.MultiViewIndex",
                    //    Action = (int)AuditAction.Edit,
                    //    ModuleName = "DepartmentUser", // Module name
                    //    SubModuleName = "MultiViewIndex", // Sub module name if any
                    //                                      // UserId = userId, // Id from Current User
                    //    ActionMessage = "Edit Department to user sucessfull." // Message if any
                    //});

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
                                ErrorFor = "DepartmentUser MultiViewIndex",
                                ErrorFrom = "DepartmentUserController.MultiViewIndex",
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
                    ErrorFor = "DepartmentUser MultiViewIndex",
                    ErrorFrom = "DepartmentUserController.MultiViewIndex",
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
