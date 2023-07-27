using System;

using Glossary = R5T.Y0000.Glossary.ForPaths;


namespace R5T.F0002
{
	public partial interface IPathOperator
	{
        /// <summary>
        /// Ensures that the path uses only the specified <paramref name="directorySeparator"/>.
        /// </summary>
        public string EnsureDirectorySeparator(
            string path,
            char directorySeparator)
        {
            var alternateDirectorySeparator = Instances.DirectorySeparatorOperator.GetAlternateDirectorySeparator(directorySeparator);

            var containsAlternateDirectorySeparator = this.ContainsDirectorySeparator(
                path,
                alternateDirectorySeparator);

            var output = containsAlternateDirectorySeparator
                ? path.Replace(alternateDirectorySeparator, directorySeparator)
                : path
                ;

            return output;
        }

		/// <summary>
		/// Ensures the path ends with a directory separator.
		/// The directory separator is detected within the path.
		/// </summary>
		public string EnsureIsDirectoryIndicated(string path)
		{
			var isDirectoryIndicated = this.IsDirectoryIndicated(path);

			var output = isDirectoryIndicated
				? path
				: this.MakeDirectoryIndicated(path)
				;

			return output;
		}

		public string EnsureIsNotDirectoryIndicated(string path)
        {
            var isDirectoryIndicated = this.IsDirectoryIndicated(path);

            var output = isDirectoryIndicated
                ? this.MakeNotDirectoryIndicated(path)
                : path
                ;

            return output;
        }

		public string EnsureNonWindowsDirectorySeparator(string path)
		{
			var output = this.MakeNonWindowsDirectorySeparated(path);
			return output;
		}

        public string EnsureWindowsDirectorySeparator(string path)
        {
            var output = this.MakeWindowsDirectorySeparated(path);
            return output;
        }

        public string MakeNonWindowsDirectorySeparated(string path)
		{
			var output = path.Replace(
				Instances.DirectorySeparators.Windows,
				Instances.DirectorySeparators.NonWindows);

			return output;
		}

        public string MakeWindowsDirectorySeparated(string path)
        {
            var output = path.Replace(
                Instances.DirectorySeparators.NonWindows,
                Instances.DirectorySeparators.Windows);

            return output;
        }

        public string MakeNotDirectoryIndicated(string path)
        {
            var output = path.TrimEnd(Instances.DirectorySeparators.Both);
            return output;
        }

        public string EnsureIsNotRootIndicated(string path)
        {
            var isRootIndicated = this.IsRootIndicated(path);

            var output = isRootIndicated
                ? this.MakeNotRootIndicated(path)
                : path
                ;

            return output;
        }

        public string MakeNotRootIndicated(string path)
        {
            var output = path.TrimStart(Instances.DirectorySeparators.Both);
            return output;
        }

		/// <summary>
		/// Ensures that both the beginning and end of a path match a reference path in terms of root-indication and directory-indication.
		/// This is useful after modifying a path when you want to retain information about whether the initial path was root- or directory-indicated.
		/// </summary>
		public string MatchTerminals(
			string path,
			string referencePath)
		{
			var output = path;

			output = this.MatchRootIndication(output, referencePath);
			output = this.MatchDirectoryIndication(output, referencePath);

			return output;
		}

		public string MatchRootIndication(
			string path,
			string referencePath)
		{
			var rootIndicated = this.IsRootIndicated(referencePath);

			var output = this.MakeRootIndicated(
				path,
				rootIndicated);

			return output;
		}

		public string MakeRootIndicated(
			string path,
			bool rootIndicated)
		{
			var directorySeparator = this.DetectDirectorySeparator(path);

			var output = this.MakeRootIndicated(
				path,
				directorySeparator,
				rootIndicated);

			return output;
		}

		public string MakeRootIndicated(
		   string path,
		   char directorySeparator,
		   bool rootIndicated)
		{
			var output = rootIndicated
				? this.MakeRootIndicated(path, directorySeparator)
				: this.MakeNotRootIndicated(path)
				;

			return output;
		}

		public string MakeRootIndicated(
			string path,
			char directorySeparator)
		{
			var output = directorySeparator + path;
			return output;
		}

		public string MatchDirectoryIndication(
			string path,
			string referencePath)
		{
			var directoryIndicated = this.IsDirectoryIndicated(referencePath);

			var output = this.MakeDirectoryIndicated(path,
				directoryIndicated);

			return output;
		}

		/// <summary>
		/// Makes a path directory indicated.
		/// </summary>
		public string MakeDirectoryIndicated(string path)
        {
			var output = this.MakeDirectoryIndicated(path, true);
			return output;
        }

		/// <summary>
		/// Detects the directory separator within the path (or errors if a directory separator cannot be detected),
		/// then adds or removes the directory separator to the end of the path if the path is not directory indicated.
		/// </summary>
		public string MakeDirectoryIndicated(
			string path,
			bool directoryIndicated)
		{
			var directorySeparator = this.DetectDirectorySeparator(path);

			var output = this.MakeDirectoryIndicated(
				path,
				directorySeparator,
				directoryIndicated);

			return output;
		}

		/// <summary>
		/// Given a path and a directory separator, makes the path either directory indicated or not, given the directory separator.
		/// </summary>
		public string MakeDirectoryIndicated(
			string path,
			char directorySeparator,
			bool directoryIndicated)
		{
			var output = directoryIndicated
				? this.MakeDirectoryIndicated(path, directorySeparator)
				: this.MakeNotDirectoryIndicated(path)
				;

			return output;
		}

		/// <summary>
		/// Adds the <paramref name="directorySeparator"/> to the end of the path.
		/// </summary>
		public string MakeDirectoryIndicated(
			string path,
			char directorySeparator)
		{
			var output = path + directorySeparator;
			return output;
		}

		public string EnsureResolved(string pathSegment)
		{
			var isResolved = this.IsResolved(pathSegment);
			if (isResolved)
			{
				return pathSegment;
			}
			else
			{
				var output = this.ResolvePath(pathSegment);
				return output;
			}
		}
	}
}