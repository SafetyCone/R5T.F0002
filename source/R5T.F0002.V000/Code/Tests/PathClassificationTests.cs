using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace R5T.F0002.V000
{
    /// <summary>
    /// Tests for classifying paths.
    /// * Valid/Invalid - No invalid path characters.
    /// * Relative/Root (Indicated) - Beginning of path. (For Windows paths, if the path contains the volume separator character, this it is rooted. For Non-Windows paths, there is no way to know if the path is rooted, without reference to a file system (since /mnt/efs might be a relative path, or
    /// * Directory/File (Indicated) - End of path. Indicated since there is no way to actually distinguish between directories and files without reference to a file system.
    /// * Windows/Non-Windows (Dominated, Assumed) - Does the path use the Windows separator.
    /// * Resolved/Unresolved - No current directory or parent directory directory names in the path.
    /// </summary>
    [TestClass]
    public class PathClassificationTests
    {
        /// <summary>
        /// Tests the <see cref="IPathOperator.IsDirectoryIndicated(string)"/> method on a file indicated path to confirm negative.
        /// </summary>
        [TestMethod]
        public void IsDirectoryIndicated_Negative()
        {
            var expectations = Instances.ExpectedValues.IsDirectoryIndicated_Negative;

            var actual = Instances.PathOperator.IsDirectoryIndicated(expectations);

            Instances.Assertion.AreEqual(expectations, actual);
        }

        /// <summary>
        /// Tests the <see cref="IPathOperator.IsDirectoryIndicated(string)"/> method on a directory indicated path to confirm positive.
        /// </summary>
        [TestMethod]
        public void IsDirectoryIndicated_Positive()
        {
            var expectations = Instances.ExpectedValues.IsDirectoryIndicated_Positive;

            var actual = Instances.PathOperator.IsDirectoryIndicated(expectations);

            Instances.Assertion.AreEqual(expectations, actual);
        }

        /// <summary>
        /// Tests the <see cref="IPathOperator.IsFileIndicated(string)"/> method on a directory indicated path to confirm negative.
        /// </summary>
        [TestMethod]
        public void IsFileIndicated_Negative()
        {
            var expectations = Instances.ExpectedValues.IsFileIndicated_Negative;

            var actual = Instances.PathOperator.IsFileIndicated(expectations);

            Instances.Assertion.AreEqual(expectations, actual);
        }

        /// <summary>
        /// Tests the <see cref="IPathOperator.IsFileIndicated(string)"/> method on a file indicated path to confirm positive.
        /// </summary>
        [TestMethod]
        public void IsFileIndicated_Positive()
        {
            var expectations = Instances.ExpectedValues.IsFileIndicated_Positive;

            var actual = Instances.PathOperator.IsFileIndicated(expectations);

            Instances.Assertion.AreEqual(expectations, actual);
        }
    }
}
