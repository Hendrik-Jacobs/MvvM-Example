using System.ComponentModel;
namespace mvvmTest2.ViewModels
{
    class MatrixViewModel : INotifyPropertyChanged
    {
        private string _matrixText;
        public string MatrixText
        {
            get => _matrixText;
            set
            {
                if (_matrixText != value)
                {
                    _matrixText = value;
                    OnPropertyChanged("MatrixText");
                }
            }
        }


        private double _labelWidth;
        public double LabelWidth
        {
            get => _labelWidth;
            set
            {
                if (_labelWidth != value)
                {
                    _labelWidth = value;
                    OnPropertyChanged("LabelWidth");
                }
            }
        }


        public int MatrixTextLength
        {
            get => _matrixText.Length;
        }


        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChanged Members
    }
}
