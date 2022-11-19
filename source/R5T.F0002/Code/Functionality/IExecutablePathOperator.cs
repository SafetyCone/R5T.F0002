using System;

using R5T.T0132;


namespace R5T.F0002
{
	/// <summary>
	/// Inheritance required since <see cref="IPathOperator"/> is not in this library.
	/// </summary>
	[FunctionalityMarker]
	public partial interface IExecutablePathOperator : IFunctionalityMarker,
		F0000.IExecutablePathOperator
	{
		new public string GetExecutableDirectoryPath()
		{
			var executableFilePath = this.GetExecutableFilePath();

			var executableDirectoryPath = Instances.PathOperator.GetParentDirectoryPath_ForFile(executableFilePath);
			return executableDirectoryPath;
		}

		public string GetExecutableDirectoryRelativeFilePath(
			string executableDirectoryRelativePath)
		{
			var executableDirectoryPath = this.GetExecutableDirectoryPath();

			var filePath = Instances.PathOperator.GetFilePath(
				executableDirectoryPath,
				executableDirectoryRelativePath);

			return filePath;
		}
	}
}