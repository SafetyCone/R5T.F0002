using System;


namespace R5T.F0002.Construction
{
    public class GlobExperiments : IGlobExperiments
    {
        #region Infrastructure

        public static IGlobExperiments Instance { get; } = new GlobExperiments();


        private GlobExperiments()
        {
        }

        #endregion
    }
}
