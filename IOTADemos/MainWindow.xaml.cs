using System.Windows;
using System.Windows.Input;

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

            
        }

        private void FillNodeDropDown() {
            //Node_chooser.Items.Add("This is random test item from code");
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

    }
}
