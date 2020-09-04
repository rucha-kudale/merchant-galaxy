using MerchantGalaxyHelper.Contract;
using MerchantGalaxyHelper.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerchantGalaxyHelper.Roman.Expressions
{
    public class UnitExpression : IExpression
    {
        private AliasMapper _aliasMap;
        private MetalMapper _metalMap;
        private IDecimalConverter _converter;
        private ExpressionValidationHelper _helper;

        public UnitExpression(AliasMapper aliasMap, MetalMapper metalMap, IDecimalConverter converter, ExpressionValidationHelper helper)
        {
            _aliasMap = aliasMap;
            _metalMap = metalMap;
            _converter = converter;
            _helper = helper;
        }

        public void Execute(string input)
        {
            string[] parts = input.Split(new string[] { " is " }, StringSplitOptions.RemoveEmptyEntries);
            string[] wordsInFirstPart = parts[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] wordsInSecondPart = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            double decimalPrice = 0;
            double.TryParse(wordsInSecondPart[0], out decimalPrice);

            string metal = wordsInFirstPart[wordsInFirstPart.Length - 1];
            string AliasValue = string.Empty;

            //Create Roman Numeral from aliases
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < wordsInFirstPart.Length - 1; i++)
            {
                sb.Append(_aliasMap.GetValueForAlias(wordsInFirstPart[i]));
            }

            //Convert Roman to decimal
            double? totalUnits = _converter.ToDecimal(sb.ToString());

            //Calculate and store per unit price of commodity
            if (totalUnits.HasValue) _metalMap.AddMetal(metal, decimalPrice / totalUnits.Value);
            else Console.WriteLine("Error occurred while calculating commodity price");
        }

        public bool Match(string input)
        {
            string[] parts = input.Split(new string[] { " is " }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) return false;

            string[] wordsInFirstPart = parts[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] wordsInSecondPart = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double output;

            return input.EndsWith("credits", StringComparison.OrdinalIgnoreCase) &&
                    !input.StartsWith("how many", StringComparison.OrdinalIgnoreCase) && parts.Length == 2 &&
                    wordsInSecondPart.Length == 2 && Double.TryParse(wordsInSecondPart[0], out output) &&
                    _helper.AreWordsValidAliases(wordsInFirstPart.Take(wordsInFirstPart.Length - 1).ToArray());
        }
    }
}
