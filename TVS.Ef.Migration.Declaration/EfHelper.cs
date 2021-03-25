using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TVS.Ef.Migration.Declaration
{
    internal class EfHelper
    {
        public static string StrTr(string sOriginal)
        {
            var pairs = new Dictionary<string, string>();
            pairs.Add("À", "a");
            pairs.Add("Á", "a");
            pairs.Add("Â", "a");
            pairs.Add("Ã", "a");
            pairs.Add("Ä", "a");
            pairs.Add("Å", "a");
            pairs.Add("à", "a");
            pairs.Add("á", "a");
            pairs.Add("â", "a");
            pairs.Add("ä", "a");
            pairs.Add("å", "a");
            pairs.Add("Ò", "o");
            pairs.Add("Ó", "o");
            pairs.Add("Ô", "o");
            pairs.Add("Õ", "o");
            pairs.Add("Ö", "o");
            pairs.Add("Ø", "o");
            pairs.Add("ò", "o");
            pairs.Add("ó", "o");
            pairs.Add("ô", "o");
            pairs.Add("õ", "o");
            pairs.Add("ö", "o");
            pairs.Add("ø", "o");
            pairs.Add("È", "e");
            pairs.Add("É", "e");
            pairs.Add("Ê", "e");
            pairs.Add("Ë", "e");
            pairs.Add("è", "e");
            pairs.Add("é", "e");
            pairs.Add("ê", "e");
            pairs.Add("ë", "e");
            pairs.Add("Ç", "c");
            pairs.Add("ç", "c");
            pairs.Add("Ì", "i");
            pairs.Add("Í", "i");
            pairs.Add("Î", "i");
            pairs.Add("Ï", "i");
            pairs.Add("ì", "i");
            pairs.Add("í", "i");
            pairs.Add("î", "i");
            pairs.Add("ï", "i");
            pairs.Add("Ù", "u");
            pairs.Add("Ú", "u");
            pairs.Add("Û", "u");
            pairs.Add("Ü", "u");
            pairs.Add("ù", "u");
            pairs.Add("ú", "u");
            pairs.Add("û", "u");
            pairs.Add("ü", "u");
            pairs.Add("ÿ", "y");
            pairs.Add("Ñ", "n");
            pairs.Add("ñ", "n");
            pairs.Add("!", " ");
            pairs.Add(";", " ");
            pairs.Add(":", " ");
            pairs.Add(@"\?", " ");
            pairs.Add("\"", string.Empty);
            pairs.Add("=", string.Empty);

            var finds = new string[pairs.Keys.Count];
            pairs.Keys.CopyTo(finds, 0);
            string findpattern = string.Join("|", finds);
            var regex = new Regex(findpattern);

            MatchEvaluator evaluator = delegate(Match m)
            {
                string match = m.Captures[0].Value;

                if (match == "?")
                    match = @"\" + match;

                if (pairs.ContainsKey(match))
                    return pairs[match];

                return match;
            };

            return regex.Replace(sOriginal, evaluator);
        }
    }
}