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
    public class UserAwardsController : BaseController
    { 
        // GET: /UserAwards/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET UserAwards/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.UserAwardss.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.User_UserId.UserName), 
            Convert.ToString(c.AwardType), 
            Convert.ToString(c.OnDate), 
            Convert.ToString(c.AwardName), 
            Convert.ToString(c.Photo), 
            Convert.ToString(c.Description), 
            Convert.ToString(c.DateAdded), 
            Convert.ToString(c.AddedBy), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /UserAwards/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /UserAwards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAwards ObjUserAwards = db.UserAwardss.Find(id);
            if (ObjUserAwards == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserAwards);
        }
        // GET: /UserAwards/Create
        public ActionResult Create()
        {
             ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");

             return View();
        }

        // POST: /UserAwards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(UserAwards ObjUserAwards ,HttpPostedFileBase Photo,string HideImage1)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    if (Photo != null) 
                    {
                        var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(Photo, Server.MapPath("~/Uploads"));
                        ModelState.Clear(); 
                        ObjUserAwards.Photo = fileName; 
                    } 
                    else 
                    { 
                        ObjUserAwards.Photo = HideImage1;  
                    }


                    db.UserAwardss.Add(ObjUserAwards);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserAwardsController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "UserAwards", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Assign Awards to user sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "UserAwards - Create",
                                ErrorFrom = "UserAwardsController.Create",
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
                    ErrorFor = "UserAwards - Create",
                    ErrorFrom = "UserAwardsController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
            return Content(sb.ToString());
             
        }
        // GET: /UserAwards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAwards ObjUserAwards = db.UserAwardss.Find(id);
            if (ObjUserAwards == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserAwards.UserId);

            return View(ObjUserAwards);
        }

        // POST: /UserAwards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(UserAwards ObjUserAwards ,HttpPostedFileBase Photo,string HideImage1)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    if (Photo != null) 
                    {
                        var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(Photo, Server.MapPath("~/Uploads"));
                        ModelState.Clear(); 
                        ObjUserAwards.Photo = fileName; 
                    } 
                    else 
                    { 
                        ObjUserAwards.Photo = HideImage1;  
                    }


                    db.Entry(ObjUserAwards).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserAwardsController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserAwards", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Awards to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserAwards Edit",
                                ErrorFrom = "UserAwardsController.Edit",
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
                    ErrorFor = "UserAwards Edit",
                    ErrorFrom = "UserAwardsController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
 
             
            return Content(sb.ToString());

        }
        // GET: /UserAwards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAwards ObjUserAwards = db.UserAwardss.Find(id);
            if (ObjUserAwards == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserAwards);
        }

        // POST: /UserAwards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    UserAwards ObjUserAwards = db.UserAwardss.Find(id);
                    db.UserAwardss.Remove(ObjUserAwards);
                    db.SaveChanges();

                    Utility.WriteAuditLog(new AuditLog()
                    {
                        ActionFrom = "UserAwardsController.Delete",
                        Action = (int)AuditAction.Delete,
                        ModuleName = "UserAwards", // Module name
                        SubModuleName = "Delete", // Sub module name if any
                                                  //UserId = userId, // Id from Current User
                        ActionMessage = "Deleting Awards to user is sucessfull." // Message if any
                    });

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                 
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "UserAwards Delete",
                    ErrorFrom = "UserAwardsController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
            return Content(sb.ToString());
  
        }
        // GET: /UserAwards/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            UserAwards ObjUserAwards = db.UserAwardss.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserAwards.UserId);

            }
            
            return View(ObjUserAwards);
        }

        // POST: /UserAwards/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(UserAwards ObjUserAwards ,HttpPostedFileBase Photo,string HideImage1)
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    if (Photo != null) 
                    {
                        var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(Photo, Server.MapPath("~/Uploads"));
                        ModelState.Clear(); 
                        ObjUserAwards.Photo = fileName; 
                    } 
                    else 
                    { 
                        ObjUserAwards.Photo = HideImage1;  
                    }


                    db.Entry(ObjUserAwards).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserAwardsController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserAwards", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Awards to user is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserAwards MultiViewIndex",
                                ErrorFrom = "UserAwardsController.MultiViewIndex",
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
                    ErrorFor = "UserAwards MultiViewIndex",
                    ErrorFrom = "UserAwardsController.MultiViewIndex",
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

