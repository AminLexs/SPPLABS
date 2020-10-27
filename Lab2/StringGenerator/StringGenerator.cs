using System;
using System.Linq;
using PluginInterface;

namespace StringGenerator
{
    public class StringGenerator : IPlugin
    {
        private string TypeName = typeof(string).Name;
        
        public dynamic GenerateValue()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string GetGeneratorTypeName()
        {
            return TypeName;
        }
    }
}