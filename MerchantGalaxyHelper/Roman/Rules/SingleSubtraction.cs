using MerchantGalaxyHelper.Contract;
using MerchantGalaxyHelper.Roman;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGalaxyHelper.Rules
{
    public class SingleSubtraction :IRule
    {
        public bool CheckViolation(string input)
        {
            if (input.Length < 3) return true;

            for (int i = input.Length - 1; i >= 2; i--)
            {
                if (RomanSymbol.IsSmaller(input[i - 1].ToString(), input[i].ToString()) &&
                        RomanSymbol.IsSmaller(input[i - 2].ToString(), input[i].ToString()))
                {
                    Console.WriteLine("SingleSubtraction Rule has been violated");
                    return false;
                }
            }

            return true;
        }
    }
}
