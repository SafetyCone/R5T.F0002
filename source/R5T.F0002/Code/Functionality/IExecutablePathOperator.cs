using System;

using R5T.T0132;


namespace R5T.F0002
{
	/// <summary>
	/// Inheritance required since <see cref="IPathOperator"/> is not in this library.
	/// </summary>
	[FunctionalityMarker]
	public partial interface IExecutablePathOperator : IFunctionalityMarker,
		F0000.IExecutablePathOperator
	{
		/// <summary>
		/// Gets the file path for an assembly in the same directory as the current executable.
		/// </summary>
		public string Get_ExecutableDirectoryAssemblyFilePath(string assemblyName)
		{
            var assemblyFileName = Instances.FileNameOperator.Get_AssemblyFileName(
                assemblyName);

            var assemblyFilePath = this.Get_Path_ExecutableDirectoryRelative(
                assemblyFileName);

            return assemblyFilePath;
        }

        /// <summary>
        /// Gets the file path for the XML documentation file of an assembly in the same directory as the current executable.
        /// </summary>
        public string Get_ExecutableDirectoryAssemblyDocumentatinFilePath(string assemblyName)
        {
            var assemblyDocumentationFileName = Instances.FileNameOperator.Get_AssemblyDocumentationFileName(
                assemblyName);

            var assemblyDocumentationFilePath = Instances.ExecutablePathOperator.Get_Path_ExecutableDirectoryRelative(
                assemblyDocumentationFileName);

            return assemblyDocumentationFilePath;
        }
    }
}