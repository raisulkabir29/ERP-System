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
    public class UserDetailsController : BaseController
    {
        // GET: /UserDetails/
        public ActionResult Index()
        {
            return View();
        }

        // GET /UserDetails/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.UserDetailss.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(), 
                //Convert.ToString(c.Id),
                //Convert.ToString(c.UserId),
                Convert.ToString(c.User_UserId !=null?c.User_UserId.UserName:""),
                string.Format("{0:dd-MMM-yyyy}",c.JoiningDate),
                Convert.ToString(c.FatherOrHusband),
                Convert.ToString(c.FatherOrHusbandName),
                Convert.ToString(c.MotherName),
                Convert.ToString(c.PresentAddressVillage),
                Convert.ToString(c.PresentAddressPO),
                Convert.ToString(c.PresentAddressThana),
                Convert.ToString(c.PresentAddressDistrict),
                Convert.ToString(c.PermanentAddressVillage),
                Convert.ToString(c.PermanentAddressPO),
                Convert.ToString(c.PermanentAddressThana),
                Convert.ToString(c.PermanentAddressDistrict),
                Convert.ToString(c.Height),
                Convert.ToString(c.Weight),
                Convert.ToString(c.Birthmark),
                Convert.ToString(c.EyeColor),
                Convert.ToString(c.HairColor),
                Convert.ToString(c.NoOfTeeth),
                Convert.ToString(c.Age),
                Convert.ToString(c.Beard),
                Convert.ToString(c.MaritalStatus),
                Convert.ToString(c.ChildNo),
                Convert.ToString(c.FamilyMember),
                Convert.ToString(c.EarningMemberInFamily),
                Convert.ToString(c.Religion),
                Convert.ToString(c.TotalExperience),
                Convert.ToString(c.EmailAddress),
                Convert.ToString(c.LandPhoneNo),
                Convert.ToString(c.MbPhoneNo),
                Convert.ToString(c.IsActive),
                //Convert.ToString(c.IsEmergency),
                Convert.ToString(c.InvolvedInCrime),
                //Convert.ToString(c.NoObjectionCert),
                //Convert.ToString(c.AddedBy),
                //string.Format("{0:dd-MMM-yyyy}",c.DateAdded),
                //string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),
            };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }

        // GET: /UserDetails/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }

        // GET: /UserDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails ObjUserDetails = db.UserDetailss.Find(id);
            if (ObjUserDetails == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserDetails);
        }

        // GET: /UserDetails/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");

            return View();
        }

        // POST: /UserDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(UserDetails ObjUserDetails)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {

                    var user = db.Users.Single(c => c.Id == ObjUserDetails.UserId);
                    DateTime dateOfBirth = Convert.ToDateTime(user.DateOfBirth);
                    DateTime joiningDate = Convert.ToDateTime(ObjUserDetails.JoiningDate);
                    var age = (joiningDate - dateOfBirth).Days / 365;
                    ObjUserDetails.Age = age;

                    db.UserDetailss.Add(ObjUserDetails);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserDetailsController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "UserDetails", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "Adding User Details for field - " + key + " - " + currentKeyValue // Message if any
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
                                ErrorFor = "UserDetails - Create",
                                ErrorFrom = "UserDetailsController.Create",
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
                    ErrorFor = "UserDetails - Create",
                    ErrorFrom = "UserDetailsController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }

        // GET: /UserDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails ObjUserDetails = db.UserDetailss.Find(id);
            if (ObjUserDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserDetails.UserId);

            return View(ObjUserDetails);
        }

        // POST: /UserDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(UserDetails ObjUserDetails)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {
                    var user = db.Users.Single(c => c.Id == ObjUserDetails.UserId);
                    DateTime dateOfBirth = Convert.ToDateTime(user.DateOfBirth);
                    DateTime joiningDate = Convert.ToDateTime(ObjUserDetails.JoiningDate);
                    var age = (joiningDate - dateOfBirth).Days / 365;
                    ObjUserDetails.Age = age;

                    db.Entry(ObjUserDetails).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserDetailsController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserDetails", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing User Details for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserDetails Edit",
                                ErrorFrom = "UserDetailsController.Edit",
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
                    ErrorFor = "UserDetails Edit",
                    ErrorFrom = "UserDetailsController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }


            return Content(sb.ToString());

        }

        // GET: /UserDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails ObjUserDetails = db.UserDetailss.Find(id);
            if (ObjUserDetails == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserDetails);
        }

        // POST: /UserDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                UserDetails ObjUserDetails = db.UserDetailss.Find(id);
                db.UserDetailss.Remove(ObjUserDetails);
                db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "UserDetailsController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "UserDetails", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Deleting user details is sucessfull." // Message if any
                });

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
            }

            return Content(sb.ToString());

        }

        // GET: /UserDetails/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            UserDetails ObjUserDetails = db.UserDetailss.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", ObjUserDetails.UserId);

            }

            return View(ObjUserDetails);
        }

        // POST: /UserDetails/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(UserDetails ObjUserDetails)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {
                    var user = db.Users.Single(c => c.Id == ObjUserDetails.UserId);
                    DateTime dateOfBirth = Convert.ToDateTime(user.DateOfBirth);
                    DateTime joiningDate = Convert.ToDateTime(ObjUserDetails.JoiningDate);
                    var age = (joiningDate - dateOfBirth).Days / 365;
                    ObjUserDetails.Age = age;

                    db.Entry(ObjUserDetails).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserDetailsController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "UserDetails", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                              //UserId = userId, // Id from Current User
                            ActionMessage = "Editing User Details for field - " + key + " - " + currentKeyValue// Message if any
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
                                ErrorFor = "UserDetails MultiViewIndex",
                                ErrorFrom = "UserDetailsController.MultiViewIndex",
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
                    ErrorFor = "UserDetails MultiViewIndex",
                    ErrorFrom = "UserDetailsController.MultiViewIndex",
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
