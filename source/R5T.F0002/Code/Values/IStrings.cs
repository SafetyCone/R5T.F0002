using System;

using R5T.T0131;


namespace R5T.F0002
{
	[ValuesMarker]
	public partial interface IStrings : IValuesMarker,
		Z0000.IStrings
	{
		public string GlobPattern_NonWindows => "**/*";
        public string GlobPattern_Windows => @"**\*";

		public string[] GlobPatterns => new[]
		{
			this.GlobPattern_NonWindows,
			this.GlobPattern_Windows,
		};
    }
}