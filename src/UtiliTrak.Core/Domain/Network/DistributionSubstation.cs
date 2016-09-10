namespace Hazeltek.UtiliTrak.Domain.Network
{
    public class DistributionSubstation: Station
    {
        public static readonly VoltageRatio[] ValidVoltageRatios = new [] {
            VoltageRatio.MVOLTH_LVOLT, VoltageRatio.MVOLTL_LVOLT
        };

        /// <summary>
        /// Gets or sets the upriser count for the station.
        /// </summary>
        public virtual int UpriserCount { get; set; }

        protected override VoltageRatio[] GetValidVoltageRatios()
        {
            return DistributionSubstation.ValidVoltageRatios;
        }
    }


}