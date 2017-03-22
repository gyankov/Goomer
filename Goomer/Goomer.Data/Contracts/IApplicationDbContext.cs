using Goomer.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Contracts
{
    public interface IApplicationDbContext
    {
        IDbSet<Tire> Tires { get; set; }

        IDbSet<Rim> Rims { get; set; }

        IDbSet<RimWithTire> RimsWithTires { get; set; }

        IDbSet<RimPicture> RimPictures { get; set; }

        IDbSet<TirePicture> TirePictures { get; set; }

        IDbSet<RimWithTirePicture> RimWithTirePictures { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
        
    }
}
