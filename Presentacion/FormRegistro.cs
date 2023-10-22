using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormRegistro : Form
    {
        EmpleadoService servicio = new EmpleadoService();
        public FormRegistro()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("El campo Nombre no puede estar vacío.");
                    return;
                }

                string nombre = txtNombre.Text;
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("El campo Nombre no puede estar vacío.");
                    return;
                }

                double salario = double.Parse(txtSalario.Text);
                if (string.IsNullOrWhiteSpace(txtSalario.Text))
                {
                    MessageBox.Show("El campo Nombre no puede estar vacío.");
                    return;
                }
                string estado = null;
                if (rbtnActivo.Checked || rbtnInactivo.Checked)
                {
                    estado = rbtnActivo.Checked ? "ACTIVO" : "INACTIVO";
                }
                else
                {
                    MessageBox.Show("Debes seleccionar un estado (ACTIVO o INACTIVO).");
                }
                // Verificar si ya existe un empleado con el mismo ID o nombre.
                if (servicio.EmpleadoExiste(id))
                {
                    MessageBox.Show("El empleado con el mismo ID ya existe y no se puede registrar nuevamente.");
                }
                else
                {
                    // Si no existe, entonces puedes guardar el empleado.
                    Guardar(new Empleado(id, nombre, salario, estado));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar el empleado: " + ex.Message);
            }
        }

        void Guardar(Empleado empleado)
        {
            var msg = servicio.Guardar(empleado);
            MessageBox.Show(msg);
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
