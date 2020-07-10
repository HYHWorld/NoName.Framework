using System;

namespace NoName.Framework.Core.Attributes
{
	public class ConfigItemAttribute : Attribute
	{
		public const string DefaultConfigPath = @".\Config";

		public string ConfigFileExtension { get; set; }

		public string ConfigName { get; set; }

		public string ConfigPath { get; set; }
	}
}