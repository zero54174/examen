using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace examen
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

            dglab.AllowUserToAddRows = false;
        }

        public void limpiar()
        {

            txtCed.Text = string.Empty;
            txtcodigo.Text = "0";
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtSexo.Text= string.Empty;
            txtCargo.Text= string.Empty;
            cboProfesion.Text= string.Empty;
            txtCed.Focus();

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre, apellido, cargo, sexo, activo, cedula,puesto;
                string cuentasAC, valoresPA = "";
                double codigo;
                cedula = txtCed.Text;
                codigo = double.Parse(txtCod.Text);
                nombre = txtNombre.Text;
                apellido = txtApellido.Text;
                sexo = txtSexo.Text;
                cargo = txtCargo.Text;
                puesto = cboProfesion.Text;
                activo = cboEsta.Text;

                if ( codigo <= 0)
                {

                }
                else
                {
                    //cuentas = String.Format("{0}", cuen);
                    valoresPA = String.Format("{0}", codigo);
                }
                //intactivoOactivo
                string[] fila = new string[8];
                fila[0] = cedula;
                fila[1] = valoresPA;
                fila[2] = nombre;
                fila[3] = apellido;
                fila[4] = sexo;
                fila[5] = cargo;
                fila[6] = puesto;
                fila[7] = activo;

                if (cedula == "" || valoresPA == "" || nombre == "" || apellido == ""|| sexo == ""|| cargo == ""|| puesto == ""|| activo == "")
                {
                    //MessageBox.Show("caracter no valido");
                }
                else
                {
                    dglab.Rows.Add(fila);
                    limpiar();

                }
            }
            catch
            {
                // MessageBox.Show("los caracter no son validos");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int f;
            f = dglab.RowCount;
            for (int i = f - 1; i >= 0; i--)
            {
                dglab.Rows.RemoveAt(i);
            }
            txtCed.Focus();
        }

        private void btbuscar_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                foreach (DataGridViewRow row in dglab.Rows)
                {
                    
                    string tabla = Convert.ToString(row.Cells["Nombre"].Value);
                    if (this.txtbuscar.Text != tabla)
                    {
                        MessageBox.Show("usuario encontrado");

                        int fila = this.dglab.CurrentRow.Index;

                        this.dglab.CurrentCell = null;

                        this.dglab.Rows[fila].Visible = false;
                        //(dglab.DataSource as DataTable).DefaultView.RowFilter = string.Format("Nombre = '{0}'", txtbuscar.Text);
                        return;

                    }
                    else
                    {
                        MessageBox.Show("Favor digite un valor");
                        int f;
                        f = dglab.RowCount;
                        for (int i = f - 1; i >= 0; i--)
                        {
                            this.dglab.CurrentCell = null;

                            this.dglab.Rows[i].Visible = true;
                        }
                    }

                }
            }
            if (radioButton2.Checked)
            {
                if (txtbuscar.Text != "")
                {

                    foreach (DataGridViewRow row in dglab.Rows)
                    {

                        string tabla = Convert.ToString(row.Cells["codigo"].Value);

                        if (this.txtbuscar.Text != tabla)
                        {
                            MessageBox.Show("usuario encontrado");
                            int fila = this.dglab.CurrentRow.Index;

                            this.dglab.CurrentCell = null;

                            this.dglab.Rows[fila].Visible = false;
                            //(dglab.DataSource as DataTable).DefaultView.RowFilter = string.Format("codigo = '{0}'", txtbuscar.Text);
                            return;

                        }
                        else
                        {
                            MessageBox.Show("usuario no encontrado");

                        }

                    }
                }
                else
                {
                    MessageBox.Show("Favor digite un valor");
                    int f;
                    f = dglab.RowCount;
                    for (int i = f - 1; i >= 0; i--)
                    {
                        this.dglab.CurrentCell = null;

                        this.dglab.Rows[i].Visible = true;
                    }
                }

            }
            if (radioButton3.Checked)
            {
                if (txtbuscar.Text != "")
                {

                    foreach (DataGridViewRow row in dglab.Rows)
                    {

                        string tabla = Convert.ToString(row.Cells["intactivoOactivo"].Value);

                        if (this.txtbuscar.Text != tabla)
                        {
                            MessageBox.Show("usuario encontrado");
                            int fila = this.dglab.CurrentRow.Index;

                            this.dglab.CurrentCell = null;

                            this.dglab.Rows[fila].Visible = false;
                            //(dglab.DataSource as DataTable).DefaultView.RowFilter = string.Format("codigo = '{0}'", txtbuscar.Text);
                            return;

                        }
                        else
                        {
                            MessageBox.Show("Favor digite un valor");
                            int f;
                            f = dglab.RowCount;
                            for (int i = f - 1; i >= 0; i--)
                            {
                                this.dglab.CurrentCell = null;

                                this.dglab.Rows[i].Visible = true;
                            }
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Favor digite un valor");
                    int f;
                    f = dglab.RowCount;
                    for (int i = f - 1; i >= 0; i--)
                    {
                        this.dglab.CurrentCell = null;

                        this.dglab.Rows[i].Visible = true;
                    }
                }

            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string ac;
            int f;
            ac = cboEsta.Text;

            f = dglab.RowCount;
            for (int i = f - 1; i >= 0; i--)
            {
                this.dglab.CurrentCell = null;

                string[] fila = new string[8];
                fila[7] = ac;
                this.dglab.Rows[7].Visible = true;
            }
        }
    }
}
