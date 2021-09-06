using FluentValidation;
using RDIDigitalTest.Domain.Core.Interfaces.Repository;
using RDIDigitalTest.Domain.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDIDigitalTest.Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            baseRepository.Add(obj);

            return obj;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return baseRepository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return baseRepository.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            baseRepository.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            baseRepository.Update(obj);
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Not found!");

            validator.ValidateAndThrow(obj);
        }
    }
}
