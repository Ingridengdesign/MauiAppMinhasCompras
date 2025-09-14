using MauiAppMinhasCompras.Helpers;
using System.Collections.ObjectModel;
using MauiAppMinhasCompras.Models;
using MauiAppMinhasCompras.Views;

namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {

        public static ObservableCollection<Produto> ListaProdutos { get; set; } = new ObservableCollection<Produto>();

        static SQLiteDatabaseHelper _db;
        public static SQLiteDatabaseHelper Db
        {
            get
            {
                if (_db == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3");

                    _db = new SQLiteDatabaseHelper(path);
                }

                return _db;
            }
            
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.ListaProduto());

            Routing.RegisterRoute(nameof(Relatorio), typeof(Relatorio));
        }
    }
}