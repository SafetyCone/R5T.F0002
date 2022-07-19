using System;

using R5T.T0131;


namespace R5T.F0002.V000
{
	[ValuesMarker]
	public partial interface IPaths : IValuesMarker
	{
		private static Z0004.IPaths ExamplePaths { get; } = Z0004.Paths.Instance;


		public string DirectoryIndicatedPath => ExamplePaths.Path_002;
		public string FileIndicatedPath => ExamplePaths.Path_001;
	}
}