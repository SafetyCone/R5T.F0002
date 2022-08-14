using System;


namespace R5T.F0002
{
	public class PathSeparators : IPathSeparators
	{
		#region Infrastructure

	    public static PathSeparators Instance { get; } = new();

	    private PathSeparators()
	    {
        }

	    #endregion
	}
}