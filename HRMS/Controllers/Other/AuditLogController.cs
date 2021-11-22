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
    public class AuditLogController : BaseController
    {

        // GET: /AuditLog/
        public ActionResult Index()
        {
            return View();
        }

        // GET /AuditLog/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.AuditLogs.ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),             
                Convert.ToString(c.User_UserId.UserName),
                Convert.ToString(c.CreatedDateTime),
                Convert.ToString(c.ModuleName),
                Convert.ToString(c.SubModuleName),
                Convert.ToString(c.ActionFrom),
                Convert.ToString(c.ActionMessage),
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
