using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class CD_Productos
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void Insertar(string nombre, DateTime Fecha, DateTime Hora, Int64 Cantidad, Int64 NoTele)
        {
            //PROCEDIMNIENTO

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsetarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@fecha", Fecha);
            comando.Parameters.AddWithValue("@hora", Hora);
            comando.Parameters.AddWithValue("@cantidad", Cantidad);
            comando.Parameters.AddWithValue("@Notele", NoTele);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();

        }

        public void Editar(string nombre, DateTime Fecha, DateTime Hora, Int64 Cantidad, Int64 NoTele, int folio)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@fecha", Fecha);
            comando.Parameters.AddWithValue("@hora", Hora);
            comando.Parameters.AddWithValue("@cantidad", Cantidad);
            comando.Parameters.AddWithValue("@Notele", NoTele);
            comando.Parameters.AddWithValue("@folio", folio);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public void Eliminar(int folio)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@foliopro", folio);

            _ = comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

    }
}
