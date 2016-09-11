namespace Hazeltek.UtiliTrak.Data.Domain.Network
{
    public class Upriser: PowerLine
    {
        public static readonly Voltage[] ValidVoltages = new [] { 
            Network.Voltage.LVOLT 
        };

        protected override Voltage[] GetValidVoltages()
        {
            return Upriser.ValidVoltages;
        }
    }


}