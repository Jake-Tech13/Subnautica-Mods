using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace KraftonIsAlterra.Replacers
{
    internal class CustomStringReplacer
    {
        internal static string ReplaceWords(string key, string input, List<object> oldWords, List<string> newWords, string lang)
        {
            for (int i = 0; i < oldWords.Count; i++)
            {
                List<string> patterns;
                if (i == 0)
                    patterns = (List<string>)oldWords[i];
                else
                    patterns = new List<string> { (string)oldWords[i] };

                try
                {
                    foreach (var pattern in patterns)
                        input = Regex.Replace(input, pattern, match =>
                        {
                            return IsAllUpper(match.Value) ? newWords[i].ToUpper() : newWords[i];
                        }, RegexOptions.IgnoreCase);
                }
                catch (Exception ex)
                {
                    Plugin.Logger.LogError($"Error replacing word: {string.Join(",", patterns)} with {newWords[i]} in input: {input}");
                    throw ex;
                }
            }

            // 4) Cas spécial Goal_Diamond
            if (key == "Goal_Diamond")
            {
                var pattern = (string)oldWords[2];
                try
                {
                    input = Regex.Replace(input, pattern, newWords[2]);
                }
                catch (Exception ex)
                {
                    Plugin.Logger.LogError($"Error replacing word: {oldWords[2]} with {newWords[2]} in input: {input}");
                    throw ex;
                }
            }

            return input;
        }

        // helper for case sensivity
        static bool IsAllUpper(string s) => s.ToUpper() == s;
    }
}
