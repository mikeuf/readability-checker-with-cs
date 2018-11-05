using System;
using System.Windows;
using System.Windows.Media;

namespace ReadabilityChecker {
    /// <summary>
    /// The Readability Checker performs a Flesch-Kincaid (FK) readability analysis.
    /// It scans the characters in the text and counts the number of words, syllables 
    /// and sentences in order to determine the readability. The RCScanner scans the
    /// text and sends the data to the RCTracker which tabulates the data
    /// and performs various calculations to return the FK grade and score
    /// 
    /// Note: This scanner intentionally handles lists differently
    /// than other applications, like Microsoft Word. This tool will count
    /// each line in a bullet list, or an ordered list, as a sentence, even
    /// if it lacks punctuation. MS Word will ignore them. This difference is intentional
    /// to encourage people to break-up large paragraphs into lists, which are
    /// more readable.
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        /*
         * When the Check Readability button is clicked it instantiates the
         * RCScanner and RCTracker classes objects. 
         * It then populates the form labels with the various counts and scores
         * and updates the meter (progress bar) to reflect the score
         */
        private void Button_Click(object sender, RoutedEventArgs e) {
            RCScanner scanner = new RCScanner();
            RCTracker tracker = new RCTracker();

            // scan the text and populate the counters
            tracker.NumSentences = scanner.CountSentences(txtMain.Text);
            tracker.NumWords = scanner.CountWords(txtMain.Text);
            tracker.NumSyllables = scanner.CountSyllables(txtMain.Text);
            tracker.NumIPs = scanner.CountIPs(txtMain.Text);
            tracker.NumLists = scanner.CountLists(txtMain.Text);

            /* Adjust some counters for special cases, such as lists and IP addresses.
             * Then perform the calculations.
             */
            tracker.ApplyModifiers();
            tracker.CalculateNumSyllablesPerWord();
            tracker.CalculateNumWordsPerSentence();
            tracker.CalculateFKGrade();
            tracker.CalculateFKScore();

            // update the form labels with the results
            lblSyllableCount.Content = tracker.NumSyllables;
            lblWordCount.Content = tracker.NumWords;
            lblSentenceCount.Content = tracker.NumSentences;
            lblSyllablesPerWordCount.Content = Math.Round(tracker.NumSyllablesPerWord, 2, MidpointRounding.AwayFromZero);
            lblWordsPerSentenceCount.Content = Math.Round(tracker.NumWordsPerSentence, 2, MidpointRounding.AwayFromZero);
            lblFKGradeNumber.Content = Math.Round(tracker.FKGrade, 2, MidpointRounding.AwayFromZero);
            lblFKScoreNumber.Content = Math.Round(tracker.FKScore, 2, MidpointRounding.AwayFromZero);

            /* update the meter, which is a progress bar control, according
             * to the FKScore. The bar changes color as well */
            meterFKScore.Value = (tracker.FKScore);
            meterFKScore.Foreground = new SolidColorBrush(Colors.Orange);

            // set a minimum bar length for really low scores, so the bar is not completely empty
            if (tracker.FKScore <= 5) {
                meterFKScore.Value = 5;
            }

            // change bar color and status depending on the score
            if (tracker.FKScore >= 0 && tracker.FKScore < 40) {
                meterFKScore.Foreground = new SolidColorBrush(Colors.Firebrick);
                lblStatusDetails.Content = "Difficult Readability:\n" +
                    "Break-up paragraphs into\n" +
                    "bullet lists or steps.\n" +
                    "Write shorter sentences\n" +
                    "with simpler words.";
            } else if (tracker.FKScore >= 40 && tracker.FKScore < 60) {
                meterFKScore.Foreground = new SolidColorBrush(Colors.Orange);
                lblStatusDetails.Content = "Medium Readability:\n" +
                    "Break-up paragraphs into\n" +
                    "bullet lists or steps.\n" +
                    "Write shorter sentences\n" +
                    "with simpler words.";
            } else {
                meterFKScore.Foreground = new SolidColorBrush(Colors.MediumSpringGreen);
                lblStatusDetails.Content = "Good Readability:\n" +
                    "This text should be\n" +
                    "understood by most\n" +
                    "readers.";
            }

            // if the word count is low, warn the user that the score may not be useful
            if (tracker.NumWords <= 20) {
                lblStatusDetails.Content = "Low Word Count:\n" +
                    "The sample size is\n" +
                    "is small. The may\n" +
                    "result in unreliable\n" +
                    "scores.";
            }
        }
    }
}
