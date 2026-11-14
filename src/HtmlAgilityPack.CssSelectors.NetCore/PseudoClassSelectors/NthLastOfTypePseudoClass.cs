using System.Linq;

namespace HtmlAgilityPack.CssSelectors.NetCore.PseudoClassSelectors
{
    [PseudoClassName("nth-last-of-type")]
    public class NthLastOfTypePseudoClass : PseudoClass
    {
        protected override bool CheckNode(HtmlNode node, string parameter)
        {
            var ofType = node.Name;
            return node.GetIndexOnParent(ofType) == node.ParentNode.Elements(ofType).Count() - int.Parse(parameter);
        }
    }
}