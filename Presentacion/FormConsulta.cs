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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Presentacion
{
    public partial class FormConsulta : Form
    {
        EmpleadoService servicio = new EmpleadoService();
        public FormConsulta()
        {
            InitializeComponent();
            string[] estados = { "ACTIVO", "INACTIVO" };
            foreach (string estado in estados)
            {
                cboxEstado.Items.Add(estado);
            }
        }


        private void FormConsulta_Load(object sender, EventArgs e)
        {
            ConsultarEstablecimientos();
        }

        private void ConsultarEstablecimientos()
        {
            dgvConsulta.DataSource = servicio.ConsultarTodos();
        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            CargarEstablecimientosFiltrado(txtConsulta.Text);
        }
        private void CargarEstablecimientosFiltrado(string filtro)
        {
            dgvConsulta.DataSource = servicio.ConsultarFiltrado(filtro);
        }

        private void cboxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtro = cboxEstado.SelectedItem.ToString();
            List<Empleado> empleadosFiltrados = servicio.ConsultarFiltradoEstado(filtro);
            dgvConsulta.DataSource = empleadosFiltrados;
            //dgvConsulta.DataSource = servicio.ConsultarFiltradoEstado(cboxEstado.SelectedItem.ToString());
        }
    }
}
