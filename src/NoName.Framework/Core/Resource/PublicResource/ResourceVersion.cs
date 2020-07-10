using System.Collections.Generic;

namespace NoName.Framework.Core.Resource.PublicResource
{
	public class ResourceVersion
	{
		public string CurrentVersionId { get; set; }

		public bool IsAbandon { get; set; }

		public IList<string> PastVersions { get; set; }

		public string ResourceName { get; set; }

		public byte[] Signature { get; set; }
	}
}