using System;

namespace ReadabilityChecker {
    /// <summary>
    /// Stores counters of items found by the scanner and performs Flesch-Kincaid 
    /// words, syllables and sentences.
    /// </summary>
    class RCTracker {

        // counters for variables items to be scanned from the text
        internal int NumWords { get; set; }
        internal int NumSentences { get; set; }
        internal int NumSyllables { get; set; }
        internal int NumIPs { get; set; }

        // calculated from the counter values
        internal double NumWordsPerSentence { get; set; }
        internal double NumSyllablesPerWord { get; set; }

        // after calculations, used to display readability scores
        internal double FKGrade { get; set; }
        internal double FKScore { get; set; }

        // constructor reinitializes counters
        public RCTracker() {
            NumWords = 0;
            NumSentences = 0;
            NumSyllables = 0;
            NumIPs = 0;
            NumWordsPerSentence = 0;
            NumSyllablesPerWord = 0;
            FKGrade = 0;
            FKScore = 0;
        }

        /// <summary>
        /// Adjusts the number of words and sentences to avoid double counting of certain items
        /// </summary>
        public void ApplyModifiers() {
            if (NumIPs > 0) {
               // Don"t count every octet of an IP address as a word
               NumWords -= (NumIPs * 4);

               // Count entire IP address as exactly 1 word and 1 syllable
               NumWords += NumIPs;
               NumSyllables += NumIPs;

               // Since IP addresses have periods, they will artificially boost sentence count by 3
               // To correct this, substract 3 sentences per IP detected
               NumSentences -= (NumIPs * 3);
            }
        }

        /// <summary>
        /// Calculates the number of words per sentence
        /// </summary>
        public void CalculateNumWordsPerSentence() {
            if(NumSentences > 0) {
               NumWordsPerSentence = (double)NumWords / (double)NumSentences;
            }
        }

        /// <summary>
        /// Calculates the number of syllable per word
        /// </summary>
        public void CalculateNumSyllablesPerWord() {
            if(NumWords > 0) {
               NumSyllablesPerWord = (double)NumSyllables / (double)NumWords;
            }
        }

        /// <summary>
        /// Calculates the Flesch-Kincaid Readability Score
        /// </summary>
        public void CalculateFKScore() {
            FKScore = (206.835 - (1.015 * NumWordsPerSentence) - (84.6 * NumSyllablesPerWord));
            if (FKScore < 0) {
                FKScore = 0;  // minimum score = 0
            }
            if (FKScore > 100) {
                FKScore = 100;  // max score = 100
            }
        }

        /// <summary>
        /// Calculates the Flesch-Kincaid Readability Grade
        /// </summary>
        public void CalculateFKGrade() {
            // calculate the Flesch-Kincaid Grade
            FKGrade = ((0.39 * NumWordsPerSentence) + (11.8 * NumSyllablesPerWord - 15.59));
            if (FKGrade < 0) {
                FKGrade = 0;
            } //minimum score = 0
        }
    }
}
