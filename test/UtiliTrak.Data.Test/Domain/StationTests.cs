using Xunit;
using System;
using System.Linq;
using Hazeltek.UtiliTrak.Data.Domain.Network;



namespace  Hazeltek.UtiliTrak.Data.Domain.Test
{
    public class StationTest
    {
        [Theory]
        [InlineData(VoltageRatio.HVOLTH_HVOLTL)]
        [InlineData(VoltageRatio.HVOLTL_MVOLTH)]
        public void TransmissionStation_Accepts_Defined_Valid_VoltageRatio(VoltageRatio ratio)
        {
            Assert.True(TransmissionStation.ValidVoltageRatios.Contains(ratio));
            var tstation = new TransmissionStation { VoltageRatio = ratio };
            Assert.True(tstation != null && tstation.VoltageRatio == ratio);
        }

        [Theory]
        [InlineData(VoltageRatio.MVOLTH_MVOLTL)]
        [InlineData(VoltageRatio.MVOLTH_LVOLT)]
        [InlineData(VoltageRatio.MVOLTL_LVOLT)]
        public void TransmissionStation_Does_Not_Accept_Non_Defined_Valid_VoltageRatio(VoltageRatio ratio)
        {
            Assert.False(TransmissionStation.ValidVoltageRatios.Contains(ratio));
            Assert.Throws<ArgumentException>(() => {
                var tstation = new TransmissionStation { VoltageRatio = ratio };
            });
        }

        [Theory]
        [InlineData(VoltageRatio.MVOLTH_MVOLTL)]
        public void InjectionSubstation_Accepts_Defined_Valid_VoltageRatio(VoltageRatio ratio)
        {
            Assert.True(InjectionSubstation.ValidVoltageRatios.Contains(ratio));
            var tstation = new InjectionSubstation { VoltageRatio = ratio };
            Assert.True(tstation != null && tstation.VoltageRatio == ratio);
        }

        [Theory]
        [InlineData(VoltageRatio.HVOLTH_HVOLTL)]
        [InlineData(VoltageRatio.HVOLTL_MVOLTH)]
        [InlineData(VoltageRatio.MVOLTH_LVOLT)]
        [InlineData(VoltageRatio.MVOLTL_LVOLT)]
        public void InjectionSubstation_Does_Not_Accept_Non_Defined_Valid_VoltageRatio(VoltageRatio ratio)
        {
            Assert.False(InjectionSubstation.ValidVoltageRatios.Contains(ratio));
            Assert.Throws<ArgumentException>(() => {
                var tstation = new InjectionSubstation { VoltageRatio = ratio };
            });
        }

        [Theory]
        [InlineData(VoltageRatio.MVOLTH_LVOLT)]
        [InlineData(VoltageRatio.MVOLTL_LVOLT)]
        public void DistributionSubstation_Accepts_Defined_Valid_VoltageRatio(VoltageRatio ratio)
        {
            Assert.True(DistributionSubstation.ValidVoltageRatios.Contains(ratio));
            var tstation = new DistributionSubstation { VoltageRatio = ratio };
            Assert.True(tstation != null && tstation.VoltageRatio == ratio);
        }

        [Theory]
        [InlineData(VoltageRatio.HVOLTH_HVOLTL)]
        [InlineData(VoltageRatio.HVOLTL_MVOLTH)]
        [InlineData(VoltageRatio.MVOLTH_MVOLTL)]
        public void DistributionSubstation_Does_Not_Accept_Non_Defined_Valid_VoltageRatio(VoltageRatio ratio)
        {
            Assert.False(DistributionSubstation.ValidVoltageRatios.Contains(ratio));
            Assert.Throws<ArgumentException>(() => {
                var tstation = new DistributionSubstation { VoltageRatio = ratio };
            });
        }
    }


}