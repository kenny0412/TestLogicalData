using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using TestLogicalData.Models;
using TestLogicalData.Views;
using Xamarin.Forms;

namespace TestLogicalData.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Constructor
        public MainPageViewModel()
        {
            Usuario = new Command(Navegar);
            NotificacionFirebase = new Command(Notification);
        }
        #endregion

        #region Properties
        public ICommand Usuario { get; private set; }
        public ICommand NotificacionFirebase { get; private set; }
        #endregion

        #region Methods
        async void Navegar()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Views.Usuario());
        }
        async void Notification(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EnviarNotificacion());
        }
        #endregion

    }
}
