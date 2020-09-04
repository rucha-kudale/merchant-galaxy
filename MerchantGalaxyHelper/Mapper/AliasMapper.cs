using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGalaxyHelper.Mapper
{
    public class AliasMapper
    {
        private Dictionary<string, string> aliasMap;
        public AliasMapper()
        {
            aliasMap = new Dictionary<string, string>();
        }

        public void AddAlias(string Alias, string value)
        {
            if (!aliasMap.ContainsKey(Alias)) aliasMap.Add(Alias, value);
            else aliasMap[Alias] = value;
        }

        public string GetValueForAlias(string Alias)
        {
            return aliasMap[Alias];
        }

        public bool Exists(string Alias)
        {
            return aliasMap.ContainsKey(Alias);
        }
    }
}
