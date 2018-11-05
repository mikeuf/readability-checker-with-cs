using System;
using System.Text.RegularExpressions;

namespace ReadabilityChecker {
    /// <summary>
    /// Scans the text and counts the number of items found, such as
    /// words, syllables and sentences. 
    /// </summary>
    class RCScanner {
        /// <summary>
        /// Counts the number of IP addresses
        /// </summary>
        /// <param name="text">The contents of the main text field</param>
        /// <returns>the number of IP address found</returns>
        public int CountIPs(String text) {
            var IP_PATTERN = new Regex(@"((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)");
            MatchCollection matches = IP_PATTERN.Matches(text);
            return matches.Count;
        }

        /// <summary>
        /// Counts the number of lists, such as bullet lists or ordered lists
        /// </summary>
        /// <param name="text">The contents of the main text field</param>
        /// <returns>the number of lists found</returns>
        public int CountLists(String text) {
            string LIST_PATTERN = @"^([A-Za-z]|[0-9]){1,2}[\.)].*$";
            MatchCollection matches = Regex.Matches(text, LIST_PATTERN, RegexOptions.Multiline);
            Console.WriteLine(matches.Count);

            return matches.Count;
        }

        /// <summary>
        /// Counts the number of URLs
        /// </summary>
        /// <param name="text">The contents of the main text field</param>
        /// <returns>the number of URLs found</returns>
        public int CountURLs(String text) {
            var URL_PATTERN = new Regex(@"((https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$\/)");
            MatchCollection matches = URL_PATTERN.Matches(text);

            return matches.Count;
        }

        /// <summary>
        /// Counts the number of words
        /// </summary>
        /// <param name="text">The contents of the main text field</param>
        /// <returns>the number of words found</returns>
        public int CountWords(String text) {
            var WORD_PATTERN = new Regex(@"(\b\s?\w+-?\'?\w*\b)");
            MatchCollection matches = WORD_PATTERN.Matches(text);

            return matches.Count;
        }

        /// <summary>
        /// Counts the number of syllables
        /// </summary>
        /// <param name="text">The contents of the main text field</param>
        /// <returns>the number of syllables found</returns>
        public int CountSyllables(String text) {
            var SYLLABLE_PATTERN = new Regex(@"((?i)(?!ed\b)([aeiouy]{1,3})(?<!e\b(?<!le\b)(?<!the|be|he|me)))");
            MatchCollection matches = SYLLABLE_PATTERN.Matches(text);

            return matches.Count;
        }

        /// <summary>
        /// Counts the number of sentences
        /// </summary>
        /// <param name="text">The contents of the main text field</param>
        /// <returns>the number of sentences found</returns>
        public int CountSentences(String text) {
            var POST_HTML_STRIP_SENTENCE_PATTERN = new Regex(@"\s?([A-Za-z]{1,2}|[0-9]{1,2})?[\}\]\)\""\']*([\.!?;]|(\n|\r|\r\n))+[""\']?");
            MatchCollection matches = POST_HTML_STRIP_SENTENCE_PATTERN.Matches(text);
            Console.WriteLine("Sentences: " + matches.Count);

            return matches.Count;
        }
    }
}
