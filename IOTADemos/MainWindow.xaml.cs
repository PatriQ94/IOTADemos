using System.Net.Http;
using System.Windows;
using System.Windows.Input;
using System.Collections;
using System.Collections.Generic;
using IOTADemos.BO;
using Newtonsoft.Json;
using System.Text;
using System.Linq;
using IOTADemos.Windows;
using Tangle.Net.Entity;

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
            Static.MainWindow = this;
        }
    }
}
