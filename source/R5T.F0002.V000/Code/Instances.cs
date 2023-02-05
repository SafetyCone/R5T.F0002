using System;

using R5T.Z0004;


namespace R5T.F0002.V000
{
    public static class Instances
    {
        public static F0101.IAssertion Assertion { get; } = F0101.Assertion.Instance;
        public static Z0004.IPaths ExamplePaths { get; } = Paths.Instance;
        public static IExpectedValues ExpectedValues { get; } = V000.ExpectedValues.Instance;
        public static IPaths Path { get; } = V000.Path.Instance;
        public static IPathOperator PathOperator { get; } = V000.PathOperator.Instance;
    }
}