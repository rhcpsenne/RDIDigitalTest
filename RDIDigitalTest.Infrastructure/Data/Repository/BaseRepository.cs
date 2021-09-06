using RDIDigitalTest.Domain.Core.Interfaces.Repository;
using RDIDigitalTest.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RDIDigitalTest.Infrastructure.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly LocalDbContext localDbContext;

        public BaseRepository(LocalDbContext localDbContext)
        {
            this.localDbContext = localDbContext;
        }

        public void Add(TEntity obj)
        {
            try
            {
                localDbContext.Set<TEntity>().Add(obj);
                localDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return localDbContext.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return localDbContext.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
