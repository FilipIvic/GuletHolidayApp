using GuletHolidayApp.Controller;
using GuletHolidayApp.Models;
using GuletHolidayApp.Utility;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuletHolidayApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {

        public ListPage(UserDto user)
        {
            
            InitializeComponent();


            ReservationController reservationController = new ReservationController();
            ReservationResponseDto response = reservationController.GetReservations(user.GetYachtId(), "2020");
            if(ShipConstants.OK.Equals(response.status))
            {
                listView.ItemsSource = response.reservations;
            }else
            {
                DisplayAlert("Error!", response.status, "OK");
            }
        }

        async private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            ReservationDto dto = e.SelectedItem as ReservationDto;
            await Navigation.PushAsync(new ReservationDetailPage(dto));
            listView.SelectedItem = null;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        async private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("LOGOUT!", "Are you sure you want to logout?", "Yes", "No");
            if (answer == true)
                await Navigation.PushAsync(new Login());
        }
    }

   
}