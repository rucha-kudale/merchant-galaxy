using MerchantGalaxyHelper.Rules;
using System;
using Xunit;

namespace MerchantGalaxyTest
{
    public class RuleTest
    {
        [Fact]
        public void TestNoRepetitionRule ()
        {
            NoRepetitionRule rule1 = new NoRepetitionRule();
            Assert.False(rule1.CheckViolation("MDDCI"));
            Assert.False(rule1.CheckViolation("MLLLDC"));
            Assert.False(rule1.CheckViolation("MVVVCI"));
            Assert.True(rule1.CheckViolation("MMDC"));
            Assert.True(rule1.CheckViolation("MDCC"));
        }

        [Fact]
        public void TestThreeFoldRepetitionRule()
        {
            ThreeflodRepetitionRule rule2 = new ThreeflodRepetitionRule();
            Assert.False(rule2.CheckViolation("MXXXXCI"));
            Assert.False(rule2.CheckViolation("MMMMDC"));
            Assert.False(rule2.CheckViolation("MCCCCI"));
            Assert.False(rule2.CheckViolation("MMDCIIII"));
            Assert.True(rule2.CheckViolation("MXXXDXCC"));
            Assert.True(rule2.CheckViolation("MMMDMCC"));
            Assert.True(rule2.CheckViolation("MDMCCCMC"));
            Assert.True(rule2.CheckViolation("MDMIIIXI"));
        }

        [Fact]
        public void TestSingleSubtraction()
        {
            SingleSubtraction rule3 = new SingleSubtraction();
            Assert.False(rule3.CheckViolation("IIX"));
            Assert.False(rule3.CheckViolation("CCM"));
            Assert.True(rule3.CheckViolation("XXIV"));
        }

        [Fact]
        public void TestNoSubtraction()
        {
            Subtraction rule4= new Subtraction();
            Assert.False(rule4.CheckViolation("CIL"));
            Assert.False(rule4.CheckViolation("MXD"));
            Assert.True(rule4.CheckViolation("XIX"));
        }
    }
}
