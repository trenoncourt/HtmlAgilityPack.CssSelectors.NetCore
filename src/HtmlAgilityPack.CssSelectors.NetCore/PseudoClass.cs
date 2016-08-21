using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HtmlAgilityPack.CssSelectors.NetCore
{
    public abstract class PseudoClass
    {
        private static readonly Dictionary<string, PseudoClass> Classes = LoadPseudoClasses();

        public virtual IEnumerable<HtmlNode> Filter(IEnumerable<HtmlNode> nodes, string parameter)
        {
            return nodes.Where(i => CheckNode(i, parameter));
        }

        protected abstract bool CheckNode(HtmlNode node, string parameter);

        
        
        public static PseudoClass GetPseudoClass(string pseudoClass)
        {
            if (!Classes.ContainsKey(pseudoClass))
                throw new NotSupportedException($"Pseudo classe {pseudoClass} not supported.");

            return Classes[pseudoClass];
        }

        private static Dictionary<string, PseudoClass> LoadPseudoClasses()
        {
            var rt = new Dictionary<string, PseudoClass>(StringComparer.OrdinalIgnoreCase);
            
            var types = Assembly.Load(new AssemblyName("HtmlAgilityPack.CssSelectors.NetCore")).GetTypes().Where(i => !i.GetTypeInfo().IsAbstract && i.GetTypeInfo().IsSubclassOf(typeof(PseudoClass)));
            types = types.OrderBy(i => Equals(i.GetTypeInfo().Assembly, typeof(PseudoClass).GetTypeInfo().Assembly) ? 0 : 1).ToList();

            foreach (var type in types)
            {
                var attr = type.GetTypeInfo().GetCustomAttributes(typeof(PseudoClassNameAttribute), false).Cast<PseudoClassNameAttribute>().FirstOrDefault();
                rt.Add(attr.FunctionName, (PseudoClass)Activator.CreateInstance(type));
            }

            return rt;
        }
    }
}