using System;

using Glossary = R5T.Y0000.Glossary.ForPaths;


// Tests for classifying paths.
// * Valid/Invalid - No invalid path characters.
// * Relative/Root (Indicated) - Beginning of path. (For Windows paths, if the path contains the volume separator character, this it is rooted. For Non-Windows paths, there is no way to know if the path is rooted, without reference to a file system (since /mnt/efs might be a relative path, or
// * Directory/File (Indicated) - End of path. Indicated since there is no way to actually distinguish between directories and files without reference to a file system.
// * Windows/Non-Windows (Dominated, Assumed) - Does the path use the Windows separator.
// * Resolved/Unresolved - No current directory or parent directory directory names in the path.

namespace R5T.F0002
{
	public partial interface IPathOperator
	{
		/// <summary>
		/// Determines whether the <paramref name="path"/> is <inheritdoc cref="Glossary.DirectoryIndicated" path="/name"/>.
		/// </summary>
		public bool IsDirectoryIndicated(string path)
        {
			// Test last character of path.
			var lastCharacter = Instances.StringOperator.GetLastCharacter(path);

			// If the last character of the path is a directory separator, then the path is directory indicated.
			var output = Instances.DirectorySeparatorOperator.IsDirectorySeparator(lastCharacter);
			return output;
        }

		/// <summary>
		/// Determines whether the <paramref name="path"/> is <inheritdoc cref="Glossary.FileIndicated" path="/name"/>.
		/// </summary>
		public bool IsFileIndicated(string path)
        {
			// Test last character of path.
			var lastCharacter = Instances.StringOperator.GetLastCharacter(path);

			var isDirectorySeparator = Instances.DirectorySeparatorOperator.IsDirectorySeparator(lastCharacter);

			// If the last character of the path is a directory separator, then the path is *not* file indicated (it is directory indicated).
			var output = !isDirectorySeparator;
			return output;
		}

		public bool IsResolved(string path)
        {
			var isUnresolved = this.IsUnresolved(path);

			// Resolved and unresolved are opposites.
			var output = !isUnresolved;
			return output;
        }

		public bool IsUnresolved(string path)
        {
			// Is the path simply one of the relative directory names?
			// Files named "." or ".." are illegal, because there is already an entry in every directory named "." or "..".
			var isRelativeDirectoryName = Instances.DirectoryNameOperator.IsRelativeDirectoryName(path);
			if (isRelativeDirectoryName)
			{
				return true;
			}

			// Since "." certainly, or ".." conceivably, might exist within the path ("." as the file extension separator and ".." perhaps accidentally in a file path), look for these directory names together with either of the directory separator, both before and after the directory name.
			// The relative directory names will not appear alone since that would instead be interpretted as part of a file name or directory name.
			var searchStrings = new[]
			{
				$"{Instances.DirectorySeparators.Windows}{Instances.DirectoryNames.ParentDirectory}",
				$"{Instances.DirectoryNames.ParentDirectory}{Instances.DirectorySeparators.Windows}",
				$"{Instances.DirectorySeparators.NonWindows}{Instances.DirectoryNames.CurrentDirectory}",
				$"{Instances.DirectoryNames.CurrentDirectory}{Instances.DirectorySeparators.NonWindows}",
			};

			var output = Instances.StringOperator.ContainsAny(path,
				searchStrings);

			return output;
		}

		public bool IsValid(string path)
        {
			// A path is valid if its:
			// 1. Not null or empty.
			// 2. Contains no invalid characters.
			// Note: there are no differences for directory names vs. file names.

			var isNullOrEmpty = Instances.StringOperator.IsNullOrEmpty(path);
			if(isNullOrEmpty)
            {
				return false;
            }
        }
	}
}