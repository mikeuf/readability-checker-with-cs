using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ReadabilityChecker
{
    class RCScanner
    {
        // regex patterns that the RCScanner checks for
        //   private static readonly String PRE_HTML_STRIP_SENTENCE_PATTERN = "((\\w+(,|:)?)(&quot;)?(&#39;)?(<.*>)?(<\\/p>|<\\/h|<\\/li>|<br))";

        public int countIPs(String s)
        {
            // private static readonly Regex IP_PATTERN = new Regex("((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)");
           var IP_PATTERN = new Regex(@"((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)");
            MatchCollection matches = IP_PATTERN.Matches(s);
        
             return matches.Count;                     
        }


        public int countLists(String s)
{
            //  private static readonly String LIST_PATTERN = "((<.*>)?(<p>|<h>|<li>|<br>|<br \\/>)(<.*>)?((\\d{1,2}\\.)|(\\d{1,2}\\))\\s))";
            // var LIST_PATTERN = new Regex(@"((<.*>)?(<p>|<h>|<li>|<br>|<br \/>)(<.*>)?((\d{1,2}\.)|(\d{1,2}\))\s))");
            var LIST_PATTERN = new Regex(@"(\n|\r|\r\n)");

            MatchCollection matches = LIST_PATTERN.Matches(s);

            return matches.Count;
        }


        
        public int countNBSPs(String s)
{

               var NBSP_PATTERN = new Regex(@"((nbsp;)(<.*>)?(<\/p>|<\/h|<\/li>|<br))");

            MatchCollection matches = NBSP_PATTERN.Matches(s);

            return matches.Count;
        }
        
        public int countURLs(String s)
{

        var URL_PATTERN = new Regex(@"((https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$\/)");

    MatchCollection matches = URL_PATTERN.Matches(s);

            return matches.Count;
        }
        

        public int countWords(String s)
{

        var WORD_PATTERN = new Regex(@"(\b\s?\w+-?\'?\w*\b)");

    MatchCollection matches = WORD_PATTERN.Matches(s);

    return matches.Count;
}
        

        public int countSyllables(String s)
{

        var SYLLABLE_PATTERN = new Regex(@"((?i)(?!ed\b)([aeiouy]{1,3})(?<!e\b(?<!le\b)(?<!the|be|he|me)))");

            MatchCollection matches = SYLLABLE_PATTERN.Matches(s);

            return matches.Count;
        }

     

public int countSentencesPostHTMLStrip(String s) {

               // var POST_HTML_STRIP_SENTENCE_PATTERN = new Regex(@"\s?([A-Za-z]{2,}|[0-9]+)[\}\]\)"']*[\.!?;]+["']?");



                    var POST_HTML_STRIP_SENTENCE_PATTERN = new Regex(@"\s?([A-Za-z]{2,}|[0-9]+)[\}\]\)\""\']*([\.!?;]|(\n|\r|\r\n))+[""\']?");

         MatchCollection matches = POST_HTML_STRIP_SENTENCE_PATTERN.Matches(s);

            return matches.Count;
        }
        
    }
}
