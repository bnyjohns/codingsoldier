using CodingSoldier.Core.Repository;
using System;

namespace CodingSoldier.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;
    }
}
