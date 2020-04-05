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
        public  MainPage()
        {
            /*
            InitializeComponent();
            
            Console.WriteLine("Hello World!");

            UserController controller = new UserController();
            UserResponseDto response = controller.GetUser(3);
            if(ShipConstants.NOK.Equals(response.status))
            {
                DisplayAlert("Error!", response.message, "OK");
            }
            else
            {
                UserDto user = response.user;
                id.Text = user.GetId().ToString();
                username.Text = user.GetUsername();
                password.Text = user.GetPassword();
                yachtId.Text = user.GetYachtId().ToString();
                yachtName.Text = user.GetYachtName();
                firstName.Text = user.GetFirstName();
                lastName.Text = user.GetLastName();
            }
            */
        }

        /*
        async void OnNext(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new Views.Login());
        }
        */
    }
}
