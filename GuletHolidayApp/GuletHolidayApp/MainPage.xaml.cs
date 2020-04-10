using GuletHolidayApp.Controller;
using GuletHolidayApp.DAO;
using GuletHolidayApp.Models;
using GuletHolidayApp.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace GuletHolidayApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Exit(null,null);
        }

        internal async void Exit(object sender, EventArgs e)
        {
            await DisplayAlert(ShipConstants.ERROR, "NO INTERNET CONNECTION!", "OK");
            System.Environment.Exit(0);
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
