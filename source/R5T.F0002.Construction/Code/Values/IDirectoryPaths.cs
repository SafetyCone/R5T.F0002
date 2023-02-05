using System;

using R5T.T0131;


namespace R5T.F0002.Construction
{
    [ValuesMarker]
    public partial interface IDirectoryPaths : IValuesMarker
    {
        public string Project01 => @"C:\Code\DEV\Git\GitHub\davidcoats\D8S.W0003.Private\source\D8S.W0003\";
        public string Project02 => @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.R0005\source\R5T.R0005\";

        public string DestinationProject => this.Project01;
        public string SourceProject => this.Project02;
    }
}
