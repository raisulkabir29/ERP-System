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
    public class FileManagerController : BaseController
    { 
        
        public ActionResult Index()
        {
            return View();
        }
        
        // GET FileManager/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.FileManagers.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Office_OfficeId.Title), 
            Convert.ToString(c.Department_DepartmentId.Name), 
            Convert.ToString(c.FileName), 
            Convert.ToString(c.FileSize), 
            Convert.ToString(c.FileExtension), 
            Convert.ToString(c.DateAdded), 
            Convert.ToString(c.AddedBy), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /FileManager/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /FileManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileManager ObjFileManager = db.FileManagers.Find(id);
            if (ObjFileManager == null)
            {
                return HttpNotFound();
            }
            return View(ObjFileManager);
        }
        // GET: /FileManager/Create
        public ActionResult Create()
        {
             ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title");
             ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");

             return View();
        }

        // POST: /FileManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(FileManager ObjFileManager ,HttpPostedFileBase FileName,string HideImage1)
        {
            ObjFileManager.FileExtension = Path.GetExtension(FileName.FileName).TrimStart('.');
            ObjFileManager.FileSize = FileName.ContentLength;
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    if (FileName != null) 
                    {
                        var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(FileName, Server.MapPath("~/Uploads"));
                        ModelState.Clear(); 
                        ObjFileManager.FileName = fileName; 
                    } 
                    else 
                    { 
                        ObjFileManager.FileName = HideImage1;  
                    }


                    db.FileManagers.Add(ObjFileManager);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "FileManagerController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "FileManager", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Adding File is sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "FileManager - Create",
                                ErrorFrom = "FileManagerController.Create",
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
                    ErrorFor = "FileManager - Create",
                    ErrorFrom = "FileManagerController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
            return Content(sb.ToString());
             
        }
        // GET: /FileManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileManager ObjFileManager = db.FileManagers.Find(id);
            if (ObjFileManager == null)
            {
                return HttpNotFound();
            }
            ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title", ObjFileManager.OfficeId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", ObjFileManager.DepartmentId);

            return View(ObjFileManager);
        }

        // POST: /FileManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(FileManager ObjFileManager ,HttpPostedFileBase FileName,string HideImage1)
        {
            ObjFileManager.FileExtension = Path.GetExtension(FileName.FileName).TrimStart('.');
            ObjFileManager.FileSize = FileName.ContentLength;
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    if (FileName != null) 
                    {
                        var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(FileName, Server.MapPath("~/Uploads"));
                        ModelState.Clear(); 
                        ObjFileManager.FileName = fileName; 
                    } 
                    else 
                    { 
                        ObjFileManager.FileName = HideImage1;  
                    }


                    db.Entry(ObjFileManager).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "FileManagerController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "FileManager", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing File is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "FileManager Edit",
                                ErrorFrom = "FileManagerController.Edit",
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
                    ErrorFor = "FileManager Edit",
                    ErrorFrom = "FileManagerController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
 
             
            return Content(sb.ToString());

        }
        // GET: /FileManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileManager ObjFileManager = db.FileManagers.Find(id);
            if (ObjFileManager == null)
            {
                return HttpNotFound();
            }
            return View(ObjFileManager);
        }

        // POST: /FileManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    FileManager ObjFileManager = db.FileManagers.Find(id);
                    db.FileManagers.Remove(ObjFileManager);
                    db.SaveChanges();

                    Utility.WriteAuditLog(new AuditLog()
                    {
                        ActionFrom = "FileManagerController.Delete",
                        Action = (int)AuditAction.Delete,
                        ModuleName = "FileManager", // Module name
                        SubModuleName = "Delete", // Sub module name if any
                                                  //UserId = userId, // Id from Current User
                        ActionMessage = "Deleting File is sucessfull." // Message if any
                    });

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                 
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "FileManager Delete",
                    ErrorFrom = "FileManagerController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
            return Content(sb.ToString());
  
        }
        // GET: /FileManager/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            FileManager ObjFileManager = db.FileManagers.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title", ObjFileManager.OfficeId);
                ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", ObjFileManager.DepartmentId);

            }
            
            return View(ObjFileManager);
        }

        // POST: /FileManager/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(FileManager ObjFileManager ,HttpPostedFileBase FileName,string HideImage1)
        {
            ObjFileManager.FileExtension = Path.GetExtension(FileName.FileName).TrimStart('.');
            ObjFileManager.FileSize = FileName.ContentLength;
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    if (FileName != null) 
                    {
                        var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(FileName, Server.MapPath("~/Uploads"));
                        ModelState.Clear(); 
                        ObjFileManager.FileName = fileName; 
                    } 
                    else 
                    { 
                        ObjFileManager.FileName = HideImage1;  
                    }


                    db.Entry(ObjFileManager).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "FileManagerController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "FileManager", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing File is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "FileManager MultiViewIndex",
                                ErrorFrom = "FileManagerController.MultiViewIndex",
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
                    ErrorFor = "FileManager MultiViewIndex",
                    ErrorFrom = "FileManagerController.MultiViewIndex",
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

