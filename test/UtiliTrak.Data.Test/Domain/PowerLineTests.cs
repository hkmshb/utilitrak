using Xunit;
using System;
using System.Linq;
using Hazeltek.UtiliTrak.Data.Domain.Network;



namespace  Hazeltek.UtiliTrak.Data.Domain.Test
{
    public class PowerLineTest
    {
        [Theory]
        [InlineData(Voltage.MVOLTH)]
        [InlineData(Voltage.MVOLTL)]
        public void Feeder_Accepts_Defined_Valid_Voltage(Voltage voltage)
        {
            Assert.True(Feeder.ValidVoltages.Contains(voltage));

            var feeder = new Feeder { Voltage = voltage };
            Assert.True(feeder != null && feeder.Voltage == voltage);
        }

        [Theory]
        [InlineData(Voltage.HVOLTH)]
        [InlineData(Voltage.HVOLTL)]
        [InlineData(Voltage.LVOLT)]
        public void Feeder_Does_Not_Accept_Non_Defined_Valid_Voltage(Voltage voltage)
        {
            Assert.False(Feeder.ValidVoltages.Contains(voltage));
            Assert.Throws<ArgumentException>(() => {
                var feeder = new Feeder { Voltage = voltage };
            });
        }

        [Theory]
        [InlineData(Voltage.LVOLT)]
        public void Upriser_Accepts_Defined_Valid_Voltage(Voltage voltage)
        {
            Assert.True(Upriser.ValidVoltages.Contains(voltage));
            var upr = new Upriser { Voltage = voltage };
            Assert.True(upr != null && upr.Voltage == voltage);
        }

        [Theory]
        [InlineData(Voltage.HVOLTH)]
        [InlineData(Voltage.HVOLTL)]
        [InlineData(Voltage.MVOLTH)]
        [InlineData(Voltage.MVOLTH)]
        public void Upriser_Does_Not_Accept_Non_Defined_Valid_Voltage(Voltage voltage)
        {
            Assert.False(Upriser.ValidVoltages.Contains(voltage));
            Assert.Throws<ArgumentException>(() => {
                var upr = new Upriser { Voltage = voltage };
            });
        }
    }


}
