using System;


namespace R5T.F0002
{
	public class PathSeparators : IPathSeparators
	{
		#region Infrastructure

	    public static IPathSeparators Instance { get; } = new PathSeparators();

	    private PathSeparators()
	    {
        }

	    #endregion
	}
}