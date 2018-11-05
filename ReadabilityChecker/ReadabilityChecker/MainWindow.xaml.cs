using System;
using System.Windows;
using System.Windows.Media;


namespace ReadabilityChecker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show(txtMain.Text);
           // lblWordCount.Content = "Hello";

            RCScanner rcscanner = new RCScanner();
            RCTracker rctracker = new RCTracker();

            /* To detect lines that do not end with punctuation,
             * it is necessary to run two separate checks (with and without 
                       * HTML tags) for sentences.
             * Checking before stripping the HTML formatting allows detection of
             * sentences that do not end with punctuation. Without this, items
             * in bullet lists and procedures would not be detected as sentences.
             *
             * Since we want to encourage authors to "break up" dense paragraphs 
                       * into lists it is better detect lists items as sentences, which 
                       * improves the readability score.
             */
       //     String plainText = stripHtmlTags(htmlEditor.getHtmlText());

            // sentence count requires both pre and post HTML strip scans
           rctracker.NumSentences = rcscanner.CountSentences(txtMain.Text);

         //   rctracker.setNumLists(rcscanner.CountLists(htmlEditor.getHtmlText()));

            // post html tag strip
            rctracker.NumWords = rcscanner.CountWords(txtMain.Text);
            rctracker.NumSyllables = rcscanner.CountSyllables(txtMain.Text);
            rctracker.NumIPs = rcscanner.CountIPs(txtMain.Text);
            rctracker.NumLists = rcscanner.CountLists(txtMain.Text);

            // Adjust some counters for special cases, such as IP addresses
            rctracker.ApplyModifiers();
            rctracker.CalculateNumSyllablesPerWord();
            rctracker.CalculateNumWordsPerSentence();
            rctracker.CalculateFKGrade();
            rctracker.CalculateFKScore();

            lblSyllableCount.Content = rctracker.NumSyllables;
            lblWordCount.Content = rctracker.NumWords;
            lblSentenceCount.Content = rctracker.NumSentences;

            lblSyllablesPerWordCount.Content = Math.Round(rctracker.NumSyllablesPerWord, 2, MidpointRounding.AwayFromZero);
            lblWordsPerSentenceCount.Content = Math.Round(rctracker.NumWordsPerSentence, 2, MidpointRounding.AwayFromZero);
            lblFKGradeNumber.Content = Math.Round(rctracker.FKGrade, 2, MidpointRounding.AwayFromZero); 
            lblFKScoreNumber.Content = Math.Round(rctracker.FKScore, 2, MidpointRounding.AwayFromZero);


            // using a local variable for readability
            double FKScore = rctracker.FKScore;

            // update the progress bar length based on the score
            meterFKScore.Value = (FKScore);
            meterFKScore.Foreground = new SolidColorBrush(Colors.Orange);

            // set a minimum bar length for really low scores
            if (FKScore <= 5) {
                meterFKScore.Value = 5;
            }

            // change bar color and status depending on the score
            if (FKScore >= 0 && FKScore < 40) {
                meterFKScore.Foreground = new SolidColorBrush(Colors.Firebrick);
                lblStatusDetails.Content = "Difficult Readability:\n" +
                    "Break-up paragraphs into\n" +
                    "bullet lists or steps.\n" +
                    "Write shorter sentences\n" +
                    "with simpler words.";
            }
            else if (FKScore >= 40 && FKScore < 60) {
                meterFKScore.Foreground = new SolidColorBrush(Colors.Orange);
                lblStatusDetails.Content = "Medium Readability:\n" +
                    "Break-up paragraphs into\n" +
                    "bullet lists or steps.\n" +
                    "Write shorter sentences\n" +
                    "with simpler words.";
            }
            else {
                meterFKScore.Foreground = new SolidColorBrush(Colors.MediumSpringGreen);
                lblStatusDetails.Content = "Good Readability:\n" +
                    "This text should be\n" +
                    "understood by most\n" +
                    "readers.";
            }

            // if the word count is low, warn the user that the score may not be useful
            if (rctracker.NumWords <= 20)
            {
                lblStatusDetails.Content = "Low Word Count:\n" +
                    "The sample size is\n" +
                    "is small. The may\n" +
                    "result in unreliable\n" +
                    "scores.";
            }
        }
    }
}
