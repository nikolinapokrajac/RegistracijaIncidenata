using System.Text.RegularExpressions;

namespace RegistrovanjeIncidenata.Utility
{
    public static class StringUtility
    {
        public static string StripPTags(string input)
        {
            // Use regular expressions to remove <p> and </p> tags
            string pattern = @"<p>(.*?)</p>";
            string replacement = "$1";
            string sanitizedContent = Regex.Replace(input, pattern, replacement, RegexOptions.IgnoreCase);

            return sanitizedContent;
        }
    }
}

