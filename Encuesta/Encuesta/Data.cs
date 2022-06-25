using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Encuesta
{
    class Data : NotificationObject
    {
        private ObservableCollection<Encuesta> encuestas;

        public ObservableCollection<Encuesta> Encuestas
        {
            get 
            {
                return encuestas; 
            }
            set
            {
                if (encuestas == value)
                {
                    return;
                }
                encuestas = value;
                OnPropertyChanged();
            }
        }
        private Encuesta seleccionarEncuesta;
        public Encuesta SeleccionarEncuesta
        {
            get
            {
                return seleccionarEncuesta;
            }
            set
            {
                if (SeleccionarEncuesta == value)
                {
                    return;
                }
                SeleccionarEncuesta = value;
                OnPropertyChanged();
            }
        }

        public Data()
        {
            Encuestas = new ObservableCollection<Encuesta>();

            MessagingCenter.Subscribe<ContentPage, Encuesta>(this, Mensajes.NuevaEncuestaCompleta, (sender, args) => { Encuestas.Add(args); });
        }
    }
}
