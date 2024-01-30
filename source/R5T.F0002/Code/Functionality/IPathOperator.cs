using System;


using R5T.T0132;


namespace R5T.F0002
{
	[FunctionalityMarker]
	public partial interface IPathOperator : IFunctionalityMarker,
		F0000.IPathOperator
	{
#pragma warning disable IDE1006 // Naming Styles
        private new Internal.IPathOperator _Internal => Internal.PathOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles
	}
}


namespace R5T.F0002.Internal
{
	[FunctionalityMarker]
	public partial interface IPathOperator : IFunctionalityMarker,
		L0066.Internal.IPathOperator
	{

	}
}
