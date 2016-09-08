using System;
using Hazeltek.Domain;



namespace Hazeltek.UtiliTrak.Domain
{
    public abstract class Station: NetworkEntity, IAddressable
    {
        /// <summary>
        /// Gets or sets the station name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the station voltage ratio.
        /// </summary>
        public VoltageRatio VoltageRatio { get; set; }

        /// <summary>
        /// Gets or sets a value which indicates whether the station is a
        /// public or dedicated.
        /// </summary>
        public bool IsPublic { get; set; }

        /// <summary>
        /// Gets or sets the address street.
        /// </summary>
        public string AddressStreet { get; set; }

        /// <summary>
        /// Gets or sets the address town.
        /// </summary>
        public string AddressTown { get; set; }

        /// <summary>
        /// Gets or sets the address postal code.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the address state Id.
        /// </summary>
        public int AddressStateId { get; set; }

        /// <summary>
        /// Gets or sets the address state.
        /// </summary>
        public State AddressState { get; set; }

        /// <summary>
        /// Gets or sets the raw address string.
        /// </summary>
        public string AddressRaw { get; set; }

        /// <summary>
        /// Gets or sets the source feeder Id.
        /// </summary>
        public virtual int SourceFeederId { get; set; }

        /// <summary>
        /// Gets or sets the source feeder.
        /// </summary>
        public virtual PowerLine SourceFeeder { get; set; }

        /// <summary>
        /// Gets or sets the date of commission.
        /// </summary>
        public DateTime DateCommissioned { get; set; }
    }


}