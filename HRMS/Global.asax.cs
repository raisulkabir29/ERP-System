using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HRMS
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			CultureInfo info = new CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.ToString());
			info.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
			System.Threading.Thread.CurrentThread.CurrentCulture = info;
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;
            ConfigurationService.SetConfiguration();
        }
	}
}

