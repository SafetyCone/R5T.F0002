using System;
using System.Xml.Linq;

using R5T.F0000;

using Instances = R5T.F0002.Instances;


namespace System
{
    public static class XElementExtensions
    {
        public static XElement GetChild<TElement>(this TElement element, string childName)
            where TElement : XElement
        {
            var output = Instances.XmlOperator.GetChild(element, childName);
            return output;
        }

        public static WasFound<XElement> HasChild_Single<TElement>(this TElement element, string childName)
            where TElement : XElement
        {
            var wasFound = Instances.XmlOperator.HasChild_Single(element, childName);
            return wasFound;
        }

        /// <summary>
		/// Chooses <see cref="HasChild_Single{TElement}(TElement, string)"/> as the default.
		/// </summary>
		public static WasFound<XElement> HasChild<TElement>(this TElement element, string childName)
            where TElement : XElement
        {
            var wasFound = element.HasChild_Single(childName);
            return wasFound;
        }
    }
}
