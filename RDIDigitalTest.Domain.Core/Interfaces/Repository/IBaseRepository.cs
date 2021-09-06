using System;
using System.Collections.Generic;
using System.Text;

namespace RDIDigitalTest.Domain.Core.Interfaces.Repository
{
    //Base Repository for CRUD operations
    public interface IBaseRepository <TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        //Using IEnumerable instead of List because it's only used for data-viewing
        IEnumerable<TEntity> GetAll(); 

        TEntity GetById(int id);
    }
}
