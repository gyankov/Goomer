using Goomer.Data.Models.BaseModels;
using Goomer.Data.Contracts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Infrastructure;

namespace Goomer.Data.Common
{
    public class EfRepository<T> : IDbRepository<T>
       where T : class, IAuditInfo, IDeletableEntity
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IDbSet<T> dbSet;
        public EfRepository(IApplicationDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", nameof(context));
            }

            this.dbContext = context;
            this.dbSet = this.dbContext.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.dbSet.Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return this.dbSet;
        }

        public T GetById(object id)
        {
            var item = this.dbSet.Find(id);
            if (item.IsDeleted)
            {
                return null;
            }

            return item;
        }

        public void Add(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
        }

        public void HardDelete(T entity)
        {
            this.dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        private DbEntityEntry AttachIfDetached(T entity)
        {
            var entry = this.dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            return entry;
        }
    }
}
