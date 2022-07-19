using System;


namespace R5T.F0002
{
	public class DirectoryNameOperator : IDirectoryNameOperator
	{
		#region Infrastructure

	    public static DirectoryNameOperator Instance { get; } = new();

	    private DirectoryNameOperator()
	    {
        }

	    #endregion
	}
}