using System;
using System.Text.RegularExpressions;

namespace ReadabilityChecker
{
    class RCScanner
    {
        // regex patterns that the RCScanner checks for
        //   private static readonly String PRE_HTML_STRIP_SENTENCE_PATTERN = "((\\w+(,|:)?)(&quot;)?(&#39;)?(<.*>)?(<\\/p>|<\\/h|<\\/li>|<br))";

        public int CountIPs(String text)
        {
            // private static readonly Regex IP_PATTERN = new Regex("((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)");
           var IP_PATTERN = new Regex(@"((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)");
            MatchCollection matches = IP_PATTERN.Matches(text);
        
             return matches.Count;                     
        }


        public int CountLists(String text)
{
            //  private static readonly String LIST_PATTERN = "((<.*>)?(<p>|<h>|<li>|<br>|<br \\/>)(<.*>)?((\\d{1,2}\\.)|(\\d{1,2}\\))\\s))";
            // var LIST_PATTERN = new Regex(@"((<.*>)?(<p>|<h>|<li>|<br>|<br \/>)(<.*>)?((\d{1,2}\.)|(\d{1,2}\))\s))");
            // var LIST_PATTERN = new Regex(@"(\n|\r|\r\n)");
            // var LIST_PATTERN = new Regex(@"(^|\n)(\d|\w){1,2}?[\.)](\s{1,2}|\t)([A-z]|\d)");

            string LIST_PATTERN = @"^([A-Za-z]|[0-9]){1,2}[\.)].*$";
           // int matchCount = 0;
            MatchCollection matches = Regex.Matches(text, LIST_PATTERN, RegexOptions.Multiline);

            Console.WriteLine(matches.Count);
    
            return matches.Count;
            /*
            Regex LIST_PATTERN = new Regex(@"^([A-Za-z]|[0-9]){1,2}[\.)].*$");

MatchCollection matches = LIST_PATTERN.Matches(s);

            Console.WriteLine("Lists: " + matches.Count);
            return matches.Count; */
        }

        
        public int CountURLs(String text)
{

        var URL_PATTERN = new Regex(@"((https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$\/)");

    MatchCollection matches = URL_PATTERN.Matches(text);

            return matches.Count;
        }
        

        public int CountWords(String text)
{

        var WORD_PATTERN = new Regex(@"(\b\s?\w+-?\'?\w*\b)");

    MatchCollection matches = WORD_PATTERN.Matches(text);

    return matches.Count;
}
        

        public int CountSyllables(String text)
{

        var SYLLABLE_PATTERN = new Regex(@"((?i)(?!ed\b)([aeiouy]{1,3})(?<!e\b(?<!le\b)(?<!the|be|he|me)))");

            MatchCollection matches = SYLLABLE_PATTERN.Matches(text);

            return matches.Count;
        }

     

public int CountSentences(String text) {

               // var POST_HTML_STRIP_SENTENCE_PATTERN = new Regex(@"\s?([A-Za-z]{2,}|[0-9]+)[\}\]\)"']*[\.!?;]+["']?");



                 //   var POST_HTML_STRIP_SENTENCE_PATTERN = new Regex(@"\s?([A-Za-z]{2,}|[0-9]+)[\}\]\)\""\']*([\.!?;]|(\n|\r|\r\n))+[""\']?");

            var POST_HTML_STRIP_SENTENCE_PATTERN = new Regex(@"\s?([A-Za-z]{1,2}|[0-9]{1,2})?[\}\]\)\""\']*([\.!?;]|(\n|\r|\r\n))+[""\']?");

         MatchCollection matches = POST_HTML_STRIP_SENTENCE_PATTERN.Matches(text);

            Console.WriteLine("Sentences: " + matches.Count);

            return matches.Count;
        }
        
    }
}
