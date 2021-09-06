using Autofac;
using AutoMapper;
using RDIDigitalTest.Application.ApplicationServices;
using RDIDigitalTest.Application.AutoMapper;
using RDIDigitalTest.Application.Interfaces;
using RDIDigitalTest.Domain.Core.Interfaces.Repository;
using RDIDigitalTest.Domain.Core.Interfaces.Service;
using RDIDigitalTest.Domain.Services;
using RDIDigitalTest.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDIDigitalTest.Infrastructure.CrossCuting.IOC
{
    public class ConfigurationIOC
    {
        /// <summary>
        /// Loads the inversion of control
        /// </summary>
        /// <param name="builder"></param>
        public static void Load(ContainerBuilder builder)
        {
            #region Dependency Injection
            builder.RegisterType<CostumerCardApplicationService>().As<ICostumerCardApplicationService>();
            builder.RegisterType<CostumerCardService>().As<ICostumerCardService>();
            builder.RegisterType<CostumerCardRepository>().As<ICostumerCardRepository>();
            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            }));
            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
            #endregion
        }
    }
}
