using System.Windows.Input;
using System.Windows;
using mvvmTest2.Models;
using mvvmTest2.CustomClasses;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Threading.Tasks;

namespace mvvmTest2.ViewModels
{
    class DataGridViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region Constructors
        public DataGridViewModel()
        {
            InsertCommand = new RelayCommand(InsertToDb, CanExecuteTrue);
            FillCommand = new RelayCommand(ExecuteFill, CanExecuteTrue);
            ClearCommand = new RelayCommand(ExecuteClear, CanExecuteTrue);
            SelectCommand = new RelayCommand(ExecuteSelect, CanExecuteTrue);

            Model = new ModelExample();
            SelectFirstTb = true;
        }
        #endregion Constructors


        #region Fields
        private bool _selectFirstTb;
        private DataRowView _selectedItem;
        private Visibility _visi;
        private string _selectedName;
        #endregion Fields


        #region Properties
        public ModelExample Model { get; set; }


        public bool SelectFirstTb
        {
            get => _selectFirstTb;
            set
            {
                Set(ref _selectFirstTb, value);
                ResetFocus();
            }
        }


        public DataRowView SelectedItem
        {
            get => _selectedItem as DataRowView;
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;

                    if (_selectedItem != null)
                    {
                        SelectedName = $"{_selectedItem["First"]} {_selectedItem["Last"]}";
                    }

                    OnPropertyChanged("SelectedItem");
                }
            }
        }


        public Visibility Visi
        {
            get => _visi;
            set
            {
                if (_visi != value)
                {
                    _visi = value;
                    OnPropertyChanged("Visi");
                }
            }
        }


        public string SelectedName
        {
            get => _selectedName;
            set
            {
                if (_selectedName != value)
                {
                    _selectedName = value;
                    OnPropertyChanged("SelectedName");
                }
            }
        }
        #endregion Properties


        #region Commands
        public ICommand InsertCommand { get; set; }
        public ICommand FillCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand SelectCommand { get; set; }
        #endregion Commands


        #region ExecuteMethods
        private void InsertToDb(object parameter)
        {
            SqliteAccess.WriteSql("insert into ttable (first, last) values (@param0, @param1);",
                new string[] { Model.First, Model.Last });

            Model.FillFromSQL();

            Model.First = "";
            Model.Last = "";

            SelectFirstTb = true;
        }


        private void ExecuteSelect(object parameter)
        {
            Model.DTable2.Rows.Clear();
            foreach (DataRowView row in parameter as IList)
            {
                var r = Model.DTable2.NewRow();
                r["ID"] = row["ID"].ToString();
                r["First"] = row["First"].ToString();
                r["Last"] = row["Last"].ToString();
                Model.DTable2.Rows.Add(r);
            }
        }


        private void ExecuteFill(object parameter)
        {
            Model.FillFromSQL();
            Model.DTable2 = Model.DTable.Copy();
            Model.DTable2.Clear();
        }


        private void ExecuteClear(object parameter) => Model.DTable.Clear();
        #endregion ExecuteMethods


        #region Methods
        private async Task ResetFocus()
        {
            await Task.Delay(50);
            SelectFirstTb = false;
        }
        #endregion Methods


        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged2;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged2?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChanged Members
    }
}
