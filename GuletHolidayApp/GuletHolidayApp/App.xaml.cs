using GuletHolidayApp.Controller;
using GuletHolidayApp.DAO;
using GuletHolidayApp.Models;
using GuletHolidayApp.Utility;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuletHolidayApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.Login())
            {
                BarBackgroundColor = Color.FromHex("#7029AF"),
                BarTextColor = Color.White
            };
        }

        protected  override void OnStart()
        {
            NauSysApi api = new NauSysApi();
            LocationsResponseDto response = api.Locations();
            ShipVariables.locations = response.locations;


        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
