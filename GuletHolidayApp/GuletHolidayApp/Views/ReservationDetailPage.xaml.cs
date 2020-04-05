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

                locationToPicker.IsVisible = false;
                locationFromPicker.IsVisible = false;
            }
            else if (reservation.reservationType == ShipConstants.ReservationTypeFree)
            {
                buttonCancellation.IsVisible = false;
            }
            else
            {
                buttonOption.IsVisible = false;
                buttonReservation.IsVisible = false;

                locationToPicker.IsVisible = false;
                locationFromPicker.IsVisible = false;
            }

            locationToPicker.ToString();

        }

        private async void ButtonOption_Clicked(object sender, EventArgs e)
        {
            buttonOption.IsVisible = false;
            activity.IsVisible = true;
            Device.BeginInvokeOnMainThread(async () =>
            {
                BookingController controller = new BookingController();
                InfoResponseDto response = controller.CreateOption(reservation.yachtId, reservation.periodFrom, reservation.periodTo);

                NextPage(response.status, ShipConstants.ReservationTypeOption, "Successful Option transaction");
                activity.IsVisible = false;
            });
        }

        private async void ButtonCancellation_Clicked(object sender, EventArgs e)
        {
            buttonCancellation.IsVisible = false;
            activity.IsVisible = true;
            Device.BeginInvokeOnMainThread(async () =>
            {
                string status = null;
                string text = null;
                string message = null;
                BookingController controller = new BookingController();

                if(ShipConstants.ReservationTypeOption == reservation.reservationType)
                {
                    OptionResponseDto response = controller.StornoOption(reservation.id, reservation.periodFrom, reservation.periodTo);
                    status = response.status;
                    text = "STORNO OPTION";
                    message = "Successful Option cancellation!";
                }
                else
                {
                    BookingResponseDto response = controller.StornoBooking(reservation.id, reservation.periodFrom, reservation.periodTo);
                    status = response.status;
                    text = "STORNO BOOKING";
                    message = "Successful Booking cancellation!";
                }

                NextPage(status, text, message);
                activity.IsVisible = false;
            });
        }

        private async void ButtonReservation_Clicked(object sender, EventArgs e)
        {
            buttonReservation.IsVisible = false;
            activity.IsVisible = true;
            Device.BeginInvokeOnMainThread(async () =>
            {
                BookingController controller = new BookingController();
                BookingResponseDto response = controller.CreateBooking(reservation.id, reservation.periodFrom, reservation.periodTo, reservation.reservationType);
                NextPage(response.status, ShipConstants.ReservationTypeReserved, "Successful Booking transaction");
                activity.IsVisible = true;
            });
        }
        
        private async void NextPage(string status, string text, string message)
        {
            if (ShipConstants.OK.Equals(status))
            {
                await DisplayAlert(text, message , "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(ShipConstants.ERROR, status, "OK");
            }
        }

    }
}