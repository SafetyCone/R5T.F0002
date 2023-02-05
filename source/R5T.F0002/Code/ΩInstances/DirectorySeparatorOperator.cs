using System;


namespace R5T.F0002
{
	public class DirectorySeparatorOperator : IDirectorySeparatorOperator
	{
		#region Infrastructure

	    public static IDirectorySeparatorOperator Instance { get; } = new DirectorySeparatorOperator();

	    private DirectorySeparatorOperator()
	    {
        }

	    #endregion
	}
}