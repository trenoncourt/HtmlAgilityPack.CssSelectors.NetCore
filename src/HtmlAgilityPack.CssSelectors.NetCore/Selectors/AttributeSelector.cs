using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlAgilityPack.CssSelectors.NetCore.Selectors
{
    internal class AttributeSelector : CssSelector
    {
        public override string Token => "[";

        protected internal override IEnumerable<HtmlNode> FilterCore(IEnumerable<HtmlNode> currentNodes)
        {
            var filter = GetFilter();
            foreach (var node in currentNodes)
            {
                if (filter(node))
                    yield return node;
            }
        }

        private Func<HtmlNode, bool> GetFilter()
        {
            string filter = Selector.Trim('[', ']');

            int idx = filter.IndexOf('=');

            if (idx == 0)
                throw new InvalidOperationException($"Invalid selector use for attribute {Selector}.");

            if (idx < 0)
                return node => node.Attributes.Contains(filter);

            var operation = GetOperation(filter[idx - 1]);

            if (!char.IsLetterOrDigit(filter[idx - 1]))
                filter = filter.Remove(idx - 1, 1);

            string[] values = filter.Split(new[] { '=' }, 2);
            filter = values[0];
            string value = values[1].Trim();
            StringComparison comparison = StringComparison.Ordinal;

            if (value.Length > 0 && (value[0] == '"' || value[0] == '\''))
            {
                int closingQuote = value.LastIndexOf(value[0]);
                if (closingQuote > 0)
                {
                    string flag = value.Substring(closingQuote + 1).Trim();
                    if (flag.Equals("i", StringComparison.OrdinalIgnoreCase))
                        comparison = StringComparison.OrdinalIgnoreCase;

                    value = value.Substring(1, closingQuote - 1);
                }
            }

            value = UnescapeValue(value);

            return node => node.Attributes.Contains(filter) &&
                operation(node.Attributes[filter].Value, value, comparison);
        }

        private static string UnescapeValue(string value)
        {
            var result = new StringBuilder(value.Length);
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == '\\' && i + 1 < value.Length)
                    i++;

                result.Append(value[i]);
            }

            return result.ToString();
        }

        private Func<string, string, StringComparison, bool> GetOperation(char value)
        {
            if (char.IsLetterOrDigit(value))
                return (attr, v, comparison) => string.Equals(attr, v, comparison);

            switch (value)
            {
                case '*': return (attr, v, comparison) =>
                    string.Equals(attr, v, comparison) || attr.IndexOf(v, comparison) >= 0;
                case '^': return (attr, v, comparison) => attr.StartsWith(v, comparison);
                case '$': return (attr, v, comparison) => attr.EndsWith(v, comparison);
                case '~': return (attr, v, comparison) =>
                    attr.Split(' ').Any(word => string.Equals(word, v, comparison));

                case '|':
                    // This operator will only match if the first full-word in the attribute value
                    // is either an exact match to the query or is an exact match immediately followed by a dash. 
                    return (attr, v, comparison) =>
                    {
                        var isMatch = false;

                        if (string.Equals(attr, v, comparison))
                        {
                            isMatch = true;
                        }
                        else if (attr.Length > v.Length)
                        {
                            var firstValue = attr
                                .Split(new[] { ' ' }, StringSplitOptions.None)
                                .FirstOrDefault();

                            if (firstValue?.StartsWith(v, comparison) ?? false)
                            {
                                isMatch = firstValue.Length > v.Length && firstValue[v.Length] == '-';
                            }
                        }

                        return isMatch;
                    };
            }

            throw new NotSupportedException($"Invalid selector use for attribute {Selector}.");
        }
    }
}