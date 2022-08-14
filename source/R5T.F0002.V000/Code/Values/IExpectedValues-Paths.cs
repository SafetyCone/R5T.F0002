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

		public InputOutputPair<string, PathClassificationInfo> Path_N001 => InputOutputPair.From(
			Instances.ExamplePaths.N001,
			new PathClassificationInfo
			{
				IsValid = true,
				IsWindows = true,
				IsFileIndicated = true,
				IsRooted = true,
				IsResolved = true,
			});

		public InputOutputPair<string, PathClassificationInfo> Path_N002 => InputOutputPair.From(
			Instances.ExamplePaths.N002,
			new PathClassificationInfo
			{
				IsValid = true,
				IsWindows = true,
				IsDirectoryIndicated = true,
				IsRooted = true,
				IsResolved = true,
			});

		/// <inheritdoc cref="Z0004.IPaths.N003"/>
		public InputOutputPair<string, PathClassificationInfo> Path_N003 => InputOutputPair.From(
			Instances.ExamplePaths.N003,
			new PathClassificationInfo
			{
				IsValid = true,
				IsNonWindows = true,
				IsFileIndicated = true,
				IsRooted = true,
				IsRootIndicated = true,
				IsResolved = true,
			});

		/// <inheritdoc cref="Z0004.IPaths.N004"/>
		public InputOutputPair<string, PathClassificationInfo> Path_N004 => InputOutputPair.From(
			Instances.ExamplePaths.N004,
			new PathClassificationInfo
			{
				IsValid = true,
				IsNonWindows = true,
				IsDirectoryIndicated = true,
				IsRooted = true,
				IsRootIndicated = true,
				IsResolved = true,
			});
	}
}