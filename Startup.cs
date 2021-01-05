using Chess20.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Collections.Generic;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management;
using System.Data.Entity;
using Microsoft.SqlServer.Management.Smo;
using Chess20.Common;

[assembly: OwinStartupAttribute(typeof(Chess20.Startup))]

namespace Chess20
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}