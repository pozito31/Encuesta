using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Encuesta
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new EncuestaVista());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
