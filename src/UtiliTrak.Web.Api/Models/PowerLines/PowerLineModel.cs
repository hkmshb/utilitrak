using Hazeltek.UtiliTrak.Data.Domain.Network;



namespace Hazeltek.UtiliTrak.Web.Api.Models.PowerLines
{
    public class PowerLineModel: NetworkEntityModel
    {
        public Voltage Voltage { get; set; }
        public int LineLength { get; set; }
        public int PoleCount { get; set; }
        public PowerLineType Type { get; set; }
        public int? SourceStationId { get; set; }
    }


}