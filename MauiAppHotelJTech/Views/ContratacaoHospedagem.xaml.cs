namespace MauiAppHotelJTech.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    private readonly Dictionary<string, decimal> quartos = new()
    {
        { "Suite Standard - R$ 180,00", 180m },
        { "Suite Luxo - R$ 260,00", 260m },
        { "Suite Familia - R$ 320,00", 320m }
    };

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        pckQuarto.ItemsSource = quartos.Keys.ToList();
        pckQuarto.SelectedIndex = 0;
        dtpckCheckin.MinimumDate = DateTime.Today;
        dtpckCheckin.Date = DateTime.Today;
        dtpckCheckout.MinimumDate = DateTime.Today.AddDays(1);
        dtpckCheckout.Date = DateTime.Today.AddDays(1);
    }

    private async void OnCalcularHospedagemClicked(object? sender, EventArgs e)
    {
        DateTime checkin = dtpckCheckin.Date.GetValueOrDefault(DateTime.Today);
        DateTime checkout = dtpckCheckout.Date.GetValueOrDefault(DateTime.Today.AddDays(1));

        if (checkout <= checkin)
        {
            await DisplayAlertAsync("Periodo invalido", "A data de check-out deve ser posterior ao check-in.", "OK");
            return;
        }

        if (pckQuarto.SelectedItem is not string quartoSelecionado)
        {
            await DisplayAlertAsync("Acomodacao", "Selecione uma suite para continuar.", "OK");
            return;
        }

        int adultos = Convert.ToInt32(stpAdultos.Value);
        int criancas = Convert.ToInt32(stpCriancas.Value);
        int diarias = (checkout - checkin).Days;
        decimal valorDiaria = quartos[quartoSelecionado];
        decimal adicionalCriancas = criancas * 45m;
        decimal total = (valorDiaria + adicionalCriancas) * diarias;

        await Navigation.PushAsync(new HospedagemContratada(
            adultos,
            criancas,
            quartoSelecionado,
            checkin,
            checkout,
            diarias,
            valorDiaria,
            total));
    }
}
