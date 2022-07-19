using System;


namespace R5T.F0002
{
	public class DirectorySeparators : IDirectorySeparators
	{
		#region Infrastructure

	    public static DirectorySeparators Instance { get; } = new();

	    private DirectorySeparators()
	    {
        }

	    #endregion
	}
}