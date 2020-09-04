using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGalaxyHelper.Contract
{
    public interface IDecimalConverter
    {
        double? ToDecimal(string input);
    }
}
