using ComprasApp.Helpers;
using System.IO;

namespace ComprasApp
{
    public partial class App : Application
    {

        static SQLiteDatabaseHelper database;

        public static SQLiteDatabaseHelper Database
        {
            get
            {
                if (database == null)
                {
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "arquivo.db3");
                    database = new SQLiteDatabaseHelper(path);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture= new System.Globalization.CultureInfo("pt-BR");

            MainPage = new AppShell();
        }


    }


}
