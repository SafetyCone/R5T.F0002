using System;


namespace R5T.F0002
{
	public class PathOperator : IPathOperator
	{
		#region Infrastructure

	    public static PathOperator Instance { get; } = new();

	    private PathOperator()
	    {
        }

	    #endregion
	}


	namespace Internal
    {
		public class PathOperator : IPathOperator
		{
			#region Infrastructure

			public static PathOperator Instance { get; } = new();

			private PathOperator()
			{
			}

			#endregion
		}
	}


	namespace Implementations
	{
		public class PathOperator : IPathOperator
		{
			#region Infrastructure

			public static PathOperator Instance { get; } = new();

			private PathOperator()
			{
			}

			#endregion
		}
	}
}