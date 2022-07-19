using System;


namespace R5T.F0002
{
	public class DirectorySeparatorOperator : IDirectorySeparatorOperator
	{
		#region Infrastructure

	    public static DirectorySeparatorOperator Instance { get; } = new();

	    private DirectorySeparatorOperator()
	    {
        }

	    #endregion
	}
}