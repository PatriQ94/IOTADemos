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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IOTADemos.Windows
{
    /// <summary>
    /// Interaction logic for AppUserControl.xaml
    /// </summary>
    public partial class AppUserControl : UserControl
    {
        public AppUserControl()
        {
            InitializeComponent();
        }

        private void Exit_button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AppUserControlViewModel.Instance.ExitApp.Execute(appusercontrol);
        }

        private void Seed_question_mark_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AppUserControlViewModel.Instance.SeedQuestionMark.Execute(appusercontrol);
        }

        private void Node_question_mark_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AppUserControlViewModel.Instance.NodeQuestionMark.Execute(appusercontrol);
        }

        private void SeedInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            AppUserControlViewModel.Instance.SeedInputValidation.Execute(appusercontrol);
        }

        private void SeedInput_GotFocus(object sender, RoutedEventArgs e)
        {
            AppUserControlViewModel.Instance.SeedInputOnFocus.Execute(appusercontrol);
        }

        private void SeedInput_LostFocus(object sender, RoutedEventArgs e)
        {
            AppUserControlViewModel.Instance.SeedInputLostFocus.Execute(appusercontrol);
        }
    }
}
