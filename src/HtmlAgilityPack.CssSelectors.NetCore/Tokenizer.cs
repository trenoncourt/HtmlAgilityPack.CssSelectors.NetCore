using System.Collections.Generic;
using System.Text;

namespace HtmlAgilityPack.CssSelectors.NetCore
{
    public class Tokenizer
    {
        public static IEnumerable<Token> GetTokens(string cssFilter)
        {
            var reader = new System.IO.StringReader(cssFilter);
            while (true)
            {
                int v = reader.Read();

                if (v < 0)
                    yield break;

                char c = (char)v;

                if (c == '>')
                {
                    yield return new Token(">");
                    continue;
                }

                if (c == ' ' || c == '\t')
                    continue;

                string word = ReadWord(reader, c);
                yield return new Token(word);
            }
        }

        private static string ReadWord(System.IO.StringReader reader, char firstCharacter)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(firstCharacter);

            if (firstCharacter == '[')
                ReadWordFromBracket(reader, sb);

            while (true)
            {
                int v = reader.Peek();

                if (v < 0)
                    break;

                char c = (char)v;

                if (c == ' ' || c == '\t' || c == '>')
                    break;

                reader.Read();

                sb.Append(c);

                if (c == '[')
                    ReadWordFromBracket(reader, sb);
            }

            return sb.ToString();
        }

        private static void ReadWordFromBracket(System.IO.StringReader reader, StringBuilder word)
        {
            char quote = '\0';

            while (true)
            {
                int v = reader.Read();
                if (v < 0)
                    break;

                char c = (char)v;
                word.Append(c);

                if (quote != '\0')
                {
                    if (c == quote)
                        quote = '\0';
                }
                else if (c == '"' || c == '\'')
                {
                    quote = c;
                }
                else if (c == ']')
                {
                    break;
                }
            }
        }
    }
}
