using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TestLogicalData.Helpers;
using TestLogicalData.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TestLogicalData.ViewModels
{
    public class EnviarNotificacionViewModel: BaseViewModel
    {
        #region Attributes
        public ICommand btnNotificacion { get; private set; }
        private Notification _Message;
        private bool _isLoading;
        #endregion

        #region Constructor
        public EnviarNotificacionViewModel()
        {
            isLoading = false;
            Message = new Notification();
            btnNotificacion = new Command(EnviarNotificacion);
        }
        #endregion

        #region Methods
        public async void EnviarNotificacion()
        {
            try
            {
                
                if (Preferences.ContainsKey("TokenFirebase"))
                {
                    if (Message.mensaje != null )
                    {
                        if (!Message.mensaje.Trim().Equals(string.Empty))
                        {
                            isLoading = true;
                            await Task.Delay(1000);
                            PushMessageModel req = CrearEntidad();
                            var res = Utils.ConsultaHttpPost("https://fcm.googleapis.com/fcm/send", JsonConvert.SerializeObject(req));
                            if (res != null)
                            {
                                PushNotificationRes response = JsonConvert.DeserializeObject<PushNotificationRes>(res.Result);
                                if (response.success == 1)
                                {
                                    isLoading = false;
                                    await Application.Current.MainPage.DisplayAlert("Notificacion", "Se envio la notificacion correctamente", "Ok");
                                }
                            }
                        }
                        else
                        {
                            isLoading = false;
                            await Application.Current.MainPage.DisplayAlert("Error", "Mensaje vacío", "Ok");
                        }
                        
                    }
                    else
                    {
                        isLoading = false;
                        await Application.Current.MainPage.DisplayAlert("Error", "Mensaje vacío", "Ok");
                    }
                    
                }
                else
                {
                    isLoading = false;
                   await Application.Current.MainPage.DisplayAlert("Notificacion", "Dispositivo no registrado para el envio de notificaciones", "Ok");
                }
                
            }
            catch (Exception)
            {
                isLoading = false;
                await Application.Current.MainPage.DisplayAlert("Notificacion", "No se pudo enviar el PushNotification", "Ok");
            }
        }

        public PushMessageModel CrearEntidad()
        {
            PushMessageModel entidad = new PushMessageModel()
            {
                token = Preferences.Get("TokenFirebase", ""),
                notification = new Notification
                {
                    titulo = "LogicalData",
                    mensaje = Message.mensaje
                }
            };
            return entidad;
        }
        #endregion

        #region Properties
        public Notification Message
        {
            get { return this._Message; }
            set
            {
                this._Message = value;
                OnPropertyChanged("Message");
            }
        }

        public bool isLoading
        {
            get { return this._isLoading; }
            set
            {
                this._isLoading = value;
                OnPropertyChanged("isLoading");
            }
        }
        #endregion

    }
}
