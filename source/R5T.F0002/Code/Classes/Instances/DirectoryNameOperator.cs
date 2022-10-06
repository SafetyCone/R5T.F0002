using System;


namespace R5T.F0002
{
	public class DirectoryNameOperator : IDirectoryNameOperator
	{
		#region Infrastructure

	    public static IDirectoryNameOperator Instance { get; } = new DirectoryNameOperator();

	    private DirectoryNameOperator()
	    {
        }

	    #endregion
	}
}