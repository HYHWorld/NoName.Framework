using System;

using NoName.Framework.Core.Exception.AuthoriseExceptions;

namespace NoName.Framework.Core.Authorizer
{
	public class BooleanAuthorizer : IAuthorizer
	{
		public void Assert(bool expression)
		{
			if (!expression)
			{
				throw new BooleanFalseException();
			}
		}
	}
}