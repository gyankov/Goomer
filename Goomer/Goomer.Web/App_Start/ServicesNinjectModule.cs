using Goomer.Services.Web;
using Goomer.Services.Web.Contracts;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goomer.Web.App_Start
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICacheService>().To<HttpCacheService>();
        }
    }
}