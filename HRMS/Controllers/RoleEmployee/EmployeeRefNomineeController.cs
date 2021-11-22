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
    public class EmployeeRefNomineeController : BaseController
    {

        // GET: /EmployeeRefNominee/
        public ActionResult Index()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                var userId = Convert.ToInt32(Env.GetUserInfo("userid"));
                if (userId == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                UserRefNominee ObjUserRefNominee = db.UserRefNominees.Find(userId);
                return View(ObjUserRefNominee);
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "EmployeeRefNominee - Create",
                    ErrorFrom = "EmployeeRefNomineeController.Create",
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
