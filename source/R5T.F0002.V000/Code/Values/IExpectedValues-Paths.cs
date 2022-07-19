using System;

using R5T.T0120;
using R5T.T0131;


namespace R5T.F0002.V000
{
	[ValuesMarker]
	public partial interface IExpectedValues : IValuesMarker
	{
		public InputOutputPair<string, bool> IsDirectoryIndicated_Positive => InputOutputPair.From(
			Instances.Path.DirectoryIndicatedPath,
			true);

		public InputOutputPair<string, bool> IsDirectoryIndicated_Negative => InputOutputPair.From(
			Instances.Path.FileIndicatedPath,
			false);

		public InputOutputPair<string, bool> IsFileIndicated_Positive => InputOutputPair.From(
			Instances.Path.FileIndicatedPath,
			true);

		public InputOutputPair<string, bool> IsFileIndicated_Negative => InputOutputPair.From(
			Instances.Path.DirectoryIndicatedPath,
			false);
	}
}