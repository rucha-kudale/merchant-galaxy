using MerchantGalaxyHelper.Contract;
using MerchantGalaxyHelper.Mapper;
using MerchantGalaxyHelper.Roman.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerchantGalaxyHelper
{
    public class ExpressionParser
    {
        private List<IExpression> expressions;
        private ExpressionValidationHelper helper;

        public ExpressionParser(AliasMapper aliasMap, IDecimalConverter converter, MetalMapper metalMap)
        {
            helper = new ExpressionValidationHelper(aliasMap, metalMap);
            expressions = GetExpressions(aliasMap, converter, metalMap, helper);
        }

        public void Parse(string input)
        {
            var matchingExpression = expressions.FirstOrDefault(e => e.Match(input));
            if (matchingExpression == null) Console.WriteLine("I have no idea what you are talking about");
            else matchingExpression.Execute(input);
        }

        private List<IExpression> GetExpressions(AliasMapper aliasMap, IDecimalConverter converter, MetalMapper metalMap, ExpressionValidationHelper helper)
        {
            List<IExpression> expressions = new List<IExpression>();
            expressions.Add(new AliasExpression(aliasMap));
            expressions.Add(new UnitExpression(aliasMap, metalMap, converter, helper));
            expressions.Add(new AliasQuestionExpression(aliasMap, converter, helper));
            expressions.Add(new UnitQuestionExpression(aliasMap, metalMap, converter, helper));
            expressions.Add(new MetalExpression(aliasMap,metalMap, converter, helper));

            return expressions;
        }
    }
}
