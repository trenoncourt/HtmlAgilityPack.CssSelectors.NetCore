using System.Collections.Generic;
using System.Linq;

namespace HtmlAgilityPack.CssSelectors.NetCore.Selectors
{
    internal class ImediateChildrenSelector : CssSelector
    {
        public override bool AllowTraverse => false;

        public override string Token => ">";

        protected internal override IEnumerable<HtmlNode> FilterCore(IEnumerable<HtmlNode> currentNodes)
        {
            return currentNodes.SelectMany(i => i.ChildNodes);
        }
    }
}