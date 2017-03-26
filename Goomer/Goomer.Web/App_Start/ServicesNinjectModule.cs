using Goomer.Services.Data;
using Goomer.Services.Data.Contracts;
using Goomer.Services.Web;
using Goomer.Services.Web.Contracts;
using Goomer.Web.Infrastructure.FileSystem;
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
            this.Bind<IUsersService>().To<UsersService>();
            this.Bind<IStatisticsService>().To<StatisticsService>();
            this.Bind<ICacheService>().To<HttpCacheService>();
            this.Bind<ITiresService>().To<TiresService>();
            this.Bind<IRimsService>().To<RimsService>();
            this.Bind<IRimsWithTiresService>().To<RimsWithTyresService>();
            this.Bind<IFileSaver>().To<FileSaver>();
            this.Bind<IIdentifierProvider>().To<IdentifierProvider>();

        }
    }
}