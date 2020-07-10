using System;
using System.Collections.Generic;
using System.Text;

namespace NoName.Framework.Core.Data.Declarations
{
	public interface IRedirectableEnumerator<out T> : IEnumerator<T>
	{
		bool MoveTo(int index);

		bool MovePrevious();

		bool MoveFirst();

		bool MoveLast();

		bool Move(Case condition);
	}
}
