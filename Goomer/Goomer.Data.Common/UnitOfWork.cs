using Goomer.Data.Common.Contracts;
using Goomer.Data.Contracts;
using System;

namespace Goomer.Data.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private IApplicationDbContext dbContext;

        public UnitOfWork(IApplicationDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException($"{nameof(dbContext)} is null in unit of work!");
            }

            this.dbContext = dbContext;
        }
        public void Commit()
        {
            this.dbContext.SaveChanges();
        }
    }
}
