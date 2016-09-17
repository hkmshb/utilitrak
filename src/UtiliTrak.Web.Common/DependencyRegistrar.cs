using Autofac;
using Hazeltek.Data.EFx;
using Hazeltek.Data.Common;
using Hazeltek.Configuration;
using Hazeltek.Infrastructure;
using Hazeltek.UtiliTrak.Services.Network;
using Hazeltek.Infrastructure.DependencyManagement;
using Hazeltek.UtiliTrak.Web.Common.TypeMapping;

namespace Hazeltek.UtiliTrak.Web.Common
{
    public class DependencyRegistrar: IDependencyRegistrar
    {
        /// <summary>
        /// Gets the ordinal/position of the task amongst other such IStartupTasks.
        /// </summary>
        public int Order 
        { 
            get { return 0; } 
        }

        /// <summary>
        /// Register services and interfaces.
        /// </summary>
        /// <param name="builder">Container builder.</param>
        /// <param name="typeFinder">Type finder.</param>
        /// <param name="config">Config.</param>
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder,
               IConfig config)
        {
            // data layer
            var dataSettingsManager = new DataSettingsManager();
            var dataProviderSettings = dataSettingsManager.LoadSettings();
            builder.Register(c => dataSettingsManager.LoadSettings()).As<DataSettings>();
            builder.Register(c => new EfDataProviderManager(c.Resolve<DataSettings>()))
                   .As<BaseDataProviderManager>().InstancePerDependency();
            builder.Register(c => c.Resolve<BaseDataProviderManager>().LoadDataProvider())
                   .As<IDataProvider>().InstancePerDependency();
            
            // missing more ...

            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>))
                   .InstancePerLifetimeScope();
            
            builder.RegisterInstance(new AutoMapperAdapter()).As<IAutoMapper>()
                   .SingleInstance();
                   
            // services
            builder.RegisterType<StationService>().As<IStationService>()
                   .InstancePerLifetimeScope();
            builder.RegisterType<PowerLineService>().As<IPowerLineService>()
                   .InstancePerLifetimeScope();
        }
    }


}