using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
           rctracker.setNumSentences(rcscanner.countSentencesPostHTMLStrip(txtMain.Text));

         //   rctracker.setNumLists(rcscanner.countLists(htmlEditor.getHtmlText()));

            // post html tag strip
            rctracker.setNumWords(rcscanner.countWords(txtMain.Text));
            rctracker.setNumSyllables(rcscanner.countSyllables(txtMain.Text));
            rctracker.setNumIPs(rcscanner.countIPs(txtMain.Text));

            // Adjust some counters for special cases, such as IP addresses
            rctracker.applyModifiers();
            rctracker.calculateNumSyllablesPerWord();
            rctracker.calculateNumWordsPerSentence();
            rctracker.calculateFKGrade();
            rctracker.calculateFKScore();

            lblSyllableCount.Content = rctracker.getNumSyllables();
            lblWordCount.Content = rctracker.getNumWords();
            lblSentenceCount.Content = rctracker.getNumSentences();
            lblSyllablesPerWordCount.Content = Math.Round(rctracker.getNumSyllablesPerWord(), 2, MidpointRounding.AwayFromZero);
            lblWordsPerSentenceCount.Content = Math.Round(rctracker.getNumWordsPerSentence(), 2, MidpointRounding.AwayFromZero);
            lblFKGradeNumber.Content = Math.Round(rctracker.getFKGrade(), 2, MidpointRounding.AwayFromZero); 
            lblFKScoreNumber.Content = Math.Round(rctracker.getFKScore(), 2, MidpointRounding.AwayFromZero);


            // using a local variable for readability
            double FKScore = rctracker.getFKScore();

            // update the progress bar length based on the score
            meterFKScore.Value = (FKScore);
            meterFKScore.Foreground = new SolidColorBrush(Colors.Orange);

            // set a minimum bar length for really low scores
            if (FKScore <= 5) {
                meterFKScore.Value = 5;
            }

            // change bar color and status depending on the score
            if (FKScore >= 0 && FKScore < 40) {
                meterFKScore.Foreground = new SolidColorBrush(Colors.Crimson);
                lblStatusDetails.Content = "Difficult Readability:\nBreak-up paragraphs into bullet\n" +
                    "lists or steps. Write shorter sentences with simpler words.";
            }
            else if (FKScore >= 40 && FKScore < 60) {
                meterFKScore.Foreground = new SolidColorBrush(Colors.Orange);
                lblStatusDetails.Content = "Medium Readability:\nBreak-up paragraphs into bullet\n" +
                    "lists or steps. Write shorter sentences with simpler words.";
            }
            else {
                meterFKScore.Foreground = new SolidColorBrush(Colors.LimeGreen);
                lblStatusDetails.Content = "Good Readability:\nThis text should be understood by\n" +
                    "most readers words.";
            }

        }

    }
}
