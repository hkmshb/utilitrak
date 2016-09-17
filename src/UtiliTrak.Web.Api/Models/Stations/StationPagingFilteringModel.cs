using Hazeltek.UtiliTrak.Web.Common.Paging;
using Hazeltek.UtiliTrak.Data.Domain.Network;



namespace Hazeltek.UtiliTrak.Web.Api.Models.Stations
{
    public partial class StationPagingFilteringModel: BasePageableModel
    {
        public bool? IsPublic { get; set; }
        public StationType? Type { get; set; }
        public string SourcePowerLineCode { get; set; }
        public VoltageRatio? VoltageRatio { get; set; }
    }

}