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

namespace HRMS.Controllers
{
	public class UserEducationController : BaseController
	{ 
		// GET: /UserEducation/
		public ActionResult Index()
		{
			return View();
		}
		
		// GET UserEducation/GetGrid
		public ActionResult GetGrid()
		{
			var tak = db.UserEducations.ToArray();
			 
			var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id),
                Convert.ToString(c.University_InstitutionId.Name),
                Convert.ToString(c.Qualification_Digree !=null?c.Qualification_Digree.Name:""),
                Convert.ToString(c.FromDate), 
			    Convert.ToString(c.ToDate), 
			    Convert.ToString(c.User_UserId.UserName), 
			    Convert.ToString(c.TotalMarks), 
			    Convert.ToString(c.OutOfMarks), 
			    Convert.ToString(c.Percentage+"%"), 
                Convert.ToString(c.InstitutionName),
				Convert.ToString(c.LatestDegree),
				Convert.ToString(c.DivisionOrGrade),
			 };
			return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
		}
		// GET: /UserEducation/ModelBindIndex
		public ActionResult ModelBindIndex()
		{
			return View();
		}
		// GET: /UserEducation/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			UserEducation ObjUserEducation = db.UserEducations.Find(id);
			if (ObjUserEducation == null)
			{
				return HttpNotFound();
			}
			return View(ObjUserEducation);
		}
		// GET: /UserEducation/Create
		public ActionResult Create()
		{
			 ViewBag.InstitutionId = new SelectList(db.Universitys, "Id", "Name");
            ViewBag.Digree = new SelectList(db.Qualifications, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");

			 return View();
		}

		// POST: /UserEducation/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Create(UserEducation ObjUserEducation )
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				double? decimalpercent=(ObjUserEducation.TotalMarks/ObjUserEducation.OutOfMarks);
				ObjUserEducation.Percentage = decimalpercent * 100;
				if (ModelState.IsValid)
				{ 
					

					db.UserEducations.Add(ObjUserEducation);
					db.SaveChanges();

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
						}
					}
				}
			}
			catch (Exception ex)
			{
				sb.Append("Error :" + ex.Message);
			}
  
			return Content(sb.ToString());
			 
		}
		// GET: /UserEducation/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			UserEducation ObjUserEducation = db.UserEducations.Find(id);
			if (ObjUserEducation == null)
			{
				return HttpNotFound();
			}
			ViewBag.InstitutionId = new SelectList(db.Universitys, "Id", "Name", ObjUserEducation.InstitutionId);
ViewBag.Digree = new SelectList(db.Qualifications, "Id", "Name", ObjUserEducation.Digree);
ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserEducation.UserId);

			return View(ObjUserEducation);
		}

		// POST: /UserEducation/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Edit(UserEducation ObjUserEducation )
		{
			double? decimalpercent = (ObjUserEducation.TotalMarks / ObjUserEducation.OutOfMarks);
			ObjUserEducation.Percentage = decimalpercent * 100;
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					

					db.Entry(ObjUserEducation).State = EntityState.Modified;
					db.SaveChanges();

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
						}
					}
				}
			}
			catch (Exception ex)
			{
				sb.Append("Error :" + ex.Message);
			}
 
			 
			return Content(sb.ToString());

		}
		// GET: /UserEducation/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			UserEducation ObjUserEducation = db.UserEducations.Find(id);
			if (ObjUserEducation == null)
			{
				return HttpNotFound();
			}
			return View(ObjUserEducation);
		}

		// POST: /UserEducation/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				  
					UserEducation ObjUserEducation = db.UserEducations.Find(id);
					db.UserEducations.Remove(ObjUserEducation);
					db.SaveChanges();

					sb.Append("Sumitted");
					return Content(sb.ToString());
				 
			}
			catch (Exception ex)
			{
				sb.Append("Error :" + ex.Message);
			}
  
			return Content(sb.ToString());
  
		}
		// GET: /UserEducation/MultiViewIndex/5
		public ActionResult MultiViewIndex(int? id)
		{ 
			UserEducation ObjUserEducation = db.UserEducations.Find(id);
			ViewBag.IsWorking = 0;
			if (id > 0)
			{
				ViewBag.IsWorking = id;
				ViewBag.InstitutionId = new SelectList(db.Universitys, "Id", "Name", ObjUserEducation.InstitutionId);
ViewBag.Digree = new SelectList(db.Qualifications, "Id", "Name", ObjUserEducation.Digree);
ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserEducation.UserId);

			}
			
			return View(ObjUserEducation);
		}

		// POST: /UserEducation/MultiViewIndex/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult MultiViewIndex(UserEducation ObjUserEducation )
		{
			double? decimalpercent = (ObjUserEducation.TotalMarks / ObjUserEducation.OutOfMarks);
			ObjUserEducation.Percentage = decimalpercent * 100;
			System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
			try
			{
				if (ModelState.IsValid)
				{ 
					

					db.Entry(ObjUserEducation).State = EntityState.Modified;
					db.SaveChanges();

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
						}
					}
				}
			}
			catch (Exception ex)
			{
				sb.Append("Error :" + ex.Message);
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

