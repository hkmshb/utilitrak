using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using AutoMapper;



namespace Hazeltek.UtiliTrak.Web.Common.TypeMapping
{
    public class AutoMapperAdapter: IAutoMapper
    {
        public TDestination Map<TDestination>(object source)
        {
            return Mapper.Map<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return Mapper.Map<TSource, TDestination>(source, destination);
        }

        public static void LoadMappingsFrom(Assembly assembly)
        {
            var typeToFind = typeof(IAutoMapperTypeConfiguration);
            var mappingTypes = GetMappingTypes(assembly, typeToFind);
            Mapper.Initialize(configurationExpr => {
                foreach (var config in mappingTypes.Select(Activator.CreateInstance)
                                                   .Cast<IAutoMapperTypeConfiguration>()) {
                    config.Configure(configurationExpr); 
                }
            });
        }

        private static IEnumerable<Type> GetMappingTypes(Assembly assembly,
                Type mappingInterface)
        {
            return assembly.GetTypes().Where(
                x => x.GetTypeInfo().IsAbstract == false &&
                     x.GetInterfaces().Any(y => y == mappingInterface)
            );
        }
    }


}