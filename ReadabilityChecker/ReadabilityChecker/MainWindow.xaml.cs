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

            lblWordCount.Content = rctracker.getNumWords();
            lblSentenceCount.Content = rctracker.getNumSentences();

        }
    }
}
