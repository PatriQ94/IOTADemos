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
using Tangle.Net.Cryptography;
using Tangle.Net.Repository;
using Tangle.Net.Entity;
using System.Windows.Media.Effects;
using System.Threading;
using IOTADemos.ViewModels;

namespace IOTADemos.Windows
{
    /// <summary>
    /// Interaction logic for Demo1.xaml
    /// </summary>
    public partial class Demo1 : UserControl
    {
        BlurEffect backgroundEffect = new BlurEffect();
        private RestIotaRepository repository;

        public Demo1()
        {
            InitializeComponent();
            //repository = new RestIotaRepository(new RestClient(Static.currentNode));
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
            Demo1ViewModel.Instance.Demo1Visibility = false;
            DemoChooserViewModel.Instance.DemoChooserVisibility = true;
        }

        private void SendButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            HistoryFundsGroup.Visibility = Visibility.Hidden;
            ReceiveFundsGroup.Visibility = Visibility.Hidden;
            SendFundsGroup.Visibility = Visibility.Visible;
        }

        private void ReceiveButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            SendFundsGroup.Visibility = Visibility.Hidden;
            HistoryFundsGroup.Visibility = Visibility.Hidden;
            ReceiveFundsGroup.Visibility = Visibility.Visible;
        }

        private void HistoryButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            SendFundsGroup.Visibility = Visibility.Hidden;
            ReceiveFundsGroup.Visibility = Visibility.Hidden;
            HistoryFundsGroup.Visibility = Visibility.Visible;
        }

        private void GenerateAddress_Click(object sender, RoutedEventArgs e)
        {
            backgroundEffect.Radius = 10;
            Effect = backgroundEffect;
            var temp = "";

            ////TODO: Fix this spinner
            //using (Spinner sp = new Spinner())
            //{
            //    Application.Current.Dispatcher.Invoke(() => {
            //        sp.Owner = this;
            //        sp.Show();
            //    });

            //    Task taskA = Task.Run(() =>
            //    {
            //        Address address = BL.Demo1.GetNextAvailableAddress(repository);
            //        temp = address.Value;
            //    });
            //    taskA.Wait();

            //    Application.Current.Dispatcher.Invoke(() => {
            //        sp.Hide();
            //    });
            //}
            Address address = BL.Demo1.GetNextAvailableAddress(repository);
            ReceiveFundsAddressOutput.Text = temp;
            backgroundEffect.Radius = 0;
            Effect = backgroundEffect;
        }
    }
}
