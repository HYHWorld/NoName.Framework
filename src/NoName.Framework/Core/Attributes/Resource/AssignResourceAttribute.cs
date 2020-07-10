using System;

namespace NoName.Framework.Core.Attributes.Resource
{
	[AttributeUsage(AttributeTargets.Property)]
	public class AssignResourceAttribute : Attribute
	{
		public string ResourceName { get; set; }

		public Type Type { get; set; }
	}
}