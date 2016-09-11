namespace Hazeltek.UtiliTrak.Data.Domain.Network
{
    public class TransmissionStation: PowerStation
    {
        public static readonly VoltageRatio[] ValidVoltageRatios = new [] {
            VoltageRatio.HVOLTH_HVOLTL, VoltageRatio.HVOLTL_MVOLTH
        };

        protected override VoltageRatio[] GetValidVoltageRatios()
        {
            return TransmissionStation.ValidVoltageRatios;
        } 
    }


}