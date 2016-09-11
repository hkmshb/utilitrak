using System;
using System.Linq;
using Hazeltek.Domain;



namespace Hazeltek.UtiliTrak.Data.Domain.Network
{
    public abstract class Station: NetworkEntity, IAddressable
    {
        // fields:
        private VoltageRatio voltageRatio = VoltageRatio.None;

        /// <summary>
        /// Gets or sets the station name.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the station voltage ratio.
        /// </summary>
        public virtual VoltageRatio VoltageRatio 
        { 
            get { return this.voltageRatio; }
            set {
                if (value != VoltageRatio.None) {
                    if (!GetValidVoltageRatios().Contains(value))
                        throw new ArgumentException();
                }
                this.voltageRatio = value;
            }
        }

        /// <summary>
        /// Gets or sets a value which indicates whether the station is a
        /// public or dedicated.
        /// </summary>
        public virtual bool IsPublic { get; set; }

        /// <summary>
        /// Gets or sets the address street.
        /// </summary>
        public virtual string AddressStreet { get; set; }

        /// <summary>
        /// Gets or sets the address town.
        /// </summary>
        public virtual string AddressTown { get; set; }

        /// <summary>
        /// Gets or sets the address postal code.
        /// </summary>
        public virtual string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the address state Id.
        /// </summary>
        public virtual int AddressStateId { get; set; }

        /// <summary>
        /// Gets or sets the address state.
        /// </summary>
        public virtual State AddressState { get; set; }

        /// <summary>
        /// Gets or sets the raw address string.
        /// </summary>
        public virtual string AddressRaw { get; set; }

        /// <summary>
        /// Gets or sets the source power ilne Id.
        /// </summary>
        public virtual int SourcePowerLineId { get; set; }

        /// <summary>
        /// Gets or sets the source power line.
        /// </summary>
        public virtual PowerLine SourcePowerLine { get; set; }

        /// <summary>
        /// Gets or sets the date of commission.
        /// </summary>
        public virtual DateTime? DateCommissioned { get; set; }

        protected abstract VoltageRatio[] GetValidVoltageRatios();
    }


}