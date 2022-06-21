using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Encuesta
{
    public class Encuesta
    {
        public string Nombre { get; set; }
        public string FechaNacimiento { get; set; }
        public string EquipoFavorito { get; set; }
        public override string ToString()
        {
            return $"{Nombre} | {FechaNacimiento} | {EquipoFavorito}";
        }
    }
    public class Mensajes
    {
        public const string NuevaEncuestaCompleta = "Nueva Encuesta Completa";
    }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EncuestaDetalleVista : ContentPage
    {
        private readonly string[] equipos =
        {
            "Real Madrid",
            "Liverpool",
            "Barcelona",
            "Juventus",
            "Machester City",
            "Bayern Munich",
            "Inter Milan",
            "Atletico de Madrid"
        };
        public EncuestaDetalleVista()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var EquipoFavorito = await DisplayActionSheet(ClaseNombres.TitulosEquiposFavoritos, null, null, equipos); 
            if (!string.IsNullOrWhiteSpace(EquipoFavorito))
            {
                EquipoFavoritoLabel.Text = EquipoFavorito;
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            //Revisión de datos completos 
            if (string.IsNullOrWhiteSpace(NombreEntry.Text) || string.IsNullOrWhiteSpace(EquipoFavoritoLabel.Text))
            {
                return;
            }

            //Creación del nuevo objeto tipo Encuesta
            var nuevaEncuesta = new Encuesta()
            {
                Nombre = NombreEntry.Text,
                FechaNacimiento = Convert.ToString(nacimientoPicker.Date),
                EquipoFavorito = EquipoFavoritoLabel.Text
            };

            MessagingCenter.Send((ContentPage)this, Mensajes.NuevaEncuestaCompleta, nuevaEncuesta);

            await Navigation.PopAsync();
        }
    }
}