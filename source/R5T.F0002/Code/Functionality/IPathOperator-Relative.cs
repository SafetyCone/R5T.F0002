using System;
using System.Collections.Generic;
using System.Linq;

using R5T.F0000;

using Glossary = R5T.Y0000.Glossary.ForPaths;


namespace R5T.F0002
{
	public partial interface IPathOperator
	{
		public string GetFilePath(string directoryPath, string fileName)
        {
			var output = this.Combine(directoryPath, fileName);
			return output;
        }

		public IEnumerable<FileCopyPair> GetDestinationFileCopyPairs(
			IEnumerable<string> sourceFilePaths,
			string destinationDirectoryPath)
        {
			var destinationFilePaths = sourceFilePaths
				.Select(sourceFilePath =>
				{
					var destinationFilePath = this.GetDestinationFilePath(
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

		public IEnumerable<string> GetDestinationFilePaths(
			IEnumerable<string> sourceFilePaths,
			string destinationDirectoryPath)
        {
			var destinationFilePaths = sourceFilePaths
				.Select(sourceFilePath => this.GetDestinationFilePath(
					sourceFilePath,
					destinationDirectoryPath))
				;

			return destinationFilePaths;
		}

		public string GetDestinationFilePath(
			string filePath,
			string destinationDirectoryPath)
        {
			var fileName = this.GetFileName(filePath);

			var destinationFilePath = this.GetFilePath(
				destinationDirectoryPath,
				fileName);

			return destinationFilePath;
        }

		/// <summary>
		/// Works for both directory and file paths.
		/// </summary>
		public string GetParentDirectoryPath(string path)
		{
			// Ensure the path is not directory indicated.
			var ensuredPath = this.EnsureIsNotDirectoryIndicated(path);

			// Get the index of the last directory separator.
			var lastDirectorySeparatorIndex = Internal.GetLastDirectorySeparatorIndex(ensuredPath);

			var anyDirectorySeparatorWasFound = Instances.StringOperator.WasFound(lastDirectorySeparatorIndex);
			if (!anyDirectorySeparatorWasFound)
			{
				throw new InvalidOperationException($"Unable to get parent directory for file path:\n{ensuredPath}");
			}

			// Get the path up-to-and-including the last directory separator, since we want to output a directory-indicated path.
			var output = ensuredPath[0..(lastDirectorySeparatorIndex + 1)];
			return output;
		}

		public string GetParentDirectoryPath_ForDirectory(string directoryPath)
        {
			// Can re-use the same code.
			var output = this.GetParentDirectoryPath(directoryPath);
			return output;
		}

		public string GetParentDirectoryPath_ForFile(string filePath)
        {
			// Can re-use the same code.
			var output = this.GetParentDirectoryPath(filePath);
			return output;
		}

		public string GetRelativePath(
			string sourcePath,
			string destinationPath)
        {
			var directorySeparator = this.DetectDirectorySeparator(sourcePath);

			var output = this.GetRelativePath(
				sourcePath,
				destinationPath,
				directorySeparator);

			return output;
        }

		public string GetRelativePath(
			string sourcePath,
			string destinationPath,
			char outputDirectorySeparator)
        {
			var sourceUri = new Uri(new Uri("file://"), sourcePath);
			var destinationUri = new Uri(new Uri("file://"), destinationPath);

			var relativeUri = sourceUri.MakeRelativeUri(destinationUri);

			var relativePath = Uri.UnescapeDataString(relativeUri.ToString());

			// Ensure we are using the desired directory separator for the output.
			var output = this.EnsureDirectorySeparator(
				relativePath,
				outputDirectorySeparator);

			return output;
		}

		public bool HasParentDirectory(string path)
        {
			// If a path has any directory separators, then it has a parent directory.
			var output = this.HasAnyDirectorySeparators(path);
			return output;
        }
	}


	namespace Internal
    {
		public partial interface IPathOperator
        {
			public int GetLastDirectorySeparatorIndex(string path)
            {
				var output = path.LastIndexOfAny(
					Instances.DirectorySeparators.Both);

				return output;
			}
        }
    }
}