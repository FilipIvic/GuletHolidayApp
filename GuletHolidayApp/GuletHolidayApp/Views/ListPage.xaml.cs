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
        int yachtId = 0;
        string listYear = DateTime.Now.Year.ToString();
        UserDto user = new UserDto();
        public ListPage(UserDto user, string year)
        {
            
            InitializeComponent();

            yachtId = user.GetYachtId();
            //yachtId = 102759;
            listYear = year;
            this.user = user;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ReservationController reservationController = new ReservationController();
            ReservationResponseDto response = reservationController.GetReservations(yachtId, listYear);

            if (ShipConstants.OK.Equals(response.status))
            {
                listView.ItemsSource = response.reservations;
            }
            else
            {
                DisplayAlert(ShipConstants.ERROR, response.status, "OK");
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

        async private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("LOGOUT!", "Are you sure you want to logout?", "Yes", "No");
            if (answer == true)
                await Navigation.PushAsync(new Login());
        }

        async private void ToolbarItem_Clicked_2020(object sender, EventArgs e)
        {
            string year = "2020";
            bool answer = await DisplayAlert("LIST CHANGE!", "Are you sure you want to load 2020 list?", "Yes", "No");
            if (answer == true)
                await Navigation.PushAsync(new ListPage(user,year));
        }

        async private void ToolbarItem_Clicked_2021(object sender, EventArgs e)
        {
            string year = "2021";
            bool answer = await DisplayAlert("LIST CHANGE!", "Are you sure you want to load 2021 list?", "Yes", "No");
            if (answer == true)
                await Navigation.PushAsync(new ListPage(user, year));
        }

        async private void ToolbarItem_Clicked_2022(object sender, EventArgs e)
        {
            await DisplayAlert("WORK IN PROGRESS!", "Not implemented yet", "OK");
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }

       
    }

   
}