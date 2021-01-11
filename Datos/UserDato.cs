using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Comun.Cache;

namespace Datos
{
   public class UserDato : ConexionSQL
    {
       public bool Login(string user, string pass)
       {
           using (var connection = GetConnection())
           {
               connection.Open();
               using (var comand = new SqlCommand())
               {
                   comand.Connection = connection;
                   comand.CommandText = "select * from Users where LoginName = @user and Password=  @pass";
                   comand.Parameters.AddWithValue("@user", user);
                   comand.Parameters.AddWithValue("@pass", pass);
                   //comand.Parameters.AddWithValue("@id", CacheDeUsuario.IdUser);
                   comand.CommandType = CommandType.Text;
                   SqlDataReader reader = comand.ExecuteReader();
                   if (reader.HasRows)
                   {
                       while (reader.Read())
                       {
                           CacheDeUsuario.IdUser = reader.GetInt32(0);
                           CacheDeUsuario.Nombre = reader.GetString(3);
                           CacheDeUsuario.Apellido = reader.GetString(4);
                           CacheDeUsuario.Cargo = reader.GetString(5);
                           CacheDeUsuario.Email= reader.GetString(6);
                       }
                       return true;
                   }
                   else
                       return false;

               }

           }
       }
    }
}
