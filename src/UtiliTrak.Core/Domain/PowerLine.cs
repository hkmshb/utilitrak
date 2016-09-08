using System;



namespace Hazeltek.UtiliTrak.Domain
{
    public class PowerLine: NetworkEntity
    {
        /// <summary>
        /// Gets or sets the powerline name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the powerline voltage.
        /// </summary>
        public Voltage Voltage { get; set; }

        /// <summary>
        /// Gets or sets the powerline source station Id.
        /// </summary>
        public int SourceStationId { get; set; }

        /// <summary>
        /// Gets or sets the powerline source station.
        /// </summary>
        public virtual Station SourceStation { get; set; }

        /// <summary>
        /// Gets or sets the date powerline was commissioned.
        /// </summary>
        public DateTime DateCommissioned { get; set; }
    }


}