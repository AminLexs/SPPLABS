using System;

namespace PluginInterface
{
    public interface IPlugin
    {
        dynamic GenerateValue();

        string GetGeneratorTypeName();
    }
}