using System;
using System.Linq;

using R5T.Magyar;

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
		public PathClassificationInfo GetPathClassificationInfo(string path)
        {
            var isValid = ResultOrException.Try(() => this.IsValid(path));

            var isWindows = ResultOrException.Try(() => this.IsWindows(path));
            var isNonWindows = ResultOrException.Try(() => this.IsNonWindows(path));
            var isMixedPlatform = ResultOrException.Try(() => this.IsMixedPlatform(path));
            var isUnknownPlatform = ResultOrException.Try(() => this.IsUnknownPlatform(path));

            var isDirectoryIndicated = ResultOrException.Try(() => this.IsDirectoryIndicated(path));
            var isFileIndicated = ResultOrException.Try(() => this.IsFileIndicated(path));

            var isRootIndicated = ResultOrException.Try(() => this.IsRootIndicated(path));

            var isRooted = ResultOrException.Try(() => this.IsRooted(path));

            var isResolved = ResultOrException.Try(() => this.IsResolved(path));
            var isUnresolved = ResultOrException.Try(() => this.IsUnresolved(path));

            var output = new PathClassificationInfo
            {
                IsDirectoryIndicated = isDirectoryIndicated,
                IsFileIndicated = isFileIndicated,
                IsMixedPlatform = isMixedPlatform,
                IsNonWindows = isNonWindows,
                IsResolved = isResolved,
                IsRooted = isRooted,
                IsRootIndicated = isRootIndicated,
                IsUnknownPlatform = isUnknownPlatform,
                IsUnresolved = isUnresolved,
                IsValid = isValid,
                IsWindows = isWindows,
            };

            return output;
        }

		public PathClassificationInfo GetPathClassificationInfo_NoValidation(string path)
		{
			var isValid = ResultOrException.Try(() => this.IsValid(path));

			var isWindows = ResultOrException.Try(() => Internal.IsWindows_AssumeTrue_NoValidation(path));
			var isNonWindows = ResultOrException.Try(() => Internal.IsNonWindows_AssumeTrue_NoValidation(path));
			var isMixedPlatform = ResultOrException.Try(() => Internal.IsMixedPlatform_NoValidation(path));
			var isUnknownPlatform = ResultOrException.Try(() => Internal.IsUnknownPlatform_NoValidation(path));

			var isDirectoryIndicated = ResultOrException.Try(() => Internal.IsDirectoryIndicated_NoValidation(path));
			var isFileIndicated = ResultOrException.Try(() => Internal.IsFileIndicated_NoValidation(path));

			var isRootIndicated = ResultOrException.Try(() => Internal.IsRootIndicated_NoValidation(path));

			var isRooted = ResultOrException.Try(() => Internal.IsRooted_NoValidation(path));

			var isResolved = ResultOrException.Try(() => Internal.IsResolved_NoValidation(path));
			var isUnresolved = ResultOrException.Try(() => Internal.IsUnresolved_NoValidation(path));

			var output = new PathClassificationInfo
			{
				IsDirectoryIndicated = isDirectoryIndicated,
				IsFileIndicated = isFileIndicated,
				IsMixedPlatform = isMixedPlatform,
				IsNonWindows = isNonWindows,
				IsResolved = isResolved,
				IsRooted = isRooted,
				IsRootIndicated = isRootIndicated,
				IsUnknownPlatform = isUnknownPlatform,
				IsUnresolved = isUnresolved,
				IsValid = isValid,
				IsWindows = isWindows,
			};

			return output;
		}

		public bool ContainsDirectorySeparator(
			string path,
			char directorySeparator)
        {
			var output = path.Contains(directorySeparator);
			return output;
        }

		public bool HasAnyDirectorySeparators(string path)
        {
			var directorySeparators = Instances.DirectorySeparators.Both;

			var output = Instances.StringOperator.ContainsAny(
				path,
				directorySeparators);

			return output;
        }

		/// <summary>
		/// Determines whether the <paramref name="path"/> is <inheritdoc cref="Glossary.DirectoryIndicated" path="/name"/>.
		/// </summary>
		public bool IsDirectoryIndicated(string path)
        {
			this.Validate(path);

			var output = Internal.IsDirectoryIndicated_NoValidation(path);
			return output;
		}

		/// <summary>
		/// Determines whether the <paramref name="path"/> is <inheritdoc cref="Glossary.FileIndicated" path="/name"/>.
		/// </summary>
		public bool IsFileIndicated(string path)
        {
			this.Validate(path);

			var output = Internal.IsFileIndicated_NoValidation(path);
			return output;
		}

		public bool IsResolved(string path)
        {
			this.Validate(path);

			var output = Internal.IsResolved_NoValidation(path);
			return output;
		}

		public bool IsUnresolved(string path)
        {
			this.Validate(path);

			var output = Internal.IsUnresolved_NoValidation(path);
			return output;
		}

        public bool IsValid(string path)
        {
			// A path is valid if it is:
			// 1. Not null or empty.
			// 2. Contains no invalid path characters (when considered as a path).
			// 3. All path parts contain no invalid file name characters.
			// 4. No path parts end with either "." or ".." (the special current directory and parent directory names).
			// Note: there are differences between the allowed characters in a path, and the allowed characters in a file name (or directory name).
			// Note: there are no differences for directory names vs. file names.

			// Not null or empty.
			var isValid_NotNullNotEmpty = Implementations.IsValid_NotNullNotEmpty(path);
            if (!isValid_NotNullNotEmpty)
            {
                return false;
            }

			// Contains invalid path characters.
			var isValid_NoInvalidPathCharacters = Implementations.IsValid_NoInvalidPathCharacters(path);
			if(!isValid_NoInvalidPathCharacters)
            {
				return false;
            }

			var isValid_NoInvalidFileNameCharactersInPathParts = Implementations.IsValid_NoInvalidFileNameCharactersInPathParts(path);
			if (!isValid_NoInvalidFileNameCharactersInPathParts)
			{
				return false;
			}

			var isValid_NoEndingWithSpecialDirectoryNames = Implementations.IsValid_NoEndingWithSpecialDirectoryNames(path);
			if(!isValid_NoEndingWithSpecialDirectoryNames)
            {
				return false;
            }


			return true;
        }

		/// <summary>
		/// Chooses <see cref="IsNonWindows_AssumeTrue(string)"/> as the default.
		/// </summary>
		public bool IsNonWindows(string path)
        {
			var output = this.IsNonWindows_AssumeTrue(path);
			return output;
        }

		/// <summary>
		/// Determines if a path is a non-Windows path, assuming it is if there are no directory separators present to allow an actual determination.
		/// </summary>
		public bool IsNonWindows_AssumeTrue(string path)
		{
			this.Validate(path);

			var output = Internal.IsNonWindows_AssumeTrue_NoValidation(path);
			return output;
		}

		/// <summary>
		/// Determines if a path is a non-Windows path, making no assumption if there are no directory separators present to allow an actual determination.
		/// </summary>
		public bool IsNonWindows_Strict(string path)
		{
			this.Validate(path);

			var output = Internal.IsNonWindows_Strict_NoValidation(path);
			return output;
		}

		/// <summary>
		/// Chooses <see cref="IsWindows_AssumeTrue(string)"/> as the default.
		/// </summary>
		public bool IsWindows(string path)
        {
			var output = this.IsWindows_AssumeTrue(path);
			return output;
		}

		public bool IsWindows_AssumeTrue(string path)
		{
			this.Validate(path);

			var output = Internal.IsWindows_AssumeTrue_NoValidation(path);
			return output;
		}

		public bool IsWindows_Strict(string path)
		{
			this.Validate(path);

			var output = Internal.IsWindows_Strict_NoValidation(path);
			return output;
		}

		public bool IsMixedPlatform(string path)
        {
			this.Validate(path);

			var output = Internal.IsMixedPlatform_NoValidation(path);
			return output;
        }

		public bool IsUnknownPlatform(string path)
        {
			this.Validate(path);

			var output = Internal.IsUnknownPlatform_NoValidation(path);
			return output;
		}

		public bool IsNullOrEmpty(string path)
        {
			var output = Instances.StringOperator.IsNullOrEmpty(path);
			return output;
		}

		public bool IsRooted(string path)
        {
			this.Validate(path);

			var output = Internal.IsRooted_NoValidation(path);
			return output;
        }

		/// <summary>
		/// Determines whether the <paramref name="path"/> is <inheritdoc cref="Glossary.RootIndicated" path="/name"/>.
		/// </summary>
		public bool IsRootIndicated(string path)
        {
			this.Validate(path);

			var output = Internal.IsRootIndicated_NoValidation(path);
			return output;
		}

		public void Validate(string path)
        {
			var isValid = this.IsValid(path);
			if(!isValid)
            {
				throw new Exception($"Invalid path: \"{path}\"");
            }
        }
    }


    namespace Internal
    {
		public partial interface IPathOperator
        {
			public WasFound<char> HasFirstDirectorySeparator(string path)
            {
				var directorySeparators = Instances.DirectorySeparators.Both;

				var indexOfFirstDirectorySeparator = Instances.StringOperator.IndexOfAny(
					path,
					directorySeparators);

				var wasFound = Instances.StringOperator.WasFound(indexOfFirstDirectorySeparator);

				var output = wasFound
					? WasFound.Found(path[indexOfFirstDirectorySeparator])
					: WasFound.NotFound<char>();
					;

				return output;
            }

			/// <summary>
			/// Determines if the first directory separator in the path is the specified <paramref name="directorySeparator"/>.
			/// If no directory separator is found, then the specified <paramref name="assumption"/> is made.
			/// </summary>
			public bool IsFirstDirectorySeparator(
				string path,
				char directorySeparator,
				bool assumption = true)
            {
				// Get the first directory separator of either type.
				var hasFirstDirectorySeparator = this.HasFirstDirectorySeparator(path);

				// If no directory separator is found in the string, make an assumption.
				if(!hasFirstDirectorySeparator)
                {
					return assumption;
                }

				// Else, see if the directory separator matches.
				var output = hasFirstDirectorySeparator == directorySeparator;
				return output;
			}

			public bool IsMixedPlatform_NoValidation(string path)
			{
				var bothDirectorySeparators = Instances.DirectorySeparators.Both;

				// If the path contains both directory separators, then it is mixed.
				var output = path.ContainsAll(bothDirectorySeparators);
				return output;
			}

			public bool IsRooted_NoValidation(string path)
			{
				// If the path is null or empty, then the path is not rooted.
				var isNullOrEmpty = Instances.StringOperator.IsNullOrEmpty(path);
				if (isNullOrEmpty)
				{
					return false;
				}

				// If the path starts with the non-Windows directory separator, then it is rooted (and assumed to be a non-Windows path).
				// Path is guaranteed to be non-null and non-empty by now.
				var firstCharacter = path.First();

				var firstCharacterIsNonWindowsDirectorySeparator = firstCharacter == Instances.DirectorySeparators.NonWindows;
				if (firstCharacterIsNonWindowsDirectorySeparator)
				{
					return true;
				}

				// If the path has a volume separator, and it comes before the first directory separator, then the path is rooted.
				// Really, it should be just if the path has a volume separator, but we would need to have better validation checks on the path to ensure the volume separator isn't somewhere invalid.
				var indexOfVolumeSeparator = path.IndexOf(Instances.PathSeparators.VolumeSeparator);

				var volumeSeparatorWasFound = Instances.StringOperator.WasFound(indexOfVolumeSeparator);
				if (volumeSeparatorWasFound)
				{
					return true;
				}

				return false;
			}

			public bool IsRootIndicated_NoValidation(string path)
			{
				// Ensure that we have a first character.
				var isNullOrEmpty = Instances.StringOperator.IsNullOrEmpty(path);
				if (isNullOrEmpty)
				{
					return false;
				}

				// Now get the first character.
				var firstCharacter = path.First();

				var directorySeparators = Instances.DirectorySeparators.Both;

				// If the first character is a directory separator, then the path is root-indicated.
				var output = directorySeparators.Contains(firstCharacter);
				return output;
			}

			public bool IsWindows_AssumeTrue_NoValidation(string path)
			{
				var output = this.IsFirstDirectorySeparator(
					path,
					Instances.DirectorySeparators.Windows,
					true);

				return output;
			}

			public bool IsWindows_Strict_NoValidation(string path)
			{
				var output = this.IsFirstDirectorySeparator(
					path,
					Instances.DirectorySeparators.Windows,
					true);

				return output;
			}

			public bool IsUnknownPlatform_NoValidation(string path)
			{
				var bothDirectorySeparators = Instances.DirectorySeparators.Both;

				var containsEither = Instances.StringOperator.ContainsAny(
					path,
					bothDirectorySeparators);

				// If the path does not contain either directory separator, then it's platform is unknown.
				var output = !containsEither;
				return output;
			}

			/// <summary>
			/// Determines if a path is a non-Windows path, assuming it is if there are no directory separators present to allow an actual determination.
			/// </summary>
			public bool IsNonWindows_AssumeTrue_NoValidation(string path)
			{
				var output = this.IsFirstDirectorySeparator(
					path,
					Instances.DirectorySeparators.NonWindows,
					true);

				return output;
			}

			/// <summary>
			/// Determines whether the <paramref name="path"/> is <inheritdoc cref="Glossary.DirectoryIndicated" path="/name"/>.
			/// </summary>
			public bool IsDirectoryIndicated_NoValidation(string path)
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
			public bool IsFileIndicated_NoValidation(string path)
			{
				// Test last character of path.
				var lastCharacter = Instances.StringOperator.GetLastCharacter(path);

				var isDirectorySeparator = Instances.DirectorySeparatorOperator.IsDirectorySeparator(lastCharacter);

				// If the last character of the path is a directory separator, then the path is *not* file indicated (it is directory indicated).
				var output = !isDirectorySeparator;
				return output;
			}

			/// <summary>
			/// Determines if a path is a non-Windows path, making no assumption if there are no directory separators present to allow an actual determination.
			/// </summary>
			public bool IsNonWindows_Strict_NoValidation(string path)
			{
				var output = this.IsFirstDirectorySeparator(
					path,
					Instances.DirectorySeparators.NonWindows,
					false);

				return output;
			}

			public bool IsResolved_NoValidation(string path)
			{
				var isUnresolved = this.IsUnresolved_NoValidation(path);

				// Resolved and unresolved are opposites.
				var output = !isUnresolved;
				return output;
			}

			public bool IsUnresolved_NoValidation(string path)
			{
				// Is the path simply one of the relative directory names?
				// Files named "." or ".." are illegal, because there is already an entry in every directory named "." or "..".
				var isRelativeDirectoryName = Instances.DirectoryNameOperator.IsRelativeDirectoryName(path);
				if (isRelativeDirectoryName)
				{
					return true;
				}

				// Since "." certainly, or ".." conceivably, might exist within the path ("." as the file extension separator and ".." perhaps accidentally in a file path), look for these directory names together with either of the directory separator.
				// Note that (at least) on Windows, the current or parent directory names cannot exist at the end of the directory or file name ("Directory.", "Directory..", "File." and "File.." are not allowed). Thus only before, instead of also after, a directory separator needs to be checked.
				// Directories and files cannot be named ".." or ".", since an entry with those names already exists in each directory.
				// The relative directory names will not appear alone since that would instead be interpretted as part of a file name or directory name.
				var searchStrings = new[]
				{
					$"{Instances.DirectoryNames.ParentDirectory}{Instances.DirectorySeparators.Windows}",
					$"{Instances.DirectoryNames.CurrentDirectory}{Instances.DirectorySeparators.Windows}",
					$"{Instances.DirectoryNames.ParentDirectory}{Instances.DirectorySeparators.NonWindows}",
					$"{Instances.DirectoryNames.CurrentDirectory}{Instances.DirectorySeparators.NonWindows}",
				};

				var output = Instances.StringOperator.ContainsAny(path,
					searchStrings);

				return output;
			}
		}
	}


	namespace Implementations
    {
		public partial interface IPathOperator
        {
			/// <summary>
			/// Determines whether a path is valid based solely on whether it is not null and not empty.
			/// </summary>
            public bool IsValid_NotNullNotEmpty(string path)
            {
				var isNullOrEmpty = Instances.StringOperator.IsNullOrEmpty(path);

				// If not null and not empty, then valid.
				var output = !isNullOrEmpty;
				return output;
			}

			/// <summary>
			/// Determines whether a path is valid based on whether the path, taken as a path, contains any 
			/// </summary>
			public bool IsValid_NoInvalidPathCharacters(string path)
            {
				var invalidCharacters = Instances.PathOperator.GetInvalidPathCharacters();

				var containsInvalidCharacters = Instances.StringOperator.ContainsAny(
					path,
					invalidCharacters);

				var output = !containsInvalidCharacters;
				return output;
			}

			/// <summary>
			/// Breaks a path down into its path parts, then verifies there are no invalid file name characters in any of the path parts (except for a volume separator in the first path part).
			/// </summary>
			public bool IsValid_NoInvalidFileNameCharactersInPathParts(string path)
            {
				// Do a quick check to ensure we have at least one path part.
				var isValid_NonNullNotEmpty = this.IsValid_NotNullNotEmpty(path);
				if(!isValid_NonNullNotEmpty)
                {
					return false;
                }

				// Now we have at least the first path part.s
				var pathParts = Instances.PathOperator.GetPathParts(path);

				var invalidFileNameCharacters = Instances.PathOperator.GetInvalidFileNameCharacters();

				var invalidFileNameCharactersExceptVolumeSeparator = invalidFileNameCharacters.Except(Instances.PathSeparators.VolumeSeparator).Now();

				var firstPathPart = pathParts.First();

				var firstPathPartIsInvalid = Instances.StringOperator.ContainsAny(
					firstPathPart,
					invalidFileNameCharactersExceptVolumeSeparator);

				if(firstPathPartIsInvalid)
                {
					return false;
                }

                foreach (var pathPart in pathParts.SkipFirst())
                {
					var pathPartIsInvalid = Instances.StringOperator.ContainsAny(
						pathPart,
						invalidFileNameCharacters);

					if(pathPartIsInvalid)
                    {
						return false;
                    }
                }

				return true;
            }

			/// <summary>
			/// Directory names and files names cannot end with the current directory name ("."), or the parent directory name ("..").
			/// </summary>
			public bool IsValid_NoEndingWithSpecialDirectoryNames(string path)
            {
				var pathParts = Instances.PathOperator.GetPathParts(path);

                foreach (var pathPart in pathParts)
                {
					var endsWithSpecialDirectoryName = pathPart.EndsWith(Instances.DirectoryNames.CurrentDirectory) || path.EndsWith(Instances.DirectoryNames.ParentDirectory);
					if(endsWithSpecialDirectoryName)
                    {
						return false;
                    }
                }

				return true;
            }
        }
    }
}