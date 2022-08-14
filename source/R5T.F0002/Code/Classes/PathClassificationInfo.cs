using System;

using R5T.Magyar;


namespace R5T.F0002
{
    public class PathClassificationInfo : IEquatable<PathClassificationInfo>
    {
        public ResultOrException<bool> IsValid { get; set; }

        public ResultOrException<bool> IsWindows { get; set; }
        public ResultOrException<bool> IsNonWindows { get; set; }
        public ResultOrException<bool> IsMixedPlatform { get; set; }
        public ResultOrException<bool> IsUnknownPlatform { get; set; }

        public ResultOrException<bool> IsDirectoryIndicated { get; set; }
        public ResultOrException<bool> IsFileIndicated { get; set; }

        public ResultOrException<bool> IsRootIndicated { get; set; }

        public ResultOrException<bool> IsRooted { get; set; }

        public ResultOrException<bool> IsResolved { get; set; }
        public ResultOrException<bool> IsUnresolved { get; set; }


        public bool Equals(PathClassificationInfo other)
        {
            if(other is null)
            {
                return false;
            }

            var output = true
                && this.IsDirectoryIndicated == other.IsDirectoryIndicated
                && this.IsFileIndicated == other.IsFileIndicated
                && this.IsMixedPlatform == other.IsMixedPlatform
                && this.IsNonWindows == other.IsNonWindows
                && this.IsResolved == other.IsResolved
                && this.IsRooted == other.IsRooted
                && this.IsRootIndicated == other.IsRootIndicated
                && this.IsUnknownPlatform == other.IsUnknownPlatform
                && this.IsUnresolved == other.IsUnresolved
                && this.IsValid == other.IsValid
                && this.IsWindows == other.IsWindows
                ;

            return output;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as PathClassificationInfo);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
