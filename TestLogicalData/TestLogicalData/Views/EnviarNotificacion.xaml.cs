using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLogicalData.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestLogicalData.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnviarNotificacion : ContentPage
    {
        public EnviarNotificacion()
        {
            InitializeComponent();
            BindingContext = new EnviarNotificacionViewModel();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}