using System;


namespace R5T.F0002.Construction
{
    public static class PathOperations
    {
        public static void SubMain()
        {
            PathOperations.TryIsDirectoryIndicated();
        }

        public static void TryIsDirectoryIndicated()
        {
            var fileIndicatedPath = Instances.Path.Path_001;
            //var expected = false;

            var isDirectoryIndicated = Instances.PathOperator.IsDirectoryIndicated(fileIndicatedPath);

            // Test.
            Console.WriteLine(isDirectoryIndicated);
        }
    }
}
