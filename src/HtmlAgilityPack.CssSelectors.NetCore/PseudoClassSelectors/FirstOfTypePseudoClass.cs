namespace HtmlAgilityPack.CssSelectors.NetCore.PseudoClassSelectors
{
    [PseudoClassName("first-of-type")]
    public class FirstOfTypePseudoClass : PseudoClass
    {
        protected override bool CheckNode(HtmlNode node, string parameter)
        {
            var ofType = node.Name;
            return node.GetIndexOnParent(ofType) == 0;
        }
    }
}