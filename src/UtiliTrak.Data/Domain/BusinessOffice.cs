using System.Collections.Generic;
using Hazeltek.Domain;



namespace Hazeltek.UtiliTrak.Data.Domain
{
    public abstract class OfficeBase: LegalEntity
    {
        /// <summary>
        /// Gets or sets the office code.
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        /// Gets or sets the office alternate code.
        /// </summary>
        public virtual string AltCode { get; set; }

        /// <summary>
        /// Gets or sets the parent office Id.
        /// </summary>
        public virtual int ParentOfficeId { get; set; }

        /// <summary>
        /// Gets or sets the parent office.
        /// </summary>
        public virtual RegionalOffice ParentOffice { get; set; }
    }


    public class RegionalOffice: OfficeBase
    {
        /// <summary>
        /// Gets or sets the sub offices for a regional office.
        /// </summary>
        public virtual IList<OfficeBase> SubOffices { get; set; }
    }


    public class BusinessOffice: OfficeBase
    {
    }    


}