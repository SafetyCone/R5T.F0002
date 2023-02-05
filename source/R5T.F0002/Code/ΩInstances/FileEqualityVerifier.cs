using System;


namespace R5T.F0002
{
	public class FileEqualityVerifier : IFileEqualityVerifier
	{
		#region Infrastructure

	    public static IFileEqualityVerifier Instance { get; } = new FileEqualityVerifier();

	    private FileEqualityVerifier()
	    {
        }

	    #endregion
	}
}