namespace Hazeltek.UtiliTrak.Data.Domain.Network
{
    public class InjectionSubstation: PowerStation
    {
        public static readonly VoltageRatio[] ValidVoltageRatios = new [] {
            VoltageRatio.MVOLTH_MVOLTL
        };

        protected override VoltageRatio[] GetValidVoltageRatios()
        {
            return InjectionSubstation.ValidVoltageRatios;
        }
    }


}