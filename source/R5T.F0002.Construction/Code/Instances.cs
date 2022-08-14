using System;

using R5T.Z0004;


namespace R5T.F0002.Construction
{
    public static class Instances
    {
        public static IPathOperator PathOperator { get; } = F0002.PathOperator.Instance;
        public static IPaths Paths { get; } = Z0004.Paths.Instance;
    }
}