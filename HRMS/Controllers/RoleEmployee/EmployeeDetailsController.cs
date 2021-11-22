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
    public class EmployeeDetailsController : BaseController
    {

        // GET: /EmployeeDetails/
        public ActionResult Index()
        {
            //var userId = Convert.ToInt32(Env.GetUserInfo("userid"));
            //if (userId == 0)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //UserDetails ObjUserDetails = db.UserDetailss.Find(userId);
            //if (ObjUserDetails == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(ObjUserDetails);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                var userId = Convert.ToInt32(Env.GetUserInfo("userid"));
                if (userId == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                UserDetails ObjUserDetails = db.UserDetailss.Find(userId);
                return View(ObjUserDetails);
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
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
