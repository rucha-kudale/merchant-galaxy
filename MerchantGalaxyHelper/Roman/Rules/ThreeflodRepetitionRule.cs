using MerchantGalaxyHelper.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGalaxyHelper.Rules
{
    public class ThreeflodRepetitionRule :IRule
    {
        public bool CheckViolation(string input)
        {
            bool result = (input.Length < 4) || !(input.Contains("IIII") || input.Contains("XXXX") || input.Contains("CCCC") || input.Contains("MMMM"));

            if (!result) { Console.WriteLine("CantBeRepeated4Times Rule has been violated"); }

            return result;
        }
    }
}
