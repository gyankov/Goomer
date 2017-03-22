using Goomer.Data;
using Goomer.Data.Common;
using Goomer.Data.Common.Contracts;
using Goomer.Data.Contracts;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goomer.Web.App_Start
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IApplicationDbContext>().To<ApplicationDbContext>().InRequestScope();
            this.Bind(typeof(IDbRepository<>)).To(typeof(EfRepository<>));
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}