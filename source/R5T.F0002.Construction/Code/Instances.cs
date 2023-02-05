using System;


namespace R5T.F0002.Construction
{
    public static class Instances
    {
        public static IDirectoryPaths DirectoryPaths => Construction.DirectoryPaths.Instance;
        public static F0000.IFileOperator FileOperator => F0000.FileOperator.Instance;
        public static IGlobbedPaths GlobbedPaths => Construction.GlobbedPaths.Instance;
        public static IGlobExperiments GlobExperiments => Construction.GlobExperiments.Instance;
        public static IPathOperator PathOperator { get; } = F0002.PathOperator.Instance;
        public static Z0004.IPaths Paths { get; } = Z0004.Paths.Instance;
    }
}