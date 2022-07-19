using System;


namespace R5T.F0002.V000
{
	public class Path : IPaths
	{
		#region Infrastructure

	    public static Path Instance { get; } = new();

	    private Path()
	    {
        }

	    #endregion
	}
}