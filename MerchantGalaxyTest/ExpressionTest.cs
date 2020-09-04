using MerchantGalaxyHelper;
using MerchantGalaxyHelper.Mapper;
using MerchantGalaxyHelper.Roman.Expressions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace MerchantGalaxyTest
{
    public class ExpressionTest
    {
        [Fact]
        public void AliasExpressionTest()
        {
            AliasMapper AliasMap = new AliasMapper();
            AliasExpression expression = new AliasExpression(AliasMap);
            Assert.True(expression.Match("glob is I"));
            Assert.False(expression.Match("glob is N"));
            expression.Execute("glob is I");
            Assert.True(AliasMap.Exists("glob"));
            Assert.Equal("I", AliasMap.GetValueForAlias("glob"));
        }

        [Fact]
        public void UnitExpressionTest()
        {
            AliasMapper AliasMap = new AliasMapper();
            RomanConverter converter = new RomanConverter();
            MetalMapper metalMap = new MetalMapper();
            AliasMap.AddAlias("glob", "I");
            AliasMap.AddAlias("pish", "X");
            ExpressionValidationHelper helper = new ExpressionValidationHelper(AliasMap, metalMap);
            UnitExpression expression = new UnitExpression(AliasMap, metalMap, converter, helper);
            expression.Execute("glob pish Iron is 900 Credits");
            Assert.True(metalMap.Exists("Iron"));
            Assert.Equal<double>(100, metalMap.GetPriceByMetal("Iron"));

            expression.Execute("pish pish Iron is 400 Credits");
            Assert.Equal<double>(20, metalMap.GetPriceByMetal("Iron"));
        }
    }
}
