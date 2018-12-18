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
    class AppUserControlViewModel : BaseViewModel
    {
        private bool _isAppUserControlVisible;
        public bool AppUserControlVisibility
        {
            get { return _isAppUserControlVisible; }

            set { SetFieldAndRefresh(ref _isAppUserControlVisible, value); }
        }

        public DelegateCommand<object> ExitApp { get; }
        public DelegateCommand<object> RandomizeSeed { get; }
        public DelegateCommand<object> Continue { get; }
        public DelegateCommand<object> SeedQuestionMark { get; }
        public DelegateCommand<object> NodeQuestionMark { get; }
        public DelegateCommand<object> SeedInputValidation { get; }
        public DelegateCommand<object> SeedInputOnFocus { get; }
        public DelegateCommand<object> SeedInputLostFocus { get; }
        public static AppUserControlViewModel _instance;
        public static AppUserControlViewModel Instance => _instance ?? (_instance = new AppUserControlViewModel());

        //Bindings
        public static ObservableCollection<string> _node_chooser = new ObservableCollection<string>();
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

        public AppUserControlViewModel() {

            if (_instance == null)
            {
                _instance = this;
            }

            //Command events
            ExitApp = new DelegateCommand<object>(CommandEnum.ExitApp, (s) => ExitAppButton(s));
            Continue = new DelegateCommand<object>(CommandEnum.Continue, (s) => ContinueNextWindow(s));
            RandomizeSeed = new DelegateCommand<object>(CommandEnum.RandomizeSeed, (s) => GenerateRandomSeed(s));
            SeedQuestionMark = new DelegateCommand<object>(CommandEnum.SeedQuestionMark, (s) => SeedQuestionMarkButton(s));
            NodeQuestionMark = new DelegateCommand<object>(CommandEnum.SeedQuestionMark, (s) => NodeQuestionMarkButton(s));
            SeedInputValidation = new DelegateCommand<object>(CommandEnum.SeedInputValidation, (s) => SeedInputValidationCheck(s));
            SeedInputOnFocus = new DelegateCommand<object>(CommandEnum.SeedInputOnFocus, (s) => SeedInputOnFocusEvent(s));
            SeedInputLostFocus = new DelegateCommand<object>(CommandEnum.SeedInputLostFocus, (s) => SeedInputLostFocusEvent(s));


            AppUserControlVisibility = true;
            Seed_Input = "Insert your seed";
            FillNodeDropDown();
        }

        /// <summary>
        /// Exit app
        /// </summary>
        private void ExitAppButton(object parameter)
        {
            var numberOfWindows = App.Current.Windows.Count - 1;
            for (int intCounter = numberOfWindows; intCounter >= 0; intCounter--)
            {
                App.Current.Windows[intCounter].Close();
            }
        }

        /// <summary>
        /// This method fills the dropdownlist for nodes
        /// </summary>
        private void FillNodeDropDown()
        {
            List<string> nodeList = new BL.AppUserControl().FillNodeDropDown();
            foreach (var node in nodeList)
            {
                Node_chooser.Add(node);
            }
        }

        /// <summary>
        /// Seed help
        /// </summary>
        private void SeedQuestionMarkButton(object parameter)
        {
            MessageBox.Show("Each wallet is identified and protected by a unique access key known as a ‘seed’. " +
                "The seed is an 81-character string, comprised of capital letters A-Z and the number 9. " +
                "It’s important to note that while we call them wallets, they do not actually store tokens. " +
                "They are better thought of as keychains that provide access to the tokens you store permanently on the ledger.", "Seed help");
        }

        /// <summary>
        /// Node help
        /// </summary>
        private void NodeQuestionMarkButton(object parameter)
        {
            MessageBox.Show("Full node is one of the participants in the decentralized IOTA network and serves as an API, " +
                "to which you connect to in order to communicate with the network.", "Node help");
        }

        /// <summary>
        /// Seed validation
        /// </summary>
        private void SeedInputValidationCheck(object parameter)
        {
            if (Seed_Input == "Insert your seed")
            {
                return;
            }

            Seed_Input  = new BL.AppUserControl().SeedValidation(Seed_Input);
        }

        private void SeedInputOnFocusEvent(object parameter)
        {
            if (Seed_Input == "Insert your seed")
            {
                Seed_Input = "";
            }
        }

        private void SeedInputLostFocusEvent(object parameter)
        {
            if (string.IsNullOrWhiteSpace(Seed_Input))
                Seed_Input = "Insert your seed";
        }

        /// <summary>
        /// This method generates a random seed on click. WARNING: The seed generation is not safe. It is only used for testing purposes.
        /// </summary>
        private void GenerateRandomSeed(object parameter)
        {
            Static.seed = Seed.Random().Value;
            Seed_Input = Static.seed;
        }

        /// <summary>
        /// This method is used to go to second screen (Choose demo)
        /// It also validates that input data is correct
        /// </summary>
        private void ContinueNextWindow(object parameter)
        {
            var seed = Seed_Input;
            var node = Selected_Node;
            if (string.IsNullOrEmpty(seed) || seed.Length != Seed.Length)
            {
                MessageBox.Show("Please fix this ugly popup lol. Also seed has to have length " +
                    "of 81 characters and contain only uppercase A-Z characters plus number 9.", "Seed validation");
                return;
            }

            if (string.IsNullOrEmpty(node) || !node.Contains("https"))
            {
                MessageBox.Show("Please fix this ugly popup lol. Also please choose a correct node to connect to.", "Node validation");
                return;
            }

            foreach (var letter in seed)
            {
                if (!Static.alphabet.Contains(letter))
                {
                    MessageBox.Show("Seed contains wrong letters. Only uppercase A-Z and number 9 are allowed.", "Seed validation");
                    return;
                }
            }

            //Set seed
            Static.seed = seed;
            Static.currentNode = node;

            _isAppUserControlVisible = false;
            DemoChooserViewModel.Instance.DemoChooserVisibility = true;
        }
    }
}
