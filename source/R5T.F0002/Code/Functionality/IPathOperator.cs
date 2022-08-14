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

		public string GetFileName(string filePath)
        {
			var pathParts = this.GetAllPathParts(filePath);

			var fileName = pathParts.Last();
			return fileName;
        }

		public string GetFileNameStem(string filePath)
        {
			var fileName = this.GetFileName(filePath);

			var output = Instances.FileNameOperator.GetFileNameStem(fileName);
			return output;
        }
	}
}