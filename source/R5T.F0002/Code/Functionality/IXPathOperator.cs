using System;
using System.Xml.Linq;
using System.Xml.XPath;

using R5T.N0000;
using R5T.T0132;


namespace R5T.F0002
{
    /// <summary>
    /// Here (instead of F0000) because <see cref="WasFound{T}"/> is in Magyar, and F0000 cannot depend on Magyar.
    /// </summary>
    [FunctionalityMarker]
	public partial interface IXPathOperator : IFunctionalityMarker
	{
		public WasFound<XElement> HasElement<TNode>(TNode node, string xPath)
			where TNode : XNode
		{
			var itemOrDefault = node.XPathSelectElement(xPath);

			var wasFound = WasFound.From(itemOrDefault);
			return wasFound;
		}
	}
}