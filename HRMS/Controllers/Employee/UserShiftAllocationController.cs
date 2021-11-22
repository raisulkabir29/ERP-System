using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using HRMS.Common.Enums;
using System.Web.Mvc;
using HRMS.Models;

namespace HRMS.Controllers
{
    public class UserShiftAllocationController : BaseController
    {

        // GET: /UserShiftAllocation/
        public ActionResult Index()
        {
            return View();
        }

        // GET UserShiftAllocation/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.UserShiftAllocations.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(),
            //Convert.ToString(c.Id),
            Convert.ToString(c.User_UserId.UserName),
            Convert.ToString(c.ShiftMaster_ShiftMasterId.Name),
            string.Format("{0:dd-MMM-yyyy}",c.ShiftFrom),
            string.Format("{0:dd-MMM-yyyy}",c.ShiftTo),
            Convert.ToString(c.Year),
            Convert.ToString(c.Month),
             string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
             string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /UserShiftAllocation/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /UserShiftAllocation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UserShiftAllocation ObjUserShiftAllocation = db.UserShiftAllocations.Find(id);            
            if (ObjUserShiftAllocation == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserShiftAllocation);
        }

        // GET: /UserShiftAllocation/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.ShiftId = new SelectList(db.ShiftMasters, "Id", "Name");

            return View();
        }

        // POST: /UserShiftAllocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(UserShiftAllocation ObjUserShiftAllocation)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {

                    db.UserShiftAllocations.Add(ObjUserShiftAllocation);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserShiftAllocationController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "UserShiftAllocation", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Assign UserShiftAllocation to user sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "UserShiftAllocation - Create",
                                ErrorFrom = "UserShiftAllocationController.Create",
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
                    ErrorFor = "UserShiftAllocation - Create",
                    ErrorFrom = "UserShiftAllocationController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /UserShiftAllocation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserShiftAllocation ObjUserShiftAllocation = db.UserShiftAllocations.Find(id);
            if (ObjUserShiftAllocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserShiftAllocation.UserId);
            ViewBag.ShiftId = new SelectList(db.ShiftMasters, "Id", "Name", ObjUserShiftAllocation.ShiftId);

            return View(ObjUserShiftAllocation);
        }

        // POST: /UserShiftAllocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(UserShiftAllocation ObjUserShiftAllocation)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjUserShiftAllocation).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserShiftAllocationController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserShiftAllocation", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Edit UserShiftAllocation to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserShiftAllocation Edit",
                                ErrorFrom = "UserShiftAllocationController.Edit",
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
                    ErrorFor = "UserShiftAllocation Edit",
                    ErrorFrom = "UserShiftAllocationController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }


            return Content(sb.ToString());

        }

        // GET: /UserShiftAllocation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserShiftAllocation ObjUserShiftAllocation = db.UserShiftAllocations.Find(id);
            if (ObjUserShiftAllocation == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserShiftAllocation);
        }

        // POST: /UserShiftAllocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                UserShiftAllocation ObjUserShiftAllocation = db.UserShiftAllocations.Find(id);
                db.UserShiftAllocations.Remove(ObjUserShiftAllocation);
                db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "UserShiftAllocationController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "UserShiftAllocation", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Delete UserShiftAllocation to user sucessfull." // Message if any
                });

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "UserShiftAllocation Delete",
                    ErrorFrom = "UserShiftAllocationController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }
        // GET: /UserShiftAllocation/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            UserShiftAllocation ObjUserShiftAllocation = db.UserShiftAllocations.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserShiftAllocation.UserId);
                ViewBag.ShiftId = new SelectList(db.ShiftMasters, "Id", "Name", ObjUserShiftAllocation.ShiftId);

            }

            return View(ObjUserShiftAllocation);
        }

        // POST: /UserShiftAllocation/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(UserShiftAllocation ObjUserShiftAllocation)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {

                    db.Entry(ObjUserShiftAllocation).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserShiftAllocationController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserShiftAllocation", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Edit UserShiftAllocation to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserShiftAllocation MultiViewIndex",
                                ErrorFrom = "UserShiftAllocationController.MultiViewIndex",
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
                    ErrorFor = "UserShiftAllocation MultiViewIndex",
                    ErrorFrom = "UserShiftAllocationController.MultiViewIndex",
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
