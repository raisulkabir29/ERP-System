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
    public class ExpenseController : BaseController
    { 
        // GET: /Expense/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET Expense/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.Expenses.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Office_OfficeId.Title), 
            Convert.ToString(c.Title), 
            Convert.ToString(c.PurchaseDate), 
            Convert.ToString(c.Amount), 
            Convert.ToString(c.PurchasedBy), 
            Convert.ToString(c.BillAttachment), 
            Convert.ToString(c.Remarks), 
            Convert.ToString(c.DateAdded), 
            Convert.ToString(c.AddedBy), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /Expense/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /Expense/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense ObjExpense = db.Expenses.Find(id);
            if (ObjExpense == null)
            {
                return HttpNotFound();
            }
            return View(ObjExpense);
        }
        // GET: /Expense/Create
        public ActionResult Create()
        {
             ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title");

             return View();
        }

        // POST: /Expense/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Expense ObjExpense ,HttpPostedFileBase BillAttachment,string HideImage1)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    if (BillAttachment != null) 
                    {
                        var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(BillAttachment, Server.MapPath("~/Uploads"));
                        ModelState.Clear(); 
                        ObjExpense.BillAttachment = fileName; 
                    } 
                    else 
                    { 
                        ObjExpense.BillAttachment = HideImage1;  
                    }


                    db.Expenses.Add(ObjExpense);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "ExpenseController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "Expense", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Adding Expense is sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "Expense - Create",
                                ErrorFrom = "ExpenseController.Create",
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
                    ErrorFor = "Expense - Create",
                    ErrorFrom = "ExpenseController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
            return Content(sb.ToString());
             
        }
        // GET: /Expense/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense ObjExpense = db.Expenses.Find(id);
            if (ObjExpense == null)
            {
                return HttpNotFound();
            }
            ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title", ObjExpense.OfficeId);

            return View(ObjExpense);
        }

        // POST: /Expense/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Expense ObjExpense ,HttpPostedFileBase BillAttachment,string HideImage1)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    if (BillAttachment != null) 
                    {
                        var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(BillAttachment, Server.MapPath("~/Uploads"));
                        ModelState.Clear(); 
                        ObjExpense.BillAttachment = fileName; 
                    } 
                    else 
                    { 
                        ObjExpense.BillAttachment = HideImage1;  
                    }


                    db.Entry(ObjExpense).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "ExpenseController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "Expense", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Expense is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "Expense Edit",
                                ErrorFrom = "ExpenseController.Edit",
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
                    ErrorFor = "Expense Edit",
                    ErrorFrom = "ExpenseController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
 
             
            return Content(sb.ToString());

        }
        // GET: /Expense/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense ObjExpense = db.Expenses.Find(id);
            if (ObjExpense == null)
            {
                return HttpNotFound();
            }
            return View(ObjExpense);
        }

        // POST: /Expense/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    Expense ObjExpense = db.Expenses.Find(id);
                    db.Expenses.Remove(ObjExpense);
                    db.SaveChanges();

                    Utility.WriteAuditLog(new AuditLog()
                    {
                        ActionFrom = "ExpenseController.Delete",
                        Action = (int)AuditAction.Delete,
                        ModuleName = "Expense", // Module name
                        SubModuleName = "Delete", // Sub module name if any
                                                  //UserId = userId, // Id from Current User
                        ActionMessage = "Deleting Expense is sucessfull." // Message if any
                    });

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                 
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "Expense Delete",
                    ErrorFrom = "ExpenseController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
            return Content(sb.ToString());
  
        }
        // GET: /Expense/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            Expense ObjExpense = db.Expenses.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title", ObjExpense.OfficeId);

            }
            
            return View(ObjExpense);
        }

        // POST: /Expense/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(Expense ObjExpense ,HttpPostedFileBase BillAttachment,string HideImage1)
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    if (BillAttachment != null) 
                    {
                        var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(BillAttachment, Server.MapPath("~/Uploads"));
                        ModelState.Clear(); 
                        ObjExpense.BillAttachment = fileName; 
                    } 
                    else 
                    { 
                        ObjExpense.BillAttachment = HideImage1;  
                    }


                    db.Entry(ObjExpense).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "ExpenseController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "Expense", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Expense is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "Expense MultiViewIndex",
                                ErrorFrom = "ExpenseController.MultiViewIndex",
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
                    ErrorFor = "Expense MultiViewIndex",
                    ErrorFrom = "ExpenseController.MultiViewIndex",
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

