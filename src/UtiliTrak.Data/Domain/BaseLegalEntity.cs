using Hazeltek.Domain;


namespace Hazeltek.UtiliTrak.Data.Domain
{
    public class BaseLegalEntity: LegalEntity
    {
        /// <summary>
        /// Gets or sets whether legal entity is deleted or not.
        /// </summary>
        public virtual bool Deleted { get; set; }
    }


}