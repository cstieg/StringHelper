using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringHelper
{
    public static class StringHelper
    {
        /// <summary>
        /// Checks whether the string matches the wildcard pattern
        /// </summary>
        /// <param name="s">The present string object</param>
        /// <param name="pattern">A wildcard pattern possible containing wildcards '*' and/or '?'</param>
        /// <returns>True if a match, false if not</returns>
        public static bool Matches(this String s, string pattern)
        {
            string regExPattern = "^" + Regex.Escape(s).Replace(@"\?", ".").Replace(@"\*", ".*") + "$";
            return Regex.IsMatch(s, pattern);
        }

        public static bool ContainsWordWithWildcard(this String s, string word)
        {
            string regExPattern = ConvertWildcardStringToRegex(word);
            return Regex.IsMatch(s, regExPattern);
        }

        public static MatchCollection FindWildcardMatches(this String s, string word)
        {
            string regExPattern = ConvertWildcardStringToRegex(word);
            return Regex.Matches(s, regExPattern);
        }

        public static string ConvertWildcardStringToRegex(string s)
        {
            return @"\b" + Regex.Escape(s).Replace(@"\?", ".").Replace(@"\*", ".*") + @"\b";
        }
    }
}