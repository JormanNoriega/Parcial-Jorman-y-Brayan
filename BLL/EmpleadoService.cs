using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmpleadoService
    {
        private string filename = "empleados.txt";
        EmpleadoRepository empleadoRepositoy;
        private List<Empleado> empleadoList;

        public EmpleadoService()
        {
            empleadoRepositoy = new EmpleadoRepository(filename);
            RefrescarLista();
        }
        void RefrescarLista()
        {
            empleadoList = empleadoRepositoy.ConsultarTodos();
        }

        public string Guardar(Empleado empleado)
        {
            if (empleado == null)
            {
                return "no se puede agregar empleados nulos o sin informacion";
            }
            var msg = empleadoRepositoy.Guardar(empleado.ToString());
            RefrescarLista();
            return msg;
        }
        public List<Empleado> ConsultarTodos()
        {
            return empleadoList;
        }

        public List<Empleado> ConsultarFiltrado(string filtro)
        {
            if (filtro == "")
            {
                return empleadoList;
            }
            List<Empleado> lista = new List<Empleado>();
            foreach (var item in empleadoList)
            {
                if (item.nombre.Contains(filtro) || item.nombre.StartsWith(filtro))
                {
                    lista.Add(item);
                }
            }
            return lista;
        }

        public bool EmpleadoExiste(int idEmpleado)
        {
            
            foreach (Empleado empleado in empleadoList)
            {
                if (empleado.idEmpleado == idEmpleado)
                {
                    return true; 
                }
            }
            return false;
        }

        public List<Empleado> ConsultarFiltradoEstado(string filtro)
        {
            if (string.IsNullOrEmpty(filtro))
            {
                return empleadoList;
            }
            List<Empleado> listaFiltrado = new List<Empleado>();
            foreach (var item in empleadoList)
            {
                if (item.estado.Equals(filtro, StringComparison.OrdinalIgnoreCase) || item.estado.StartsWith(filtro))
                {
                    listaFiltrado.Add(item);
                }
            }
            return listaFiltrado;
        }

    }
}
