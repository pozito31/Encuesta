using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Encuesta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EncuestaVista : ContentPage
    {
        public EncuestaVista()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<ContentPage, Encuesta>(this, Mensajes.NuevaEncuestaCompleta, (sender, args) =>
            {
                PanelEncuesta.Children.Add(new Label()
                {
                    Text = args.ToString()
                });
            }

            );
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EncuestaDetalleVista());
        }
    }
}