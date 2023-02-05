using System;

using R5T.T0141;


namespace R5T.F0002.Construction
{
	[ExplorationsMarker]
	public partial interface IXmlExplorations : IExplorationsMarker
	{
		public void TryXPath()
        {
			var xmlFilePath =
                //@"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.Excel\source\R5T.Excel.Construction\R5T.Excel.Construction.csproj"
                @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.L0017\source\R5T.L0017.D001\R5T.L0017.D001.csproj"
                ;

            var xDocument = F0000.XmlOperator.Instance.Load(xmlFilePath);

			var xPath = "/Project";

			//var elementWasFound = xDocument.HasElement(xPath);
			
			//Console.WriteLine(elementWasFound);
        }
	}
}