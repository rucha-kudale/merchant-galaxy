using MerchantGalaxyHelper.Contract;
using MerchantGalaxyHelper.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGalaxyHelper.Roman.Expressions
{
    public class AliasExpression : IExpression
    {
        private AliasMapper _aliasMap;

        public AliasExpression(AliasMapper aliasMap)
        {
            _aliasMap = aliasMap;
        }

        public void Execute(string input)
        {
            string[] parts = input.Split(new string[] { " is " }, StringSplitOptions.RemoveEmptyEntries);

            string roman = parts[1];
            _aliasMap.AddAlias(parts[0], parts[1]);
        }

        public bool Match(string input)
        {
            string romanAlphabet = RomanSymbol.GetAlphabet();
            string[] parts = input.Split(new string[] { " is " }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2) return false;

            string roman = parts[1];
            bool found = false;

            for (int i = 0; i < romanAlphabet.Length; i++)
            {
                if (String.Equals(roman, romanAlphabet[i].ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    break;
                }
            }

            return found;
        }
    }
}
