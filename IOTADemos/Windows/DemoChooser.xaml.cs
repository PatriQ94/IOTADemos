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

        private void Back_button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {          
            DemoChooserViewModel.Instance.NavigateBack.Execute(demochooser);
        }

        private void Exit_button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DemoChooserViewModel.Instance.ExitApp.Execute(demochooser);
        }
    }
}
