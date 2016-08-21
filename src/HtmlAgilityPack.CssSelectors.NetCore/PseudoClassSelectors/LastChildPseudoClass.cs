using System.Linq;

namespace HtmlAgilityPack.CssSelectors.NetCore.PseudoClassSelectors
{
    [PseudoClassName("last-child")]
    internal class LastChildPseudoClass : PseudoClass
    {
        protected override bool CheckNode(HtmlNode node, string parameter)
        {
            return node.ParentNode.GetChildElements().Last() == node;
        }
    }
}