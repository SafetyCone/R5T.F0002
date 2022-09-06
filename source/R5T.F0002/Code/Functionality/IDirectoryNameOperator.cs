using System;

using R5T.T0132;


namespace R5T.F0002
{
	[FunctionalityMarker]
	public partial interface IDirectoryNameOperator : IFunctionalityMarker
	{
		/// <summary>
		/// <para>Returns true if the directory name is *not* the <see cref="IDirectoryNames.CurrentDirectory"/> or <see cref="IDirectoryNames.ParentDirectory"/> name.</para>
		/// <para><inheritdoc cref="IsActualDirectoryName(string)" path="/useful-when"/></para>
		/// </summary>
		/// <useful-when>This method is useful in the many situations where the <see cref="IDirectoryNames.CurrentDirectory"/> and <see cref="IDirectoryNames.ParentDirectory"/> names appear (such as low-level directory listings).</useful-when>
		public bool IsActualDirectoryName(string directoryName)
        {
			var output = true
				&& directoryName != Instances.DirectoryNames.CurrentDirectory
				&& directoryName != Instances.DirectoryNames.ParentDirectory
				;

			return output;
		}

		public bool IsCurrentDirectory(string directoryName)
        {
			var output = directoryName == Instances.DirectoryNames.CurrentDirectory;
			return output;
        }

		public bool IsCurrentOrParentDirectoryName(string directoryName)
        {
			var output = this.IsRelativeDirectoryName(directoryName);
			return output;
		}

		public bool IsParentDirectory(string directoryName)
        {
			var output = directoryName == Instances.DirectoryNames.ParentDirectory;
			return output;
        }

		public bool IsRelativeDirectoryName(string directoryName)
        {
			var output = false
				|| this.IsCurrentDirectory(directoryName)
				|| this.IsParentDirectory(directoryName)
				;

			return output;
        }
	}
}