using System;


namespace R5T.F0002
{
	public class EnumerationHelper : IEnumerationHelper
	{
		#region Infrastructure

	    public static IEnumerationHelper Instance { get; } = new EnumerationHelper();

	    private EnumerationHelper()
	    {
        }

	    #endregion
	}
}