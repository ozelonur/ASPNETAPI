using System.Reflection;
using Autofac;
using KPSS.Core.Repositories;
using KPSS.Core.Services;
using KPSS.Core.UnitOfWorks;
using KPSS.Repository;
using KPSS.Repository.Repositories;
using KPSS.Repository.UnitOfWorks;
using KPSS.Service.Mapping;
using KPSS.Service.Services;
using Module = Autofac.Module;

namespace KPSS.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(ServiceWithDto<,>)).As(typeof(IServiceWithDto<,>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ProductServiceWithDto>().As<IProductServiceWithDto>().InstancePerLifetimeScope();
            
            Assembly apiAssembly = Assembly.GetExecutingAssembly();
            Assembly repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            Assembly serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            // builder.RegisterType<ProductServiceWithCaching>().As<IProductService>();

        }
    }
}

