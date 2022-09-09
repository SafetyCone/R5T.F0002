using System;
using System.IO;
using System.Linq;

using R5T.T0132;


namespace R5T.F0002
{
	[FunctionalityMarker]
	public partial interface IPathOperator : IFunctionalityMarker
	{
		private static Internal.IPathOperator Internal { get; } = F0002.Internal.PathOperator.Instance;
		private static Implementations.IPathOperator Implementations { get; } = F0002.Implementations.PathOperator.Instance;


		public char DetectDirectorySeparator(string path)
        {
			var hasDirectorySeparator = Internal.HasFirstDirectorySeparator(path);
			if(!hasDirectorySeparator)
            {
				throw new InvalidOperationException($"No directory separator found in path:\n{path}");
            }

			return hasDirectorySeparator.Result;
        }

		public char DetectDirectorySeparatorOrStandard(
			string pathSegment)
		{
			this.TryDetectDirectorySeparator(pathSegment, out char output, Instances.DirectorySeparators.Standard);

			return output;
		}

		/// <summary>
		/// Returns all path parts, even empty path parts.
		/// </summary>
		public string[] GetAllPathParts(string path)
		{
			var directorySeparators = Instances.DirectorySeparators.Both;

			// Split path on directory separators, keeping empty entries, and not trimming any spaces.
			var pathParts = path.Split(directorySeparators, StringSplitOptions.None);
			return pathParts;
		}

		public string[] GetNonEmptyPathParts(string path)
		{
			var directorySeparators = Instances.DirectorySeparators.Both;

			// Split path on directory separators, removing empty entries.
			var pathParts = path.Split(directorySeparators, StringSplitOptions.RemoveEmptyEntries);
			return pathParts;
		}

		/// <summary>
		/// Chooses <see cref="GetNonEmptyPathParts(string)"/> as the default.
		/// </summary>
		public string[] GetPathParts(string path)
		{
			var output = this.GetNonEmptyPathParts(path);
			return output;
		}

		public char[] GetInvalidFileNameCharacters()
        {
            var output = Path.GetInvalidFileNameChars();
            return output;
        }

        public char[] GetInvalidPathCharacters()
        {
            var output = Path.GetInvalidPathChars();
            return output;
        }

        public string GetDirectoryName(string directoryPath)
        {
            var output = this.GetLastPathPart(directoryPath);
            return output;
        }

        public string GetFileName(string filePath)
        {
			var output = this.GetLastPathPart(filePath);
			return output;
        }

		public string GetLastPathPart(string path)
        {
			var pathParts = this.GetAllPathParts(path);

			var fileName = pathParts.Last();
			return fileName;
		}

		public string GetFileNameStem(string filePath)
        {
			var fileName = this.GetFileName(filePath);

			var output = Instances.FileNameOperator.GetFileNameStem(fileName);
			return output;
        }

		/// <summary>
		/// Attempts to detect the directory separator (Windows or non-Windows) used within a path segment.
		/// Returns true if the a directory separator can be detected, and sets the output <paramref name="directorySeparator"/> to the detected value.
		/// Returns false if a directory separator cannot be detected, and sets the output <paramref name="directorySeparator"/> to the provided <paramref name="defaultDirectorySeparator"/> value.
		/// Returns true if both (mixed) directory separators are detected, and sets the sets the output <paramref name="directorySeparator"/> to the dominant value.
		/// A path segment might have both Windows and non-Windows directory separators. Whichever directory separator occurs first in the path segment (thus, closer to the root) is dominant, and is returned as the path segment's directory separator.
		/// </summary>
		public bool TryDetectDirectorySeparator(
			string pathSegment, out char directorySeparator, char defaultDirectorySeparator)
		{
			var firstIndexOfDirectorySeparator = pathSegment.IndexOfAny(Instances.DirectorySeparators.Both);

			var exists = StringHelper.IsFound(firstIndexOfDirectorySeparator);

			directorySeparator = exists
				? pathSegment[firstIndexOfDirectorySeparator]
				: defaultDirectorySeparator
				;

			return exists;
		}
	}
}