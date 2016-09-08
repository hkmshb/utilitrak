using System;
using Hazeltek.Domain;


namespace Hazeltek.UtiliTrak.Domain
{
    public class Manufacturer: Entity
    {
        // fields:
        private string shortName = string.Empty;

        /// <summary>
        /// Gets or sets the manufacturer name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer short name.
        /// </summary>
        public string ShortName 
        { 
            get {
                if (!string.IsNullOrWhiteSpace(this.shortName))
                    return this.shortName;
                return this.Name;
            }
            set { this.shortName = value; } 
        }

        /// <summary>
        /// Gets or sets the manufacturer email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer phone.
        /// </summary>
        public string PhoneNo { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer web url.
        /// </summary>
        public string WebUrl { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets a value which indicates whether the local.
        /// </summary>
        public bool IsLocal { get; set; }
    }


}