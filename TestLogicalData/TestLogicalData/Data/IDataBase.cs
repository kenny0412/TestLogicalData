using System;
using System.Collections.Generic;
using System.Text;

namespace TestLogicalData.Data
{
    public interface IDataBase
    {
        SQLite.SQLiteConnection GetConnection();
    }
}
