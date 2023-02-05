using System;


namespace R5T.F0002.Construction
{
    public class PathOperations : IPathOperations
    {
        #region Infrastructure

        public static IPathOperations Instance { get; } = new PathOperations();


        private PathOperations()
        {
        }

        #endregion
    }
}
