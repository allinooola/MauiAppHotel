namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesApp;
	public ContratacaoHospedagem()
	{
        InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkout.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        DateTime checkin = dtpck_checkin.Date ?? DateTime.Now;
        dtpck_checkout.MinimumDate = checkin.AddDays(1);
        dtpck_checkout.MaximumDate = checkin.AddMonths(6);
    }
    private async void BtnSobre_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(page: new HospedagemContratada());
        } catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {

    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_checkin = elemento.Date ?? DateTime.Now;

        dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
        dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }
}