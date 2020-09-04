using MerchantGalaxyHelper;
using System;
using Xunit;

namespace MerchantGalaxyTest
{
    public class RomanConverterTest
    {
        [Fact]
        public void TestRomanConverter()
        {
            RomanConverter converter = new RomanConverter();
            Assert.Equal<double>(24, converter.ToDecimal("XXIV").Value);
            Assert.Equal<double>(247, converter.ToDecimal("CCXLVII").Value);
            Assert.Equal<double>(784, converter.ToDecimal("DCCLXXXIV").Value);
            Assert.Equal<double>(2421, converter.ToDecimal("MMCDXXI").Value);
        }

    }
}
