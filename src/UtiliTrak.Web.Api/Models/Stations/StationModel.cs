using Hazeltek.UtiliTrak.Data.Domain.Network;



namespace Hazeltek.UtiliTrak.Web.Api.Models.Stations
{
    public class StationModel: NetworkEntityModel
    {
        public VoltageRatio VoltageRatio { get; set; }
        public int? SourcePowerLineId { get; set; }
        public StationType Type { get; set; }
        public bool IsPublic { get; set; }
        public string AddressStreet { get; set; }        
        public string AddressTown { get; set; }
        public string PostalCode { get; set; }
        public int? AddressStateId { get; set; }
        public string AddressRaw { get; set; }
    }


}