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
using HRMS.Common.Enums;
using System.Globalization;

namespace HRMS.Controllers
{
    public class UserRefNomineeController : BaseController
    {
        // GET: /UserRefNominee/
        public ActionResult Index()
        {
            return View();
        }

        // GET /UserRefNominee/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.UserRefNominees.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(), 
                //Convert.ToString(c.Id),
                //Convert.ToString(c.UserId),
                Convert.ToString(c.User_UserId !=null?c.User_UserId.UserName:""),
                Convert.ToString(c.CurrentGuardianName),
                Convert.ToString(c.Recommender),
                Convert.ToString(c.EmergContactName),
                Convert.ToString(c.EmergContactRel),
                Convert.ToString(c.EmergContactAddrVillage),
                Convert.ToString(c.EmergContactAddrPO),
                Convert.ToString(c.EmergContactAddrThana),
                Convert.ToString(c.EmergContactAddrDistrict),
                Convert.ToString(c.EmergContactPhNo),
                Convert.ToString(c.EmergContactMbNo),
                Convert.ToString(c.Reference1Name),
                Convert.ToString(c.Reference1Company),
                Convert.ToString(c.Reference1Designation),
                Convert.ToString(c.Reference1ContactNo),
                Convert.ToString(c.Reference1AddrVillage),
                Convert.ToString(c.Reference1AddrPO),
                Convert.ToString(c.Reference1AddrThana),
                Convert.ToString(c.Reference1AddrDistrict),
                Convert.ToString(c.Reference2Name),
                Convert.ToString(c.Reference2Company),
                Convert.ToString(c.Reference2Designation),
                Convert.ToString(c.Reference2ContactNo),
                Convert.ToString(c.Reference2AddrVillage),
                Convert.ToString(c.Reference2AddrPO),
                Convert.ToString(c.Reference2AddrThana),
                Convert.ToString(c.Reference2AddrDistrict),
                Convert.ToString(c.NomineeName),
                Convert.ToString(c.NomineeFatherName),
                Convert.ToString(c.NomineeMotherName),
                Convert.ToString(c.NomineeProfession),
                Convert.ToString(c.NomineeContactPhNo),
                Convert.ToString(c.NomineeRel),
                Convert.ToString(c.NomineeAddrVillage),
                Convert.ToString(c.NomineeAddrPO),
                Convert.ToString(c.NomineeAddrUnion),
                Convert.ToString(c.NomineeAddrUpazilla),
                Convert.ToString(c.NomineeAddrDistrict),
                Convert.ToString(c.BirthCertificate),
                Convert.ToString(c.PoliceVerification),               
                //Convert.ToString(c.AddedBy),
                //Convert.ToString(c.DateAdded),
                string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
                string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),
            };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }

        // GET: /UserRefNominee/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }

        // GET: /UserRefNominee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRefNominee ObjUserRefNominee = db.UserRefNominees.Find(id);
            if (ObjUserRefNominee == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserRefNominee);
        }

        // GET: /UserRefNominee/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");

            return View();
        }

        // POST: /UserRefNominee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(UserRefNominee ObjUserRefNominee)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {

                    db.UserRefNominees.Add(ObjUserRefNominee);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserRefNomineeController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "UserRefNominee", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Adding URef & Nominee to user sucessfull for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "UserRefNominee - Create",
                                ErrorFrom = "UserRefNomineeController.Create",
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
                    ErrorFor = "UserRefNominee - Create",
                    ErrorFrom = "UserRefNomineeController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /UserRefNominee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRefNominee ObjUserRefNominee = db.UserRefNominees.Find(id);
            if (ObjUserRefNominee == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserRefNominee.UserId);

            return View(ObjUserRefNominee);
        }

        // POST: /UserRefNominee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(UserRefNominee ObjUserRefNominee)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(ObjUserRefNominee).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserRefNomineeController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserRefNominee", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editinf Ref & Nominee to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserRefNominee Edit",
                                ErrorFrom = "UserRefNomineeController.Edit",
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
                    ErrorFor = "UserRefNominee Edit",
                    ErrorFrom = "UserRefNomineeController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }


            return Content(sb.ToString());

        }

        // GET: /UserRefNominee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRefNominee ObjUserRefNominee = db.UserRefNominees.Find(id);
            if (ObjUserRefNominee == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserRefNominee);
        }

        // POST: /UserRefNominee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                UserRefNominee ObjUserRefNominee = db.UserRefNominees.Find(id);
                db.UserRefNominees.Remove(ObjUserRefNominee);
                db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "UserRefNomineeController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "UserRefNominee", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Deleting Ref & Nominee to user sucessfull." // Message if any
                });

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "UserRefNominee Delete",
                    ErrorFrom = "UserRefNomineeController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /UserRefNominee/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            UserRefNominee ObjUserRefNominee = db.UserRefNominees.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserRefNominee.UserId);

            }

            return View(ObjUserRefNominee);
        }

        // POST: /UserRefNominee/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(UserRefNominee ObjUserRefNominee)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(ObjUserRefNominee).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserRefNomineeController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserRefNominee", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing Ref & Nominee to user sucessfull for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserRefNominee MultiViewIndex",
                                ErrorFrom = "UserRefNomineeController.MultiViewIndex",
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
                    ErrorFor = "UserRefNominee MultiViewIndex",
                    ErrorFrom = "UserRefNomineeController.MultiViewIndex",
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
