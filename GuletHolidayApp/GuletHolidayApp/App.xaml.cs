using GuletHolidayApp.Controller;
using GuletHolidayApp.DAO;
using GuletHolidayApp.Models;
using GuletHolidayApp.Utility;
using System;
using System.Collections.Generic;
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
            try
            {
                List<PeriodPriceDto> PeriodPrice = new List<PeriodPriceDto>();
                ShipVariables.PeriodPrice = PeriodPrice;

                NauSysApi api = new NauSysApi();
                LocationsResponseDto response = api.Locations();
                ShipVariables.locations = response.locations;
            }
            catch (Exception e)
            {
                MainPage = new NavigationPage(new MainPage());
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
