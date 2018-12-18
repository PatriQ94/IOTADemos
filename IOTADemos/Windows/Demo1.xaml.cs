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
        public Demo1()
        {
            InitializeComponent();
            //repository = new RestIotaRepository(new RestClient(Static.currentNode));
        }

        private void Exit_button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Demo1ViewModel.Instance.ExitApp.Execute(demo1);
        }

        private void Back_button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Demo1ViewModel.Instance.NavigateBack.Execute(demo1);
        }
    }
}
