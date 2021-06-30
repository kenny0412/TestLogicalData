using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestLogicalData.Models
{
    [Table("USUARIOS")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
    }
}
