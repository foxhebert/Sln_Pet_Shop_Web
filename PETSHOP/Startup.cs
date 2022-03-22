using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CBX_Web_PetShopWeb.Startup))]
namespace CBX_Web_PetShopWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);//
            app.MapSignalR();
        }
    }
}
