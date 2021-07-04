using System.Windows;
using mvvmTest2.CustomClasses;

namespace mvvmTest2
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SqliteAccess.CreateIfNotExist("testdb.db");
            MainWindow window = new MainWindow();
            window.InitializeComponent();
            window.Show();
        }
    }
}
