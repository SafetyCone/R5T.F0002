using System;


namespace R5T.F0002
{
	public class ExecutablePathOperator : IExecutablePathOperator
	{
		#region Infrastructure

	    public static ExecutablePathOperator Instance { get; } = new();

	    private ExecutablePathOperator()
	    {
        }

	    #endregion
	}
}