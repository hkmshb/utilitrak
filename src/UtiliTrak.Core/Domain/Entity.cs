using System;
using Hazeltek.Data.Common;



namespace Hazeltek.UtiliTrak.Domain
{
    public abstract class Entity: BaseEntity
    {
        /// <summary>
        /// Gets or sets the date entity was created.
        /// </summary>
        public virtual DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date entity was last updated.
        /// </summary>
        public virtual DateTime LastUpdated { get; set; }
    }


}