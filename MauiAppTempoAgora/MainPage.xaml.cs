using Java.Util.Concurrent;
using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Services;

namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        private async void Button_Clicked_Previsao(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(txt_cidade))
                {
                    Tempo? t = await DataService.GetPrevisao(txt_cidade.Text);

                    if (t != null) 
                    {
                        string dados_previsao = "";

                        dados_previsao = $"Latitude: {t.lat} \n" +
                                         $"longitude: {t.lon} \n" +
                                         $"Nascer do Sol: {t.sumset} \n" +
                                         $"Temp Máx: {t.temp_max}\n" +
                                         $"Tempo_Min? {t.temp_min}\n" +

                     lbl_res.Text = dados_previsao;

                        string mapa = $"https://embed.windy.com/embed.html?" +
                    $"type=map&location=coordinates&metricRain=default&metricTemp=default" +
                    $"&metricWind=default&zoom=5&overlay=wind&product=&level=surface&lat={t.lat.ToString().Replace(",", ".")}&lon={t.lon.ToString().Replace(",", ".")}";

                        wv_mapa.Source = mapa;

                        Debug.WriteLine(mapa);
                    }
                    else
                    {
                        lbl_res.Text = "Sem Dados de Previsão";
                    }
                }
                else
                {
                    lbl_res.Text = "Preencha a cidade.";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private async void Search_Clicked(object sender, EventArgs e)
        {
            try
            {
                GeolocationRequest request = new GeolocationRequest
               (
                    GeolocationAccuracy.Medium,
                    TimeSpan.FromSeconds(10)
               );

                Location? local = await Geolocation.Default.GetLocationAsync(request);



            }
            }
        }
    }

}
