using System;


namespace R5T.F0002
{
	public class XPathOperator : IXPathOperator
	{
		#region Infrastructure

	    public static IXPathOperator Instance { get; } = new XPathOperator();

	    private XPathOperator()
	    {
        }

	    #endregion
	}
}