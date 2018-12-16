using System.Net.Http;
using System.Windows;
using System.Windows.Input;
using System.Collections;
using System.Collections.Generic;
using IOTADemos.BO;
using Newtonsoft.Json;

namespace IOTADemos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            FillNodeDropDown();
        }

        /// <summary>
        /// This method fills the dropdownlist for nodes
        /// </summary>
        private void FillNodeDropDown() {
            var responseString = Static.client.GetStringAsync("https://nodes.iota.works/api/ssl/live").Result;

            if (!string.IsNullOrEmpty(responseString)) {
                List<Node> nodes = new List<Node>();
                nodes = JsonConvert.DeserializeObject<List<Node>>(responseString);
                foreach (var node in nodes)
                {
                    Node_chooser.Items.Add(node.node);
                }
            }           
        }

        /// <summary>
        /// Exit app
        /// </summary>
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var numberOfWindows = App.Current.Windows.Count - 1;
            for (int intCounter = numberOfWindows; intCounter >= 0; intCounter--) {
                App.Current.Windows[intCounter].Close();
            }
        }

        /// <summary>
        /// This method is used to go to second screen (Choose demo)
        /// It also validates that input data is correct
        /// </summary>
        private void Continue_button_Click(object sender, RoutedEventArgs e)
        {
            var seed = SeedInput.Text;
            var node = Node_chooser.Text;
            if (string.IsNullOrEmpty(seed) || seed.Length != 81) {
                MessageBox.Show("Please fix this ugly popup lol. Also seed has to have length of 81 characters and contain only uppercase A-Z characters plus number 9.");
                return;
            }

            if (string.IsNullOrEmpty(node) || !node.Contains("https"))
            {
                MessageBox.Show("Please fix this ugly popup lol. Also please choose a correct node to connect to.");
                return;
            }

            //Set seed
            Static.seed = seed;
            Static.currentNode = node;

            this.Hide();
            DemoChooser dc = new DemoChooser();
            dc.ShowDialog();
        }

        /// <summary>
        /// This method generates a random seed on click. WARNING: The seed generation is not safe. It is only used for testing purposes.
        /// </summary>
        private void Randomize_seed_button_Click(object sender, RoutedEventArgs e)
        {
            var seed = "";
            for (int i = 0; i < 81; i++)
            {
                int r = Static.random.Next(Static.alphabet.Count);
                seed += Static.alphabet[r].ToString();
            }
            SeedInput.Text = seed;
        }

        private void Seed_question_mark_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Each wallet is identified and protected by a unique access key known as a ‘seed’. The seed is an 81-character string, comprised of capital letters A-Z and the number 9. It’s important to note that while we call them wallets, they do not actually store tokens. They are better thought of as keychains that provide access to the tokens you store permanently on the ledger.");
        }

        private void Node_question_mark_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Full node is one of the participants in the decentralized IOTA network and serves as an API, to which you connect to in order to communicate with the network.");
        }
    }
}
