using System;

using R5T.T0141;


namespace R5T.F0002.Construction
{
    /// <summary>
    /// Experiments for working with globbed paths (like "./Components/**/*.razor").
    /// </summary>
    [ExperimentsMarker]
    public partial interface IGlobExperiments : IExperimentsMarker
    {
        public void GetRelativePath()
        {
            var globbedRelativePath = Instances.GlobbedPaths.RazorComponents;
            var destinationDirectoryPath = Instances.DirectoryPaths.DestinationProject;

            var sourceDirectoryPath = Instances.DirectoryPaths.SourceProject;

            var sourceGlobbedPath = Instances.PathOperator.Combine(
                sourceDirectoryPath,
                globbedRelativePath);

            var relativePathFromSourceToDestination = Instances.PathOperator.GetRelativePath(
                destinationDirectoryPath,
                sourceGlobbedPath);

            var expected = @"..\..\..\..\SafetyCone\R5T.R0005\source\R5T.R0005\Components\**\*.razor";

            Console.WriteLine(expected);
            Console.WriteLine(relativePathFromSourceToDestination);
        }

        public void GetAbsolutePath()
        {
            var globbedRelativePath = Instances.GlobbedPaths.RazorComponents;
            var directoryPath = Instances.DirectoryPaths.DestinationProject;

            var expected = @"C:\Code\DEV\Git\GitHub\davidcoats\D8S.W0003.Private\source\D8S.W0003\Components\**\*.razor";

            var actual = Instances.PathOperator.Combine(
                directoryPath,
                globbedRelativePath);

            Console.WriteLine(expected);
            Console.WriteLine(actual);
        }
    }
}
