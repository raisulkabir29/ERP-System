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
    public class UserController : BaseController
    {
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }

        // GET User/GetGrid
        public ActionResult GetGrid()
        {
            //var user = db.Users.ToArray();

            //var result = from c in user
            //             select new string[] { c.Id.ToString(), Convert.ToString(c.Id),
            //    Convert.ToString(c.UserName),
            //    Convert.ToString(c.Password),
            //    Convert.ToString(c.Gender_GenderId !=null?c.Gender_GenderId.Title:""),
            //    string.Format("{0:dd-MMM-yyyy}",c.DateOfBirth),
            //    Convert.ToString(c.BloodGroup),
            //    Convert.ToString(c.Nationality),
            //    Convert.ToString(c.FirstName+" "+c.LastName),
            //    Convert.ToString(c.CanLogin),
            //    Convert.ToString(c.IsActive),
            //    Convert.ToString(c.ProfilePicture),
            //    Convert.ToString(c.Office_OfficeId !=null?c.Office_OfficeId.Title:""),
            //    Convert.ToString(c.DateAdded),
            //    Convert.ToString(c.NationalId),
            //};

            //string query2 = "SELECT u.[Id], u.[UserName],D.[Name]"+
            //    "FROM[User] u" +
            //    "LEFT JOIN[DepartmentUser] du ON  u.Id = du.[UserId]" +
            //    "LEFT JOIN[Department] d ON du.[DepartmentId] = d.[ID]; ";

            //string query = "Select * from Employees";
            //List<Employee> employees = db.Database.SqlQuery<Employee>(query).ToList();

            //return View(employees);


            //var user = db.Users.ToArray();
            //var userDept = db.DepartmentUsers.ToArray();
            //var dept = db.Departments.ToArray();

            //var result = from c in user
            //             join ud in userDept on c.Id equals ud.UserId
            //             join d in dept on ud.DepartmentId equals d.Id
            //             select new string[] { c.Id.ToString(), Convert.ToString(c.Id),
            //    Convert.ToString(c.UserName),
            //    Convert.ToString(c.Password),
            //    //Convert.ToString(ud.DepartmentId),
            //    Convert.ToString(d.Name),
            //    Convert.ToString(c.Gender_GenderId !=null?c.Gender_GenderId.Title:""),
            //    string.Format("{0:dd-MMM-yyyy}",c.DateOfBirth),
            //    Convert.ToString(c.BloodGroup),
            //    Convert.ToString(c.Nationality),
            //    Convert.ToString(c.FirstName+" "+c.LastName),
            //    Convert.ToString(c.CanLogin),
            //    Convert.ToString(c.IsActive),
            //    Convert.ToString(c.ProfilePicture),
            //    Convert.ToString(c.Office_OfficeId !=null?c.Office_OfficeId.Title:""),
            //    Convert.ToString(c.DateAdded),
            //    Convert.ToString(c.NationalId),
            //};

            //var user = db.Users.ToArray();
            //var userDesig = db.UserAllocations.ToArray();
            //var desig = db.JobTitles.ToArray();

            //var result = from c in user
            //             join ud in userDesig on c.Id equals ud.UserId
            //             join d in desig on ud.JobTitleId equals d.Id
            //             select new string[] { c.Id.ToString(), Convert.ToString(c.Id),
            //    Convert.ToString(c.UserName),
            //    Convert.ToString(c.Password),
            //    //Convert.ToString(ud.DepartmentId),
            //    Convert.ToString(d.Name),
            //    Convert.ToString(c.Gender_GenderId !=null?c.Gender_GenderId.Title:""),
            //    string.Format("{0:dd-MMM-yyyy}",c.DateOfBirth),
            //    Convert.ToString(c.BloodGroup),
            //    Convert.ToString(c.Nationality),
            //    Convert.ToString(c.FirstName+" "+c.LastName),
            //    Convert.ToString(c.CanLogin),
            //    Convert.ToString(c.IsActive),
            //    Convert.ToString(c.ProfilePicture),
            //    Convert.ToString(c.Office_OfficeId !=null?c.Office_OfficeId.Title:""),
            //    Convert.ToString(c.DateAdded),
            //    Convert.ToString(c.NationalId),
            //};

            var user = db.Users.ToArray();

            var result = from c in user
                         select new string[] { c.Id.ToString(),
                          //Convert.ToString(c.Id),
                Convert.ToString(c.UserName),
                //Convert.ToString(c.Password),
                Convert.ToString(c.CustomId),
                Convert.ToString(c.Gender_GenderId !=null?c.Gender_GenderId.Title:""),
                string.Format("{0:dd-MMM-yyyy}",c.DateOfBirth),
                Convert.ToString(c.BloodGroup),
                Convert.ToString(c.Nationality),
                Convert.ToString(c.FirstName+" "+c.LastName),
                Convert.ToString(c.CanLogin),
                Convert.ToString(c.IsActive),
                Convert.ToString(c.ProfilePicture),
                Convert.ToString(c.Office_OfficeId !=null?c.Office_OfficeId.Title:""),
                Convert.ToString(c.NationalId),
                string.Format("{0:dd-MMM-yyyy}",c.DateAdded),                
                string.Format("{0:dd-MMM-yyyy}",c.ModifiedDate),
            };

            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }

        // GET: /User/CustomGrid
        public ActionResult CustomGrid()
        {
            return View();
        }

        public ActionResult GetCustomGrid()
        {
            var user = db.Users.ToArray();
            var userDept = db.DepartmentUsers.ToArray();
            var dept = db.Departments.ToArray();

            var result = from c in user
                         join ud in userDept
                         on c.Id equals ud.UserId
                         join d in dept
                         on ud.DepartmentId equals d.Id
                         select new string[] { c.Id.ToString(), Convert.ToString(c.Id),
                Convert.ToString(c.UserName),
                Convert.ToString(c.Password),
                Convert.ToString(ud.DepartmentId),
                Convert.ToString(d.Name),
                Convert.ToString(c.Gender_GenderId !=null?c.Gender_GenderId.Title:""),
                string.Format("{0:dd-MMM-yyyy}",c.DateOfBirth),
                Convert.ToString(c.BloodGroup),
                Convert.ToString(c.Nationality),
                Convert.ToString(c.FirstName+" "+c.LastName),
                Convert.ToString(c.CanLogin),
                Convert.ToString(c.IsActive),
                Convert.ToString(c.ProfilePicture),
                Convert.ToString(c.Office_OfficeId !=null?c.Office_OfficeId.Title:""),
                Convert.ToString(c.DateAdded),
                Convert.ToString(c.NationalId),
            };

            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }

        // GET: /User/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User ObjUser = db.Users.Find(id);
            if (ObjUser == null)
            {
                return HttpNotFound();
            }
            return View(ObjUser);
        }
        // GET: /User/Create
        public ActionResult Create()
        {
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Title");
            ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title");

            return View();
        }

        // POST: /User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(User ObjUser, HttpPostedFileBase ProfilePicture, string HideImage1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {
                    if (ProfilePicture != null)
                    {
                        var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(ProfilePicture, Server.MapPath("~/Uploads"));
                        ModelState.Clear();
                        ObjUser.ProfilePicture = fileName;
                    }
                    else
                    {
                        ObjUser.ProfilePicture = HideImage1;
                    }


                    db.Users.Add(ObjUser);
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        if (key == "HideImage1") continue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserController.Create",
                            Action = (int)AuditAction.Create,
                            ModuleName = "User", // Module name
                            SubModuleName = "Create", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "User created sucessfully for field - " + key + " - " + currentKeyValue // Message if any
                        });

                    }
                    //Utility.WriteAuditLog(new AuditLog()
                    //{
                    //    ActionFrom = "UserController.Create",
                    //    Action = (int)AuditAction.Create,
                    //    ModuleName = "User", // Module name
                    //    SubModuleName = "Create", // Sub module name if any
                    //    //UserId = userId, // Id from Current User
                    //    ActionMessage = "User created sucessfully." // Message if any
                    //});

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
                                ErrorFor = "User Create",
                                ErrorFrom = "UserController.Create",
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
                    ErrorFor = "User Create",
                    ErrorFrom = "UserController.Create",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }
        // GET: /User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User ObjUser = db.Users.Find(id);
            if (ObjUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Title", ObjUser.GenderId);
            ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title", ObjUser.OfficeId);

            return View(ObjUser);
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(User ObjUser,HttpPostedFileBase ProfilePicture, string HideImage1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {
                    if (ProfilePicture != null)
                    {
                        var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(ProfilePicture, Server.MapPath("~/Uploads"));
                        ModelState.Clear();
                        ObjUser.ProfilePicture = fileName;
                    }
                    else
                    {
                        ObjUser.ProfilePicture = HideImage1;
                    }


                    db.Entry(ObjUser).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        if ( key == "HideImage1") continue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserController.Edit",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "User", // Module name
                            SubModuleName = "Edit", // Sub module name if any
                                                      //UserId = userId, // Id from Current User
                            ActionMessage = "User edited sucessfully for field - " + key + " - " + currentKeyValue// Message if any
                        });

                    }

                    //Utility.WriteAuditLog(new AuditLog()
                    //{
                    //    ActionFrom = "UserController.Edit",
                    //    Action = (int)AuditAction.Edit,
                    //    ModuleName = "User", // Module name
                    //    SubModuleName = "Edit", // Sub module name if any
                    //                            //UserId = userId, // Id from Current User
                    //    ActionMessage = "Editing user is sucessfull." // Message if any
                    //});

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
                                ErrorFor = "User Edit",
                                ErrorFrom = "UserController.Edit",
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
                    ErrorFor = "User Edit",
                    ErrorFrom = "UserController.Edit",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }


            return Content(sb.ToString());

        }
        // GET: /User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User ObjUser = db.Users.Find(id);
            if (ObjUser == null)
            {
                return HttpNotFound();
            }
            return View(ObjUser);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                User ObjUser = db.Users.Find(id);
                db.Users.Remove(ObjUser);
                db.SaveChanges();

                Utility.WriteAuditLog(new AuditLog()
                {
                    ActionFrom = "UserController.Delete",
                    Action = (int)AuditAction.Delete,
                    ModuleName = "User", // Module name
                    SubModuleName = "Delete", // Sub module name if any
                                              //UserId = userId, // Id from Current User
                    ActionMessage = "Deleted user name - " + ObjUser.FirstName + " " + ObjUser.LastName // Message if any
                });

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "User Delete",
                    ErrorFrom = "UserController.Delete",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }
        // GET: /User/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            User ObjUser = db.Users.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.GenderId = new SelectList(db.Genders, "Id", "Title", ObjUser.GenderId);
                ViewBag.OfficeId = new SelectList(db.Offices, "Id", "Title", ObjUser.OfficeId);

            }

            return View(ObjUser);
        }

        // POST: /User/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(User ObjUser,HttpPostedFileBase ProfilePicture, string HideImage1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
               if (ModelState.IsValid)
                {
                    if (ProfilePicture != null)
                    {
                        var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(ProfilePicture, Server.MapPath("~/Uploads"));
                        ModelState.Clear();
                        ObjUser.ProfilePicture = fileName;
                    }
                    else
                    {
                        ObjUser.ProfilePicture = HideImage1;
                    }


                    db.Entry(ObjUser).State = EntityState.Modified;
                    db.SaveChanges();

                    foreach (var key in ViewData.ModelState.Keys)
                    {
                        var modelStateVal = ViewData.ModelState[key];
                        var currentKeyValue = ModelState[key].Value.AttemptedValue;

                        if (key == "HideImage1") continue;

                        Utility.WriteAuditLog(new AuditLog()
                        {
                            ActionFrom = "UserController.MultiViewIndex",
                            Action = (int)AuditAction.Edit,
                            ModuleName = "User", // Module name
                            SubModuleName = "MultiViewIndex", // Sub module name if any
                                                    //UserId = userId, // Id from Current User
                            ActionMessage = "Editing user is sucessfull for field - " + key + " - " + currentKeyValue// Message if any
                        });

                    }

                    //Utility.WriteAuditLog(new AuditLog()
                    //{
                    //    ActionFrom = "UserController.MultiViewIndex",
                    //    Action = (int)AuditAction.Edit,
                    //    ModuleName = "User", // Module name
                    //    SubModuleName = "MultiViewIndex", // Sub module name if any
                    //                                      // UserId = userId, // Id from Current User
                    //    ActionMessage = "Editing user is sucessfull." // Message if any
                    //});

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
                                ErrorFor = "User MultiViewIndex",
                                ErrorFrom = "UserController.MultiViewIndex",
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
                    ErrorFor = "User MultiViewIndex",
                    ErrorFrom = "UserController.MultiViewIndex",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }

            return Content(sb.ToString());

        }
        public ActionResult RoleUserGetGrid(int id = 0)
        {
            var tak = db.RoleUsers.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.Role_RoleId.RoleName),Convert.ToString(c.UserId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DepartmentUserGetGrid(int id = 0)
        {
            var tak = db.DepartmentUsers.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.Department_DepartmentId.Name),Convert.ToString(c.UserId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult MenuPermissionGetGrid(int id = 0)
        {
            var tak = db.MenuPermissions.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.IsCreate),
                Convert.ToString(c.IsRead),
                Convert.ToString(c.IsUpdate),
                Convert.ToString(c.IsDelete),
                Convert.ToString(c.Id),
                Convert.ToString(c.SortOrder),
                Convert.ToString(c.Role_RoleId.RoleName),Convert.ToString(c.UserId),
                Convert.ToString(c.Menu_MenuId.MenuText), };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserPayrollSalaryGetGrid(int id = 0)
        {
            var tak = db.UserPayrollSalarys.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Basic),
                Convert.ToString(c.SpecialAllowance),
                Convert.ToString(c.Bonus),
                Convert.ToString(c.ProvidentFund),
                Convert.ToString(c.ProfessionalTax),
                Convert.ToString(c.LunchRecovery),
                Convert.ToString(c.TransportRecovery),
                Convert.ToString(c.TravellingAllowance),
                Convert.ToString(c.DearnessAllowance),
                Convert.ToString(c.IncomeTax),
                Convert.ToString(c.TotalAmount),
                Convert.ToString(c.TotalDeduction),
                Convert.ToString(c.NetAmount),
                Convert.ToString(c.HouseRentAllowance),
                Convert.ToString(c.MedicalAllowance),
                Convert.ToString(c.Id),
                Convert.ToString(c.UserId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserAllocationGetGrid(int id = 0)
        {
            var tak = db.UserAllocations.Where(i => i.SuperiorUserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.AllocationFrom),
                Convert.ToString(c.AllocationTo),
                Convert.ToString(c.Id),
                Convert.ToString(c.UserId),
                Convert.ToString(c.SuperiorUserId),
                Convert.ToString(c.Office_OfficeId.Title),Convert.ToString(c.JobTitle_JobTitleId.Name), };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserTerminationGetGrid(int id = 0)
        {
            var tak = db.UserTerminations.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.TerminationReason),
                Convert.ToString(c.IsResignation),
                Convert.ToString(c.NoticeDate),
                Convert.ToString(c.TerminationDate),
                Convert.ToString(c.ResignationApproveDate),
                Convert.ToString(c.Description),
                Convert.ToString(c.DateAdded),
                Convert.ToString(c.AddedBy),
                Convert.ToString(c.Id),
                Convert.ToString(c.UserId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserAwardsGetGrid(int id = 0)
        {
            var tak = db.UserAwardss.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.AwardType),
                Convert.ToString(c.AwardName),
                Convert.ToString(c.Photo),
                Convert.ToString(c.OnDate),
                Convert.ToString(c.Description),
                Convert.ToString(c.DateAdded),
                Convert.ToString(c.AddedBy),
                Convert.ToString(c.Id),
                Convert.ToString(c.UserId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserTravelsGetGrid(int id = 0)
        {
            var tak = db.UserTravelss.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.PurposeOfVisit),
                Convert.ToString(c.PlaceOfVisit),
                Convert.ToString(c.TravelBy),
                Convert.ToString(c.ExpectedTravelBudget),
                Convert.ToString(c.ActualTravelBudget),
                Convert.ToString(c.StartDate),
                Convert.ToString(c.EndDate),
                Convert.ToString(c.Description),
                Convert.ToString(c.DateAdded),
                Convert.ToString(c.AddedBy),
                Convert.ToString(c.Id),
                Convert.ToString(c.UserId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserSkillGetGrid(int id = 0)
        {
            var tak = db.UserSkills.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.SkillName),
                Convert.ToString(c.RateYourSelf),
                Convert.ToString(c.Id),
                Convert.ToString(c.UserId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserAddressGetGrid(int id = 0)
        {
            var tak = db.UserAddresss.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Line1),
                Convert.ToString(c.Line2),
                Convert.ToString(c.City),
                Convert.ToString(c.PinCode),
                Convert.ToString(c.NearBy),
                Convert.ToString(c.IsEmergency),
                Convert.ToString(c.Id),
                Convert.ToString(c.UserId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserPhoneGetGrid(int id = 0)
        {
            var tak = db.UserPhones.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.PhoneNumber),
                Convert.ToString(c.IsActive),
                Convert.ToString(c.IsEmergency),
                Convert.ToString(c.Id),
                Convert.ToString(c.UserId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserEmailGetGrid(int id = 0)
        {
            var tak = db.UserEmails.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.EmailAddress),
                Convert.ToString(c.IsActive),
                Convert.ToString(c.IsEmergency),
                Convert.ToString(c.Id),
                Convert.ToString(c.UserId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserEducationGetGrid(int id = 0)
        {
            var tak = db.UserEducations.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.FromDate),
                Convert.ToString(c.ToDate),
                Convert.ToString(c.TotalMarks),
                Convert.ToString(c.OutOfMarks),
                Convert.ToString(c.Percentage),
                Convert.ToString(c.Id),
                Convert.ToString(c.UserId),
                Convert.ToString(c.Qualification_Digree.Name),Convert.ToString(c.University_InstitutionId.Name), };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserAttendenceGetGrid(int id = 0)
        {
            var tak = db.UserAttendences.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.AnyRemarks),
                Convert.ToString(c.IsPresent),
                Convert.ToString(c.DateOfAttendence),
                Convert.ToString(c.PunchIn),
                Convert.ToString(c.PunchOut),
                Convert.ToString(c.Id),
                Convert.ToString(c.UserId),
                Convert.ToString(c.Office_CompanyOfficeId.Title), };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserLeaveApplicationGetGrid(int id = 0)
        {
            var tak = db.UserLeaveApplications.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.IsApproved),
                Convert.ToString(c.LeaveActiveFrom),
                Convert.ToString(c.LeaveActiveTo),
                Convert.ToString(c.DateAdded),
                Convert.ToString(c.Id),
                Convert.ToString(c.ApprovedBy),
                Convert.ToString(c.UserId),
                Convert.ToString(c.LeaveType_LeaveTypeId.Name), };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserLanguageGetGrid(int id = 0)
        {
            var tak = db.UserLanguages.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.DateAdded),
                Convert.ToString(c.DateModied),
                Convert.ToString(c.ModifiedBy),
                Convert.ToString(c.AddedBy),
                Convert.ToString(c.Id),
                Convert.ToString(c.RateYourSelf),
                Convert.ToString(c.UserId),
                Convert.ToString(c.Language_LanguageId.Name), };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserWorkExperienceGetGrid(int id = 0)
        {
            var tak = db.UserWorkExperiences.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.DescribeJob),
                Convert.ToString(c.CompanyName),
                Convert.ToString(c.Position),
                Convert.ToString(c.IsCurrent),
                Convert.ToString(c.FromDate),
                Convert.ToString(c.ToDate),
                Convert.ToString(c.Id),
                Convert.ToString(c.UserId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserAllocationGetGrid2(int id = 0)
        {
            var tak = db.UserAllocations.Where(i => i.SuperiorUserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.AllocationFrom),
                Convert.ToString(c.AllocationTo),
                Convert.ToString(c.Id),
                Convert.ToString(c.UserId),
                Convert.ToString(c.SuperiorUserId),
                Convert.ToString(c.Office_OfficeId.Title),Convert.ToString(c.JobTitle_JobTitleId.Name), };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserSalaryTransactionGetGrid(int id = 0)
        {
            var tak = db.UserSalaryTransactions.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.HouseRentAllowance),
                Convert.ToString(c.MedicalAllowance),
                Convert.ToString(c.TravellingAllowance),
                Convert.ToString(c.DearnessAllowance),
                Convert.ToString(c.Basic),
                Convert.ToString(c.SpecialAllowance),
                Convert.ToString(c.Bonus),
                Convert.ToString(c.ProvidentFund),
                Convert.ToString(c.ProfessionalTax),
                Convert.ToString(c.LunchRecovery),
                Convert.ToString(c.TransportRecovery),
                Convert.ToString(c.IncomeTax),
                Convert.ToString(c.TotalAmount),
                Convert.ToString(c.TotalDeduction),
                Convert.ToString(c.NetAmount),
                Convert.ToString(c.OnDate),
                Convert.ToString(c.Remarks),
                Convert.ToString(c.DateAdded),
                Convert.ToString(c.AddedBy),
                Convert.ToString(c.Id),
                Convert.ToString(c.UserId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserPromotionGetGrid(int id = 0)
        {
            var tak = db.UserPromotions.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.PromotionTitle),
                Convert.ToString(c.PromotionDate),
                Convert.ToString(c.Description),
                Convert.ToString(c.DateAdded),
                Convert.ToString(c.AddedBy),
                Convert.ToString(c.Id),
                Convert.ToString(c.UserId),
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

