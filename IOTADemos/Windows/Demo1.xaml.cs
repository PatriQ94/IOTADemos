using IOTADemos.BO;
using RestSharp;
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
using System.Windows.Shapes;
using Tangle.Net.Entity;
using Tangle.Net.Repository;

namespace IOTADemos.Windows
{
    /// <summary>
    /// Interaction logic for Demo1.xaml
    /// </summary>
    public partial class Demo1 : Window
    {

        private RestIotaRepository repository;


        public Demo1()
        {
            InitializeComponent();
            repository = new RestIotaRepository(new RestClient(Static.currentNode));

        }

        private Address GetNextAvailableAddress()
        {
            Seed seed = new Seed(Static.seed);

            for (int i = 0; i < 50; i++)
            {
                List<Address> addresses = repository.GetNewAddresses(seed, i, 1, 2);

                if (addresses != null && addresses.Count > 0 && !addresses.First().SpentFrom)
                {
                    return addresses.First();
                }

            }

            return null;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var numberOfWindows = App.Current.Windows.Count - 1;
            for (int intCounter = numberOfWindows; intCounter >= 0; intCounter--)
            {
                App.Current.Windows[intCounter].Close();
            }
        }

        private void Back_button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            DemoChooser dc = new DemoChooser();
            dc.ShowDialog();
        }

        private void SendButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            HistoryFundsGroup.Visibility = Visibility.Hidden;
            SendFundsGroup.Visibility = Visibility.Visible;
        }

        private void ReceiveButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            SendFundsGroup.Visibility = Visibility.Hidden;
            HistoryFundsGroup.Visibility = Visibility.Hidden;
        }

        private void HistoryButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            SendFundsGroup.Visibility = Visibility.Hidden;
            HistoryFundsGroup.Visibility = Visibility.Visible;
        }
    }
}
