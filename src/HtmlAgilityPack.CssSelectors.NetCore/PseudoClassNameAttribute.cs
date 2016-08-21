using System;

namespace HtmlAgilityPack.CssSelectors.NetCore
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PseudoClassNameAttribute : Attribute
    {
        public string FunctionName { get; private set; }

        public PseudoClassNameAttribute(string name)
        {
            FunctionName = name;
        }
    }
}
