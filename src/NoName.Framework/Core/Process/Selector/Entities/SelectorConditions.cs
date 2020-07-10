using System;

namespace NoName.Framework.Core.Process.Selector.Entities
{
	public class SelectorCondition<T>
	{
		public Func<T, bool> Conditon { get; set; }

		public int GroupId { get; set; }

		public int GroupOrder { get; set; }
	}
}