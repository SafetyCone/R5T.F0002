using System;

using R5T.T0131;


namespace R5T.F0002.Construction
{
    [ValuesMarker]
    public partial interface IGlobbedPaths : IValuesMarker
    {
        public string RazorComponents => @"./Components/**/*.razor";
    }
}
