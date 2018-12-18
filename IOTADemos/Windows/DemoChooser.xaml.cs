using IOTADemos.BO;
using IOTADemos.ViewModels;
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
    public partial class DemoChooser : UserControl
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

        private void Back_button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {          
            DemoChooserViewModel.Instance.DemoChooserVisibility = false;
            AppUserControlViewModel.Instance.AppUserControlVisibility = true;

            AppUserControlViewModel.Instance.Seed_Input = Static.seed;
            AppUserControlViewModel.Instance.Node_chooser.Add(Static.currentNode);
        }
    }
}
