using System;

using R5T.T0131;


namespace R5T.F0002
{
	[ValuesMarker]
	public partial interface IDirectoryNames : IValuesMarker
	{
		public string CurrentDirectory => Instances.Strings.Period;
		public string ParentDirectory => Instances.Strings.DoubleDot;
	}
}