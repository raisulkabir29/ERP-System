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
    public class LanguageController : BaseController
    { 
        // GET: /Language/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET Language/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.Languages.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Name), 
            Convert.ToString(c.Code), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /Language/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /Language/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Language ObjLanguage = db.Languages.Find(id);
            if (ObjLanguage == null)
            {
                return HttpNotFound();
            }
            return View(ObjLanguage);
        }
        // GET: /Language/Create
        public ActionResult Create()
        {
             
             return View();
        }

        // POST: /Language/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Language ObjLanguage )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Languages.Add(ObjLanguage);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "LanguageController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "Language", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Assign Language to user sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "Language - Create",
                                ErrorFrom = "LanguageController.Create",
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
                    ErrorFor = "Language - Create",
                    ErrorFrom = "LanguageController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
            return Content(sb.ToString());
             
        }
        // GET: /Language/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Language ObjLanguage = db.Languages.Find(id);
            if (ObjLanguage == null)
            {
                return HttpNotFound();
            }
            
            return View(ObjLanguage);
        }

        // POST: /Language/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Language ObjLanguage )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjLanguage).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "LanguageController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "Language", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Language to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "Language Edit",
                                ErrorFrom = "LanguageController.Edit",
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
                    ErrorFor = "Language Edit",
                    ErrorFrom = "LanguageController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
 
             
            return Content(sb.ToString());

        }
        // GET: /Language/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Language ObjLanguage = db.Languages.Find(id);
            if (ObjLanguage == null)
            {
                return HttpNotFound();
            }
            return View(ObjLanguage);
        }

        // POST: /Language/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    Language ObjLanguage = db.Languages.Find(id);
                    db.Languages.Remove(ObjLanguage);
                    db.SaveChanges();

                    Utility.WriteAuditLog(new AuditLog()
                    {
                        ActionFrom = "LanguageController.Delete",
                        Action = (int)AuditAction.Delete,
                        ModuleName = "Language", // Module name
                        SubModuleName = "Delete", // Sub module name if any
                                                  //UserId = userId, // Id from Current User
                        ActionMessage = "Delete Language to user sucessfull." // Message if any
                    });

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                 
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "Language Delete",
                    ErrorFrom = "LanguageController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
            return Content(sb.ToString());
  
        }
        // GET: /Language/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            Language ObjLanguage = db.Languages.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                
            }
            
            return View(ObjLanguage);
        }

        // POST: /Language/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(Language ObjLanguage )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjLanguage).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "LanguageController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "Language", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Edit Language to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "Language MultiViewIndex",
                                ErrorFrom = "LanguageController.MultiViewIndex",
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
                    ErrorFor = "Language MultiViewIndex",
                    ErrorFrom = "LanguageController.MultiViewIndex",
                    ErrorMessage = "Exception: " + ex.Message
                });
            } 
             
            return Content(sb.ToString());
 
        }
         public ActionResult UserLanguageGetGrid(int id=0)
        {
            var tak = db.UserLanguages.Where(i=>i.LanguageId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.DateAdded),
                Convert.ToString(c.DateModied),
                Convert.ToString(c.ModifiedBy),
                Convert.ToString(c.AddedBy),
                Convert.ToString(c.Id),
                Convert.ToString(c.RateYourSelf),
                Convert.ToString(c.User_UserId.UserName),Convert.ToString(c.LanguageId),
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

