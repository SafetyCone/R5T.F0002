using System;

using R5T.T0132;


namespace R5T.F0002
{
	[FunctionalityMarker]
	public partial interface IFileSystemOperator : IFunctionalityMarker,
        F0000.IFileSystemOperator
	{
        public void CreateBackupFile(string filePath)
        {
            var backupFilePath = FilePathOperator.Instance.GetBackupCopyFilePath(filePath);

            this.Copy_File(
                filePath,
                backupFilePath);
        }
    }
}