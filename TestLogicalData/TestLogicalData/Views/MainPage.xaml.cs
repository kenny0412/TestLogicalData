using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLogicalData.ViewModels;
using Xamarin.Forms;

namespace TestLogicalData
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
            NavigationPage.SetHasNavigationBar(this, false);
        }


    }
}
