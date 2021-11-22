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
	public class CompanyController : BaseController
	{ 
		// GET: /Company/
		public ActionResult Index()
		{
			return View();
		}

        // GET Company/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.Companys.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(),
                            //Convert.ToString(c.Id), 
			                Convert.ToString(c.Name),
                            Convert.ToString(c.About),
                            Convert.ToString(c.IsActive),
                            Convert.ToString(c.Website),
                            Convert.ToString(c.Phone),
                            Convert.ToString(c.Fax),
                            //Convert.ToString(c.MapLatitude),
                            //Convert.ToString(c.MapLongitude),
                            Convert.ToString(c.TaxNumberOrEIN),
                            Convert.ToString(c.Logo),
                            Convert.ToString(c.Address),
                            string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
                            string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),

             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /Company/ModelBindIndex
        public ActionResult ModelBindIndex()
		{
			return View();
		}
		// GET: /Company/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Company ObjCompany = db.Companys.Find(id);
			if (ObjCompany == null)
			{
				return HttpNotFound();
			}
			return View(ObjCompany);
		}
		// GET: /Company/Create
		public ActionResult Create()
		{
			 
			 return View();
		}

		// POST: /Company/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Create(Company ObjCompany ,HttpPostedFileBase Logo,string HideImage1)
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					if (Logo != null) 
					{
						var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(Logo, Server.MapPath("~/Uploads"));
						ModelState.Clear(); 
						ObjCompany.Logo = fileName; 
					} 
					else 
					{ 
						ObjCompany.Logo = HideImage1;  
					}


					db.Companys.Add(ObjCompany);
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "CompanyController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "Company", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Adding Company is sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "Company - Create",
                                ErrorFrom = "CompanyController.Create",
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
                    ErrorFor = "Company - Create",
                    ErrorFrom = "CompanyController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
			return Content(sb.ToString());
			 
		}
		// GET: /Company/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Company ObjCompany = db.Companys.Find(id);
			if (ObjCompany == null)
			{
				return HttpNotFound();
			}
			
			return View(ObjCompany);
		}

		// POST: /Company/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Edit(Company ObjCompany ,HttpPostedFileBase Logo,string HideImage1)
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					if (Logo != null) 
					{
						var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(Logo, Server.MapPath("~/Uploads"));
						ModelState.Clear(); 
						ObjCompany.Logo = fileName; 
					} 
					else 
					{ 
						ObjCompany.Logo = HideImage1;  
					}


					db.Entry(ObjCompany).State = EntityState.Modified;
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "CompanyController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "Company", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Company is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "Company Edit",
                                ErrorFrom = "CompanyController.Edit",
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
                    ErrorFor = "Company Edit",
                    ErrorFrom = "CompanyController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
 
			 
			return Content(sb.ToString());

		}
		// GET: /Company/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Company ObjCompany = db.Companys.Find(id);
			if (ObjCompany == null)
			{
				return HttpNotFound();
			}
			return View(ObjCompany);
		}

		// POST: /Company/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				  
					Company ObjCompany = db.Companys.Find(id);
					db.Companys.Remove(ObjCompany);
					db.SaveChanges();

                    Utility.WriteAuditLog(new AuditLog()
                    {
                        ActionFrom = "CompanyController.Delete",
                        Action = (int)AuditAction.Delete,
                        ModuleName = "Company", // Module name
                        SubModuleName = "Delete", // Sub module name if any
                                                  //UserId = userId, // Id from Current User
                        ActionMessage = "Deleting Company is sucessfull." // Message if any
                    });

                    sb.Append("Sumitted");
					return Content(sb.ToString());
				 
			}
			catch (Exception ex)
			{
				sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "Company Delete",
                    ErrorFrom = "CompanyController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
			return Content(sb.ToString());
  
		}
		// GET: /Company/MultiViewIndex/5
		public ActionResult MultiViewIndex(int? id)
		{ 
			Company ObjCompany = db.Companys.Find(id);
			ViewBag.IsWorking = 0;
			if (id > 0)
			{
				ViewBag.IsWorking = id;
				
			}
			
			return View(ObjCompany);
		}

		// POST: /Company/MultiViewIndex/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult MultiViewIndex(Company ObjCompany ,HttpPostedFileBase Logo,string HideImage1)
		{  
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					if (Logo != null) 
					{
						var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(Logo, Server.MapPath("~/Uploads"));
						ModelState.Clear(); 
						ObjCompany.Logo = fileName; 
					} 
					else 
					{ 
						ObjCompany.Logo = HideImage1;  
					}


					db.Entry(ObjCompany).State = EntityState.Modified;
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "CompanyController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "Company", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Company is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "Company MultiViewIndex",
                                ErrorFrom = "CompanyController.MultiViewIndex",
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
                    ErrorFor = "Company MultiViewIndex",
                    ErrorFrom = "CompanyController.MultiViewIndex",
                    ErrorMessage = "Exception: " + ex.Message
                });
            } 
			 
			return Content(sb.ToString());
 
		}
		 public ActionResult OfficeGetGrid(int id=0)
		{
			var tak = db.Offices.Where(i=>i.CompanyId==id).ToArray();
			 
			var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Country),
				Convert.ToString(c.City),
				Convert.ToString(c.ZipCode),
				Convert.ToString(c.MapLatitude),
				Convert.ToString(c.MapLongitude),
				Convert.ToString(c.Details),
				Convert.ToString(c.Fax),
				Convert.ToString(c.Title),
				Convert.ToString(c.Code),
				Convert.ToString(c.CreatedOn),
				Convert.ToString(c.Id),
				Convert.ToString(c.CompanyId),
				Convert.ToString(c.OfficeType_OfficeTypeId.Name), };
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

