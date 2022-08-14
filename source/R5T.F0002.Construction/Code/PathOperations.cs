using System;
using System.IO;
using System.Linq;


namespace R5T.F0002.Construction
{
    public static class PathOperations
    {
        public static void SubMain()
        {
            //PathOperations.TryIsDirectoryIndicated();
            PathOperations.AnalyzePath();
        }

#pragma warning disable IDE0051 // Remove unused private members

        private static void AnalyzePath()
        {
            // Select a file-indicated path.
            var path = Instances.Paths.N013;

            var outputFilePath = @"C:\Temp\Path Analysis.txt";

            PathOperations.AnalyzePath(
                path,
                outputFilePath);
        }

        private static void AnalyzePath(
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

            FileHelper.WriteAllLines_Synchronous(
                outputFilePath,
                lines);
        }

        private static void TryIsDirectoryIndicated()
        {
            var fileIndicatedPath = Instances.Paths.N001;
            //var expected = false;

            var isDirectoryIndicated = Instances.PathOperator.IsDirectoryIndicated(fileIndicatedPath);

            // Test.
            Console.WriteLine(isDirectoryIndicated);
        }
    }
}
