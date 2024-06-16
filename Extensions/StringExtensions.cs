using System.Text.RegularExpressions;

namespace PeriodicTableTutor.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Create sentence string for given phrase
        /// </summary>
        /// <param name="str"></param>
        /// <returns>E.g. AlkaliMetal -> Alkali metal</returns>
        public static string ToSentenceCase(this string str) => Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1]));
    }
}
