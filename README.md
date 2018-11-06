# Readability Checker with C#
This program performs a Flesch-Kincaid readability analysis by scanning the characters in the text and counting the number of words, syllables, sentences, and other items, in order to determine the overall text readability. Statistics are provided, including brief suggestions for how to improve text readability. Both a Flesch-Kincaid score and grade level are calculated.<br /><br />
More information about Flesh-Kincaid readability tests is available from Wikipedia:
https://en.wikipedia.org/wiki/Flesch%E2%80%93Kincaid_readability_tests
## Table of Contents
**[How to Run this Program](#how-to-run-this-program)**  
**[Examples of Readability Analyses](#examples-of-readability-analyses)**<br /> 

## How to Run this Program
Aan executable file called **ReadabilityChecker.exe** is available here:<br />
https://github.com/mikeuf/readability-checker-with-cs/raw/master/ReadabilityChecker/ReadabilityChecker/bin/Debug/ReadabilityChecker.exe<br /><br />
You may receive a message from your browser stating that the program is "not commonly downloaded and may be dangerous," or something to this effect. Your browser should give you the option to either discard or keep the file.

## Examples of Readability Analyses
The Readability Checker will provide an analysis of the selection. Text with good readability tends to have short sentences, with simple words (Figure 1). Text with medium readability (Figure 2) and poor readability (Figure 3) will have longer sentences and more complex words.If a very small amount of text is entered, the checker may provide unusual scores due to the small sample size.<br /><br />
**Note:** This version of the Readability Checker may produce slightly different results from the Java version because of differences between the RegEx implementations and because the Java version uses an HTML editor instead of a text editor.


**Figure 1 - Good readability**
![Good readability](https://github.com/mikeuf/readability-checker-with-cs/blob/master/screenshots/good-readability.jpg "Good readability")
<br />
<br />
**Figure 2 - Medium readability**
![Medium readability](https://github.com/mikeuf/readability-checker-with-cs/blob/master/screenshots/medium-readability.jpg "Medium readability")
<br />
<br />

**Figure 3 - Difficult readability**
![Difficult readability](https://github.com/mikeuf/readability-checker-with-cs/blob/master/screenshots/difficult-readability.jpg "Difficult readability")
<br />
<br />
