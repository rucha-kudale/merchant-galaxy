using System;
using MerchantGalaxyHelper.Contract;
using MerchantGalaxyHelper.Mapper;
using System.IO;

namespace MerchantGalaxyHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            string path = "../../input.txt";
            string readText = File.ReadAllText(path);
            string[] lines = readText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(readText);
            Console.WriteLine();
            AliasMapper AliasMap = new AliasMapper();
            IDecimalConverter converter = new RomanConverter();
            MetalMapper metalMap = new MetalMapper();
            ExpressionParser parser = new ExpressionParser(AliasMap, converter, metalMap);
            foreach (string line in lines)
            {
                parser.Parse(line);
            }
            Console.ReadLine();
        }
    }
}
