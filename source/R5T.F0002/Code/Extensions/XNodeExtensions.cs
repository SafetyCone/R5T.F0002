using System;
using System.Xml.Linq;

using R5T.F0000;

using Instances = R5T.F0002.Instances;


namespace System
{
    public static class XNodeExtensions
    {
        public static WasFound<XElement> HasElement<TNode>(this TNode node, Func<TNode, XElement> elementOrDefaultSelector)
            where TNode : XNode
        {
            var elementOrDefault = elementOrDefaultSelector(node);

            var wasFound = WasFound.From(elementOrDefault);
            return wasFound;
        }

        public static WasFound<XElement> HasElement<TNode>(this TNode node, string xPath)
            where TNode : XNode
        {
            var wasFound = Instances.XPathOperator.HasElement(node, xPath);
            return wasFound;
        }
    }
}
