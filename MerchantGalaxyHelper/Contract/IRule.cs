using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGalaxyHelper.Contract
{
    public interface IRule
    {
        bool CheckViolation(string input);
    }
}
