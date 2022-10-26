using System;
using System.Linq;
using System.Xml.Linq;

using R5T.F0000;
using R5T.T0132;


namespace R5T.F0002
{
    /// <summary>
    /// Here (instead of F0000) because <see cref="WasFound{T}"/> is in Magyar, and F0000 cannot depend on Magyar.
    /// </summary>
    [FunctionalityMarker]
	public partial interface IXmlOperator : IFunctionalityMarker,
		F0000.IXmlOperator
	{
	}
}