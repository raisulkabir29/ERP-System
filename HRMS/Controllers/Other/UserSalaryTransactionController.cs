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
	public class UserSalaryTransactionController : BaseController
	{
		// GET: /UserSalaryTransaction/
		public ActionResult Index()
		{
			return View();
		}

		// GET UserSalaryTransaction/GetGrid
		public ActionResult GetGrid()
		{
			var tak = db.UserSalaryTransactions.ToArray();

			var result = from c in tak
                         //where c.Month == "Nov"
						 select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
				Convert.ToString(c.User_UserId.UserName), 
				Convert.ToString(c.HouseRentAllowance), 
				Convert.ToString(c.MedicalAllowance), 
				Convert.ToString(c.TravellingAllowance), 
				Convert.ToString(c.DearnessAllowance), 
				Convert.ToString(c.Basic), 
				Convert.ToString(c.SpecialAllowance), 
				Convert.ToString(c.Bonus), 
				Convert.ToString(c.ProvidentFund), 
				Convert.ToString(c.ProfessionalTax), 
				Convert.ToString(c.LunchRecovery), 
				Convert.ToString(c.TransportRecovery), 
				Convert.ToString(c.IncomeTax), 
				Convert.ToString(c.TotalAmount), 
				Convert.ToString(c.TotalDeduction), 
				Convert.ToString(c.NetAmount), 
				Convert.ToString(c.OnDate), 
				Convert.ToString(c.Remarks), 
				Convert.ToString(c.DateAdded), 
				Convert.ToString(c.AddedBy), 
				Convert.ToString(c.OTNOT),
				Convert.ToString(c.ConveyanceAllowance),
				Convert.ToString(c.FoodAllowance),
				Convert.ToString(c.PerformanceAllowance),
				Convert.ToString(c.AttendanceBonus),
				Convert.ToString(c.Stamp),
				Convert.ToString(c.Gross),
                Convert.ToString(c.Year),
				Convert.ToString(c.Month),
			 };
			return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
		}
		// GET: /UserSalaryTransaction/ModelBindIndex
		public ActionResult ModelBindIndex()
		{
			return View();
		}
		// GET: /UserSalaryTransaction/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			UserSalaryTransaction ObjUserSalaryTransaction = db.UserSalaryTransactions.Find(id);
			if (ObjUserSalaryTransaction == null)
			{
				return HttpNotFound();
			}
			return View(ObjUserSalaryTransaction);
		}
		// GET: /UserSalaryTransaction/Create
		public ActionResult Create()
		{
			ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");

			return View();
		}

		// POST: /UserSalaryTransaction/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Create(UserSalaryTransaction ObjUserSalaryTransaction)
		{System.Text.StringBuilder sb = new System.Text.StringBuilder();
			try
			{
				if (ModelState.IsValid)
				{
					ObjUserSalaryTransaction = calculateSalary(ObjUserSalaryTransaction);
					db.UserSalaryTransactions.Add(ObjUserSalaryTransaction);
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserSalaryTransactionController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "UserSalaryTransaction", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Add Salary Transaction to user sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "UserSalaryTransaction - Create",
                                ErrorFrom = "UserSalaryTransactionController.Create",
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
                    ErrorFor = "UserSalaryTransaction - Create",
                    ErrorFrom = "UserSalaryTransactionController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

			return Content(sb.ToString());

		}
		// GET: /UserSalaryTransaction/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			UserSalaryTransaction ObjUserSalaryTransaction = db.UserSalaryTransactions.Find(id);
			if (ObjUserSalaryTransaction == null)
			{
				return HttpNotFound();
			}
			ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserSalaryTransaction.UserId);

			return View(ObjUserSalaryTransaction);
		}

		// POST: /UserSalaryTransaction/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Edit(UserSalaryTransaction ObjUserSalaryTransaction)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			try
			{
				if (ModelState.IsValid)
				{

					ObjUserSalaryTransaction = calculateSalary(ObjUserSalaryTransaction);
					db.Entry(ObjUserSalaryTransaction).State = EntityState.Modified;
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserSalaryTransactionController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserSalaryTransaction", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Salary Transaction to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserSalaryTransaction Edit",
                                ErrorFrom = "UserSalaryTransactionController.Edit",
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
                    ErrorFor = "UserSalaryTransaction Edit",
                    ErrorFrom = "UserSalaryTransactionController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }


			return Content(sb.ToString());

		}
		// GET: /UserSalaryTransaction/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			UserSalaryTransaction ObjUserSalaryTransaction = db.UserSalaryTransactions.Find(id);
			if (ObjUserSalaryTransaction == null)
			{
				return HttpNotFound();
			}
			return View(ObjUserSalaryTransaction);
		}

		// POST: /UserSalaryTransaction/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			try
			{

				UserSalaryTransaction ObjUserSalaryTransaction = db.UserSalaryTransactions.Find(id);
				db.UserSalaryTransactions.Remove(ObjUserSalaryTransaction);
				db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "UserSalaryTransactionController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "UserSalaryTransaction", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Delete Salary Transaction to user sucessfull." // Message if any
                });

                sb.Append("Sumitted");
				return Content(sb.ToString());

			}
			catch (Exception ex)
			{
				sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "UserSalaryTransaction Delete",
                    ErrorFrom = "UserSalaryTransactionController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

			return Content(sb.ToString());

		}
		// GET: /UserSalaryTransaction/MultiViewIndex/5
		public ActionResult MultiViewIndex(int? id)
		{
			UserSalaryTransaction ObjUserSalaryTransaction = db.UserSalaryTransactions.Find(id);
			ViewBag.IsWorking = 0;
			if (id > 0)
			{
				ViewBag.IsWorking = id;
				ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserSalaryTransaction.UserId);

			}

			return View(ObjUserSalaryTransaction);
		}

		// POST: /UserSalaryTransaction/MultiViewIndex/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult MultiViewIndex(UserSalaryTransaction ObjUserSalaryTransaction)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			try
			{
				if (ModelState.IsValid)
				{


					db.Entry(ObjUserSalaryTransaction).State = EntityState.Modified;
					db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserSalaryTransactionController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserSalaryTransaction", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Salary Transaction to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserSalaryTransaction MultiViewIndex",
                                ErrorFrom = "UserSalaryTransactionController.MultiViewIndex",
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
                    ErrorFor = "UserSalaryTransaction MultiViewIndex",
                    ErrorFrom = "UserSalaryTransactionController.MultiViewIndex",
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
		public UserSalaryTransaction calculateSalary(UserSalaryTransaction ObjUserSalaryTransaction)
		{
			ObjUserSalaryTransaction.DearnessAllowance = Convert.ToDecimal(ObjUserSalaryTransaction.DearnessAllowance);
			ObjUserSalaryTransaction.HouseRentAllowance = Convert.ToDecimal(ObjUserSalaryTransaction.HouseRentAllowance);
			ObjUserSalaryTransaction.MedicalAllowance = Convert.ToDecimal(ObjUserSalaryTransaction.MedicalAllowance);
			ObjUserSalaryTransaction.TravellingAllowance = Convert.ToDecimal(ObjUserSalaryTransaction.TravellingAllowance);
			ObjUserSalaryTransaction.Basic = Convert.ToDecimal(ObjUserSalaryTransaction.Basic);
			ObjUserSalaryTransaction.SpecialAllowance = Convert.ToDecimal(ObjUserSalaryTransaction.SpecialAllowance);
			ObjUserSalaryTransaction.Bonus = Convert.ToDecimal(ObjUserSalaryTransaction.Bonus);
			ObjUserSalaryTransaction.ProvidentFund = Convert.ToDecimal(ObjUserSalaryTransaction.ProvidentFund);
			ObjUserSalaryTransaction.LunchRecovery = Convert.ToDecimal(ObjUserSalaryTransaction.LunchRecovery);
			ObjUserSalaryTransaction.TransportRecovery = Convert.ToDecimal(ObjUserSalaryTransaction.TransportRecovery);
			decimal? professionaltax = Convert.ToDecimal((ObjUserSalaryTransaction.ProfessionalTax / 100));
			professionaltax = professionaltax * ObjUserSalaryTransaction.Basic;
			decimal? incometax = Convert.ToDecimal((ObjUserSalaryTransaction.IncomeTax / 100));
			incometax = incometax * ObjUserSalaryTransaction.Basic;
			decimal totalAmount = (ObjUserSalaryTransaction.HouseRentAllowance.Value + ObjUserSalaryTransaction.MedicalAllowance.Value + ObjUserSalaryTransaction.SpecialAllowance.Value + ObjUserSalaryTransaction.TravellingAllowance.Value + ObjUserSalaryTransaction.Basic.Value + ObjUserSalaryTransaction.Bonus.Value + ObjUserSalaryTransaction.DearnessAllowance.Value);
			decimal? totalDeduction = (ObjUserSalaryTransaction.ProvidentFund.Value + ObjUserSalaryTransaction.LunchRecovery.Value + ObjUserSalaryTransaction.TransportRecovery.Value + incometax + professionaltax);
			ObjUserSalaryTransaction.TotalAmount = totalAmount;
			ObjUserSalaryTransaction.TotalDeduction = totalDeduction.Value;
			ObjUserSalaryTransaction.NetAmount = totalAmount - totalDeduction.Value;
			return ObjUserSalaryTransaction;
		}
	}
}

