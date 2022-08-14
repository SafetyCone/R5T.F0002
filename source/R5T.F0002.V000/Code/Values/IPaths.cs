using System;

using R5T.T0131;


namespace R5T.F0002.V000
{
	[ValuesMarker]
	public partial interface IPaths : IValuesMarker
	{
		public string DirectoryIndicatedPath => Instances.ExamplePaths.N002;
		public string FileIndicatedPath => Instances.ExamplePaths.N001;
	}
}