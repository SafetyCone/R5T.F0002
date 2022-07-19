using System;
using System.Linq;

using R5T.T0132;


namespace R5T.F0002
{
	[FunctionalityMarker]
	public partial interface IDirectorySeparatorOperator : IFunctionalityMarker
	{
		public bool IsDirectorySeparator(char character)
        {
			var directorySeparators = Instances.DirectorySeparators.Both;

			var output = directorySeparators.Contains(character);
			return output;
        }

		public bool IsNonWindowsDirectorySeparator(char character)
		{
			var output = character == Instances.DirectorySeparators.NonWindows;
			return output;
		}

		public bool IsWindowsDirectorySeparator(char character)
        {
			var output = character == Instances.DirectorySeparators.Windows;
			return output;
        }
	}
}