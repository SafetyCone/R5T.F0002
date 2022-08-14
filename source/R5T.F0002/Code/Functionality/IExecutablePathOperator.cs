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
		public string GetExecutableDirectoryPath()
		{
			var executableFilePath = this.GetExecutableFilePath();

			var executableDirectoryPath = Instances.PathOperator.GetParentDirectoryPath_ForFile(executableFilePath);
			return executableDirectoryPath;
		}
	}
}