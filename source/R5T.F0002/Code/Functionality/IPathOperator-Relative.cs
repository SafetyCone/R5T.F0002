using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0221;

using Glossary = R5T.Y0006.Glossary.ForPaths;


namespace R5T.F0002
{
    public partial interface IPathOperator
	{
		public IEnumerable<FileCopyPair> Get_DestinationFileCopyPairs(
			IEnumerable<string> sourceFilePaths,
			string destinationDirectoryPath)
        {
			var destinationFilePaths = sourceFilePaths
				.Select(sourceFilePath =>
				{
					var destinationFilePath = this.Get_DestinationFilePath(
						sourceFilePath,
						destinationDirectoryPath);

					var fileCopyPair = new FileCopyPair
					{
						SourceFilePath = sourceFilePath,
						DestinationFilePath = destinationFilePath,
					};

					return fileCopyPair;
				})
				;

			return destinationFilePaths;
        }
	}
}