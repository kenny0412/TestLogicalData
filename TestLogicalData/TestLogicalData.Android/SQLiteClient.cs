
using SQLite;
using System;
using System.IO;
using TestLogicalData.Data;
using TestLogicalData.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteClient))]
namespace TestLogicalData.Droid
{
    public class SQLiteClient : IDataBase
    {
        public SQLiteConnection GetConnection()
        {
            String bbddfile = "LogicalData.db3";
            String rutadocumentos = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            String path = Path.Combine(rutadocumentos, bbddfile);
            SQLiteConnection cn = new SQLiteConnection(path);
            return cn;
        }
    }
}