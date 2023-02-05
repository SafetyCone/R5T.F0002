using System;
using System.Linq;

using R5T.T0132;


namespace R5T.F0002.Construction
{
    [FunctionalityMarker]
    public partial interface IPathOperations : IFunctionalityMarker
    {
        public void AnalyzePath()
        {
            // Select a file-indicated path.
            var path = Instances.Paths.N013;

            var outputFilePath = @"C:\Temp\Path Analysis.txt";

            this.AnalyzePath(
                path,
                outputFilePath);
        }

        public void AnalyzePath(
            string path,
            string outputFilePath)
        {
            var pathClassificationInfo = Instances.PathOperator.GetPathClassificationInfo(path);
            var pathClassificationInfo_NoValidation = Instances.PathOperator.GetPathClassificationInfo_NoValidation(path);

            static string[] GetLines(PathClassificationInfo pathClassificationInfo)
            {
                var lines = new[]
                {
                    $"Valid: {pathClassificationInfo.IsValid}",
                    "",
                    $"Windows: {pathClassificationInfo.IsWindows}",
                    $"Non-Windows: {pathClassificationInfo.IsNonWindows}",
                    $"Mixed Platform: {pathClassificationInfo.IsMixedPlatform}",
                    $"Unknown Platform: {pathClassificationInfo.IsUnknownPlatform}",
                    "",
                    $"Directory Indicated: {pathClassificationInfo.IsDirectoryIndicated}",
                    $"File Indicated: {pathClassificationInfo.IsFileIndicated}",
                    "",
                    $"Root Indicated: {pathClassificationInfo.IsRootIndicated}",
                    "",
                    $"Rooted: {pathClassificationInfo.IsRooted}",
                    "",
                    $"Resolved: {pathClassificationInfo.IsResolved}",
                    $"Unresolved: {pathClassificationInfo.IsUnresolved}",
                };

                return lines;
            }

            var lines = new[]
            {
                $"\n# With Validation #\n\nPath:\n\"{path}\"\n",
            }
            .AppendRange(GetLines(pathClassificationInfo))
            .Append($"\n# Without Validation #\n\nPath:\n\"{path}\"\n")
            .AppendRange(GetLines(pathClassificationInfo_NoValidation));

            Instances.FileOperator.WriteAllLines_Synchronous(
                outputFilePath,
                lines);
        }

        public void TryIsDirectoryIndicated()
        {
            var fileIndicatedPath = Instances.Paths.N001;
            //var expected = false;

            var isDirectoryIndicated = Instances.PathOperator.IsDirectoryIndicated(fileIndicatedPath);

            // Test.
            Console.WriteLine(isDirectoryIndicated);
        }
    }
}
