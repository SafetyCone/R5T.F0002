using System;


namespace R5T.F0002.V000
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