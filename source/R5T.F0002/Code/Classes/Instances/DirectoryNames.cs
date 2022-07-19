using System;


namespace R5T.F0002
{
	public class DirectoryNames : IDirectoryNames
	{
		#region Infrastructure

	    public static DirectoryNames Instance { get; } = new();

	    private DirectoryNames()
	    {
        }

	    #endregion
	}
}