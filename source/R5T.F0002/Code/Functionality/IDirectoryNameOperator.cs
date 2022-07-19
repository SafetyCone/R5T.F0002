using System;

using R5T.T0132;


namespace R5T.F0002
{
	[FunctionalityMarker]
	public partial interface IDirectoryNameOperator : IFunctionalityMarker
	{
		public bool IsCurrentDirectory(string directoryName)
        {
			var output = directoryName == Instances.DirectoryNames.CurrentDirectory;
			return output;
        }

		public bool IsParentDirectory(string directoryName)
        {
			var output = directoryName == Instances.DirectoryNames.ParentDirectory;
			return output;
        }

		public bool IsRelativeDirectoryName(string directoryName)
        {
			var output = false
				|| directoryName == Instances.DirectoryNames.CurrentDirectory
				|| directoryName == Instances.DirectoryNames.ParentDirectory
				;

			return output;
        }
	}
}