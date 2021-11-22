using HRMS.ModelDto;
using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Controllers.Other
{
    public class AttendenceController : Controller
    {
        SIContext db = new SIContext();
        double? userid = Convert.ToDouble(Env.GetUserInfo("userid"));
        double? CompanyId = Convert.ToDouble(Env.GetUserInfo("companyid"));
        double? officeid = Convert.ToDouble(Env.GetUserInfo("officeid"));
        public ActionResult PerDay()
        {
            List<IndexDto> rBinder = new List<IndexDto>();
            var LeaveApplicationUser = db.UserLeaveApplications.Where(j =>DbFunctions.TruncateTime(j.LeaveActiveFrom) <= DbFunctions.TruncateTime(DateTime.Now) && DbFunctions.TruncateTime(j.LeaveActiveTo) >= DbFunctions.TruncateTime(DateTime.Now) && j.IsApproved.HasValue && j.IsApproved.Value).Select(j => j.UserId).ToArray();
            var attendenceList = db.UserAttendences.Where(i => DbFunctions.TruncateTime(i.DateOfAttendence) == DbFunctions.TruncateTime(DateTime.Now) && i.User_UserId.OfficeId == officeid).ToArray();
            var userList = db.Users.Where(i => i.OfficeId == officeid).ToArray();
            if (LeaveApplicationUser.Count() > 0)
                userList = userList.Where(i => (!LeaveApplicationUser.Contains(i.Id))).ToArray();
            if (attendenceList.Count() > 0)
                userList = userList.Where(i => (!attendenceList.Select(j => j.UserId).Contains(i.Id))).ToArray();
            if (userList.Count() > 0)
            {
                UserAttendence us = new UserAttendence();
                foreach (var item in userList)
                {
                    us.UserId = item.Id;
                    us.CompanyOfficeId = Convert.ToInt32(officeid);
                    us.DateOfAttendence = DateTime.Now.Date;
                    us.IsPresent = false;
                    us.AnyRemarks = "";
                    us.PunchIn = DateTime.Now;
                    us.PunchOut = DateTime.Now;
                    db.UserAttendences.Add(us);
                    db.SaveChanges();
                }
            }
                var usratt = db.UserAttendences.Where(i => DbFunctions.TruncateTime(i.DateOfAttendence) == DbFunctions.TruncateTime(DateTime.Now) && i.User_UserId.OfficeId == officeid);
                if (usratt.Count() > 0)
                {
                    foreach (var item in usratt)
                    {
                        rBinder.Add(new IndexDto
                        {
                            Id = item.Id,
                            Title = item.Office_CompanyOfficeId.Title,
                            Name = item.User_UserId.UserName,
                            dateEntity = item.DateOfAttendence,
                            PunchIn = item.PunchIn,
                            PunchOut = item.PunchOut,
                            Details = item.AnyRemarks,
                            IsActive = item.IsPresent
                        });
                    }
            }
            return View(rBinder);
        }
        public ActionResult GetGrid()
        {
            var tak = db.UserAttendences.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(),
            Convert.ToString(c.Office_CompanyOfficeId.Title), 
            Convert.ToString(c.User_UserId.UserName), 
            Convert.ToString(c.PunchIn.ToString("hh:mm tt")), 
            Convert.ToString(c.PunchOut.ToString("hh:mm tt")), 
            Convert.ToString(c.DateOfAttendence.ToString("dd-MMM-yyyy")), 
            Convert.ToString(c.IsPresent), 
            Convert.ToString(c.AnyRemarks), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult saveAttendence(int? id, bool Attendence)
        {
            try
            {
                var UserAttendence = db.UserAttendences.Where(i => i.Id == id).FirstOrDefault();

                if (UserAttendence != null)
                {
                    UserAttendence.IsPresent = Attendence;
                    db.SaveChanges();

                }
                return Json(new { aaData = "done" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { aaData = ex }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}