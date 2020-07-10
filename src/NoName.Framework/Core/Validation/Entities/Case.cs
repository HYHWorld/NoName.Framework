using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

using NoName.Framework.Core.Validation.Entities;

namespace NoName.Framework.Core.Validation.Declarations
{
	public class Case
	{					  
		public LambdaExpression Left { get; set; }

		public LambdaExpression Right { get; set; }

		public OperatorEnum Operator { get; set; }
	}
}
