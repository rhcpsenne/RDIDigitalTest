using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDIDigitalTest.Domain.Core.Interfaces.Service
{
    public interface IBaseService <TEntity> where  TEntity : class
    {
        TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;

        void Update(TEntity obj);

        void Remove(TEntity obj);

        //Using IEnumerable instead of List because it's only used for data-viewing
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);
    }
}
