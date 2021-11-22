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
    public class OfficeController : BaseController
    { 
        // GET: /Office/
        public ActionResult Index()
        {
            return View();
        }

        // GET Office/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.Offices.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(),
                            //Convert.ToString(c.Id), 
                            Convert.ToString(c.Title),
                            Convert.ToString(c.Code),
                            Convert.ToString(c.CreatedOn),
                            Convert.ToString(c.OfficeType_OfficeTypeId.Name),
                            Convert.ToString(c.Company_CompanyId.Name),
                            //Convert.ToString(c.MapLatitude),
                            //Convert.ToString(c.MapLongitude),
                            Convert.ToString(c.Details),
                            Convert.ToString(c.Fax),
                            Convert.ToString(c.Country),
                            Convert.ToString(c.City),
                            Convert.ToString(c.ZipCode),
                            string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
                            string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /Office/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /Office/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Office ObjOffice = db.Offices.Find(id);
            if (ObjOffice == null)
            {
                return HttpNotFound();
            }
            return View(ObjOffice);
        }
        // GET: /Office/Create
        public ActionResult Create()
        {
             ViewBag.OfficeTypeId = new SelectList(db.OfficeTypes, "Id", "Name");
             ViewBag.CompanyId = new SelectList(db.Companys, "Id", "Name");

             return View();
        }

        // POST: /Office/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Office ObjOffice )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Offices.Add(ObjOffice);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "OfficeController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "Office", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Adding Office is sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "Office - Create",
                                ErrorFrom = "OfficeController.Create",
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
                    ErrorFor = "Office - Create",
                    ErrorFrom = "OfficeController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
            return Content(sb.ToString());
             
        }
        // GET: /Office/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Office ObjOffice = db.Offices.Find(id);
            if (ObjOffice == null)
            {
                return HttpNotFound();
            }
            ViewBag.OfficeTypeId = new SelectList(db.OfficeTypes, "Id", "Name", ObjOffice.OfficeTypeId);
            ViewBag.CompanyId = new SelectList(db.Companys, "Id", "Name", ObjOffice.CompanyId);

            return View(ObjOffice);
        }

        // POST: /Office/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Office ObjOffice )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjOffice).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "OfficeController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "Office", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Office is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "Office Edit",
                                ErrorFrom = "OfficeController.Edit",
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
                    ErrorFor = "Office Edit",
                    ErrorFrom = "OfficeController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
 
             
            return Content(sb.ToString());

        }
        // GET: /Office/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Office ObjOffice = db.Offices.Find(id);
            if (ObjOffice == null)
            {
                return HttpNotFound();
            }
            return View(ObjOffice);
        }

        // POST: /Office/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    Office ObjOffice = db.Offices.Find(id);
                    db.Offices.Remove(ObjOffice);
                    db.SaveChanges();

                    Utility.WriteAuditLog(new AuditLog()
                    {
                        ActionFrom = "OfficeController.Delete",
                        Action = (int)AuditAction.Delete,
                        ModuleName = "Office", // Module name
                        SubModuleName = "Delete", // Sub module name if any
                                                  //UserId = userId, // Id from Current User
                        ActionMessage = "Deleting Office is sucessfull." // Message if any
                    });

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                 
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "Office Delete",
                    ErrorFrom = "OfficeController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
            return Content(sb.ToString());
  
        }
        // GET: /Office/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            Office ObjOffice = db.Offices.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.OfficeTypeId = new SelectList(db.OfficeTypes, "Id", "Name", ObjOffice.OfficeTypeId);
                ViewBag.CompanyId = new SelectList(db.Companys, "Id", "Name", ObjOffice.CompanyId);

            }
            
            return View(ObjOffice);
        }

        // POST: /Office/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(Office ObjOffice )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjOffice).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "OfficeController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "Office", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Office is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "Office MultiViewIndex",
                                ErrorFrom = "OfficeController.MultiViewIndex",
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
                    ErrorFor = "Office MultiViewIndex",
                    ErrorFrom = "OfficeController.MultiViewIndex",
                    ErrorMessage = "Exception: " + ex.Message
                });
            } 
             
            return Content(sb.ToString());
 
        }
         public ActionResult UserAllocationGetGrid(int id=0)
        {
            var tak = db.UserAllocations.Where(i=>i.OfficeId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.AllocationFrom),
                Convert.ToString(c.AllocationTo),
                Convert.ToString(c.Id),
                Convert.ToString(c.User_UserId.UserName),Convert.ToString(c.User_SuperiorUserId.UserName),Convert.ToString(c.OfficeId),
                Convert.ToString(c.JobTitle_JobTitleId.Name), };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
         public ActionResult OfficeAddressGetGrid(int id=0)
        {
            var tak = db.OfficeAddresss.Where(i=>i.OfficeId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.UserAddress_AddressId.Line1),Convert.ToString(c.OfficeId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
         public ActionResult OfficeEmailGetGrid(int id=0)
        {
            var tak = db.OfficeEmails.Where(i=>i.OfficeId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.UserEmail_EmailId.EmailAddress),Convert.ToString(c.OfficeId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
         public ActionResult OfficePhoneGetGrid(int id=0)
        {
            var tak = db.OfficePhones.Where(i=>i.OfficeId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Phone),
                Convert.ToString(c.Id),
                Convert.ToString(c.OfficeId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
         public ActionResult UserAttendenceGetGrid(int id=0)
        {
            var tak = db.UserAttendences.Where(i=>i.CompanyOfficeId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.AnyRemarks),
                Convert.ToString(c.IsPresent),
                Convert.ToString(c.DateOfAttendence),
                Convert.ToString(c.PunchIn),
                Convert.ToString(c.PunchOut),
                Convert.ToString(c.Id),
                Convert.ToString(c.User_UserId.UserName),Convert.ToString(c.CompanyOfficeId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
         public ActionResult AnnouncementOrNoteGetGrid(int id=0)
        {
            var tak = db.AnnouncementOrNotes.Where(i=>i.OfficeId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Summary),
                Convert.ToString(c.Title),
                Convert.ToString(c.IsNote),
                Convert.ToString(c.PostedDate),
                Convert.ToString(c.Description),
                Convert.ToString(c.DateAdded),
                Convert.ToString(c.AddedBy),
                Convert.ToString(c.Id),
                Convert.ToString(c.OfficeId),
                Convert.ToString(c.Department_DepartmentId.Name), };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
         public ActionResult ExpenseGetGrid(int id=0)
        {
            var tak = db.Expenses.Where(i=>i.OfficeId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Title),
                Convert.ToString(c.PurchasedBy),
                Convert.ToString(c.Amount),
                Convert.ToString(c.BillAttachment),
                Convert.ToString(c.PurchaseDate),
                Convert.ToString(c.Remarks),
                Convert.ToString(c.DateAdded),
                Convert.ToString(c.AddedBy),
                Convert.ToString(c.Id),
                Convert.ToString(c.OfficeId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
         public ActionResult PolicyGetGrid(int id=0)
        {
            var tak = db.Policys.Where(i=>i.OfficeId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Title),
                Convert.ToString(c.Attachment),
                Convert.ToString(c.Description),
                Convert.ToString(c.DateAdded),
                Convert.ToString(c.AddedBy),
                Convert.ToString(c.Id),
                Convert.ToString(c.OfficeId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
         public ActionResult TicketGetGrid(int id=0)
        {
            var tak = db.Tickets.Where(i=>i.OfficeId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Subject),
                Convert.ToString(c.IsClose),
                Convert.ToString(c.Description),
                Convert.ToString(c.DateAdded),
                Convert.ToString(c.AddedBy),
                Convert.ToString(c.Id),
                Convert.ToString(c.OfficeId),
                Convert.ToString(c.Ticket2 !=null?c.Ticket2.Subject:""), };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
         public ActionResult FileManagerGetGrid(int id=0)
        {
            var tak = db.FileManagers.Where(i=>i.OfficeId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.FileExtension),
                Convert.ToString(c.FileSize),
                Convert.ToString(c.FileName),
                Convert.ToString(c.DateAdded),
                Convert.ToString(c.AddedBy),
                Convert.ToString(c.Id),
                Convert.ToString(c.OfficeId),
                Convert.ToString(c.Department_DepartmentId.Name), };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
         public ActionResult DepartmentGetGrid(int id=0)
        {
            var tak = db.Departments.Where(i=>i.OfficeId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Name),
                Convert.ToString(c.Id),
                Convert.ToString(c.OfficeId),
                Convert.ToString(c.Department2 !=null?c.Department2.Name:""), };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
         public ActionResult HolidayGetGrid(int id=0)
        {
            var tak = db.Holidays.Where(i=>i.OfficeId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Detail),
                Convert.ToString(c.Name),
                Convert.ToString(c.HolidayDate),
                Convert.ToString(c.Id),
                Convert.ToString(c.OfficeId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
         public ActionResult UserGetGrid(int id=0)
        {
            var tak = db.Users.Where(i=>i.OfficeId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.BloodGroup),
                Convert.ToString(c.Nationality),
                Convert.ToString(c.FirstName),
                Convert.ToString(c.LastName),
                Convert.ToString(c.UserName),
                Convert.ToString(c.Password),
                Convert.ToString(c.CanLogin),
                Convert.ToString(c.IsActive),
                Convert.ToString(c.ProfilePicture),
                Convert.ToString(c.DateOfBirth),
                Convert.ToString(c.Id),
                Convert.ToString(c.OfficeId),
                Convert.ToString(c.Gender_GenderId.Title), };
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

