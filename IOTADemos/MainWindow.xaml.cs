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

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var numberOfWindows = App.Current.Windows.Count - 1;
            for (int intCounter = numberOfWindows; intCounter >= 0; intCounter--) {
                App.Current.Windows[intCounter].Close();
            }
        }

        private void Continue_button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            DemoChooser dc = new DemoChooser();
            dc.ShowDialog();
        }

        /// <summary>
        /// This method generates a random seed on block. WARNING: The method is not safe. It is only used for testing purposes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Randomize_seed_button_Click(object sender, RoutedEventArgs e)
        {
            var seed = "";
            List<char> alphabet = new List<char>() {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','9'};
            for (int i = 0; i < 81; i++)
            {
                int r = Static.rnd.Next(alphabet.Count);
                seed += alphabet[r].ToString();
            }
            SeedInput.Text = seed;
        }
    }
}
