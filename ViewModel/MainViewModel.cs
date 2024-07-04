using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PokerCalculatorWPF.Model;
using PokerCalculatorWPF.ViewModel.UserControls;
using PokerCalculatorWPF.View.UserControls;

namespace PokerCalculatorWPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        #region Fields
        private MainUserControlViewModel mainUserControlViewModel = new MainUserControlViewModel();
        private UserControl userControl;
        #endregion

        #region Properties
        public UserControl UserControl
        {
            get { return userControl; }
            set
            {
                userControl = value;
                RaisePropertyChanged(nameof(UserControl));

            }
        }
        #endregion
        #region Commands        
        public ICommand SetSettingView { get; set; }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            UserControl = new MainUserControl() { DataContext = mainUserControlViewModel };          
        }
        #endregion
    }
}
