using System;
using PluginInterface;

namespace DateTimeGenerator
{
    public class DateTimeGenerator : IPlugin
    {
        private string TypeName = typeof(DateTime).Name;
        
        public dynamic GenerateValue()
        {
            var rand = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;           
            return start.AddDays(rand.Next(range));
        }

        public string GetGeneratorTypeName()
        {
            return TypeName;
        }
    }
}