using PluginInterface;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PluginService
{
    public class PluginService
    {
        private readonly string _pluginPath = Path.Combine(
            Directory.GetCurrentDirectory(), 
            "Plugins");

        public List<IPlugin> Plugins {get;}

        public PluginService()
        {
            Plugins = new List<IPlugin>();
            RefreshPlugins();
        }
        
        private void RefreshPlugins()
        {
            Plugins.Clear();

            DirectoryInfo pluginDirectory = new DirectoryInfo(_pluginPath);
            if (!pluginDirectory.Exists)
                pluginDirectory.Create();
            
            var pluginFiles = Directory.GetFiles(_pluginPath, "*.dll");
            foreach (var file in pluginFiles)
            {
                Assembly asm = Assembly.LoadFrom(file);
                var types = asm.GetTypes().
                    Where(t => t.GetInterfaces().
                        Where(i => i.FullName == typeof(IPlugin).FullName).Any());
                foreach (var type in types)
                {           
                    var plugin = asm.CreateInstance(type.FullName) as IPlugin;
                    Plugins.Add(plugin);
                }
            }
        }
    }
}