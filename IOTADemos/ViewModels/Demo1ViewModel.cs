using IOTADemos.BO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Effects;
using Tangle.Net.Entity;

namespace IOTADemos.ViewModels
{
    class Demo1ViewModel : BaseViewModel
    {
        #region Visibility
        private bool _isDemo1Visible;
        public bool Demo1Visibility
        {
            get { return _isDemo1Visible; }

            set { SetFieldAndRefresh(ref _isDemo1Visible, value); }
        }
        private bool _isSendTabVisible;
        public bool SendTabVisibility
        {
            get { return _isSendTabVisible; }

            set { SetFieldAndRefresh(ref _isSendTabVisible, value); }
        }
        private bool _isReceiveTabVisible;
        public bool ReceiveTabVisibility
        {
            get { return _isReceiveTabVisible; }

            set { SetFieldAndRefresh(ref _isReceiveTabVisible, value); }
        }
        private bool _isHistoryTabVisible;
        public bool HistoryTabVisibility
        {
            get { return _isHistoryTabVisible; }

            set { SetFieldAndRefresh(ref _isHistoryTabVisible, value); }
        }
        #endregion

        BlurEffect backgroundEffect = new BlurEffect();
        public DelegateCommand<object> ExitApp { get; }
        public DelegateCommand<object> NavigateBack { get; }
        public DelegateCommand<string> SendFundsMenuButton { get; }
        public DelegateCommand<string> ReceiveFundsMenuButton { get; }
        public DelegateCommand<string> HistoryMenuButton { get; }
        public DelegateCommand<string> GenerateAddressButton { get; }
        public static Demo1ViewModel _instance;
        public static Demo1ViewModel Instance => _instance ?? (_instance = new Demo1ViewModel());

        //Bindings
        public string _address_output;
        public string Address_Output
        {
            get { return _address_output; }
            set { SetFieldAndRefresh(ref _address_output, value); }
        }

        public Demo1ViewModel() {

            if (_instance == null)
            {
                _instance = this;
            }

            //Command events
            ExitApp = new DelegateCommand<object>(CommandEnum.ExitApp, (s) => ExitAppButton());
            NavigateBack = new DelegateCommand<object>(CommandEnum.NavigateBack, (s) => BackNavigation());
            SendFundsMenuButton = new DelegateCommand<string>(CommandEnum.SendFundsMenuButton, (s) => SendTabOpen());
            ReceiveFundsMenuButton = new DelegateCommand<string>(CommandEnum.ReceiveFundsMenuButton, (s) => ReceiveTabOpen());
            HistoryMenuButton = new DelegateCommand<string>(CommandEnum.HistoryMenuButton, (s) => HistoryTabOpen());
            GenerateAddressButton = new DelegateCommand<string>(CommandEnum.GenerateAddressButton, (s) => GenerateNewAddress());
            Demo1Visibility = false;
            SendTabVisibility = true;
            ReceiveTabVisibility = false;
            HistoryTabVisibility = false;
            Address_Output = "Click the button to generate a new address";
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

        private void BackNavigation()
        {
            Instance.Demo1Visibility = false;
            DemoChooserViewModel.Instance.DemoChooserVisibility = true;
        }

        private void SendTabOpen()
        {
            Instance.ReceiveTabVisibility = false;
            Instance.HistoryTabVisibility = false;
            Instance.SendTabVisibility = true;
        }

        private void ReceiveTabOpen()
        {
            Instance.SendTabVisibility = false;
            Instance.HistoryTabVisibility = false;
            Instance.ReceiveTabVisibility = true;
        }

        private void HistoryTabOpen()
        {
            Instance.SendTabVisibility = false;
            Instance.ReceiveTabVisibility = false;
            Instance.HistoryTabVisibility = true;
        }

        private void GenerateNewAddress()
        {
            backgroundEffect.Radius = 10;
            //Effect = backgroundEffect;
            var tmp = "";

            SpinnerViewModel.Instance.SpinnerVisibility = true;


            Application.Current.Dispatcher.Invoke(() =>
            {
                Address address = BL.Demo1.GetNextAvailableAddress(Static.repository);
                tmp = address.Value;
            });

            SpinnerViewModel.Instance.SpinnerVisibility = false;

            Address_Output = tmp;
            backgroundEffect.Radius = 0;
            //Effect = backgroundEffect;
        }
    }
}
