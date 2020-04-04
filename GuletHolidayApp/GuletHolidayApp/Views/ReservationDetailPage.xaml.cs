using GuletHolidayApp.Controller;
using GuletHolidayApp.Models;
using GuletHolidayApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuletHolidayApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationDetailPage : ContentPage
    {
        private ReservationDto reservation;
        public ReservationDetailPage(ReservationDto reservation)
        {
            if (reservation == null)
                throw new ArgumentException();

            this.reservation = reservation;

            BindingContext = reservation;


            InitializeComponent();


            if (locationFromPicker.Items.Count == 0)
            {
                foreach (LocationDto dto in ShipVariables.locations)
                {
                    locationFromPicker.Items.Add(dto.name.textHR);
                    locationToPicker.Items.Add(dto.name.textHR);
                }
            }


            if (reservation.reservationType == ShipConstants.ReservationTypeOption)
            {
                buttonOption.IsVisible = false;
                buttonReservation.IsVisible = false;
                locationToPicker.IsVisible = false;
                locationFromPicker.IsVisible = false;
            }
            else if (reservation.reservationType == ShipConstants.ReservationTypeFree)
            {
                buttonCancellation.IsVisible = false;
                buttonReservationAfterOption.IsVisible = false;

                /*foreach (LocationDto dto in ShipVariables.locations)
                {
                    locationFromPicker.Items.Add(dto.name.textHR);
                    locationToPicker.Items.Add(dto.name.textHR);
                }*/
            }
            else
            {
                buttonOption.IsVisible = false;
                buttonReservation.IsVisible = false;
                buttonReservationAfterOption.IsVisible = false;
                locationToPicker.IsVisible = false;
                locationFromPicker.IsVisible = false;
            }

            locationToPicker.ToString();

        }

        private async void ButtonOption_Clicked(object sender, EventArgs e)
        {
            CreateController controller = new CreateController();
            InfoResponseDto response = controller.GetInfo(reservation.yachtId, reservation.periodFrom, reservation.periodTo);
            
            if(ShipConstants.OK.Equals(response.status))
            {
                await DisplayAlert("OPTION", "Successful Option transaction", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("ERROR!", response.status, "OK");
            }

            
        }
    }
}