using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PushNotification.DALSQLite;

using Xamarin.Forms;

namespace PushNotification
{
    public partial class App : Application
    {
        public static AppDatabase database;
        public App()
        {
            InitializeComponent();
           
            database = new AppDatabase();

            MainPage = new PushNotification.LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
