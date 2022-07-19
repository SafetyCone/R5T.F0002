using System;

using R5T.T0131;


namespace R5T.F0002
{
	[ValuesMarker]
	public partial interface IDirectorySeparators : IValuesMarker
	{
		public char[] Both => new[] { Instances.Characters.Backslash, Instances.Characters.Slash };

		public char NonWindows => Instances.Characters.Slash;
		public char Windows => Instances.Characters.Backslash;
	}
}