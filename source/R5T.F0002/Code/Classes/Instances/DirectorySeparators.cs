using System;


namespace R5T.F0002
{
	public class DirectorySeparators : IDirectorySeparators
	{
		#region Infrastructure

	    public static IDirectorySeparators Instance { get; } = new DirectorySeparators();

	    private DirectorySeparators()
	    {
        }

	    #endregion
	}
}