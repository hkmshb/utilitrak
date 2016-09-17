using Hazeltek.UtiliTrak.Web.Common.Paging;
using Hazeltek.UtiliTrak.Data.Domain.Network;



namespace Hazeltek.UtiliTrak.Web.Api.Models.PowerLines
{
    public class PowerLinePagingFilteringModel: BasePageableModel
    {
        public Voltage? Voltage { get; set; }
        public PowerLineType? Type { get; set; }
        public string SourceStationCode { get; set; }
    }


}