using System;

namespace ReadabilityChecker {
    /// <summary>
    /// Scans the text and counts the number of items found, such as
    /// words, syllables and sentences.
    /// </summary>
    class RCTracker {
        // counters of different items found in provided text 
        /*
        private int numWords;
        private int numSentences;
        private int numSyllables;
        private int numClosingPTags;
        private int numIPs;
        private int numLists;
        private int numNBSPs;
        */
        internal int NumWords { get; set; }
        internal int NumSentences { get; set; }
        internal int NumSyllables { get; set; }
       // internal int NumClosingPTags { get; set; }
        internal int NumIPs { get; set; }
        internal int NumLists { get; set; }
        internal int NumNBSPs { get; set; }

        // calculated from the counter values
        /*
        private double numWordsPerSentence;
        private double numSyllablesPerWord;
        */
        internal double NumWordsPerSentence { get; set; }
        internal double NumSyllablesPerWord { get; set; }

        // after calculations, used to display readability scores
      //  private double FKGrade;
      //  private double FKScore;

        internal double FKGrade { get; set; }
        internal double FKScore { get; set; }

        // constructor initializes counters
        public RCTracker() {
            NumWords = 0;
            NumSentences = 0;
            NumSyllables = 0;
          //  NumClosingPTags = 0;
            NumIPs = 0;
            NumLists = 0;
            NumNBSPs = 0;
            NumWordsPerSentence = 0;
            NumSyllablesPerWord = 0;
            FKGrade = 0;
            FKScore = 0;
        }

        // getters
        // public int getNumWords() { return this.numWords; }
       // internal int NumWords { get; set; }
       /*
        public int getNumSentences() { return this.numSentences; }
        public int getNumSyllables() { return this.numSyllables; }
        public int getNumClosingPTags() { return this.numClosingPTags; }
        public int getNumIPs() { return this.numIPs; }
        public int getNumLists() { return this.numLists; }
        public int getNumNBSPs() { return this.numNBSPs; }
        public Double getNumWordsPerSentence() { return numWordsPerSentence; }
        public Double getNumSyllablesPerWord() { return numSyllablesPerWord; }
        public Double getFKScore() { return this.FKScore; }
        public Double getFKGrade() { return this.FKGrade; }

        // setters
        public void setNumWords(int numWords) { this.numWords = numWords; }
        public void setNumSentences(int numSentences) { this.numSentences = numSentences; }
        public void setNumSyllables(int numSyllables) { this.numSyllables = numSyllables; }
        public void setNumClosingPTags(int numClosingPTags) { this.numClosingPTags = numClosingPTags; }
        public void setNumIPs(int numIPs) { this.numIPs = numIPs; }
        public void setNumLists(int numLists) { this.numLists = numLists; }
        public void setNumNBSPs(int numNBSPs) { this.numNBSPs = numNBSPs; }
        public void setNumWordsPerSentence(double numWordsPerSentence) { this.numWordsPerSentence = numWordsPerSentence; }
        public void setNumSyllablesPerWord(double numSyllablesPerWord) { this.numSyllablesPerWord = numSyllablesPerWord; }
        public void setFKScore(double FKScore) { this.FKScore = FKScore; }
        public void setFKGrade(double FKGrade) { this.FKGrade = FKGrade; }
        */

        public void ApplyModifiers() {
            // Don't count things like "1." and "2." at the beginning of lists as words or sentences
           NumWords -= NumLists;
           NumSentences -= NumLists;

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

        public void CalculateNumWordsPerSentence() {
            if(NumSentences > 0) {
               NumWordsPerSentence = (double)NumWords / (double)NumSentences;
            }
            Console.WriteLine("NumWordsPerSentence: {0} / {1} = {2}", (double)NumWords, (double)NumSentences, ((double)NumWords / (double)NumSentences));
        }

        public void CalculateNumSyllablesPerWord() {
            if(NumWords > 0) {
               NumSyllablesPerWord = (double)NumSyllables / (double)NumWords;
            }
        }

        public void CalculateFKScore() {
            // calculate the Flesch-Kincaid Score
            FKScore = (206.835 - (1.015 * NumWordsPerSentence) - (84.6 * NumSyllablesPerWord));
            if (FKScore < 0) {
                FKScore = 0;  // minimum score = 0
            }
            if (FKScore > 100) {
                FKScore = 100;  // max score = 100
            }
        }

        public void CalculateFKGrade() {
            // calculate the Flesch-Kincaid Grade
            FKGrade = ((0.39 * NumWordsPerSentence) + (11.8 * NumSyllablesPerWord - 15.59));
            if (FKGrade < 0) {
                FKGrade = 0;
            } //minimum score = 0
        }
    }
}
