using AutoMapper;



namespace Hazeltek.UtiliTrak.Web.Common.TypeMapping
{
    public interface IAutoMapperTypeConfiguration
    {
        void Configure(IMapperConfigurationExpression configurationExpr);
    }


}