using System.Globalization;

namespace MauiAppHotelJTech.Views;

public partial class HospedagemContratada : ContentPage
{
    private readonly CultureInfo culturaBrasil = new("pt-BR");

    public HospedagemContratada()
        : this(1, 0, "Suite Standard - R$ 180,00", DateTime.Today, DateTime.Today.AddDays(1), 1, 180m, 180m)
    {
    }

    public HospedagemContratada(
        int adultos,
        int criancas,
        string quarto,
        DateTime checkin,
        DateTime checkout,
        int diarias,
        decimal valorDiaria,
        decimal total)
    {
        InitializeComponent();

        lblQuarto.Text = quarto;
        lblHospedes.Text = $"Hospedes: {adultos} adulto(s) e {criancas} crianca(s)";
        lblPeriodo.Text = $"Periodo: {checkin:dd/MM/yyyy} ate {checkout:dd/MM/yyyy}";
        lblDiarias.Text = $"Quantidade de diarias: {diarias}";
        lblValorDiaria.Text = $"Valor da diaria: {valorDiaria.ToString("C", culturaBrasil)}";
        lblTotal.Text = $"Total: {total.ToString("C", culturaBrasil)}";
    }

    private async void OnNovaConsultaClicked(object? sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}
