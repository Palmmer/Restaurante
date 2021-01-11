using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comun.Cache;
using Negocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Presentacion
{
    public partial class Principal : Form
    {
        CN_Productos objetoCN = new CN_Productos();
        private string folioPro = null;
        private bool EDITAR = false;

        public Principal()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de Cerrar Sesion?", "Advertencia",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }
        private void LoadUserData()
        {
            lbNombre.Text = CacheDeUsuario.Nombre+", "+CacheDeUsuario.Apellido;
            lbCargo.Text = CacheDeUsuario.Cargo;
            lbEmail.Text = CacheDeUsuario.Email;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            LoadUserData();
            MostrarProdctos();
        }
        private void MostrarProdctos()
        {

            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.MostrarProd();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtCantidad.Text== "" || txtHora.Text==""||txtTelefono.Text=="")
            {
                MessageBox.Show("FALTA LLENAR UN CAMPO!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (EDITAR == false)
                {


                    try
                    {
                        ////MessageBox.Show("Nombre: " + txtNombre.Text + "Fecha" + FechaPicker1.Text + "Hora:" + txtHora.Text + "Cantidad" + txtCantidad.Text + "Telefono" + txtTelefono.Text);
                        objetoCN.InsertarPRod(txtNombre.Text, Convert.ToDateTime(FechaPicker1.Text), Convert.ToDateTime(txtHora.Text), Convert.ToInt64(txtCantidad.Text), Convert.ToInt64(txtTelefono.Text));
                        MessageBox.Show("SE A INSERTADO CORRECTAMENTE!");
                        MostrarProdctos();
                        LimpiarFrom();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("NO SE LOGRO INSERTAR LOS DATOS CORRECTAMENTE DEBIDO A: NO SE INSERTARON DATOS ");
                    }
                }
            }

            //INsertar
            //if (EDITAR==false)
            //{


            //    try
            //    {
            //        ////MessageBox.Show("Nombre: " + txtNombre.Text + "Fecha" + FechaPicker1.Text + "Hora:" + txtHora.Text + "Cantidad" + txtCantidad.Text + "Telefono" + txtTelefono.Text);
            //        objetoCN.InsertarPRod(txtNombre.Text, Convert.ToDateTime(FechaPicker1.Text), Convert.ToDateTime(txtHora.Text), Convert.ToInt64(txtCantidad.Text), Convert.ToInt64(txtTelefono.Text));
            //        MessageBox.Show("SE A INSERTADO CORRECTAMENTE!");
            //        MostrarProdctos();
            //        LimpiarFrom();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("NO SE LOGRO INSERTAR LOS DATOS CORRECTAMENTE DEBIDO A: NO SE INSERTARON DATOS ");
            //    }
            //}
            //Editar
            if (EDITAR==true)
            {
                try
                {
                    objetoCN.EditarProd(txtNombre.Text, Convert.ToDateTime(FechaPicker1.Text), Convert.ToDateTime(txtHora.Text), Convert.ToInt64(txtCantidad.Text), Convert.ToInt64(txtTelefono.Text), folioPro);
                    MessageBox.Show("SE A EDITADO CORRECTAMENTE!");
                    MostrarProdctos();
                    LimpiarFrom();
                    EDITAR = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("NO SE LOGRO EDITAR LOS DATOS CORRECTAMENTE DEBIDO A: NO SE INSERTARON DATOS");
                }
                
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                EDITAR = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["NombreCliente"].Value.ToString();
                FechaPicker1.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
                txtHora.Text = dataGridView1.CurrentRow.Cells["Hora"].Value.ToString();
                txtCantidad.Text = dataGridView1.CurrentRow.Cells["CantidadPersonas"].Value.ToString();
                txtTelefono.Text = dataGridView1.CurrentRow.Cells["NoTelefono"].Value.ToString();
                folioPro = dataGridView1.CurrentRow.Cells["FOLIO"].Value.ToString();
            }
            else
                MessageBox.Show("Favor de seleccionar la fila a editar!");
        }
        // Limpia los txtbox
        private void LimpiarFrom()
        {
            txtNombre.Clear();
           
            txtHora.Clear();
            txtCantidad.Clear();
            txtTelefono.Clear();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                folioPro = dataGridView1.CurrentRow.Cells["FOLIO"].Value.ToString();
                objetoCN.EliminarPRod(folioPro);
                MessageBox.Show("Eliminado Correctamente ");
                MostrarProdctos();
            }
            else
                MessageBox.Show("Favor de seleccionar la fila a Eliminar!");
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloLetrasNombre(e);
        }

        private void txtHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloNumerosHora(e);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloNumeros(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloNumeros(e);
        }

        private void txtNombre_Validated(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "")
            {
                errorCamposVacios.SetError(txtNombre, "INGRESE EL NOMBRE DEL CLIENTE..");
                txtNombre.Focus();
            }
            else
                errorCamposVacios.Clear();

        }

        private void FechaPicker1_Validated(object sender, EventArgs e)
        {
            if (FechaPicker1.Text.Trim() == "")
            {
                errorCamposVacios.SetError(FechaPicker1, "INGRESE LA FECHA DE RESERVACION..");
                FechaPicker1.Focus();
            }
            else
                errorCamposVacios.Clear();
        }

        private void txtHora_Validated(object sender, EventArgs e)
        {
            if (txtHora.Text.Trim() == "")
            {
                errorCamposVacios.SetError(txtHora, "El Siguiente formato.."+"Hora"+":"+"Minuto");
                txtHora.Focus();
            }
            else
                errorCamposVacios.Clear();
        }

        private void txtCantidad_Validated(object sender, EventArgs e)
        {
            if (txtCantidad.Text.Trim() == "")
            {
                errorCamposVacios.SetError(txtCantidad, "INGRESE LA CANTIDAD DE PERSONAS..");
                txtCantidad.Focus();
            }
            else
                errorCamposVacios.Clear();
        }

        private void txtTelefono_Validated(object sender, EventArgs e)
        {
            if (txtTelefono.Text.Trim() == "")
            {
                errorCamposVacios.SetError(txtTelefono, "INGRESE EL NUMERO TELEFONICO..");
                txtTelefono.Focus();
            }
            else
                errorCamposVacios.Clear();
        }

        public void exportgridtopdf(DataGridView dgw,string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdfTable = new PdfPTable(dgw.Columns.Count);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

            foreach (DataGridViewColumn column in dgw.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText,text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240,240,240);
                pdfTable.AddCell(cell);
            }

            foreach (DataGridViewRow row in dgw.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }

            var savefiledialoge = new SaveFileDialog();
            savefiledialoge.FileName = filename;
            savefiledialoge.DefaultExt = " .pdf";
            if (savefiledialoge.ShowDialog()==DialogResult.OK)
            {
                using (FileStream stream = new FileStream (savefiledialoge.FileName,FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4,10f,10f,10f,0f);
                    PdfWriter.GetInstance(pdfdoc,stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdfTable);
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }

        private void Reporte_Click(object sender, EventArgs e)
        {
            exportgridtopdf(dataGridView1, "test");
        }
    }
}
