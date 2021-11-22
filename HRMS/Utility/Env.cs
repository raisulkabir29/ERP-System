using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using HRMS.Models;
namespace HRMS
{
    public static class Env
    {
        /// <summary>
        /// Its used for get role id and role name from Claims
        /// </summary>
        /// <param name="s"></param>
        /// <param name="IsRoleID">If you want role ID then pass true , if role name then pass false</param>
        /// <returns></returns>
        public static string GetUserRoleOrUsername(this HtmlHelper s, bool IsRoleID)
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            string role = string.Empty;
            if (IsRoleID == true)
            {
                role = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).SingleOrDefault();
            }
            else
            {
                role = identity.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
            }

            return role;
        }

        /// <summary>
        /// This Method will used for take all data from Claims Cookies 
        /// </summary>
        /// <param name="value">use "name" for Get UserName, 
        /// use "userid" for Get Logedin UserId,
        /// use "company" for Get Company Name,
        /// use "email" for Get Email,
        /// use "roleid" for Get RoleId,
        /// use "rolename" for Get RoleName,
        /// use "image" for Get User Profile Image,
        /// use "theme" for Get Theme (color scheme)
        /// </param>
        /// <returns>String</returns>
        public static string GetUserInfo(string value)
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            string ReturnVal = string.Empty;
            switch (value)
            {
                case "name":
                    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
                    break;
                case "roleid":
                    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).SingleOrDefault();
                    break;
                case "userid":
                    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault();
                    break;
                case "companyid":
                    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.GivenName).Select(c => c.Value).SingleOrDefault();
                    break;
                case "officeid":
                    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();
                    break;
                case "companyName":
                    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.Actor).Select(c => c.Value).SingleOrDefault();
                    break;
                case "officeName":
                    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.Locality).Select(c => c.Value).SingleOrDefault();
                    break;
                //case "image":
                //    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.Picture).Select(c => c.Value).SingleOrDefault();
                //    break;              
                default:
                    ReturnVal = "";
                    break;
            }

            return ReturnVal;

        }

        public static string GetUserImage()
        {
            SIContext db = new SIContext();
            //get role id and role regarding to role bind this
            var userId = Convert.ToInt32(Env.GetUserInfo("userid"));
            var RoleId = Convert.ToInt32(Env.GetUserInfo("roleid"));
            string ReturnVal = string.Empty;

            User ObjUser = db.Users.Find(userId);
            if (ObjUser == null)
            {
                ReturnVal = "";
            }
            else
            {
                ReturnVal = ObjUser.ProfilePicture;
            }
            return ReturnVal;
        }


        public static string Language()
        {
            var currentContext = new HttpContextWrapper(System.Web.HttpContext.Current);
            try
            {
                var routeData = RouteTable.Routes.GetRouteData(currentContext);
                string languageCode = (string)routeData.Values["cultureName"];
                return languageCode.ToLower();
            }
            catch (Exception)
            {
                return "en";
            }

        }

        public static string Decrypt(string cryptedString)
        {
            byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");
            if (String.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException("The string which needs to be decrypted can not be null.");
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);

            return reader.ReadToEnd();
        }

        /// <summary>
        /// Encrypt Method used for Encrypt to any String. you may use this for password encryption and decryption or other string.
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        public static string Encrypt(string originalString)
        {
            byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");
            if (String.IsNullOrEmpty(originalString))
            {
                throw new ArgumentNullException("The string which needs to be encrypted can not be null.");
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);

            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(originalString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            string output = Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            //if (output.Contains('+'))
            //{
            //    output = output.Replace("+", "%2B");
            //}
            return output;
        }

        public static string GetSiteRoot()
        {
            string sOut = "";
            if (System.Web.HttpContext.Current != null)
            {
                string Port = System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
                if (Port == null || Port == "80" || Port == "443")
                    Port = string.Empty;
                else
                    Port = ":" + Port;

                string Protocol = System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];
                if (Protocol == null || Protocol.Equals("0"))
                    Protocol = "http://";
                else
                    Protocol = "https://";

                string appPath = System.Web.HttpContext.Current.Request.ApplicationPath;
                if (appPath == "/")
                    appPath = "";

                sOut = Protocol + System.Web.HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + Port + appPath;
            }
            return sOut;
        }
        public static MvcHtmlString GetMenuBarPage(Nullable<int> ParentId)
        {
            StringBuilder sb = new StringBuilder();
            SIContext db = new SIContext();
            //get role id and role regarding to role bind this
            var userId = Convert.ToInt32(Env.GetUserInfo("userid"));
            var RoleId = Convert.ToInt32(Env.GetUserInfo("roleid"));

            var cacheItemKey = "jApMenuBar" + userId + "Us" + RoleId;

            var globle = HttpRuntime.Cache.Get(cacheItemKey);
            if (globle == null)
            {
                globle = db.MenuPermissions.Where(i => i.RoleId == RoleId || i.UserId == userId).ToArray();
                HttpRuntime.Cache.Insert(cacheItemKey, globle, null, DateTime.Now.AddMinutes(50), System.Web.Caching.Cache.NoSlidingExpiration);
            }

            sb.Append("<ul class=\"sidebar-menu\">");
            sb.Append("<li class=\"active\"> <a href=\"" + MicrosoftHelper.MSHelper.GetSiteRoot() + "/Home\"> <i class=\"fa fa-dashboard\"></i> <span>Dashboard</span> </a> </li>");

            sb.Append(GetMenuBar(ParentId, (MenuPermission[])globle));
            sb.Append("</ul>");
            return MvcHtmlString.Create(sb.ToString());
        }




        private static MvcHtmlString GetMenuBar(Nullable<int> ParentId, MenuPermission[] q)
        {
            StringBuilder sb = new StringBuilder();
            var userId = Convert.ToInt32(Env.GetUserInfo("userid"));
            var RoleId = Convert.ToInt32(Env.GetUserInfo("roleid"));
            if (q != null)
            {
                foreach (var item in q.Where(i => i.Menu_MenuId.ParentId == ParentId && i.UserId == userId).OrderBy(i => i.SortOrder))                
                {
                    var js = q;

                    //if (js.Count(j => j.Menu_MenuId.ParentId == item.Menu_MenuId.Id) > 0)
                    if ( (js.Count(j => j.Menu_MenuId.Id == item.Menu_MenuId.Id) > 0) && (item.Menu_MenuId.ParentId == null))
                    {
                        if (item.Menu_MenuId.ParentId == null)
                        {
                            //sb.Append("<li class=\"treeview\"> <a href=\"#\"> <i class=\"fa fa-folder\"></i> <span>" + item.Menu_MenuId.MenuText + "</span> <i class=\"fa fa-angle-left pull-right\"></i>  </a><ul class=\"treeview-menu\">");
                            sb.Append("<li class=\"treeview " + item.Menu_MenuId.MenuText.Replace(" ", "-").Replace("/", "-").Replace("&", "w") + " " + " \"> <a href=\"#\"> <i class=\"fa fa-folder\"></i> <span>" + item.Menu_MenuId.MenuText + "</span> <i class=\"fa fa-angle-left pull-right\"></i>  </a><ul class=\"treeview-menu\">");

                        }
                        else
                        {
                            //sb.Append("<li class=\"treeview\"> <a href=\"#\"> <i class=\"fa fa-folder\"></i> <span>" + item.Menu_MenuId.MenuText + "</span> <i class=\"fa fa-angle-left pull-right\"></i>  </a><ul class=\"treeview-menu\">");
                            sb.Append("<li class=\"treeview " + item.Menu_MenuId.MenuText.Replace(" ", "-").Replace("/", "-").Replace("&", "w") + " " + "\"> <a href=\"#\"> <i class=\"fa fa-folder\"></i> <span>" + item.Menu_MenuId.MenuText + "</span> <i class=\"fa fa-angle-left pull-right\"></i>  </a><ul class=\"treeview-menu\">");
                        }
                        sb.Append(GetMenuBar(item.Menu_MenuId.Id, q));
                    }
                    else
                    {
                        if (item.Menu_MenuId.ParentId == null)
                        {
                            //sb.Append("<li class=\"\"> <a href=\"" + MicrosoftHelper.MSHelper.GetSiteRoot() + "/" + item.Menu_MenuId.MenuURL + "\"><i class=\"fa fa-angle-double-right\"></i>  " + item.Menu_MenuId.MenuText + "</a></li>");
                            sb.Append("<li class=\" " + item.Menu_MenuId.MenuText.Replace(" ", "-").Replace("/", "-").Replace("&", "w") + " " + " \"> <a href=\"" + MicrosoftHelper.MSHelper.GetSiteRoot() + "/" + item.Menu_MenuId.MenuURL + "\"><i class=\"fa fa-angle-double-right\"></i>  " + item.Menu_MenuId.MenuText + "</a></li>");
                        }
                        else
                        {
                            //sb.Append("<li class=\"\"> <a href=\"" + MicrosoftHelper.MSHelper.GetSiteRoot() + "/" + item.Menu_MenuId.MenuURL + "\"><i class=\"fa fa-angle-double-right\"></i>  " + item.Menu_MenuId.MenuText + "</a></li>");
                            sb.Append("<li class=\" " + item.Menu_MenuId.MenuText.Replace(" ", "-").Replace("/", "-").Replace("&", "w") + " " + " \"> <a href=\"" + MicrosoftHelper.MSHelper.GetSiteRoot() + "/" + item.Menu_MenuId.MenuURL + "\"><i class=\"fa fa-angle-double-right\"></i>  " + item.Menu_MenuId.MenuText + "</a></li>");
                        }

                    }

                }
                sb.Append("</ul>");
            }


            return MvcHtmlString.Create(sb.ToString());
        }

        public static DateTime AddTimeInDate(DateTime comingDate, string time)
        {
            DateTime retrunDate = new DateTime();
            try
            {
                string[] tim = time.Split(':');
                int hour = 00;
                int min = 00;
                try
                {
                    hour = Convert.ToInt32(tim[0]);
                    min = Convert.ToInt32(tim[1]);
                }
                catch (Exception) { }

                System.TimeSpan duration = new System.TimeSpan(hour, min, 0);
                //DateTime finalDate = DateTime.Today + duration;
                DateTime finalDate = comingDate.Date + duration;
                //System.DateTime finalDate = comingDate.Add(duration);

                retrunDate = finalDate;
            }
            catch (Exception)
            {
            }
            return retrunDate;
        }

    }
}
