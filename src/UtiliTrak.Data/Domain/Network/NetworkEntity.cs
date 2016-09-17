using Hazeltek.Domain;



namespace Hazeltek.UtiliTrak.Data.Domain.Network
{
    public abstract class NetworkEntity: TimestampedEntity
    {
        /// <summary>
        /// Gets or sets the network entity code.
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        /// Gets or sets an alternative code for the network entity.
        /// </summary>
        public virtual string AltCode { get; set; }

        /// <summary>
        /// Gets or sets whether the network entity is deleted or not.
        /// </summary>
        public virtual bool Deleted  { get; set; }
    }


}