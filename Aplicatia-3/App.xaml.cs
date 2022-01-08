using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Aplicatia_3.Data;
using System.IO;


namespace Aplicatia_3
{
    public partial class App : Application
    {
        static AppointmentListDatabase database;
        public static AppointmentListDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   AppointmentListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "AppointmentList.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new ListEntryPage());
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
