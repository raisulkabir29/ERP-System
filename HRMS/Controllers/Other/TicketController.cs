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
    public class TicketController : BaseController
    { 
        // GET: /Ticket/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET Ticket/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.Tickets.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Office_OfficeId.Title), 
            Convert.ToString(c.Subject), 
            Convert.ToString(c.Description), 
            Convert.ToString(c.ParentId),
            Convert.ToString(c.DateAdded), 
            Convert.ToString(c.AddedBy), 
            Convert.ToString(c.IsClose), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /Ticket/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /Ticket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ObjTicket = db.Tickets.Find(id);
            if (ObjTicket == null)
            {
                return HttpNotFound();
            }
            return View(ObjTicket);
        }
        // GET: /Ticket/Create
        public ActionResult Create()
        {
             ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title");
             ViewBag.ParentId = new SelectList(db.Tickets, "Id", "Subject");

             return View();
        }

        // POST: /Ticket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Ticket ObjTicket )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Tickets.Add(ObjTicket);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "TicketController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "Ticket", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Adding Ticket is sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "Ticket - Create",
                                ErrorFrom = "TicketController.Create",
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
                    ErrorFor = "Ticket - Create",
                    ErrorFrom = "TicketController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
            return Content(sb.ToString());
             
        }
        // GET: /Ticket/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ObjTicket = db.Tickets.Find(id);
            if (ObjTicket == null)
            {
                return HttpNotFound();
            }
            ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title", ObjTicket.OfficeId);
            ViewBag.ParentId = new SelectList(db.Tickets, "Id", "Subject", ObjTicket.ParentId);

            return View(ObjTicket);
        }

        // POST: /Ticket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Ticket ObjTicket )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjTicket).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "TicketController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "Ticket", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Ticket is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "Ticket Edit",
                                ErrorFrom = "TicketController.Edit",
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
                    ErrorFor = "Ticket Edit",
                    ErrorFrom = "TicketController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
 
             
            return Content(sb.ToString());

        }
        // GET: /Ticket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ObjTicket = db.Tickets.Find(id);
            if (ObjTicket == null)
            {
                return HttpNotFound();
            }
            return View(ObjTicket);
        }

        // POST: /Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    Ticket ObjTicket = db.Tickets.Find(id);
                    db.Tickets.Remove(ObjTicket);
                    db.SaveChanges();

                    Utility.WriteAuditLog(new AuditLog()
                    {
                        ActionFrom = "TicketController.Delete",
                        Action = (int)AuditAction.Delete,
                        ModuleName = "Ticket", // Module name
                        SubModuleName = "Delete", // Sub module name if any
                                                  //UserId = userId, // Id from Current User
                        ActionMessage = "Deleting Ticket is sucessfull." // Message if any
                    });

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                 
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "Ticket Delete",
                    ErrorFrom = "TicketController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
  
            return Content(sb.ToString());
  
        }
        // GET: /Ticket/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            Ticket ObjTicket = db.Tickets.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title", ObjTicket.OfficeId);
                ViewBag.ParentId = new SelectList(db.Tickets, "Id", "Subject", ObjTicket.ParentId);

            }
            
            return View(ObjTicket);
        }

        // POST: /Ticket/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(Ticket ObjTicket )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjTicket).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "TicketController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "Ticket", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Ticket is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "Ticket MultiViewIndex",
                                ErrorFrom = "TicketController.MultiViewIndex",
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
                    ErrorFor = "Ticket MultiViewIndex",
                    ErrorFrom = "TicketController.MultiViewIndex",
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

