namespace Hazeltek.UtiliTrak.Domain.Network
{
    public class Feeder: PowerLine
    {
        public static readonly Voltage[] ValidVoltages = new [] { 
            Network.Voltage.MVOLTH, Network.Voltage.MVOLTL 
        };

        protected override Voltage[] GetValidVoltages()
        {
            return Feeder.ValidVoltages;
        }
    }


}