using System;


namespace R5T.F0002.Construction
{
	public class XmlExplorations : IXmlExplorations
	{
		#region Infrastructure

	    public static IXmlExplorations Instance { get; } = new XmlExplorations();

	    private XmlExplorations()
	    {
        }

	    #endregion
	}
}