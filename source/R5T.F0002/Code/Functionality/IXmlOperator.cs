using System;

using R5T.T0132;


namespace R5T.F0002
{
    /// <summary>
    /// Here (instead of F0000) because <see cref="T0221.WasFound{T}"/> is in Magyar, and F0000 cannot depend on Magyar.
    /// </summary>
    [FunctionalityMarker]
	public partial interface IXmlOperator : IFunctionalityMarker,
		F0000.IXmlOperator
	{
	}
}