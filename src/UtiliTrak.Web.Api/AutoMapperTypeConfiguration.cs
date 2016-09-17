using AutoMapper;
using Hazeltek.UtiliTrak.Data.Domain.Network;
using Hazeltek.UtiliTrak.Web.Common.TypeMapping;
using Hazeltek.UtiliTrak.Web.Api.Models.Stations;



namespace Hazeltek.UtiliTrak.Web.Api
{
    public class AutoMapperTypeConfiguration: IAutoMapperTypeConfiguration
    {
        public void Configure(IMapperConfigurationExpression conf)
        {
            // station mapping
            conf.CreateMap<TransmissionStation, StationModel>()
                .ForMember(s => s.Type, x => x.Ignore());
            conf.CreateMap<InjectionSubstation, StationModel>()
                .ForMember(s => s.Type, x => x.Ignore());
            conf.CreateMap<DistributionSubstation, StationModel>()
                .ForMember(s => s.Type, x => x.Ignore());
            conf.CreateMap<StationModel, TransmissionStation>();
            conf.CreateMap<StationModel, InjectionSubstation>();
            conf.CreateMap<StationModel, DistributionSubstation>();
        }
    }


}