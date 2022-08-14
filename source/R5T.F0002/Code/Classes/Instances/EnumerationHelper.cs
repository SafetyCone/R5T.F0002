using System;


namespace R5T.F0002
{
	public class EnumerationHelper : IEnumerationHelper
	{
		#region Infrastructure

	    public static EnumerationHelper Instance { get; } = new();

	    private EnumerationHelper()
	    {
        }

	    #endregion
	}
}