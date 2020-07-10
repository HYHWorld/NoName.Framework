using System;

namespace NoName.Framework.Core.Authorizer
{
	public interface IAuthorizer
	{
		void Assert(bool expression);
	}
}