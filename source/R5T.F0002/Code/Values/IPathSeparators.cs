using System;

using R5T.T0131;


namespace R5T.F0002
{
	[ValuesMarker]
	public partial interface IPathSeparators : IValuesMarker
	{
		public char VolumeSeparator => Instances.Characters.Colon;
	}
}