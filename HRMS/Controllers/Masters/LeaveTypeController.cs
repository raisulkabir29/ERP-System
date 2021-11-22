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
	public class LeaveTypeController : BaseController
	{ 
		// GET: /LeaveType/
		public ActionResult Index()
		{
			return View();
		}

        // GET LeaveType/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.LeaveTypes.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(),
                //Convert.ToString(c.Id), 
				Convert.ToString(c.Name),
                Convert.ToString(c.Description),
                Convert.ToString(c.NoOfLeavesPerYear),
                string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
                string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /LeaveType/ModelBindIndex
        public ActionResult ModelBindIndex()
		{
			return View();
		}
		// GET: /LeaveType/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			LeaveType ObjLeaveType = db.LeaveTypes.Find(id);
			if (ObjLeaveType == null)
			{
				return HttpNotFound();
			}
			return View(ObjLeaveType);
		}
		// GET: /LeaveType/Create
		public ActionResult Create()
		{
			 
			 return View();
		}

		// POST: /LeaveType/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Create(LeaveType ObjLeaveType )
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					

					db.LeaveTypes.Add(ObjLeaveType);
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "LeaveTypeController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "LeaveType", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Adding Leave Type is sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "LeaveType - Create",
                                ErrorFrom = "LeaveTypeController.Create",
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
                    ErrorFor = "LeaveType - Create",
                    ErrorFrom = "LeaveTypeController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
			return Content(sb.ToString());
			 
		}
		// GET: /LeaveType/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			LeaveType ObjLeaveType = db.LeaveTypes.Find(id);
			if (ObjLeaveType == null)
			{
				return HttpNotFound();
			}
			
			return View(ObjLeaveType);
		}

		// POST: /LeaveType/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Edit(LeaveType ObjLeaveType )
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					

					db.Entry(ObjLeaveType).State = EntityState.Modified;
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "LeaveTypeController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "LeaveType", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Leave Type is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "LeaveType Edit",
                                ErrorFrom = "LeaveTypeController.Edit",
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
                    ErrorFor = "LeaveType Edit",
                    ErrorFrom = "LeaveTypeController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
 
			 
			return Content(sb.ToString());

		}
		// GET: /LeaveType/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			LeaveType ObjLeaveType = db.LeaveTypes.Find(id);
			if (ObjLeaveType == null)
			{
				return HttpNotFound();
			}
			return View(ObjLeaveType);
		}

		// POST: /LeaveType/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				  
					LeaveType ObjLeaveType = db.LeaveTypes.Find(id);
					db.LeaveTypes.Remove(ObjLeaveType);
					db.SaveChanges();

                    Utility.WriteAuditLog(new AuditLog()
                    {
                        ActionFrom = "LeaveTypeController.Delete",
                        Action = (int)AuditAction.Delete,
                        ModuleName = "LeaveType", // Module name
                        SubModuleName = "Delete", // Sub module name if any
                                                  //UserId = userId, // Id from Current User
                        ActionMessage = "Deleting Leave Type is sucessfull." // Message if any
                    });

                    sb.Append("Sumitted");
					return Content(sb.ToString());
				 
			}
			catch (Exception ex)
			{
				sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "LeaveType Delete",
                    ErrorFrom = "LeaveTypeController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
			return Content(sb.ToString());
  
		}
		// GET: /LeaveType/MultiViewIndex/5
		public ActionResult MultiViewIndex(int? id)
		{ 
			LeaveType ObjLeaveType = db.LeaveTypes.Find(id);
			ViewBag.IsWorking = 0;
			if (id > 0)
			{
				ViewBag.IsWorking = id;
				
			}
			
			return View(ObjLeaveType);
		}

		// POST: /LeaveType/MultiViewIndex/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult MultiViewIndex(LeaveType ObjLeaveType )
		{  
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					

					db.Entry(ObjLeaveType).State = EntityState.Modified;
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "LeaveTypeController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "LeaveType", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Leave Type is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "LeaveType MultiViewIndex",
                                ErrorFrom = "LeaveTypeController.MultiViewIndex",
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
                    ErrorFor = "LeaveType MultiViewIndex",
                    ErrorFrom = "LeaveTypeController.MultiViewIndex",
                    ErrorMessage = "Exception: " + ex.Message
                });
            } 
			 
			return Content(sb.ToString());
 
		}
		 public ActionResult UserLeaveApplicationGetGrid(int id=0)
		{
			var tak = db.UserLeaveApplications.Where(i=>i.LeaveTypeId==id).ToArray();
			 
			var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.IsApproved),
				Convert.ToString(c.LeaveActiveFrom),
				Convert.ToString(c.LeaveActiveTo),
				Convert.ToString(c.DateAdded),
				Convert.ToString(c.Id),
				Convert.ToString(c.ApprovedBy),
				Convert.ToString(c.User_UserId.UserName),Convert.ToString(c.LeaveTypeId),
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

