using GuletHolidayApp.Controller;
using GuletHolidayApp.Models;
using GuletHolidayApp.Utility;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuletHolidayApp.Views
{
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

            usernameEntry.Text = Settings.LastUsedUsername;
            passwordEntry.Text = Settings.LastUsedPassword;

            if (string.Empty.Equals(usernameEntry.Text))
                rememberMe.IsChecked = false;
            else
                rememberMe.IsChecked = true;
        }

        async void OnLogin(object sender, EventArgs e)
        {
            activity.IsVisible = true;

            Device.BeginInvokeOnMainThread(async () =>
            {
                UserController controller = new UserController();
                UserResponseDto response = controller.GetUser(usernameEntry.Text, passwordEntry.Text);

                if (ShipConstants.NOK.Equals(response.status))
                {
                    await DisplayAlert(ShipConstants.ERROR, response.message, "OK");
                    usernameEntry.Text = "";
                    passwordEntry.Text = "";
                }
                else
                {
                    if (rememberMe.IsChecked)
                    {
                        Settings.LastUsedUsername = usernameEntry.Text;
                        Settings.LastUsedPassword = passwordEntry.Text;
                    }
                    else
                    {
                        Settings.LastUsedUsername = string.Empty;
                        Settings.LastUsedPassword = string.Empty;
                    }
                    await Navigation.PushAsync(new ListPage(response.user, DateTime.Now.Year.ToString()));
                }
                activity.IsVisible = false;
            });
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}