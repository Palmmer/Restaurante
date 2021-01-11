using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    class validar
    {
        public static void SoloLetrasNombre(KeyPressEventArgs v)
        {
            if (Char.IsLetter(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsSeparator(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsControl(v.KeyChar))
            {
                v.Handled = false;
            }
            else
            {
                v.Handled = true;
                MessageBox.Show("Favor de usar solo letras");
            }
        }

        public static void SoloNumeros(KeyPressEventArgs v)
        {
            if (Char.IsDigit(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsSeparator(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsControl(v.KeyChar))
            {
                v.Handled = false;
            }
            else
            {
                v.Handled = true;
                MessageBox.Show("Favor de usar solo numeros");
            }
        }

        //public static void SoloNumerosHora(KeyPressEventArgs v)
        //{
        //    if (Char.IsDigit(v.KeyChar))
        //    {
        //        v.Handled = false;
        //    }
        //    else if (Char.IsSeparator(v.KeyChar))
        //    {
        //        v.Handled = false;
        //    }
        //    else if (Char.IsControl(v.KeyChar))
        //    {
        //        v.Handled = false;
        //    }
        //    else if (v.KeyChar.ToString().Equals(":"))
        //    {
        //        v.Handled = false;
        //    }
        //    else
        //    {
        //        v.Handled = true;
        //        MessageBox.Show("Favor de usar el sigueinte formato 'horas:minutos'");
        //    }
        //}
        public static void SoloNumerosHora(KeyPressEventArgs v)
        {
            if (Char.IsDigit(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsSeparator(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsControl(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (v.KeyChar.ToString().Equals(":"))
            {
                v.Handled = false;
            }
            else
            {
                v.Handled = true;
                MessageBox.Show("Favor de usar el sigueinte formato 'horas:minutos'");
            }
        }

    }
}
