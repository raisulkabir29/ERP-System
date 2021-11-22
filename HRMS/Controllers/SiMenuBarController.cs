using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using HRMS.Models;
namespace HRMS.Controllers
{
    public class SiMenuBarController : Controller
    {
        //
        // GET: /SiMenuBar/ 
        public ActionResult Index()
        {
            ViewBag.bar = GetMenuBarPage(null);
            return PartialView();
        }


        public MvcHtmlString GetMenuBarPage(Nullable<int> ParentId)
        {
            StringBuilder sb = new StringBuilder();
            SIContext db = new SIContext();
            //get role id and role regarding to role bind this
            var userId = Convert.ToInt32(Env.GetUserInfo("userid"));
            var RoleId = Convert.ToInt32(Env.GetUserInfo("roleid"));

            var q = db.MenuPermissions.Where(i => i.RoleId == RoleId || i.UserId == userId).ToArray();
            sb.Append("<ul class=\"nav\" id=\"side-menu\">");
            sb.Append("<li class=\"active\"> <a href=\"" + MicrosoftHelper.MSHelper.GetSiteRoot() + "/Home\"> <i class=\"fa fa-dashboard\"></i> <span>Dashboard</span> </a> </li>");
            if (RoleId == 1)
            {
                //get role id here if admin then 
                sb.Append("<li> <a href=\"#\"> <i class=\"fa fa-th\"></i> <span>Menu Management</span> </a>  <ul class=\"nav nav-second-level\"> <li><a href=\"" + MicrosoftHelper.MSHelper.GetSiteRoot() + "/Menu\"><i class=\"fa fa-angle-double-right\"></i> Menu List</a></li> <li><a href=\"" + MicrosoftHelper.MSHelper.GetSiteRoot() + "/Menu/Create\"><i class=\"fa fa-angle-double-right\"></i> Menu Create</a></li> </ul> </li>");

                sb.Append("<li>  <a href=\"#\"> <i class=\"fa fa-th\"></i> <span>Menu Permission</span> </a> <ul class=\"nav nav-second-level\">  <li><a href=\"" + MicrosoftHelper.MSHelper.GetSiteRoot() + "/MenuPermission\"><i class=\"fa fa-angle-double-right\"></i> Permission List</a></li>  <li><a href=\"" + MicrosoftHelper.MSHelper.GetSiteRoot() + "/MenuPermission/Create\"><i class=\"fa fa-angle-double-right\"></i> Create Permission By Role</a></li> </ul> </li>");
                //
            }

            sb.Append(GetMenuBar(ParentId, q));
            sb.Append("</ul>");
            return MvcHtmlString.Create(sb.ToString());
        }




        public MvcHtmlString GetMenuBar(Nullable<int> ParentId, MenuPermission[] q)
        {
            StringBuilder sb = new StringBuilder();
            if (q != null)
            {
                foreach (var item in q.Where(i => i.Menu_MenuId.ParentId == ParentId))
                {
                    var js = q;

                    if (js.Count(j => j.Menu_MenuId.ParentId == item.Menu_MenuId.Id) > 0)
                    {
                        if (item.Menu_MenuId.ParentId == null)
                        {
                            sb.Append("<li> <a href=\"#\"> <i class=\"fa fa-folder\"></i> <span>" + item.Menu_MenuId.MenuText + "</span> <i class=\"fa fa-angle-left pull-right\"></i>  </a><ul class=\"nav nav-second-level\">");
                        }
                        else
                        {
                            sb.Append("<li> <a href=\"#\"> <i class=\"fa fa-folder\"></i> <span>" + item.Menu_MenuId.MenuText + "</span> <i class=\"fa fa-angle-left pull-right\"></i>  </a><ul class=\"nav nav-second-level\">");
                        }
                        sb.Append(GetMenuBar(item.Menu_MenuId.Id, q));
                    }
                    else
                    {
                        if (item.Menu_MenuId.ParentId == null)
                        {
                            sb.Append("<li class=\"\"> <a href=\"" + MicrosoftHelper.MSHelper.GetSiteRoot() + "/" + item.Menu_MenuId.MenuURL + "\"><i class=\"fa fa-angle-double-right\"></i>  " + item.Menu_MenuId.MenuText + "</a></li>");
                        }
                        else
                        {
                            sb.Append("<li class=\"\"> <a href=\"" + MicrosoftHelper.MSHelper.GetSiteRoot() + "/" + item.Menu_MenuId.MenuURL + "\"><i class=\"fa fa-angle-double-right\"></i>  " + item.Menu_MenuId.MenuText + "</a></li>");
                        }

                    }

                }
                sb.Append("</ul>");
            }


            return MvcHtmlString.Create(sb.ToString());
        }
    }
}
