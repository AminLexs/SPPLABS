using System;

namespace Plugin
{
    public interface IPlugin
    {
        dynamic GenerateValue();

        String GetGeneratorTypeName();
    }
}