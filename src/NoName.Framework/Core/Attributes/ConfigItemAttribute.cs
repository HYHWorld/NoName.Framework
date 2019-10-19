using System;

namespace NoName.Framework.Core.Attributes
{
    public class ConfigItemAttribute : Attribute
    {
        public const String DefaultConfigPath = @".\Config";

        public String ConfigName { get; set; }

        public String ConfigPath { get; set; }

        public String ConfigFileExtension { get; set; }
    }
}
