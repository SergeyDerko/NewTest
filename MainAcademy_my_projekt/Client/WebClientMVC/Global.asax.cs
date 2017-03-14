using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TestWcfCommon;

namespace WebClientMVC
{

        public class MvcApplication : HttpApplication
        {
            protected void Application_Start()
            {
                LogInit();
                try
                {
                    AreaRegistration.RegisterAllAreas();
                    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                    RouteConfig.RegisterRoutes(RouteTable.Routes);
                    BundleConfig.RegisterBundles(BundleTable.Bundles);
                }
                catch (Exception e)
                {
                    Logger.Info(e.ToString());
                }

            }

            protected void Application_Error(object sender, EventArgs e)
            {
                Exception exception = Server.GetLastError();
                Response.Clear();

                HttpException httpException = exception as HttpException;

                if (httpException != null)
                {
                    Logger.Exception(httpException);
                }
                else if (exception != null)
                {
                    Logger.Exception(exception);
                }
                else
                {
                    Logger.Error("Беда)))");
                }
            }

            private void LogInit()
            {
                Logger.Level = Config.Get.Log.Level;

                try
                {
                    Logger.Dir = Config.Get.Log.Dir;
                    if (!Directory.Exists(Logger.Dir))
                    {
                        Directory.CreateDirectory(Logger.Dir);
                    }
                }
                catch
                {
                }

                Logger.Prefix = Config.Get.Log.Prefix;
                Logger.Start();

                Logger.Write(Level.Info, "Обращение к сайту");

            }
        }
}
