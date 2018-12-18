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
    class DemoChooserViewModel : BaseViewModel
    {
        private bool _isDemoChooserVisible;
        public bool DemoChooserVisibility
        {
            get { return _isDemoChooserVisible; }

            set { SetFieldAndRefresh(ref _isDemoChooserVisible, value); }
        }
        public DelegateCommand<string> Demo1Navigate { get; }
        public static DemoChooserViewModel _instance;
        public static DemoChooserViewModel Instance => _instance ?? (_instance = new DemoChooserViewModel());

        public DemoChooserViewModel() {

            if (_instance == null)
            {
                _instance = this;
            }
            //Command events
            Demo1Navigate = new DelegateCommand<string>(CommandEnum.Demo1Navigate, (s) => Demo1Navigation());
            DemoChooserVisibility = false;
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

        /// <summary>
        /// Navigate to Demo1
        /// </summary>
        private void Demo1Navigation()
        {
            Instance.DemoChooserVisibility = false;
            Demo1ViewModel.Instance.Demo1Visibility = true;
        }
    }
}
