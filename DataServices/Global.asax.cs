using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace DataServices
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var workingFolder = Environment.CurrentDirectory;
            var dbPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName;

            AppDomain.CurrentDomain.SetData("DataDirectory", dbPath);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
