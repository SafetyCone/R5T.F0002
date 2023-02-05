using System;
using System.Collections.Generic;


namespace R5T.F0002.V000.T000
{
    /// <summary>
    /// Only compare values for properties with non-null values.
    /// </summary>
    public class PathClassificationInfoAllowNullEqualityComparer : IEqualityComparer<PathClassificationInfo>
    {
        #region Static

        public static PathClassificationInfoAllowNullEqualityComparer Instance { get; } = new PathClassificationInfoAllowNullEqualityComparer();

        #endregion


        public bool Equals(
            PathClassificationInfo x,
            PathClassificationInfo y)
        {
            var output = true
                && (x.IsDirectoryIndicated?.Equals(y.IsDirectoryIndicated) ?? true)
                && (x.IsFileIndicated?.Equals(y.IsFileIndicated) ?? true)
                && (x.IsMixedPlatform?.Equals(y.IsMixedPlatform) ?? true)
                && (x.IsNonWindows?.Equals(y.IsNonWindows) ?? true)
                && (x.IsResolved?.Equals(y.IsResolved) ?? true)
                && (x.IsRooted?.Equals(y.IsRooted) ?? true)
                && (x.IsRootIndicated?.Equals(y.IsRootIndicated) ?? true)
                && (x.IsUnknownPlatform?.Equals(y.IsUnknownPlatform) ?? true)
                && (x.IsUnresolved?.Equals(y.IsUnresolved) ?? true)
                && (x.IsValid?.Equals(y.IsValid) ?? true)
                && (x.IsWindows?.Equals(y.IsWindows) ?? true)
                ;

            return output;
        }

        /// <summary>
        /// Just leave unimplemented.
        /// </summary>
        public int GetHashCode(PathClassificationInfo obj)
        {
            throw new NotImplementedException();
        }
    }
}
