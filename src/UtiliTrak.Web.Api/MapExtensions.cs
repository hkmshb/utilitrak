using Hazeltek.Infrastructure;
using Hazeltek.UtiliTrak.Web.Common.TypeMapping;

namespace Hazeltek.UtiliTrak.Web.Api
{
    public static class MappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            var mapper = EngineContext.Current.Resolve<IAutoMapper>();
            return mapper.Map<TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source,
               TDestination destination)
        {
            var mapper = EngineContext.Current.Resolve<IAutoMapper>();
            return mapper.Map<TSource, TDestination>(source, destination);
        } 
    }


}