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
		public XElement GetChild_Single<TElement>(TElement element, string childName)
			where TElement : XElement
		{
			var wasFound = this.HasChild_Single(element, childName);
			if(!wasFound)
            {
				throw new Exception($"No child found with name: '{childName}'");
            }

			return wasFound.Result;
		}

		/// <summary>
		/// Chooses <see cref="GetChild_Single{TElement}(TElement, string)"/> as the default.
		/// </summary>
		public XElement GetChild<TElement>(TElement element, string childName)
			where TElement : XElement
		{
			var wasFound = this.GetChild_Single(element, childName);
			return wasFound;
		}

		public WasFound<XElement> HasChild_Single<TElement>(TElement element, string childName)
			where TElement : XElement
		{
			// If empty, shortcut.
			if (!element.HasElements)
			{
				return WasFound.NotFound<XElement>();
			}

			var outputOrDefault = element.Elements()
				.Where(xElement => xElement.Name == childName)
				.SingleOrDefault();

			var wasFound = WasFound.From(outputOrDefault);
			return wasFound;
		}

		/// <summary>
		/// Chooses <see cref="HasChild_Single{TElement}(TElement, string)"/> as the default.
		/// </summary>
		public WasFound<XElement> HasChild<TElement>(TElement element, string childName)
			where TElement : XElement
		{
			var wasFound = this.HasChild_Single(element, childName);
			return wasFound;
		}
	}
}