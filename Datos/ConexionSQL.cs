using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public abstract class ConexionSQL
    {
        private readonly string connectionString;
        public ConexionSQL()
        {
            connectionString = "Server=DESKTOP-9PP39F6;DataBase= RI1;Integrated Security=true ";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}
