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
    /// Interaction logic for DemoChooser.xaml
    /// </summary>
    public partial class DemoChooser : Window
    {
        public DemoChooser()
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

        private void Demo1_button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Demo1 d1 = new Demo1();
            d1.ShowDialog();
        }
    }
}
