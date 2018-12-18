using IOTADemos.BO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tangle.Net.Entity;

namespace IOTADemos.ViewModels
{
    class Demo1ViewModel : BaseViewModel
    {
        private bool _isDemo1Visible;
        public DelegateCommand<string> ExitApp { get; }
        public static Demo1ViewModel _instance;
        public static Demo1ViewModel Instance => _instance ?? (_instance = new Demo1ViewModel());

        //Bindings
        public ObservableCollection<string> _node_chooser;
        public ObservableCollection<string> Node_chooser
        {
            get { return _node_chooser; }
            set { SetFieldAndRefresh(ref _node_chooser, value); }
        }

        public string _seed_input;
        public string Seed_Input
        {
            get { return _seed_input; }
            set { SetFieldAndRefresh(ref _seed_input, value); }
        }

        public string _selected_node;
        public string Selected_Node
        {
            get { return _selected_node; }
            set { SetFieldAndRefresh(ref _selected_node, value); }
        }
        public bool Demo1Visibility
        {
            get { return _isDemo1Visible; }

            set { SetFieldAndRefresh(ref _isDemo1Visible, value); }
        }

        public Demo1ViewModel() {

            if (_instance == null)
            {
                _instance = this;
            }
            Seed_Input = "Please insert your seed";

            //Command events
            ExitApp = new DelegateCommand<string>(CommandEnum.ExitApp, (s) => ExitAppButton());
            Demo1Visibility = false;
        }

        /// <summary>
        /// Exit app
        /// </summary>
        private void ExitAppButton()
        {
            var numberOfWindows = App.Current.Windows.Count - 1;
            for (int intCounter = numberOfWindows; intCounter >= 0; intCounter--)
            {
                App.Current.Windows[intCounter].Close();
            }
        }
        
    }
}
