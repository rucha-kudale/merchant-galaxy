using MerchantGalaxyHelper.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGalaxyHelper.Rules
{
    public class Subtraction :IRule
    {
        public bool CheckViolation(string input)
        {
            bool result = (input.Length < 2) ||
                    !(input.Contains("IL") || input.Contains("IC") || input.Contains("ID") || input.Contains("IM") ||
                    input.Contains("XD") || input.Contains("XM"));

            if (!result) { Console.WriteLine("Subtraction Rule has been violated"); }

            return result;
        }
    }
}
