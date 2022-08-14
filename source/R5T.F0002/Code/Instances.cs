using System;

using R5T.F0000;
using R5T.Z0000;


namespace R5T.F0002
{
    public static class Instances
    {
        public static ICharacters Characters { get; } = Z0000.Characters.Instance;
        public static IDirectoryNames DirectoryNames { get; } = F0002.DirectoryNames.Instance;
        public static IDirectoryNameOperator DirectoryNameOperator { get; } = F0002.DirectoryNameOperator.Instance;
        public static IDirectorySeparatorOperator DirectorySeparatorOperator { get; } = F0002.DirectorySeparatorOperator.Instance;
        public static IDirectorySeparators DirectorySeparators { get; } = F0002.DirectorySeparators.Instance;
        public static IEnumerationHelper EnumerationHelper { get; } = F0002.EnumerationHelper.Instance;
        public static IFileNameOperator FileNameOperator { get; } = F0000.FileNameOperator.Instance;
        public static IPathOperator PathOperator { get; } = F0002.PathOperator.Instance;
        public static IPathSeparators PathSeparators { get; } = F0002.PathSeparators.Instance;
        public static IStringOperator StringOperator { get; } = F0000.StringOperator.Instance;
        public static IStrings Strings { get; } = Z0000.Strings.Instance;
    }
}