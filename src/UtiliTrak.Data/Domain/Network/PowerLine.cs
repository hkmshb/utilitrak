using System;
using System.Linq;



namespace Hazeltek.UtiliTrak.Data.Domain.Network
{
    public abstract class PowerLine: NetworkEntity
    {
        // fields:
        private Voltage voltage = Voltage.None;

        /// <summary>
        /// Gets or sets the powerline name.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the powerline voltage.
        /// </summary>
        public virtual Voltage Voltage 
        { 
            get { return this.voltage; }
            set {
                if (value != Voltage.None) {
                    if (!GetValidVoltages().Contains(value))
                        throw new ArgumentException();
                }
                this.voltage = value;
            }
        }

        /// <summary>
        /// Gets or sets the approximate line length in meters.
        /// </summary>
        public virtual int LineLength { get; set; }

        /// <summary>
        /// Gets or sets the approximate pole count.
        /// </summary>
        public virtual int PoleCount { get; set; }

        /// <summary>
        /// Gets or sets the powerline source station Id.
        /// </summary>
        public virtual int? SourceStationId { get; set; }

        /// <summary>
        /// Gets or sets the powerline source station.
        /// </summary>
        public virtual Station SourceStation { get; set; }

        /// <summary>
        /// Gets or sets the date powerline was commissioned.
        /// </summary>
        public virtual DateTime? DateCommissioned { get; set; }

        protected abstract Voltage[] GetValidVoltages();
    }


}