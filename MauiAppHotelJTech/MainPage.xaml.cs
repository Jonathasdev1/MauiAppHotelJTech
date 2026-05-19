using MauiAppHotelJTech.Views;

namespace MauiAppHotelJTech
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCalcularDiariaClicked(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContratacaoHospedagem());
        }
    }
}
