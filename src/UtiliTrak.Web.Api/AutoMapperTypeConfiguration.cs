using AutoMapper;
using Hazeltek.UtiliTrak.Data.Domain.Network;
using Hazeltek.UtiliTrak.Web.Common.TypeMapping;
using Hazeltek.UtiliTrak.Web.Api.Models.Stations;
using Hazeltek.UtiliTrak.Web.Api.Models.PowerLines;

namespace Hazeltek.UtiliTrak.Web.Api
{
    public class AutoMapperTypeConfiguration: IAutoMapperTypeConfiguration
    {
        public void Configure(IMapperConfigurationExpression conf)
        {
            // station mapping
            conf.CreateMap<TransmissionStation, StationModel>()
                .ForMember(s => s.Type, x => x.UseValue(StationType.Transmission));
            conf.CreateMap<InjectionSubstation, StationModel>()
                .ForMember(s => s.Type, x => x.UseValue(StationType.Injection));
            conf.CreateMap<DistributionSubstation, StationModel>()
                .ForMember(s => s.Type, x => x.UseValue(StationType.Distribution));
            conf.CreateMap<StationModel, TransmissionStation>();
            conf.CreateMap<StationModel, InjectionSubstation>();
            conf.CreateMap<StationModel, DistributionSubstation>();

            // powerline mapping
            conf.CreateMap<Feeder, PowerLineModel>()
                .ForMember(p => p.Type, x => x.UseValue(PowerLineType.Feeder));
            conf.CreateMap<Upriser, PowerLineModel>()
                .ForMember(p => p.Type, x => x.UseValue(PowerLineType.Upriser));
            conf.CreateMap<PowerLineModel, Feeder>();
            conf.CreateMap<PowerLineModel, Upriser>();
        }
    }


}