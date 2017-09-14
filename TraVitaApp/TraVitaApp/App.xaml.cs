using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TraVitaApp
{
    public partial class App : Application
    {
        static SQLHelper database;
        public App()
        {
            InitializeComponent();

            MainPage = new TraVitaApp.HomePage();
            //MainPage = new NavigationPage(new HomePage());
            var navPage = new NavigationPage(new HomePage());
            Application.Current.MainPage = navPage;
        }
        public static SQLHelper Database
        {
            get
            {
                if (database == null)
                {
                    database = new SQLHelper();
                }
                return database;
            }
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
