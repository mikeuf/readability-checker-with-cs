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

            
         int i = 0;
       //  Pattern p = Pattern.compile(IP_PATTERN);
       //  Matcher matcher = p.matcher(s);
       var m = IP_PATTERN.Match(s);

             while (matcher.find())
             {
                 ++i;
             }
             return i;
                     
        }


        public int countLists(String s)
{

        private static readonly String LIST_PATTERN = "((<.*>)?(<p>|<h>|<li>|<br>|<br \\/>)(<.*>)?((\\d{1,2}\\.)|(\\d{1,2}\\))\\s))";

int i = 0;
Pattern p = Pattern.compile(LIST_PATTERN);
Matcher matcher = p.matcher(s);
            while (matcher.find())
            {
                ++i;
            }
            return i;
        }



        public int countNBSPs(String s)
{

                private static readonly String NBSP_PATTERN = "((nbsp;)(<.*>)?(<\\/p>|<\\/h|<\\/li>|<br))";

int i = 0;
Pattern p = Pattern.compile(NBSP_PATTERN);
Matcher matcher = p.matcher(s);
            while (matcher.find())
            {
                ++i;
            }
            return i;
        }

        public int countURLs(String s)
{

        private static readonly String URL_PATTERN = "((https?:\\/\\/)?([\\da-z\\.-]+)\\.([a-z\\.]{2,6})([\\/\\w \\.-]*)*\\/?$\\/)";

int i = 0;
Pattern p = Pattern.compile(URL_PATTERN);
Matcher matcher = p.matcher(s);
            while (matcher.find())
            {
                ++i;
            }
            return i;
        }

        public int countWords(String s)
{

        private static readonly String WORD_PATTERN = "(\\b\\s?\\w+-?\'?\\w*\\b)";

int i = 0;
Pattern p = Pattern.compile(WORD_PATTERN);
Matcher matcher = p.matcher(s);
            while (matcher.find())
            {
                ++i;
            }
            return i;
        }

        public int countSyllables(String s)
{

        private static readonly String SYLLABLE_PATTERN = "((?i)(?!ed\\b)([aeiouy]{1,3})(?<!e\\b(?<!le\\b)(?<!the|be|he|me)))";

int i = 0;
Pattern p = Pattern.compile(SYLLABLE_PATTERN);
Matcher matcher = p.matcher(s);
            while (matcher.find())
            {
                ++i;
            }
            return i;
        }

        public int countSentencesPreHTMLStrip(String s)
{
    int i = 0;
    Pattern p = Pattern.compile(PRE_HTML_STRIP_SENTENCE_PATTERN);
    Matcher matcher = p.matcher(s);
    while (matcher.find())
    {
        ++i;
    }
    return i;
}

public int countSentencesPostHTMLStrip(String s)
{

                private static readonly String POST_HTML_STRIP_SENTENCE_PATTERN = "(\\s?([A-Za-z]{2,}|[0-9]+)[\\}\\]\\)\"\']*[.!?;]+[\"\']?)";

int i = 0;
Pattern p = Pattern.compile(POST_HTML_STRIP_SENTENCE_PATTERN);
Matcher matcher = p.matcher(s);
            while (matcher.find())
            {
                ++i;
            }
            return i;
        }
    }
}
