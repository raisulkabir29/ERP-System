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

namespace HRMS.Controllers
{
    public class EmployeeController : BaseController
    {

        // GET: /Employee/
        public ActionResult Index()
        {
            var userId = Convert.ToInt32(Env.GetUserInfo("userid"));
            if (userId == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User ObjUser = db.Users.Find(userId);
            if (ObjUser == null)
            {
                return HttpNotFound();
            }
            return View(ObjUser);
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
