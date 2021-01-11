using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Datos;

namespace Negocio
{
    public class CN_Productos
    {
        private CD_Productos objetoCD = new CD_Productos();

        public DataTable MostrarProd()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsertarPRod(string nombre, DateTime Fecha, DateTime Hora, Int64 Cantidad, Int64 NoTele)
        {

            objetoCD.Insertar(nombre,Fecha, Convert.ToDateTime(Hora), Convert.ToInt64(Cantidad), Convert.ToInt64(NoTele));
        }

        public void EditarProd(string nombre, DateTime Fecha, DateTime Hora, Int64 Cantidad, Int64 NoTele, string folio)
        {
            objetoCD.Editar(nombre, Fecha, Convert.ToDateTime(Hora), Convert.ToInt64(Cantidad), Convert.ToInt64(NoTele), Convert.ToInt32(folio));
        }

        public void EliminarPRod(string folio)
        {

            objetoCD.Eliminar(Convert.ToInt32(folio));
        }

    }
}
