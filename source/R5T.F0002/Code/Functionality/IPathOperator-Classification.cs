using System;
using System.Linq;

using R5T.F0000;
using R5T.T0132;
using R5T.T0221;

using Glossary = R5T.Y0006.Glossary.For_Paths;


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
            var isValid = ResultOrException.Try(() => this.Is_Valid(path));

            var isWindows = ResultOrException.Try(() => this.Is_Windows(path));
            var isNonWindows = ResultOrException.Try(() => this.Is_NonWindows(path));
            var isMixedPlatform = ResultOrException.Try(() => this.Is_MixedPlatform(path));
            var isUnknownPlatform = ResultOrException.Try(() => this.Is_UnknownPlatform(path));

            var isDirectoryIndicated = ResultOrException.Try(() => this.Is_DirectoryIndicated(path));
            var isFileIndicated = ResultOrException.Try(() => this.Is_FileIndicated(path));

            var isRootIndicated = ResultOrException.Try(() => this.Is_RootIndicated(path));

            var isRooted = ResultOrException.Try(() => this.Is_Rooted(path));

            var isResolved = ResultOrException.Try(() => this.Is_Resolved(path));
            var isUnresolved = ResultOrException.Try(() => this.Is_Unresolved(path));

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
			var isValid = ResultOrException.Try(() => this.Is_Valid(path));

			var isWindows = ResultOrException.Try(() => this.Is_Windows_AssumeTrue(path));
			var isNonWindows = ResultOrException.Try(() => this.Is_NonWindows_AssumeTrue(path));
			var isMixedPlatform = ResultOrException.Try(() => this.Is_MixedPlatform(path));
			var isUnknownPlatform = ResultOrException.Try(() => this.Is_UnknownPlatform(path));

			var isDirectoryIndicated = ResultOrException.Try(() => this.Is_DirectoryIndicated(path));
			var isFileIndicated = ResultOrException.Try(() => this.Is_FileIndicated(path));

			var isRootIndicated = ResultOrException.Try(() => this.Is_RootIndicated(path));

			var isRooted = ResultOrException.Try(() => this.Is_Rooted(path));

			var isResolved = ResultOrException.Try(() => this.Is_Resolved(path));
			var isUnresolved = ResultOrException.Try(() => this.Is_Unresolved(path));

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

		public bool IsGlobbed(string path)
		{
			var globPatterns = Instances.Strings.GlobPatterns;

			foreach (var globPattern in globPatterns)
			{
				var pathContainsGlobPattern = path.Contains(globPattern);
				if(pathContainsGlobPattern)
				{
					return true;
				}
			}

			// Else, failure.
			return false;
		}
    }
}