using mvvmTest2.CustomClasses;
using System.ComponentModel;
using System.Data;

namespace mvvmTest2.Models
{
    public class ModelExample : INotifyPropertyChanged
    {
        #region Constructors
        public ModelExample()
        {
            First = "Hello";
            Last = "World";
            DTable = new DataTable();
            DTable2 = new DataTable();
        }
        #endregion Constructors


        #region Fields
        private string _first;
        private string _last;
        private DataTable _dTable;
        private DataTable _dTable2;
        #endregion Fields


        #region Properties
        public string First
        {
            get => _first;
            set
            {
                if (_first != value)
                {
                    _first = value;
                    OnPropertyChanged("First");
                }
            }
        }


        public string Last
        {
            get => _last;
            set
            {
                if (_last != value)
                {
                    _last = value;
                    OnPropertyChanged("Last");
                }
            }
        }


        public DataTable DTable
        {
            get => _dTable;
            set
            {
                if (value != _dTable)
                {
                    _dTable = value;
                    OnPropertyChanged("DTable");
                }
            }
        }


        public DataTable DTable2
        {
            get => _dTable2;
            set
            {
                if (value != _dTable2)
                {
                    _dTable2 = value;
                    OnPropertyChanged("DTable2");
                }
            }
        }
        #endregion Properties


        #region Methods
        public void FillFromSQL(string query = "select * from ttable;")
        {
            DTable = SqliteAccess.ExecuteReadQuery(query);
            OnPropertyChanged("DTable");
        }
        #endregion Methods


        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChanged Members
    }
}
