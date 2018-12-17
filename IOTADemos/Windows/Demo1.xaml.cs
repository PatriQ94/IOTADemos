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

namespace IOTADemos.Windows
{
    /// <summary>
    /// Interaction logic for Demo1.xaml
    /// </summary>
    public partial class Demo1 : Window
    {
        public Demo1()
        {
            InitializeComponent();
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
    }
}
