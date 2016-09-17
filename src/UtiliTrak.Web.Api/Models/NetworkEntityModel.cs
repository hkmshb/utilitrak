using System;

namespace Hazeltek.UtiliTrak.Web.Api.Models
{
    public abstract class NetworkEntityModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string AltCode { get; set; }
        public string Name { get; set; }
        public DateTime  DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? DateCommissioned { get; set; }
    }
}