using System;


namespace R5T.F0002
{
	public class XmlOperator : IXmlOperator
	{
		#region Infrastructure

	    public static IXmlOperator Instance { get; } = new XmlOperator();

	    private XmlOperator()
	    {
        }

	    #endregion
	}
}