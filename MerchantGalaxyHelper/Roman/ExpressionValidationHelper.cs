using MerchantGalaxyHelper.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGalaxyHelper
{
    public class ExpressionValidationHelper
    {
        private AliasMapper _pseudonymMap;
        private MetalMapper _metalMap;

        public ExpressionValidationHelper(AliasMapper pseudonymMap, MetalMapper metalMap)
        {
            _pseudonymMap = pseudonymMap;
            _metalMap = metalMap;
        }

        public bool AreWordsValidAliases(string[] words)
        {
            foreach (string word in words) { if (!_pseudonymMap.Exists(word)) { return false; } }
            return true;
        }

        public bool AreWordsValidCommodities(string[] words)
        {
            foreach (string word in words) { if (!_metalMap.Exists(word)) { return false; } }
            return true;
        }
    }
}
