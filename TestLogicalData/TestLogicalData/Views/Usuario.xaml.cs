using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLogicalData.Data.Repository;
using TestLogicalData.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestLogicalData.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Usuario : ContentPage
    {
        UsuarioViewModel usuarioVM;
        public Usuario()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            usuarioVM = new UsuarioViewModel();
            BindingContext = usuarioVM;
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            usuarioVM.VModelActive();
        }

    }
}