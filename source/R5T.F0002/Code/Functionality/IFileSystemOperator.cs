using System;
using System.Collections.Generic;

using R5T.T0132;
using R5T.T0221;


namespace R5T.F0002
{
	[FunctionalityMarker]
	public partial interface IFileSystemOperator : IFunctionalityMarker,
        F0000.IFileSystemOperator,
        L0071.IFileSystemOperator
	{
        public void Copy_File(FileCopyPair pair)
        {
            this.Copy_File(
                pair.SourceFilePath,
                pair.DestinationFilePath);
        }

        public void Copy_Files(IEnumerable<FileCopyPair> pairs)
        {
            foreach (var pair in pairs)
            {
                this.Copy_File(pair);
            }
        }
    }
}