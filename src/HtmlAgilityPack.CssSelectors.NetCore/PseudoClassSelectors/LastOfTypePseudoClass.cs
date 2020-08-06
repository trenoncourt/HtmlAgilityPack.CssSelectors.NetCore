using System.Linq;

namespace HtmlAgilityPack.CssSelectors.NetCore.PseudoClassSelectors
{
    [PseudoClassName("last-of-type")]
    public class LastOfTypePseudoClass : PseudoClass
    {
        protected override bool CheckNode(HtmlNode node, string parameter)
        {
            var ofType = node.Name;
            return node.GetIndexOnParent(ofType) == node.ParentNode.Elements(ofType).Count() - 1;
        }
    }
}