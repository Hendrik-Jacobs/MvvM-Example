using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace mvvmTest2.ViewModels
{
    class InputBindingViewModel : MainViewModel, INotifyPropertyChanged
    {
        #region Constructors
        public InputBindingViewModel()
        {
            ReturnCommand = new RelayCommand(ExecuteReturn, CanExecuteTrue);
            ClearCommand = new RelayCommand(ExecuteClear, CanExecuteTrue);
            ClearBothCommand = new RelayCommand(ExecuteClearBoth, CanExecuteTrue);


            _infoBoxText =
@"
LeftClick
MiddleClick
RightClick
WheelClick
LeftDoubleClick
RightDoubleClick";


            _infoBoxText2 =
@"

Keys:   (In upper TextBox)
Return: Mirror upper to lower TextBox
Return + Ctrl: Clear lower TextBox

Mouse:  (In Rectangle)
LeftClick: Clear both TextBoxes";

            TbOne = "Hello World.";
        }
        #endregion Constructors


        #region Fields
        private readonly string _infoBoxText;
        private readonly string _infoBoxText2;
        private string _tbOne;
        private string _tbTwo;
        #endregion Fields


        #region Properties
        public string InfoBoxText
        {
            get => _infoBoxText;
        }


        public string InfoBoxText2
        {
            get => _infoBoxText2;
        }


        public string TbOne
        {
            get => _tbOne;
            set
            {
                if (_tbOne != value)
                {
                    _tbOne = value;
                    OnPropertyChanged("TbOne");
                }
            }
        }


        public string TbTwo
        {
            get => _tbTwo;
            set
            {
                if (_tbTwo != value)
                {
                    _tbTwo = value;
                    OnPropertyChanged("TbTwo");
                }
            }
        }
        #endregion Properties


        #region Commands
        public ICommand ReturnCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand ClearBothCommand { get; set; }
        #endregion Commands


        #region ExecuteCommands
        private void ExecuteReturn(object parameter) => TbTwo = TbOne;
        private void ExecuteClear(object parameter) => TbTwo = "";
        private void ExecuteClearBoth(object parameter)
        {
            TbTwo = "";
            TbOne = "";
        }
        #endregion ExecuteCommands


        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChanged Members
    }
}
