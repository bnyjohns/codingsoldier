using CodingSoldier.Core.Entities;
using CodingSoldier.Core.Repository;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingSoldier.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private CodingSoldierDbContext _dbContext;
        IdentityDbContext<ApplicationUser> _identityDbContext;
        private Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        public UnitOfWork(CodingSoldierDbContext dbContext, IdentityDbContext<ApplicationUser> identityDbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException(nameof(dbContext));
            _dbContext = dbContext as CodingSoldierDbContext;

            _identityDbContext = identityDbContext ?? throw new ArgumentNullException(nameof(identityDbContext));
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if(_repositories.Keys.Contains(typeof(T)))
            {
                return _repositories[typeof(T)] as IRepository<T>;
            }
            IRepository<T> repository = new Repository<T>(_dbContext);
            _repositories.Add(typeof(T), repository);
            return repository;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
