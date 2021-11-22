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
using System.Globalization;

namespace HRMS.Controllers.Other
{
    public class ErrorLogController : BaseController
    {

        // GET: ErrorLog
        public ActionResult Index()
        {
            return View();
        }
        // GET ErrorLog/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.ErrorLogs.ToArray();

            var result = from c in tak
                         select new string[] {
                            Convert.ToString(c.Id),
                            Convert.ToString(c.User_UserId.UserName),
                            Convert.ToString(c.CreatedDateTime),
                            //string.Format("{0:dd-MMM-yyyy}",c.CreatedDate),
                            //Convert.ToString(c.CreatedDate),
                            Convert.ToString(c.ErrorFrom),
                            Convert.ToString(c.ErrorFor),
                            Convert.ToString(c.ErrorMessage),
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
