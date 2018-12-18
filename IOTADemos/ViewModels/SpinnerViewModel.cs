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
    class SpinnerViewModel : BaseViewModel
    {
        private bool _isSpinnerVisible;
        public bool SpinnerVisibility
        {
            get { return _isSpinnerVisible; }

            set { SetFieldAndRefresh(ref _isSpinnerVisible, value); }
        }

        public static SpinnerViewModel _instance;
        public static SpinnerViewModel Instance => _instance ?? (_instance = new SpinnerViewModel());
       
        public SpinnerViewModel() {

            if (_instance == null)
            {
                _instance = this;
            }
            //Command events
            SpinnerVisibility = false;
        }     
    }
}
