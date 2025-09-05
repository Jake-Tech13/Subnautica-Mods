using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace KraftonIsAlterra.Replacers
{
    internal class CustomStringReplacer
    {
        internal static string ReplaceWords(string key, string input, List<string> oldWords, List<string> newWords)
        {
            // replace Alterra/Alterrans words in string
            for (int i = 0; i < oldWords.Count; i++)
            {
                string pattern = $@"\b{Regex.Escape(oldWords[i])}\b";
                try
                {
                    input = Regex.Replace(input, pattern, match =>
                    {
                        string replacement = newWords[i];

                        // case adaptation
                        if (IsAllUpper(match.Value))
                            return replacement.ToUpper();

                        return replacement;
                    }, RegexOptions.IgnoreCase);
                }
                catch (Exception ex)
                {
                    // log the error but continue processing
                    Plugin.Logger.LogError($"Error replacing word: {oldWords[i]} with {newWords[i]} in input: {input}");
                    throw ex;
                }
            }
            
            // look for the number 3 in a string with a specific key (doesn't work yet with symbole-based languages)
            if (key == "Goal_Diamond")
            {
                string pattern = $@"\b{Regex.Escape(oldWords[2])}\b";
                try
                {
                    input = Regex.Replace(input, pattern, newWords[2]);
                }
                catch (Exception ex)
                {
                    // log the error but continue processing
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
