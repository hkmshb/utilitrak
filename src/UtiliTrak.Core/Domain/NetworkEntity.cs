using System;



namespace Hazeltek.UtiliTrak.Domain
{
    public abstract class NetworkEntity: Entity
    {
        /// <summary>
        /// Gets or sets the network entity code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets an alternative code for the network entity.
        /// </summary>
        public string AltCode { get; set; }
    }


}