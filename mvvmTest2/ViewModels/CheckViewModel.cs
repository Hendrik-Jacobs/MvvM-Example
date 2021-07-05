using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace mvvmTest2.ViewModels
{
    class CheckViewModel : MainViewModel, INotifyPropertyChanged
    {
        #region Constructors
        public CheckViewModel()
        {
            Check1Command = new RelayCommand(ExecuteCheck1, CanExecuteTrue);
            Check2Command = new RelayCommand(ExecuteCheck2, CanExecuteTrue);
            Check3Command = new RelayCommand(ExecuteCheck3, CanExecuteTrue);

            _check1Visi = Visibility.Visible;
            _check2Visi = Visibility.Visible;
            _check3Visi = Visibility.Visible;
            _iconVisi = Visibility.Visible;
            _borderVisi = Visibility.Visible;
            _blackVisi = Visibility.Visible;
        }
        #endregion Constructors


        #region Commands
        public ICommand Check1Command { get; set; }
        public ICommand Check2Command { get; set; }
        public ICommand Check3Command { get; set; }
        #endregion Commands


        #region Fields
        private Visibility _check1Visi;
        private Visibility _check2Visi;
        private Visibility _check3Visi;
        private Visibility _iconVisi;
        private Visibility _borderVisi;
        private Visibility _blackVisi;
        #endregion Fields


        #region Properties
        public Visibility Check1Visi
        {
            get => _check1Visi;
            set
            {
                if (_check1Visi != value)
                {
                    _check1Visi = value;
                    OnPropertyChanged("Check1Visi");
                }
            }
        }

        public Visibility Check2Visi
        {
            get => _check2Visi;
            set
            {
                if (_check2Visi != value)
                {
                    _check2Visi = value;
                    OnPropertyChanged("Check2Visi");
                }
            }
        }

        public Visibility Check3Visi
        {
            get => _check3Visi;
            set
            {
                if (_check3Visi != value)
                {
                    _check3Visi = value;
                    OnPropertyChanged("Check3Visi");
                }
            }
        }

        public Visibility IconVisi
        {
            get => _iconVisi;
            set
            {
                if (_iconVisi != value)
                {
                    _iconVisi = value;
                    OnPropertyChanged("IconVisi");
                }
            }
        }

        public Visibility BorderVisi
        {
            get => _borderVisi;
            set
            {
                if (_borderVisi != value)
                {
                    _borderVisi = value;
                    OnPropertyChanged("BorderVisi");
                }
            }
        }

        public Visibility BlackVisi
        {
            get => _blackVisi;
            set
            {
                if (_blackVisi != value)
                {
                    _blackVisi = value;
                    OnPropertyChanged("BlackVisi");
                }
            }
        }
        #endregion Properties


        #region ExecuteMethods
        private void ExecuteCheck1(object parameter)
        {
            if (Check1Visi == Visibility.Visible)
            {
                Check1Visi = Visibility.Collapsed;
                IconVisi = Visibility.Collapsed;
            }
            else
            {
                Check1Visi = Visibility.Visible;
                IconVisi = Visibility.Visible;
            }
        }

        private void ExecuteCheck2(object parameter)
        {
            if (Check2Visi == Visibility.Visible)
            {
                Check2Visi = Visibility.Collapsed;
                BlackVisi = Visibility.Collapsed;
            }
            else
            {
                Check2Visi = Visibility.Visible;
                BlackVisi = Visibility.Visible;
            }
        }

        private void ExecuteCheck3(object parameter)
        {
            if (Check3Visi == Visibility.Visible)
            {
                Check3Visi = Visibility.Collapsed;
                BorderVisi = Visibility.Collapsed;
            }
            else
            {
                Check3Visi = Visibility.Visible;
                BorderVisi = Visibility.Visible;
            }
        }
        #endregion ExecuteMethods


        #region INotifyPropertyChanged Members  
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChanged Members
    }
}
