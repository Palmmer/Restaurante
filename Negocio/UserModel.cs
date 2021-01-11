using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Comun.Cache;

namespace Negocio
{
    public class UserModel
    {
        UserDato userDato = new UserDato();
        public bool LoginUser(string user, string pass)
        {
            return userDato.Login(user,pass);
        }
        //public bool EditarContraseña(int user, string pass)
        //{
        //    if (user == CacheDeUsuario.IdUser)
        //    {
                
        //    }
        //    return true;
        //}
    }
}
