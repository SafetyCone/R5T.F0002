using System;


namespace R5T.F0002.Construction
{
    public class GlobbedPaths : IGlobbedPaths
    {
        #region Infrastructure

        public static IGlobbedPaths Instance { get; } = new GlobbedPaths();


        private GlobbedPaths()
        {
        }

        #endregion
    }
}
