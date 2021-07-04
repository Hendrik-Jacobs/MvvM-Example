using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using mvvmTest2.ViewModels;
using System.ComponentModel;

namespace mvvmTest2
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Constructors
        public MainViewModel()
        {
            DataGridCommand = new RelayCommand(OpenDataGrid, CanExecuteTrue);
            InputBindingCommand = new RelayCommand(OpenInputBindings, CanExecuteTrue);
            CloseCommand = new RelayCommand(ExecuteClose, CanExecuteTrue);
            MaxiCommand = new RelayCommand(ExecuteMaxi, CanExecuteTrue);
            MiniCommand = new RelayCommand(ExecuteMini, CanExecuteTrue);
            DragCommand = new RelayCommand(ExecuteDrag, CanExecuteTrue);
            MatrixCommand = new RelayCommand(ExecuteMatrix, CanExecuteTrue);

            CheckVisi = Visibility.Collapsed;
        }
        #endregion Constructors

        private Visibility _checkVisi;
        public Visibility CheckVisi
        {
            get => _checkVisi;
            set
            {
                if (_checkVisi != value)
                {
                    _checkVisi = value;
                    OnPropertyChanged("CheckVisi");
                }
            }
        }


        #region Commands
        public ICommand DataGridCommand { get; set; }
        public ICommand InputBindingCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MaxiCommand { get; set; }
        public ICommand MiniCommand { get; set; }
        public ICommand DragCommand { get; set; }
        public ICommand MatrixCommand { get; set; }
        #endregion Commands


        #region CanExecuteMethods
        public bool CanExecuteTrue(object parameter) => true;
        private void OpenDataGrid(object parameter)
        {
            DGView dataGridView = new DGView();
            dataGridView.InitializeComponent();
            dataGridView.Show();
        }
        #endregion CanExecuteMethods


        #region ExecuteMethods
        private void OpenInputBindings(object parameter)
        {
            InputBindingWin window = new InputBindingWin();
            window.InitializeComponent();
            window.Show();
        }

        private void ExecuteDrag(object parameter)
        {
            Window win = parameter as Window;
            win.DragMove();
        }

        private void ExecuteMini(object parameter)
        {
            Window win = parameter as Window;
            win.WindowState = WindowState.Minimized;
        }

        private void ExecuteMaxi(object parameter)
        {
            Window win = parameter as Window;
            if (win.WindowState != WindowState.Maximized)
            {
                win.WindowState = WindowState.Maximized;
            }
            else
            {
                win.WindowState = WindowState.Normal;
            }
        }

        private void ExecuteClose(object parameter)
        {
            Window win = parameter as Window;
            win.Close();
        }
        private void ExecuteMatrix (object parameter)
        {
            Grid grid = parameter as Grid;
            UIElement uIElement = new TextBlock();

            foreach (UIElement uiElement in grid.Children)
            {
                if (uiElement.GetType() == typeof(MatrixLabel))
                {
                    if (uiElement != null)
                    {
                        uIElement = uiElement;
                        break;
                    }
                }
            }

            if (uIElement.GetType() == typeof(MatrixLabel))
            {
                grid.Children.Remove(uIElement);
                CheckVisi = Visibility.Collapsed;
                return;
            }

            CheckVisi = Visibility.Visible;
            MatrixLabel ml = new MatrixLabel();
            grid.Children.Add(ml);
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
