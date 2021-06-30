using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TestLogicalData.Data.Repository;
using TestLogicalData.Models;
using Xamarin.Forms;

namespace TestLogicalData.ViewModels
{
    public class UsuarioViewModel: BaseViewModel
    {

        #region Attributes
        public ICommand GuardarUsuario { get; private set; }
        RepositoryUsuario repo;
        private Usuario _Usuario;
        private string _Nombre;
        private string _Edad;
        private bool _isData;
        private bool _isLoading;
        #endregion

        #region Constructor
        public UsuarioViewModel()
        {
            isLoading = false;
            isData = false;
            repo = new RepositoryUsuario();
            Usuario = new Usuario();
            GuardarUsuario = new Command(InsertarUsuario);
        }
        #endregion

        #region Methods
        public async void InsertarUsuario()
        {
            try
            {
                if (!repo.isDBExist())
                {
                    isLoading = true;
                    repo.CrearBD();
                    isLoading = false;
                }
                if (Usuario.Nombre != null && Usuario.Nombre != null )
                {
                    if (!Usuario.Nombre.Trim().Equals(string.Empty) && !Usuario.Nombre.Trim().Equals(string.Empty))
                    {
                        repo.EliminarUsuarios();
                        repo.InsertarUsuario(Usuario.Nombre, Usuario.Edad);
                        await Application.Current.MainPage.DisplayAlert("Formulario", "Para visualizar la información reinicie la aplicación", "Ok");
                    }
                    
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Nombre o edad vacios, valide los campos", "Ok");
                }
               
            }
            catch (Exception)
            {
                isLoading = false;
                await Application.Current.MainPage.DisplayAlert("Formulario", "No se logro guardar el usuario", "Ok");
            }
        }

        public void VModelActive()
        {
            if (repo.isDBExist())
            {
                isData = true;
                var usuarios = repo.GetUsuarios();
                if (usuarios != null && usuarios.Count > 0)
                {
                    Nombre = usuarios.LastOrDefault().Nombre;
                    Edad = usuarios.LastOrDefault().Edad;
                }
            }
        }
        #endregion

        #region Properties

        public Usuario Usuario
        {
            get { return _Usuario; }
            set
            {
                _Usuario = value;
                OnPropertyChanged("Usuario");
            }
        }
        public string Nombre
        {
            get { return this._Nombre; }
            set
            {
                this._Nombre = value;
                OnPropertyChanged("Nombre");
            }
        }
        public string Edad
        {
            get { return this._Edad; }
            set
            {
                this._Edad = value;
                OnPropertyChanged("Edad");
            }
        }

        public bool isData
        {
            get { return this._isData; }
            set
            {
                this._isData = value;
                OnPropertyChanged("isData");
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
