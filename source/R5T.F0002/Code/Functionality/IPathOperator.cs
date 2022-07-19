using System;

using R5T.T0132;


namespace R5T.F0002
{
	[FunctionalityMarker]
	public partial interface IPathOperator : IFunctionalityMarker
	{
		public char[] GetInvalidPathCharacters()
	}
}