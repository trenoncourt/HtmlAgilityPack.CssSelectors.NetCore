using System.Linq;

namespace HtmlAgilityPack.CssSelectors.NetCore.PseudoClassSelectors
{
    [PseudoClassName("only-of-type")]
    public class OnlyOfTypePseudoClass : PseudoClass
    {
        protected override bool CheckNode(HtmlNode node, string parameter)
        {
            var ofType = node.Name;
            return node.ParentNode.Elements(ofType).Count() == 1;
        }
    }
}