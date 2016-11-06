namespace Hazeltek.UtiliTrak.Data.Domain.Network
{
    public class Feeder: PowerLine
    {
        /// <summary>
        /// Gets or sets a value which indicates whether the powerline is
        /// public or dedicated.
        /// </summary>
        public virtual bool IsPublic { get; set; }

        public static readonly Voltage[] ValidVoltages = new [] { 
            Network.Voltage.MVOLTH, Network.Voltage.MVOLTL 
        };

        protected override Voltage[] GetValidVoltages()
        {
            return Feeder.ValidVoltages;
        }
    }


}