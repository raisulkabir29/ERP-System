using HRMS.ModelDto;
using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Controllers
{
    public class ReportsController : Controller
    {
        SIContext db = new SIContext();
        StringBuilder sb = new StringBuilder();
        double? userid = Convert.ToDouble(Env.GetUserInfo("userid"));
        double? CompanyId = Convert.ToDouble(Env.GetUserInfo("companyid"));
        double? officeid = Convert.ToDouble(Env.GetUserInfo("officeid"));
        DateTime? nowDate = DateTime.Now.Date;

        [HttpGet]
        public ActionResult Index()
        {
            var Datefrom = Env.AddTimeInDate(Convert.ToDateTime(DateTime.Now), "00:01");
            var Dateto = Env.AddTimeInDate(Convert.ToDateTime(DateTime.Now), "23:59");

            BaseOfReport("00:01", "23:59", Datefrom, Dateto, 1);


            List<IndexDto> rBinder = new List<IndexDto>();
            rBinder.Add(new IndexDto { Id = 1, Title = "Name" });

            return View(rBinder);
        }

        [HttpPost]
        public ActionResult Index(string FromDate, string ToDate, string stime, string etime, string productName)
        {
            var Datefrom = Env.AddTimeInDate(DateTime.ParseExact(FromDate, "MM/dd/yyyy", CultureInfo.InvariantCulture), stime);
            var Dateto = Env.AddTimeInDate(DateTime.ParseExact(ToDate, "MM/dd/yyyy", CultureInfo.InvariantCulture), etime);

            BaseOfReport(stime, etime, Datefrom, Dateto, 0);

            List<IndexDto> rBinder = new List<IndexDto>();
            return View(rBinder);
        }



        [HttpGet]
        public ActionResult AllUserDateWise()
        {
            ViewBag.header = companyDetails();
            var Datefrom = Env.AddTimeInDate(Convert.ToDateTime(DateTime.Now), "00:01");
            var Dateto = Env.AddTimeInDate(Convert.ToDateTime(DateTime.Now), "23:59");

            BaseOfReport("00:01", "23:59", Datefrom, Dateto, 1);
            IEnumerable<User> rBinder = null;
            try
            {
                rBinder = db.Users.Where(i => i.OfficeId == officeid && i.DateAdded >= Datefrom && i.DateAdded <= Dateto).OrderBy(i => i.Id);//date constraint(Now I amm getting according to dateofbirth)
            }
            catch (Exception ex)
            {
                return Content(ex.Message.ToString());
            }
            return View();
        }

        [HttpPost]
        public ActionResult AllUserDateWise(string FromDate, string ToDate)
        {
            ViewBag.header = companyDetails();
            IEnumerable<User> rBinder = null;
            try
            {

                var Datefrom = Env.AddTimeInDate(DateTime.ParseExact(FromDate, "MM/dd/yyyy", CultureInfo.InvariantCulture), DateTime.Now.TimeOfDay.ToString());
                var Dateto = Env.AddTimeInDate(DateTime.ParseExact(ToDate, "MM/dd/yyyy", CultureInfo.InvariantCulture), DateTime.Now.TimeOfDay.ToString());
                BaseOfReport(null, null, Datefrom, Dateto, 0);
                rBinder = db.Users.Where(i => i.OfficeId == officeid && i.DateAdded >= Datefrom && i.DateAdded <= Dateto).OrderBy(i => i.Id);//date constraint(Now I amm getting according to dateofbirth)

            }
            catch (Exception ex) { }

            return View(rBinder);
        }

        [HttpGet]
        public ActionResult SingleUserFull(int? id)
        {
            ViewBag.header = companyDetails();
            userid = id != null ? id : userid;
            ViewBag.UserLists = new SelectList(db.Users.Where(i => i.OfficeId == officeid), "Id", "UserName", userid);

            IndexDto rBinder = new IndexDto();
            try
            {
                rBinder.usr = db.Users.FirstOrDefault(i => i.Id == userid);
                rBinder.usrAllocate = db.UserAllocations.Where(i => i.UserId == userid).FirstOrDefault();
                rBinder.promote = db.UserPromotions.Where(i => i.UserId == userid).ToArray(); ;
                rBinder.userLanguage = db.UserLanguages.Where(i => i.UserId == userid).ToArray();
                rBinder.awd = db.UserAwardss.Where(i => i.UserId == userid).ToArray(); ;
                rBinder.skill = db.UserSkills.Where(i => i.UserId == userid).ToArray();
                rBinder.userEducation = db.UserEducations.Where(i => i.UserId == userid).ToArray();
                rBinder.usrExperience = db.UserWorkExperiences.Where(i => i.UserId == userid).ToArray();
                rBinder.usertravels = db.UserTravelss.Where(i => i.UserId == userid).ToArray();
                rBinder.userPhone = db.UserPhones.Where(i => i.UserId == userid && i.IsActive == true).ToArray();
                rBinder.userAddress = db.UserAddresss.Where(i => i.UserId == userid && i.IsEmergency == true).ToArray();
                rBinder.userEmail = db.UserEmails.Where(i => i.UserId == userid && (i.IsActive == true || i.IsEmergency == true)).ToArray();
                rBinder.usrTermination = db.UserTerminations.Where(i => i.UserId == userid).ToArray();

                return View(rBinder);
            }
            catch (Exception ex)
            {
                return Content(ex.Message.ToString());
            }
        }
        [HttpPost]
        public ActionResult SingleUserFull(double? UserLists)
        {
            ViewBag.header = companyDetails();
            ViewBag.UserLists = new SelectList(db.Users.Where(i => i.OfficeId == officeid), "Id", "UserName", UserLists);

            IndexDto rBinder = new IndexDto();
            try
            {
                rBinder.usr = db.Users.FirstOrDefault(i => i.Id == UserLists);
                rBinder.usrAllocate = db.UserAllocations.Where(i => i.UserId == UserLists).FirstOrDefault();
                rBinder.promote = db.UserPromotions.Where(i => i.UserId == UserLists).ToArray(); ;
                rBinder.userLanguage = db.UserLanguages.Where(i => i.UserId == UserLists).ToArray();
                rBinder.awd = db.UserAwardss.Where(i => i.UserId == UserLists).ToArray(); ;
                rBinder.skill = db.UserSkills.Where(i => i.UserId == UserLists).ToArray();
                rBinder.userEducation = db.UserEducations.Where(i => i.UserId == UserLists).ToArray();
                rBinder.usrExperience = db.UserWorkExperiences.Where(i => i.UserId == UserLists).ToArray();
                rBinder.usertravels = db.UserTravelss.Where(i => i.UserId == UserLists).ToArray();
                rBinder.userPhone = db.UserPhones.Where(i => i.UserId == UserLists && i.IsActive == true).Take(2).ToArray();
                rBinder.userAddress = db.UserAddresss.Where(i => i.UserId == UserLists && i.IsEmergency == true).Take(1).ToArray();
                rBinder.userEmail = db.UserEmails.Where(i => i.UserId == UserLists && (i.IsActive == true || i.IsEmergency == true)).ToArray();
                rBinder.usrTermination = db.UserTerminations.Where(i => i.UserId == UserLists).ToArray();
                return View(rBinder);
            }
            catch (Exception ex)
            {
                return Content(ex.Message.ToString());
            }
        }

        [HttpGet]
        public ActionResult OfficeFull()
        {
            ViewBag.header = companyDetails();
            var Datefrom = Env.AddTimeInDate(Convert.ToDateTime(DateTime.Now), "00:01");
            var Dateto = Env.AddTimeInDate(Convert.ToDateTime(DateTime.Now), "23:59");

            BaseOfReport("00:01", "23:59", Datefrom, Dateto, 1);
            return View(db.Offices.Where(i => DbFunctions.TruncateTime(i.CreatedOn) >= DbFunctions.TruncateTime(Datefrom) && DbFunctions.TruncateTime(i.CreatedOn) <= DbFunctions.TruncateTime(Dateto)));
        }
        [HttpPost]
        public ActionResult OfficeFull(string FromDate, string ToDate)
        {
            ViewBag.header = companyDetails();
            try
            {

                DateTime Datefrom = Env.AddTimeInDate(DateTime.ParseExact(FromDate, "MM/dd/yyyy", CultureInfo.InvariantCulture), DateTime.Now.TimeOfDay.ToString());
                DateTime Dateto = Env.AddTimeInDate(DateTime.ParseExact(ToDate, "MM/dd/yyyy", CultureInfo.InvariantCulture), DateTime.Now.TimeOfDay.ToString());
                BaseOfReport(null, null, Datefrom, Dateto, 0);
                return View(db.Offices.Where(i => DbFunctions.TruncateTime(i.CreatedOn) >= DbFunctions.TruncateTime(Datefrom) && DbFunctions.TruncateTime(i.CreatedOn) <= DbFunctions.TruncateTime(Dateto)));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult HollydayYearWise()
        {
            ViewBag.header = companyDetails();
            try
            {
                var HolidayList = db.Holidays.Where(i => i.HolidayDate.Year == DateTime.Now.Year);
                ViewBag.timestring = sb.AppendLine("<div style=\"text-align:center;font-size:18px;font-weight:bold;\">From 01-Jan-" + DateTime.Now.Year + " To 12-Dec-" + DateTime.Now.Year + " </div>");
                return View(HolidayList);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }
        [HttpPost]
        public ActionResult HollydayYearWise(string from, string to)
        {
            ViewBag.header = companyDetails();
            try
            {
                DateTime Datefrom = DateTime.ParseExact(from, "yyyy", CultureInfo.InvariantCulture);
                DateTime Dateto = DateTime.ParseExact(to, "yyyy", CultureInfo.InvariantCulture);
                var HolidayList = db.Holidays.Where(i => i.HolidayDate.Year >= Datefrom.Year && i.HolidayDate.Year <= Dateto.Year).OrderBy(i => i.Id);
                ViewBag.timestring = sb.AppendLine("<div style=\"text-align:center;font-size:18px;font-weight:bold;\">From: 01-Jan-" + from + " To 01-Dec-" + to + " </div>");
                return View(HolidayList);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }
        [HttpGet]
        public ActionResult DepartmentsList()
        {
            ViewBag.header = companyDetails();
            try
            {
                var deptList = db.Departments.Where(i => i.Office_OfficeId.CompanyId == CompanyId);
                ViewBag.officeList = new SelectList(db.Offices.Where(i => i.CompanyId == CompanyId), "Id", "Title");
                return View(deptList);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult DepartmentsList(int? OfficeList)
        {
            ViewBag.header = companyDetails();
            try
            {
                var deptList = db.Departments.Where(i => i.OfficeId == OfficeList);
                ViewBag.officeList = new SelectList(db.Offices.Where(i => i.CompanyId == CompanyId), "Id", "Title", OfficeList);
                return View(deptList);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult Announcement()
        {
            ViewBag.header = companyDetails();
            try
            {
                var Datefrom = Env.AddTimeInDate(Convert.ToDateTime(DateTime.Now), "00:01");
                var Dateto = Env.AddTimeInDate(Convert.ToDateTime(DateTime.Now), "23:59");
                BaseOfReport("00:01", "23:59", Datefrom, Dateto, 1);
                var AnnouncementList = db.AnnouncementOrNotes.Where(i => !i.IsNote && DbFunctions.TruncateTime(i.PostedDate) >= DbFunctions.TruncateTime(Datefrom) && DbFunctions.TruncateTime(i.PostedDate) <= DbFunctions.TruncateTime(Dateto));
                return View(AnnouncementList);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Announcement(string FromDate, string ToDate)
        {
            ViewBag.header = companyDetails();
            try
            {

                var Datefrom = Env.AddTimeInDate(DateTime.ParseExact(FromDate, "MM/dd/yyyy", CultureInfo.InvariantCulture), "00:01");
                var Dateto = Env.AddTimeInDate(DateTime.ParseExact(ToDate, "MM/dd/yyyy", CultureInfo.InvariantCulture), "23:59");
                BaseOfReport("00:01", "23:59", Datefrom, Dateto, 1);
                var AnnouncementList = db.AnnouncementOrNotes.Where(i => i.PostedDate >= Datefrom && i.PostedDate <= Dateto && !i.IsNote).OrderBy(i => i.Id);
                return View(AnnouncementList);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult Note()
        {
            ViewBag.header = companyDetails();
            try
            {
                var Datefrom = Env.AddTimeInDate(Convert.ToDateTime(DateTime.Now), "00:01");
                var Dateto = Env.AddTimeInDate(Convert.ToDateTime(DateTime.Now), "23:59");
                BaseOfReport("00:01", "23:59", Datefrom, Dateto, 1);
                var NoteList = db.AnnouncementOrNotes.Where(i => i.IsNote && DbFunctions.TruncateTime(i.PostedDate) >= DbFunctions.TruncateTime(Datefrom) && DbFunctions.TruncateTime(i.PostedDate) <= DbFunctions.TruncateTime(Dateto));
                return View(NoteList);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }
        [HttpPost]
        public ActionResult Note(string FromDate, string ToDate)
        {
            ViewBag.header = companyDetails();
            try
            {

                var Datefrom = Env.AddTimeInDate(DateTime.ParseExact(FromDate, "MM/dd/yyyy", CultureInfo.InvariantCulture), "00:01");
                var Dateto = Env.AddTimeInDate(DateTime.ParseExact(ToDate, "MM/dd/yyyy", CultureInfo.InvariantCulture), "23:59");
                BaseOfReport("00:01", "23:59", Datefrom, Dateto, 1);
                var NoteList = db.AnnouncementOrNotes.Where(i => i.PostedDate >= Datefrom && i.PostedDate <= Dateto && i.IsNote).OrderBy(i => i.Id);
                return View(NoteList);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult policy()
        {
            ViewBag.header = companyDetails();
            List<IndexDto> rBinder = new List<IndexDto>();
            try
            {
                var PolicyList = db.Policys.Where(i => i.Office_OfficeId.CompanyId == CompanyId).ToArray();
                foreach (var item in PolicyList)
                {
                    rBinder.Add(new IndexDto { Id = item.Id, officeTitle = item.Office_OfficeId.Title, Title = item.Title, Details = item.Description, filename = item.Attachment });
                }
                ViewBag.officeList = new SelectList(db.Offices.Where(i => i.CompanyId == CompanyId), "Id", "Title");

            }
            catch (Exception ex)
            { }
            return View(rBinder);

        }
        [HttpPost]
        public ActionResult policy(int? officeList)
        {
            ViewBag.header = companyDetails();
            List<IndexDto> rBinder = new List<IndexDto>();
            try
            {
                var PolicyList = db.Policys.Where(i => i.OfficeId == officeList);
                foreach (var item in PolicyList)
                {
                    rBinder.Add(new IndexDto { Id = item.Id, Title = item.Title, Details = item.Description, filename = item.Attachment });
                } ViewBag.officeList = officeList.HasValue ? new SelectList(db.Offices.Where(i => i.CompanyId == CompanyId), "Id", "Title", officeList.Value) : new SelectList(db.Offices.Where(i => i.CompanyId == CompanyId), "Id", "Title");

            }

            catch (Exception ex)
            { }
            return View(rBinder);
        }
        [HttpGet]
        public ActionResult Expense()
        {
            ViewBag.header = companyDetails();
            var ExpenseData = db.Expenses.Where(i => DbFunctions.TruncateTime(i.PurchaseDate) == DbFunctions.TruncateTime(DateTime.Now)).ToArray();
            var officeDetail = db.Offices.FirstOrDefault(i => i.Id == officeid);
            sb.AppendLine("<div style=\"text-align:center;font-size:24px;font-weight:bold;margin-left:15px;\">" + officeDetail.Company_CompanyId.Name + "</div>");
            sb.AppendLine("<div id=\"customer\">");
            sb.AppendLine("<div id=\"customer-title\">" + officeDetail.Title + "(" + officeDetail.Code + ")<br />" + officeDetail.City + "/" + officeDetail.Country + "/" + officeDetail.ZipCode + "</div>");
            sb.AppendLine("<table id=\"meta\">");
            sb.AppendLine("<tr><td class=\"meta-head\">Phone#</td><td><div>" + officeDetail.Company_CompanyId.Phone + "</div></td></tr>");
            sb.AppendLine("<tr><td class=\"meta-head\">Fax#</td><td><div>" + officeDetail.Fax + "</div></td></tr>");
            sb.AppendLine("<tr><td class=\"meta-head\">Website#</td><td><div>" + officeDetail.Company_CompanyId.Website + "</div></td></tr>");
            sb.AppendLine("<tr><td class=\"meta-head\">Purchase From#</td><td><div>" + DateTime.Now.ToString("dd-MMM-yyyy") + "</div></td></tr>");
            sb.AppendLine("<tr><td class=\"meta-head\">Purchase To#</td><td><div>" + DateTime.Now.ToString("dd-MMM-yyyy") + "</div></td></tr>");
            sb.AppendLine(" </table>");
            sb.AppendLine("</div>");
            ViewBag.CompanyDetails = sb.ToString();
            ViewBag.amt = ExpenseData.Sum(i => i.Amount).ToString();
            ViewBag.dt = string.Format("{0:dd-MMM-yyyy}", DateTime.Now);
            return View(ExpenseData);
        }
        [HttpPost]
        public ActionResult Expense(string FromDate, string toDate)
        {
            ViewBag.header = companyDetails();
            DateTime? dt = null;
            var Datefrom = Env.AddTimeInDate(DateTime.ParseExact(FromDate, "MM/dd/yyyy", CultureInfo.InvariantCulture), DateTime.Now.TimeOfDay.ToString());
            var Dateto = Env.AddTimeInDate(DateTime.ParseExact(toDate, "MM/dd/yyyy", CultureInfo.InvariantCulture), DateTime.Now.TimeOfDay.ToString());
            BaseOfReport(null, null, Datefrom, Dateto, 0);
            var ExpenseData = db.Expenses.Where(i => DbFunctions.TruncateTime(i.PurchaseDate) >= DbFunctions.TruncateTime(Datefrom) && DbFunctions.TruncateTime(i.PurchaseDate) <= DbFunctions.TruncateTime(Dateto)).ToArray();
            var officeDetail = db.Offices.FirstOrDefault(i => i.Id == officeid);
            sb.AppendLine("<div style=\"text-align:center;font-size:30px;font-weight:bold;margin-left:15px;\">" + officeDetail.Company_CompanyId.Name + "</div>");
            sb.AppendLine("<div id=\"customer\">");
            sb.AppendLine("<div id=\"customer-title\">" + officeDetail.Title + "(" + officeDetail.Code + ")<br />" + officeDetail.City + "/" + officeDetail.Country + "/" + officeDetail.ZipCode + "</div>");
            sb.AppendLine("<table id=\"meta\">");
            sb.AppendLine("<tr><td class=\"meta-head\">Phone#</td><td><div>" + officeDetail.Company_CompanyId.Phone + "</div></td></tr>");
            sb.AppendLine("<tr><td class=\"meta-head\">Fax#</td><td><div>" + officeDetail.Fax + "</div></td></tr>");
            sb.AppendLine("<tr><td class=\"meta-head\">Website#</td><td><div>" + officeDetail.Company_CompanyId.Website + "</div></td></tr>");
            sb.AppendLine("<tr><td class=\"meta-head\">Purchase From#</td><td><div>" + Datefrom.ToString("dd-MMM-yyyy") + "</div></td></tr>");
            sb.AppendLine("<tr><td class=\"meta-head\">Purchase To#</td><td><div>" + Dateto.ToString("dd-MMM-yyyy") + "</div></td></tr>");
            sb.AppendLine(" </table>");
            sb.AppendLine("</div>");
            ViewBag.CompanyDetails = sb.ToString();
            ViewBag.amt = ExpenseData.Sum(i => i.Amount).ToString();
            return View(ExpenseData);
        }
        [HttpGet]
        public ActionResult SingleUserAttendence(int? id)
        {
			userid=id.HasValue?id.Value:userid;
            ViewBag.header = companyDetails();
            var UserDetails = db.Users.FirstOrDefault(i => i.Id == userid);
            var attendence = db.UserAttendences.Where(i => i.UserId == userid && i.DateOfAttendence.Month == DateTime.Now.Month);
            sb.AppendLine("<div style=\"text-align:center;font-size:24px;font-weight:bold;margin-left:15px;\">" + UserDetails.FirstName + " " + UserDetails.LastName + "</div>");
            sb.AppendLine("<div id=\"customer\">");
            //sb.AppendLine("<div id=\"customer-title\">" + officeDetail.Title + "(" + officeDetail.Code + ")<br />" + officeDetail.City + "/" + officeDetail.Country + "/" + officeDetail.ZipCode + "</div>");
            sb.AppendLine("<table id=\"meta\" style=\"float:left;\">");
            sb.AppendLine("<tr><td class=\"meta-head\">UserName#</td><td><div>" + UserDetails.UserName + "</div></td></tr>");
            sb.AppendLine("<tr><td class=\"meta-head\">DOB#</td><td><div>" + string.Format("{0:dd-MMM-yyyy}", UserDetails.DateOfBirth) + "</div></td></tr>");
            sb.AppendLine("<tr><td class=\"meta-head\">Nationality#</td><td><div>" + UserDetails.Nationality + "</div></td></tr>");
            if (attendence != null)
            {
                sb.AppendLine("<tr><td class=\"meta-head\">Attendence Month#</td><td><div>" + string.Format("{0:dd-MMM-yyyy}", DateTime.Now.Month) + "</div></td></tr>");
            }
            sb.AppendLine(" </table>");
            sb.AppendLine("</div>");
            ViewBag.Users = new SelectList(db.Users.Where(i => i.OfficeId == officeid), "Id", "UserName",userid);

            return View(attendence);
        }
        [HttpPost]
        public ActionResult SingleUserAttendence(double? Users, string monthyear)
        {
            ViewBag.header = companyDetails();
            DateTime date = DateTime.ParseExact(monthyear, "MM/yyyy", CultureInfo.InvariantCulture);
            var UserDetails = db.Users.FirstOrDefault();
            if (Users > 0)
                UserDetails = db.Users.Where(i => i.Id == Users).FirstOrDefault();
            else
                UserDetails = db.Users.Where(i => i.Id == userid).FirstOrDefault();
            var attendence = db.UserAttendences.Where(i => i.UserId == UserDetails.Id && i.DateOfAttendence.Month == date.Month);

            sb.AppendLine("<div style=\"text-align:center;font-size:24px;font-weight:bold;margin-left:15px;\">" + UserDetails.FirstName + " " + UserDetails.LastName + "</div>");
            sb.AppendLine("<div id=\"customer\">");
            //sb.AppendLine("<div id=\"customer-title\">" + officeDetail.Title + "(" + officeDetail.Code + ")<br />" + officeDetail.City + "/" + officeDetail.Country + "/" + officeDetail.ZipCode + "</div>");
            sb.AppendLine("<table id=\"meta\" style=\"float:left;\">");
            sb.AppendLine("<tr><td class=\"meta-head\">UserName#</td><td><div>" + UserDetails.UserName + "</div></td></tr>");
            sb.AppendLine("<tr><td class=\"meta-head\">DOB#</td><td><div>" + string.Format("{0:dd-MMM-yyyy}", UserDetails.DateOfBirth) + "</div></td></tr>");
            sb.AppendLine("<tr><td class=\"meta-head\">Nationality#</td><td><div>" + UserDetails.Nationality + "</div></td></tr>");
            if (attendence != null)
            {
                sb.AppendLine("<tr><td class=\"meta-head\">Attendence Month#</td><td><div>" + string.Format("{0:dd-MMM-yyyy}", DateTime.Now.Month) + "</div></td></tr>");
            }
            sb.AppendLine(" </table>");
            sb.AppendLine("</div>");
            ViewBag.Users = new SelectList(db.Users.Where(i => i.OfficeId == officeid), "Id", "UserName");

            return View(attendence);
        }
        [HttpGet]
        public ActionResult UserAttendence()
        {
            ViewBag.header = companyDetails();
            var Datefrom = Env.AddTimeInDate(Convert.ToDateTime(DateTime.Now), "00:01");
            var Dateto = Env.AddTimeInDate(Convert.ToDateTime(DateTime.Now), "23:59");
            BaseOfReport("00:01", "23:59", Datefrom, Dateto, 1);
            var attndnceList = db.UserAttendences.Where(i => DbFunctions.TruncateTime(i.DateOfAttendence) == DbFunctions.TruncateTime(DateTime.Now));
            return View(attndnceList);
        }
        [HttpPost]
        public ActionResult UserAttendence(string FromDate, string ToDate)
        {
            ViewBag.header = companyDetails();
            List<UserAttendence> rBinder = new List<UserAttendence>();
            try
            {
                var Datefrom = Env.AddTimeInDate(DateTime.ParseExact(FromDate, "MM/dd/yyyy", CultureInfo.InvariantCulture), "00:01");
                var Dateto = Env.AddTimeInDate(DateTime.ParseExact(ToDate, "MM/dd/yyyy", CultureInfo.InvariantCulture), "23:59");
                BaseOfReport("00:01", "23:59", Datefrom, Dateto, 1);
                DateTime dtFrom = DateTime.ParseExact(FromDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                DateTime dtTo = DateTime.ParseExact(ToDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                ViewBag.UserList = new SelectList(db.Users.Where(i => i.OfficeId == officeid), "Id", "UserName");
                rBinder = db.UserAttendences.Where(i => DbFunctions.TruncateTime(i.DateOfAttendence) >= DbFunctions.TruncateTime(dtFrom) && DbFunctions.TruncateTime(i.DateOfAttendence) <= DbFunctions.TruncateTime(dtTo)).ToList();
            }
            catch (Exception ex)
            {
            }
            return View(rBinder);
        }
        [HttpGet]
        public ActionResult Termination()
        {
            ViewBag.header = companyDetails();
            var username = db.Users.Where(i => i.Id == userid).FirstOrDefault();
            ViewBag.UserList = new SelectList(db.Users.Where(i => i.OfficeId == officeid), "Id", "UserName");
            try
            {
                var Datefrom = Env.AddTimeInDate(Convert.ToDateTime(DateTime.Now), "00:01");
                var Dateto = Env.AddTimeInDate(Convert.ToDateTime(DateTime.Now), "23:59");
                BaseOfReport("00:01", "23:59", Datefrom, Dateto, 1);
                var UserTerminate = db.UserTerminations.Where(i => i.TerminationDate == nowDate).ToArray();
                return View(UserTerminate);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Termination(string FromDate, string ToDate)
        {
            ViewBag.header = companyDetails();
            List<UserTermination> rBinder = new List<UserTermination>();
            try
            {

                var Datefrom = Env.AddTimeInDate(DateTime.ParseExact(FromDate, "MM/dd/yyyy", CultureInfo.InvariantCulture), "00:01");
                var Dateto = Env.AddTimeInDate(DateTime.ParseExact(ToDate, "MM/dd/yyyy", CultureInfo.InvariantCulture), "23:59");
                BaseOfReport("00:01", "23:59", Datefrom, Dateto, 1);
                DateTime dtFrom = DateTime.ParseExact(FromDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                DateTime dtTo = DateTime.ParseExact(ToDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                ViewBag.UserList = new SelectList(db.Users.Where(i => i.OfficeId == officeid), "Id", "UserName");
                var UserTerminate = db.UserTerminations.Where(i => i.TerminationDate >= dtFrom && i.TerminationDate <= dtTo).ToArray();
                if (UserTerminate.Count() > 0)
                {
                    foreach (var item in UserTerminate)
                    {
                        rBinder.Add(new UserTermination { NoticeDate = item.NoticeDate, TerminationDate = item.TerminationDate, TerminationReason = item.TerminationReason, Description = item.Description, IsResignation = item.IsResignation.HasValue, ResignationApproveDate = item.ResignationApproveDate });
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return View(rBinder);
        }
        [HttpGet]
        public ActionResult SingleTermination(int? id)
        {
			userid=id.HasValue?id.Value:userid;
            ViewBag.header = companyDetails();
            List<UserTermination> rBinder = new List<UserTermination>();
            var username = db.Users.Where(i => i.Id == userid).FirstOrDefault();
            ViewBag.UserName = username.FirstName + " " + username.LastName;
            ViewBag.UserList = new SelectList(db.Users.Where(i => i.OfficeId == officeid), "Id", "UserName",userid);
            try
            {
                var UserTerminate = db.UserTerminations.Where(i => i.UserId == userid).ToArray();
                if (UserTerminate.Count() > 0)
                {
                    foreach (var item in UserTerminate)
                    {
                        rBinder.Add(new UserTermination { NoticeDate = item.NoticeDate, TerminationDate = item.TerminationDate, TerminationReason = item.TerminationReason, Description = item.Description, IsResignation = item.IsResignation.HasValue, ResignationApproveDate = item.ResignationApproveDate });
                    }
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(rBinder);
        }
        [HttpPost]
        public ActionResult SingleTermination(double? UserList)
        {
            ViewBag.header = companyDetails();
            List<UserTermination> rBinder = new List<UserTermination>();
            var username = db.Users.Where(i => i.Id == UserList).FirstOrDefault();
            ViewBag.UserName = username.FirstName + " " + username.LastName;
            ViewBag.UserList = new SelectList(db.Users.Where(i => i.OfficeId == officeid), "Id", "UserName");
            try
            {
                var UserTerminate = db.UserTerminations.Where(i => i.UserId == UserList).ToArray();
                if (UserTerminate.Count() > 0)
                {
                    foreach (var item in UserTerminate)
                    {
                        rBinder.Add(new UserTermination { NoticeDate = item.NoticeDate, TerminationDate = item.TerminationDate, TerminationReason = item.TerminationReason, Description = item.Description, IsResignation = item.IsResignation.HasValue, ResignationApproveDate = item.ResignationApproveDate });
                    }
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(rBinder);
        }
        [HttpGet]
        public ActionResult SingleUserPayroll(int? id)
        {
			userid=id.HasValue?id.Value:userid;
            ViewBag.header = companyDetails();
            try
            {
                var UserDetails = db.Users.FirstOrDefault(i => i.Id == userid);
                var salaryDetails = db.UserPayrollSalarys.FirstOrDefault(i => i.UserId == userid);
                sb.AppendLine("<div style=\"text-align:center;font-size:30px;font-weight:bold;margin-left:15px;\">" + UserDetails.FirstName + " " + UserDetails.LastName + "</div>");
                sb.AppendLine("<div id=\"customer\">");
                //sb.AppendLine("<div id=\"customer-title\">" + officeDetail.Title + "(" + officeDetail.Code + ")<br />" + officeDetail.City + "/" + officeDetail.Country + "/" + officeDetail.ZipCode + "</div>");
                sb.AppendLine("<table id=\"meta\" style=\"float:left;\">");
                sb.AppendLine("<tr><td class=\"meta-head\">UserName#</td><td><div>" + UserDetails.UserName + "</div></td></tr>");
                sb.AppendLine("<tr><td class=\"meta-head\">DOB#</td><td><div>" + string.Format("{0:dd-MMM-yyyy}", UserDetails.DateOfBirth) + "</div></td></tr>");
                sb.AppendLine("<tr><td class=\"meta-head\">Nationality#</td><td><div>" + UserDetails.Nationality + "</div></td></tr>");
                sb.AppendLine(" </table>");
                sb.AppendLine("</div>");
                ViewBag.usersalary = sb.ToString();
                ViewBag.Users = new SelectList(db.Users.Where(i => i.OfficeId == officeid), "Id", "UserName",userid);
                return View(salaryDetails);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult SingleUserPayroll(double? Users)
        {
            ViewBag.header = companyDetails();
            ViewBag.Users = new SelectList(db.Users.Where(i => i.OfficeId == officeid), "Id", "UserName", Users);
            try
            {
                var UserDetails = db.Users.FirstOrDefault(i => i.Id == Users);
                var salaryDetails = db.UserPayrollSalarys.FirstOrDefault(i => i.UserId == Users);
                sb.AppendLine("<div style=\"text-align:center;font-size:24px;font-weight:bold;margin-left:15px;\">" + UserDetails.FirstName + " " + UserDetails.LastName + "</div>");
                sb.AppendLine("<div id=\"customer\">");
                //sb.AppendLine("<div id=\"customer-title\">" + officeDetail.Title + "(" + officeDetail.Code + ")<br />" + officeDetail.City + "/" + officeDetail.Country + "/" + officeDetail.ZipCode + "</div>");
                sb.AppendLine("<table id=\"meta\" style=\"float:left;\">");
                sb.AppendLine("<tr><td class=\"meta-head\">UserName#</td><td><div>" + UserDetails.UserName + "</div></td></tr>");
                sb.AppendLine("<tr><td class=\"meta-head\">DOB#</td><td><div>" + string.Format("{0:dd-MMM-yyyy}", UserDetails.DateOfBirth) + "</div></td></tr>");
                sb.AppendLine("<tr><td class=\"meta-head\">Nationality#</td><td><div>" + UserDetails.Nationality + "</div></td></tr>");
                sb.AppendLine("<tr><td class=\"meta-head\">Date of Payment#</td><td><div>#</div></td></tr>");
                sb.AppendLine(" </table>");
                sb.AppendLine("</div>");
                ViewBag.usersalary = sb.ToString();
                return View(salaryDetails);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }
        [HttpGet]
        public ActionResult FullYearSalarySlip(int? id)
        {
			userid=id.HasValue?id.Value:userid;
            ViewBag.header = companyDetails();
            try
            {
                var UserDetails = db.Users.FirstOrDefault(i => i.Id == userid);
                var salaryDetails = db.UserSalaryTransactions.Where(i => i.UserId == userid && i.OnDate.Year == DateTime.Now.Year);
                var designation = db.UserAllocations.Where(i => i.UserId == userid).FirstOrDefault();
                sb.AppendLine("<div style=\"text-align:center;font-size:24px;font-weight:bold;margin-left:15px;\">" + UserDetails.FirstName + " " + UserDetails.LastName + "</div>");
                sb.AppendLine("<div id=\"customer\">");
                sb.AppendLine("<table id=\"meta\" style=\"float:left;\">");
                sb.AppendLine("<tr><td class=\"meta-head\">UserName#</td><td><div>" + UserDetails.UserName + "</div></td></tr>");
                sb.AppendLine("<tr><td class=\"meta-head\">DOB#</td><td><div>" + string.Format("{0:dd-MMM-yyyy}", UserDetails.DateOfBirth) + "</div></td></tr>");
                sb.AppendLine("<tr><td class=\"meta-head\">Nationality#</td><td><div>" + UserDetails.Nationality + "</div></td></tr>");
                if (designation != null)
                {
                    if (designation.JobTitleId.HasValue)
                    {
                        sb.AppendLine("<tr><td class=\"meta-head\">Designation#</td><td><div>" + designation.JobTitle_JobTitleId.Name + "</div></td></tr>");
                    }
                    else
                    {
                        sb.AppendLine("<tr><td class=\"meta-head\">Designation#</td><td><div>" + "-" + "</div></td></tr>");
                    }
                }
                else
                {
                    sb.AppendLine("<tr><td class=\"meta-head\">Designation#</td><td><div>" + "-" + "</div></td></tr>");
                }

                sb.AppendLine(" </table>");
                sb.AppendLine("</div>");
                ViewBag.usersalary = sb.ToString();
                ViewBag.Users = new SelectList(db.Users.Where(i => i.OfficeId == officeid), "Id", "UserName",userid);
                ViewBag.timestring = sb.AppendLine("<div style=\"text-align:center;font-size:18px;font-weight:bold;\">From 01-Jan-" + DateTime.Now.Year + " To 12-Dec-" + DateTime.Now.Year + " </div>");
                ViewBag.year = DateTime.Now.Year;
                return View(salaryDetails);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult FullYearSalarySlip(double? Users, string year)
        {
            ViewBag.header = companyDetails();
            try
            {
                DateTime date = DateTime.ParseExact(year, "yyyy", CultureInfo.InvariantCulture);
                var UserDetails = db.Users.FirstOrDefault(i => i.Id == Users);
                var salaryDetails = db.UserSalaryTransactions.Where(i => i.UserId == Users && i.OnDate.Year == date.Year);
                var designation = db.UserAllocations.Where(i => i.UserId == userid).FirstOrDefault();
                sb.AppendLine("<div style=\"text-align:center;font-size:24px;font-weight:bold;margin-left:15px;\">" + UserDetails.FirstName + " " + UserDetails.LastName + "</div>");
                sb.AppendLine("<div id=\"customer\">");
                //sb.AppendLine("<div id=\"customer-title\">" + officeDetail.Title + "(" + officeDetail.Code + ")<br />" + officeDetail.City + "/" + officeDetail.Country + "/" + officeDetail.ZipCode + "</div>");
                sb.AppendLine("<table id=\"meta\" style=\"float:left;\">");
                sb.AppendLine("<tr><td class=\"meta-head\">UserName#</td><td><div>" + UserDetails.UserName + "</div></td></tr>");
                sb.AppendLine("<tr><td class=\"meta-head\">DOB#</td><td><div>" + string.Format("{0:dd-MMM-yyyy}", UserDetails.DateOfBirth) + "</div></td></tr>");
                sb.AppendLine("<tr><td class=\"meta-head\">Nationality#</td><td><div>" + UserDetails.Nationality + "</div></td></tr>");
                if (designation != null)
                {
                    if (designation.JobTitleId.HasValue)
                    {
                        sb.AppendLine("<tr><td class=\"meta-head\">Designation#</td><td><div>" + designation.JobTitle_JobTitleId.Name + "</div></td></tr>");
                    }
                    else
                    {
                        sb.AppendLine("<tr><td class=\"meta-head\">Designation#</td><td><div>" + "-" + "</div></td></tr>");
                    }
                }
                else
                {
                    sb.AppendLine("<tr><td class=\"meta-head\">Designation#</td><td><div>" + "-" + "</div></td></tr>");
                }
                sb.AppendLine(" </table>");
                sb.AppendLine("</div>");
                ViewBag.usersalary = sb.ToString();
                ViewBag.Users = new SelectList(db.Users.Where(i => i.OfficeId == officeid), "Id", "UserName");
                ViewBag.timestring = sb.AppendLine("<div style=\"text-align:center;font-size:18px;font-weight:bold;\">From 01-Jan-" + date.Year + " To 12-Dec-" + date.Year + " </div>");
                ViewBag.year = year;
                return View(salaryDetails);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult SalarySlip(int? id)
        {
			userid=id.HasValue?id.Value:userid;
            ViewBag.header = companyDetails();
            var UserDetails = db.Users.FirstOrDefault(i => i.Id == userid);
            var salaryDetails = db.UserSalaryTransactions.FirstOrDefault(i => i.UserId == userid && i.OnDate.Month == DateTime.Now.Month);
            var designation = db.UserAllocations.Where(i => i.UserId == userid).FirstOrDefault();
            sb.AppendLine("<div style=\"text-align:center;font-size:24px;font-weight:bold;margin-left:15px;\">" + UserDetails.FirstName + " " + UserDetails.LastName + "</div>");
            sb.AppendLine("<div id=\"customer\">");
            //sb.AppendLine("<div id=\"customer-title\">" + officeDetail.Title + "(" + officeDetail.Code + ")<br />" + officeDetail.City + "/" + officeDetail.Country + "/" + officeDetail.ZipCode + "</div>");
            sb.AppendLine("<table id=\"meta\" style=\"float:left;\">");
            sb.AppendLine("<tr><td class=\"meta-head\">UserName#</td><td><div>" + UserDetails.UserName + "</div></td></tr>");
            sb.AppendLine("<tr><td class=\"meta-head\">DOB#</td><td><div>" + string.Format("{0:dd-MMM-yyyy}", UserDetails.DateOfBirth) + "</div></td></tr>");
            sb.AppendLine("<tr><td class=\"meta-head\">Nationality#</td><td><div>" + UserDetails.Nationality + "</div></td></tr>");
            if (designation != null)
            {
                if (designation.JobTitleId.HasValue)
                {
                    sb.AppendLine("<tr><td class=\"meta-head\">Designation#</td><td><div>" + designation.JobTitle_JobTitleId.Name + "</div></td></tr>");
                }
                else
                {
                    sb.AppendLine("<tr><td class=\"meta-head\">Designation#</td><td><div>" + "-" + "</div></td></tr>");
                }
            }
            else
            {
                sb.AppendLine("<tr><td class=\"meta-head\">Designation#</td><td><div>" + "-" + "</div></td></tr>");
            }
            if (salaryDetails != null)
            {
                sb.AppendLine("<tr><td class=\"meta-head\">Date of Payment#</td><td><div>" + string.Format("{0:dd-MMM-yyyy}", salaryDetails.OnDate) + "</div></td></tr>");
            }
            sb.AppendLine(" </table>");
            sb.AppendLine("</div>");
            ViewBag.usersalary = sb.ToString();
            ViewBag.Users = new SelectList(db.Users.Where(i => i.OfficeId == officeid), "Id", "UserName",userid);
            return View(salaryDetails);
        }
        [HttpPost]
        public ActionResult SalarySlip(double? Users)
        {
            ViewBag.header = companyDetails();
            ViewBag.Users = new SelectList(db.Users.Where(i => i.OfficeId == officeid), "Id", "UserName", Users);
            try
            {
                var UserDetails = db.Users.FirstOrDefault(i => i.Id == Users);
                var salaryDetails = db.UserSalaryTransactions.FirstOrDefault(i => i.UserId == Users && i.OnDate.Month == DateTime.Now.Month);
                var designation = db.UserAllocations.Where(i => i.UserId == userid).FirstOrDefault();
                sb.AppendLine("<div style=\"text-align:center;font-size:24px;font-weight:bold;margin-left:15px;\">" + UserDetails.FirstName + " " + UserDetails.LastName + "</div>");
                sb.AppendLine("<div id=\"customer\">");
                //sb.AppendLine("<div id=\"customer-title\">" + officeDetail.Title + "(" + officeDetail.Code + ")<br />" + officeDetail.City + "/" + officeDetail.Country + "/" + officeDetail.ZipCode + "</div>");
                sb.AppendLine("<table id=\"meta\" style=\"float:left;\">");
                sb.AppendLine("<tr><td class=\"meta-head\">UserName#</td><td><div>" + UserDetails.UserName + "</div></td></tr>");
                sb.AppendLine("<tr><td class=\"meta-head\">DOB#</td><td><div>" + string.Format("{0:dd-MMM-yyyy}", UserDetails.DateOfBirth) + "</div></td></tr>");
                sb.AppendLine("<tr><td class=\"meta-head\">Nationality#</td><td><div>" + UserDetails.Nationality + "</div></td></tr>");
                if (designation != null)
                {
                    if (designation.JobTitleId.HasValue)
                    {
                        sb.AppendLine("<tr><td class=\"meta-head\">Designation#</td><td><div>" + designation.JobTitle_JobTitleId.Name + "</div></td></tr>");
                    }
                    else
                    {
                        sb.AppendLine("<tr><td class=\"meta-head\">Designation#</td><td><div>" + "-" + "</div></td></tr>");
                    }
                }
                else
                {
                    sb.AppendLine("<tr><td class=\"meta-head\">Designation#</td><td><div>" + "-" + "</div></td></tr>");
                } if (salaryDetails != null)
                {
                    sb.AppendLine("<tr><td class=\"meta-head\">Date of Payment#</td><td><div>" + string.Format("{0:dd-MMM-yyyy}", salaryDetails.OnDate) + "</div></td></tr>");
                } sb.AppendLine(" </table>");
                sb.AppendLine("</div>");
                ViewBag.usersalary = sb.ToString();
                return View(salaryDetails);
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        [HttpGet]
        public ActionResult PerUserLeaveApplication(int? id)
        {
			userid=id.HasValue?id.Value:userid;
            ViewBag.header = companyDetails();
            List<IndexDto> rBinder = new List<IndexDto>();
            var username = db.Users.Where(i => i.Id == userid).FirstOrDefault();
            ViewBag.UserName = username.FirstName + " " + username.LastName;
            ViewBag.UserList = new SelectList(db.Users.Where(i => i.OfficeId == officeid), "Id", "UserName",userid);
            try
            {
                var UserLeaveApps = db.UserLeaveApplications.Where(i => i.UserId == userid).ToArray();
                if (UserLeaveApps.Count() > 0)
                {
                    foreach (var item in UserLeaveApps)
                    {
                        rBinder.Add(new IndexDto { Name = item.LeaveType_LeaveTypeId.Name, FromDate = item.LeaveActiveFrom, ToDate = item.LeaveActiveTo, status = (!item.IsApproved.HasValue) ? "Pending" : ((item.IsApproved.Value) ? "Approved" : "Not-Approved"), ApprovedBy = (item.ApprovedBy == null) ? "---" : db.Users.Where(i => i.Id == item.ApprovedBy).FirstOrDefault().UserName });
                    }
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(rBinder);
        }
        [HttpPost]
        public ActionResult PerUserLeaveApplication(double? UserList)
        {
            ViewBag.header = companyDetails();
            List<IndexDto> rBinder = new List<IndexDto>();
            var username = db.Users.Where(i => i.Id == userid).FirstOrDefault();
            ViewBag.UserName = username.FirstName + " " + username.LastName;
            ViewBag.UserList = new SelectList(db.Users.Where(i => i.OfficeId == officeid), "Id", "UserName");
            try
            {
                var UserLeaveApps = db.UserLeaveApplications.Where(i => i.UserId == UserList).ToArray();
                if (UserLeaveApps.Count() > 0)
                {
                    foreach (var item in UserLeaveApps)
                    {
                        rBinder.Add(new IndexDto { Name = item.LeaveType_LeaveTypeId.Name, FromDate = item.LeaveActiveFrom, ToDate = item.LeaveActiveTo, status = (!item.IsApproved.HasValue) ? "Pending" : ((item.IsApproved.Value) ? "Approved" : "Not-Approved"), ApprovedBy = (item.ApprovedBy == null) ? "---" : db.Users.Where(i => i.Id == item.ApprovedBy).FirstOrDefault().UserName });
                    }
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(rBinder);
        }
        [HttpGet]
        public ActionResult UserContacts(int? id)
        {
			userid=id.HasValue?id.Value:userid;
            ViewBag.header = companyDetails();
            ViewBag.UserList = new SelectList(db.Users.Where(i => i.OfficeId == officeid), "Id", "UserName",userid);
            IndexDto rBinder = new IndexDto();
            try
            {
                var UserDetail = db.Users.FirstOrDefault(i => i.Id == userid);
                rBinder.Name = UserDetail.FirstName + " " + UserDetail.LastName;
                rBinder.userAddress = db.UserAddresss.Where(i => i.UserId.Value == UserDetail.Id).ToArray();
                rBinder.userEmail = db.UserEmails.Where(i => i.UserId.Value == UserDetail.Id).ToArray();
                rBinder.userPhone = db.UserPhones.Where(i => i.UserId.Value == UserDetail.Id).ToArray();
            }
            catch (Exception ex)
            { }
            return View(rBinder);

        }
        [HttpPost]
        public ActionResult UserContacts(double? UserList)
        {
            ViewBag.header = companyDetails();
            ViewBag.UserList = new SelectList(db.Users.Where(i => i.OfficeId == officeid), "Id", "UserName", UserList);
            IndexDto rBinder = new IndexDto();
            try
            {
                var UserDetail = db.Users.FirstOrDefault(i => i.Id == UserList);
                rBinder.Name = UserDetail.FirstName + " " + UserDetail.LastName;
                rBinder.userAddress = db.UserAddresss.Where(i => i.UserId.Value == UserDetail.Id).ToArray();
                rBinder.userEmail = db.UserEmails.Where(i => i.UserId.Value == UserDetail.Id).ToArray();
                rBinder.userPhone = db.UserPhones.Where(i => i.UserId.Value == UserDetail.Id).ToArray();
            }
            catch (Exception ex)
            { }
            return View(rBinder);
        }
        [HttpGet]
        public ActionResult Interviews()
        {
            ViewBag.header = companyDetails();
            try
            {
                var Datefrom = Env.AddTimeInDate(Convert.ToDateTime(DateTime.Now), "00:01");
                var Dateto = Env.AddTimeInDate(Convert.ToDateTime(DateTime.Now), "23:59");
                BaseOfReport("00:01", "23:59", Datefrom, Dateto, 1);
                return View(db.Interviews);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Interviews(string FromDate, string ToDate)
        {
            ViewBag.header = companyDetails();
            try
            {
                DateTime dtFrom = Env.AddTimeInDate(DateTime.ParseExact(FromDate, "MM/dd/yyyy", CultureInfo.InvariantCulture), DateTime.Now.TimeOfDay.ToString());
                DateTime dtTo = Env.AddTimeInDate(DateTime.ParseExact(ToDate, "MM/dd/yyyy", CultureInfo.InvariantCulture), DateTime.Now.TimeOfDay.ToString());
                BaseOfReport("00:01", "23:59", dtFrom, dtTo, 1);
                var Interviews = db.Interviews.Where(i => i.InterviewDate >= dtFrom && i.InterviewDate <= dtTo);
                return View(Interviews);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }
        [HttpGet]
        public ActionResult InterviewsPerUser(int? id)
        {
			userid=id.HasValue?id.Value:userid;
            ViewBag.header = companyDetails();
            var userLists = db.Users.Where(i => i.OfficeId == officeid);
            ViewBag.InterviewUsers = new SelectList(db.Interviews.Where(i => userLists.Select(us => us.Id).Contains(i.InterviewBy)), "Id", "CandidateName",userid);
            try
            {
                var InterviewList = db.Interviews.Where(i => i.Id==userid).FirstOrDefault();
                if (InterviewList != null)
                {

                    var user = db.Users.Where(i => i.Id == InterviewList.InterviewBy).FirstOrDefault();
                    ViewBag.InterviewBy = user.FirstName + " " + user.LastName;
                    return View(InterviewList);
                }
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpPost]
        public ActionResult InterviewsPerUser(double? InterviewUsers)
        {
            ViewBag.header = companyDetails();
            var userLists = db.Users.Where(i => i.OfficeId == officeid);
            ViewBag.InterviewUsers = new SelectList(db.Interviews.Where(i => userLists.Select(us => us.Id).Contains(i.InterviewBy)), "Id", "CandidateName");
            try
            {
                var InterviewList = db.Interviews.Where(i => i.Id == InterviewUsers).FirstOrDefault();
                if (InterviewList != null)
                {
                    var user = db.Users.Where(i => i.Id == InterviewList.InterviewBy).FirstOrDefault();
                    ViewBag.InterviewBy = user.FirstName + " " + user.LastName;
                    return View(InterviewList);
                }
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private void BaseOfReport(string stime, string etime, DateTime Datefrom, DateTime Dateto, int IsGet)
        {
            StringBuilder sb = new StringBuilder();
            ViewBag.FromDate = Datefrom.ToString("MM/dd/yyyy");
            ViewBag.ToDate = Dateto.ToString("MM/dd/yyyy");

            ViewBag.stime = stime;
            ViewBag.etime = etime;
            ViewBag.timess = IsGet;

            try
            {
                ViewBag.start = Datefrom;
                ViewBag.end = Dateto;
                ViewBag.timestring = sb.AppendLine("<div style=\"text-align:center;font-size:18px;font-weight:bold;\"> " + Datefrom + " to " + Dateto + "  </div>");
            }
            catch (Exception)
            {
            }
        }
        private string companyDetails()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                var companyDetails = db.Companys.Where(i => i.Id == CompanyId).FirstOrDefault();
                sb.AppendLine("<div class=\"col-xs-12\" style=\"border-bottom:2px black groove;\">");
                sb.AppendLine("<div class=\"col-xs-2\">");
                sb.AppendLine("<img src=\"" + Env.GetSiteRoot() + "/uploads/" + companyDetails.Logo + "\" alt=\"logo\" height=\"100px\" />");
                sb.AppendLine("</div>");
                sb.AppendLine("<div class=\"col-xs-10\">");
                sb.AppendLine("<div style=\"text-align:right;font-size:30px;font-weight:bold;\">" + companyDetails.Name + "</div>");
                sb.AppendLine("<div style=\"text-align:right;font-size:16px;font-weight:bold;\">" + companyDetails.Address + "</div>");
                sb.AppendLine("<div style=\"text-align:right;font-size:16px;font-weight:bold;\">" + companyDetails.Phone + "</div>");
                sb.AppendLine("<div style=\"text-align:right;font-size:16px;font-weight:bold;\">" + companyDetails.Website + "</div>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
            }
            catch (Exception)
            {
            }
            return sb.ToString();
        }

    }
}