using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace R5T.F0002.V000
{
    [TestClass]
    public class PathRelativeTests
    {
        [TestMethod]
        public void GetParentDirectory_ForFile01()
        {
            var filePath = Instances.ExamplePaths.N005;

            var expectedParentDirectoryPath = Instances.ExamplePaths.N008;

            var actual = Instances.PathOperator.GetParentDirectoryPath_ForFile(filePath);

            Instances.Assertion.AreEqual(actual, expectedParentDirectoryPath);
        }

        /// <summary>
        /// Test the pathological case of a directory-indicated file path.
        /// </summary>
        [TestMethod]
        public void GetParentDirectory_ForFile02()
        {
            var filePath = Instances.ExamplePaths.N005_DirectoryIndicated;

            var expectedParentDirectoryPath = Instances.ExamplePaths.N008;

            var actual = Instances.PathOperator.GetParentDirectoryPath_ForFile(filePath);

            Instances.Assertion.AreEqual(actual, expectedParentDirectoryPath);
        }

        [TestMethod]
        public void GetRelativePath01()
        {
            var sourceDirectoryPath = Instances.ExamplePaths.N008;
            var destinationDirectoryPath = Instances.ExamplePaths.N006;

            var expectedRelativePath = Instances.ExamplePaths.N007;

            var actual = Instances.PathOperator.GetRelativePath(
                sourceDirectoryPath,
                destinationDirectoryPath);

            Instances.Assertion.AreEqual(actual, expectedRelativePath);
        }
    }
}
