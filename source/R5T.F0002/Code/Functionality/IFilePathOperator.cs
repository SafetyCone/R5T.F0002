using System;

using R5T.T0132;


namespace R5T.F0002
{
	[FunctionalityMarker]
	public partial interface IFilePathOperator : IFunctionalityMarker
	{
		public string GetBackupCopyFilePath(string filePath)
		{
			var parentDirectoryPath = Instances.PathOperator.GetParentDirectoryPath_ForFile(filePath);
			var fileName = Instances.PathOperator.GetFileName(filePath);

			var backupCopyFileName = F0000.FileNameOperator.Instance.GetBackupCopyFileName(fileName);

			var backupCopyFilePath = Instances.PathOperator.GetFilePath(
				parentDirectoryPath,
				backupCopyFileName);

			return backupCopyFilePath;
		}
	}
}