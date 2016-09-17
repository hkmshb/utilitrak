using System;
using Hazeltek.UtiliTrak.Data.Domain.Network;



namespace Hazeltek.UtiliTrak.Web.Api.Models.Stations
{
    public class StationModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string AltCode { get; set; }
        public string Name { get; set; }
        public VoltageRatio VoltageRatio { get; set; }
        public int? SourcePowerLineId { get; set; }
        public StationType Type { get; set; }
        public bool IsPublic { get; set; }
        public string AddressStreet { get; set; }        
        public string AddressTown { get; set; }
        public string PostalCode { get; set; }
        public int? AddressStateId { get; set; }
        public string AddressRaw { get; set; }
        public DateTime  DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? DateCommissioned { get; set; }
    }


}