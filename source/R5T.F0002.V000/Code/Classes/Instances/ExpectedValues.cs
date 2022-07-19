using System;


namespace R5T.F0002.V000
{
	public class ExpectedValues : IExpectedValues
	{
		#region Infrastructure

	    public static ExpectedValues Instance { get; } = new();

	    private ExpectedValues()
	    {
        }

	    #endregion
	}
}