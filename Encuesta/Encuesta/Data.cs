using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;

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
        public ICommand NuevaEncuestaCommand
        {
            get;
            set;

        }
        public Data()
        {
            NuevaEncuestaCommand = new Command(NuevaEncuestaCommandExecute);
            Encuestas = new ObservableCollection<Encuesta>();

            MessagingCenter.Subscribe<ContentPage, Encuesta>(this, Mensajes.NuevaEncuestaCompleta, (sender, args) => { Encuestas.Add(args); });
        }

        private void NuevaEncuestaCommandExecute()
        {
            MessagingCenter.Send(this, Mensajes.NuevaEncuesta);
        }
    }
}
