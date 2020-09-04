using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGalaxyHelper.Mapper
{
    public class MetalMapper
    {
        private Dictionary<string, double> metalMap;

        public MetalMapper()
        {
            metalMap = new Dictionary<string, double>();
        }

        public void AddMetal(string name, double perUnitPrice)
        {
            if (!metalMap.ContainsKey(name)) metalMap.Add(name, perUnitPrice);
            else metalMap[name] = perUnitPrice;
        }

        public double GetPriceByMetal(string material)
        {
            return metalMap[material];
        }

        public bool Exists(string material)
        {
            return metalMap.ContainsKey(material);
        }
    }
}
