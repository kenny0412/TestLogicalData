using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestLogicalData.Models;
using Xamarin.Forms;

namespace TestLogicalData.Data.Repository
{
    public class RepositoryUsuario
    {
        #region Atributtes
        public SQLiteConnection connection { get; set; }
        #endregion

        #region Constructor
        public RepositoryUsuario()
        {
            connection = DependencyService.Get<IDataBase>().GetConnection();
        }
        #endregion

        #region Methods
        public void CrearBD()
        {
            connection.CreateTable<Usuario>();
        }

        public bool isDBExist()
        {
            const string cmdText = "SELECT name FROM sqlite_master WHERE type='table' AND name='USUARIOS'";
            var cmd = connection.CreateCommand(cmdText, typeof(Usuario).Name);
            return cmd.ExecuteScalar<string>() != null;
        }

        public void EliminarBD()
        {
            connection.DropTable<Usuario>();
        }

        public List<Usuario> GetUsuarios()
        {
            var consulta = from datos in connection.Table<Usuario>()
                           select datos;
            return consulta.ToList();
        }
        public Usuario BuscarUsuario(int num)
        {
            var consulta = from datos in connection.Table<Usuario>()
                           where datos.IdUsuario == num
                           select datos;
            return consulta.FirstOrDefault();   
        }
        public void InsertarUsuario( string nombre, string edad)
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = nombre;
            usuario.Edad = edad;
            connection.Insert(usuario);
        }

        public void ModificarUsuario(int idUsuario, string nombre, string edad)
        {
            Usuario usuario = BuscarUsuario(idUsuario);
            usuario.Nombre = nombre;
            usuario.Edad = edad;
            connection.Update(usuario);
        }
        public void EliminarUsuario(int idUsuario)
        {
            Usuario usuario = BuscarUsuario(idUsuario);
            connection.Delete<Usuario>(usuario);
        }

        public void EliminarUsuarios()
        {
            connection.DeleteAll<Usuario>();
        }
        #endregion



    }
}
