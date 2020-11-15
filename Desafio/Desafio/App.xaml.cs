using Desafio.Services;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Desafio.Views;

namespace Desafio
{
    public partial class App : Application
    {

        static Database database;
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "address.db1"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new Tabbed();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
