using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.ModelDto;
using HRMS.Models;
using System.Data.Entity;
namespace HRMS.Controllers
{
    public class HomeController : BaseController
    {
        double? userid = Convert.ToDouble(Env.GetUserInfo("userid"));
        double? CompanyId = Convert.ToDouble(Env.GetUserInfo("companyid"));
        double? officeid = Convert.ToDouble(Env.GetUserInfo("officeid"));
        double? RoleId = Convert.ToInt32(Env.GetUserInfo("roleid"));

        public ActionResult Index()
        {
            HomeDto home = new HomeDto();

            using (SIContext db = new SIContext())
            {
                var expenseAmount = db.Expenses.Where(i => i.OfficeId == officeid && DbFunctions.TruncateTime(i.PurchaseDate) == DbFunctions.TruncateTime(DateTime.Now)).ToArray();
                home.Menu = db.Menus.Count();
                home.Role = db.Roles.Count();
                home.User = db.Users.Count();
                home.Offce = db.Offices.Where(i => i.CompanyId == CompanyId).Count();
                home.Department = db.Departments.Where(i => i.Office_OfficeId.CompanyId == CompanyId).Count();
                home.Interviews = db.Interviews.Where(i => i.InterviewBy == userid && DbFunctions.TruncateTime(i.InterviewDate) == DbFunctions.TruncateTime(DateTime.Now)).Count();
                //home.Interviews = db.Interviews.Where(i => i.InterviewBy == userid).Count();
                home.Expense = expenseAmount.Count() > 0 ? Convert.ToDecimal(expenseAmount.Sum(i => i.Amount)) : Convert.ToDecimal(0.0);
                home.PresentEmployee = db.UserAttendences.Where(i => i.User_UserId.OfficeId == officeid && i.IsPresent && DbFunctions.TruncateTime(i.DateOfAttendence) == DbFunctions.TruncateTime(DateTime.Now)).Count();
                home.AbsentEmployees = db.UserAttendences.Where(i => i.User_UserId.OfficeId == officeid && !i.IsPresent && DbFunctions.TruncateTime(i.DateOfAttendence) == DbFunctions.TruncateTime(DateTime.Now)).Count();
                home.LeaveEmployess = db.UserLeaveApplications.Where(i => i.User_UserId.OfficeId == officeid && i.IsApproved.HasValue && i.IsApproved == true && DbFunctions.TruncateTime(i.LeaveActiveFrom) <= DbFunctions.TruncateTime(DateTime.Now) && DbFunctions.TruncateTime(i.LeaveActiveTo) >= DbFunctions.TruncateTime(DateTime.Now)).Count();
                home.Holidays = db.Holidays.Where(i => i.OfficeId == officeid && i.HolidayDate.Month == DateTime.Now.Month).Count();
                home.Announcement = db.AnnouncementOrNotes.Where(i => i.OfficeId == officeid && !i.IsNote).Count();
                home.Notes = db.AnnouncementOrNotes.Where(i => i.OfficeId == officeid && i.IsNote).Count();
                home.Policy = db.Policys.Where(i => i.OfficeId == officeid).Count();
            }

            return View(home);

        }


        public class DateTable
        {
            public DateTime DateAdded { get; set; }

        }


        public JsonResult LineChart(int lastDay = 7)
        {
            SIContext db = new Models.SIContext();

            List<GraphData> dataList = new List<GraphData>();

            var LastDays = DateTime.Now.Date.AddDays(-lastDay);

            ///listDateTable just add your table where have date field like db.User
            var LastRegister = db.UserAllocations.Where(i => i.AllocationFrom >= LastDays).ToArray();

            for (int i = 0; i < lastDay; i++)
            {
                var dateDynamic = DateTime.Now.Date.AddDays(-i);
                int year = dateDynamic.Year;
                int month = dateDynamic.Month;
                int day = dateDynamic.Day;

                DateTime newDate = new DateTime(year, month, day);
                var hav = LastRegister.Count(j => j.AllocationFrom.Date == newDate.Date);
                if (hav > 0)
                {
                    GraphData gdata = new GraphData();
                    gdata.label = newDate.ToString("yyyy-MM-dd");
                    gdata.value = hav;
                    dataList.Add(gdata);
                }
                else
                {
                    GraphData gdata = new GraphData();
                    gdata.label = newDate.ToString("yyyy-MM-dd");
                    gdata.value = 0;
                    dataList.Add(gdata);
                }

            }

            return Json(dataList, JsonRequestBehavior.AllowGet);
        }
        private class GraphData
        {
            public string label { get; set; }
            public decimal? value { get; set; }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
