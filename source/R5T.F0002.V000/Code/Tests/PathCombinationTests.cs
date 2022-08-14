using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace R5T.F0002.V000
{
    [TestClass]
    public class PathCombinationTests
    {
        [TestMethod]
        public void Combine01()
        {
            var sourceDirectoryPath = Instances.ExamplePaths.N008;
            var fileRelativePath = Instances.ExamplePaths.N007;

            var expectedFilePath = Instances.ExamplePaths.N006;

            var actual = Instances.PathOperator.Combine(
                sourceDirectoryPath,
                fileRelativePath);

            Instances.Assertion.AreEqual(actual, expectedFilePath);
        }
    }
}
