using System;

namespace HtmlAgilityPack.CssSelectors.NetCore.PseudoClassSelectors
{
    [PseudoClassName("nth-child")]
    internal class NthChildPseudoClass : PseudoClass
    {
        protected override bool CheckNode(HtmlNode node, string parameter) 
        {
            var indexOnParent = node.GetIndexOnParent();
            
            if (parameter.Equals("odd", StringComparison.OrdinalIgnoreCase)) 
            {
                return (indexOnParent + 1) % 2 != 0;
            }

            if (parameter.Equals("even", StringComparison.OrdinalIgnoreCase)) 
            {
                return (indexOnParent + 1) % 2 == 0;
            }

            return indexOnParent == int.Parse(parameter) - 1;
        }
    }
}