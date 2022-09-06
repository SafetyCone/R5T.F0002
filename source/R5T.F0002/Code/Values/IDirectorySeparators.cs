using System;

using R5T.T0131;


namespace R5T.F0002
{
	[ValuesMarker]
	public partial interface IDirectorySeparators : IValuesMarker
	{
		private static readonly char[] zBoth = new[] { Instances.Characters.Backslash, Instances.Characters.Slash };
		public char[] Both => IDirectorySeparators.zBoth;

		public char NonWindows => Instances.Characters.Slash;
		public char Windows => Instances.Characters.Backslash;

		/// <summary>
		/// The standard is <see cref="Windows"/>.
		/// </summary>
		public char Standard => this.Windows;
	}
}