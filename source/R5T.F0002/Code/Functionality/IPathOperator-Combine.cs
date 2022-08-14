using System;
using System.Collections.Generic;
using System.Linq;

using Glossary = R5T.Y0000.Glossary.ForPaths;


namespace R5T.F0002
{
	public partial interface IPathOperator
	{
        public string Combine(
            string prefixPath,
            string suffixPath)
        {
            var directorySeparator = this.DetectDirectorySeparator(
                prefixPath,
                suffixPath);

            var output = this.Combine_EnsureResolved(
                prefixPath,
                suffixPath,
                directorySeparator);

            return output;
        }

        public char DetectDirectorySeparator(
            string prefixPath,
            string suffixPath)
        {
            var prefixHasDirectorySeparator = Internal.HasFirstDirectorySeparator(prefixPath);
            if(prefixHasDirectorySeparator)
            {
                return prefixHasDirectorySeparator.Result;
            }

            var suffixHasDirectorySeparator = Internal.HasFirstDirectorySeparator(prefixPath);
            if(suffixHasDirectorySeparator)
            {
                return suffixHasDirectorySeparator.Result;
            }

            // Else, use the current platform's directory separator.
            var output = Instances.DirectorySeparatorOperator.GetCurrentPlatformDirectorySeparator();
            return output;
        }

        /// <summary>
        /// Combine the path segments, ensuring that the result is resolved.
        /// </summary>
        public string Combine_EnsureResolved(
            string prefixPath,
            string suffixPath,
            char directorySeparator)
        {
            var combinedDirectorySeparatorEnsuredPath = this.Combine_EnsureDirectorySeparator(
                prefixPath,
                suffixPath,
                directorySeparator);

            var output = this.EnsureResolved(combinedDirectorySeparatorEnsuredPath);
            return output;
        }

        /// <summary>
        /// Combines the paths, ensuring that the path uses the specified directory separator.
        /// </summary>
        public string Combine_EnsureDirectorySeparator(
            string prefixPath,
            string suffixPath,
            char directorySeparator)
        {
            var possiblyMixedDirectorySeparatorsPath = this.Combine_EnsureLinkingDirectorySeparator(
                prefixPath,
                suffixPath,
                directorySeparator);

            var output = this.EnsureDirectorySeparator(
                possiblyMixedDirectorySeparatorsPath,
                directorySeparator);

            return output;
        }

        /// <summary>
        /// Combines the two paths, ensuring that only the specified directory separator is between the two paths.
        /// This is useful because paths might end with a directory separator or begin with a directory separator, and you don't want to have double directory separators.
        /// </summary>
        public string Combine_EnsureLinkingDirectorySeparator(
            string prefixPath,
            string suffixPath,
            char directorySeparator)
        {
            var ensuredPrefixPath = this.EnsureIsNotDirectoryIndicated(prefixPath);
            var ensuredSuffixPath = this.EnsureIsNotRootIndicated(suffixPath);

            var output = this.Combine_WithoutModification(
                ensuredPrefixPath,
                ensuredSuffixPath,
                directorySeparator);

            return output;
        }

        public string Combine_WithoutModification(
            string[] pathSegments,
            char directorySeparator)
        {
            var output = String.Join(directorySeparator, pathSegments);
            return output;
        }

        public string Combine_WithoutModification(
            string prefixPath,
            string suffixPath,
            char directorySeparator)
        {
            var output = $"{prefixPath}{directorySeparator}{suffixPath}";
            return output;
        }

        public string Combine_WithoutModification(
            string prefixPath,
            string suffixPath)
        {
            var output = $"{prefixPath}{suffixPath}";
            return output;
        }

        public string GetDirectoryPath(string parentDirectoryPath, string directoryName)
        {
            var output = this.Combine(parentDirectoryPath, directoryName);
            return output;
        }

        public string GetDirectoryPath(string parentDirectoryPath, IEnumerable<string> directoryNames)
        {
            var output = parentDirectoryPath;

            foreach (var directoryName in directoryNames)
            {
                output = this.GetDirectoryPath(output, directoryName);
            }

            return output;
        }

        public string GetDirectoryPath(string parentDirectoryPath, params string[] directoryNames)
        {
            var output = this.GetDirectoryPath(parentDirectoryPath, directoryNames.AsEnumerable());
            return output;
        }
    }
}