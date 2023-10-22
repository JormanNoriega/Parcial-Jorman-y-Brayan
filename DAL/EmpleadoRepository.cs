using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmpleadoRepository:Archivo
    {

        public EmpleadoRepository(string fileName) : base(fileName)
        {
        }

        public List<Empleado> ConsultarTodos()
        {
            var empleadoList = new List<Empleado>();
            try
            {
                StreamReader lector = new StreamReader(fileName);
                while (!lector.EndOfStream)
                {
                    empleadoList.Add(Map(lector.ReadLine()));
                }
                lector.Close();
                return empleadoList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Empleado BuscarId(int id)
        {
            var empleadoList = ConsultarTodos();
            foreach (var item in empleadoList)
            {
                if (item.idEmpleado == id)
                {
                    return item;
                }

            }
            return null;
        }

        private Empleado Map(string linea)
        {
            var e = new Empleado();
            e.idEmpleado = int.Parse(linea.Split(';')[0]);
            e.nombre = linea.Split(';')[1];
            e.salario = double.Parse(linea.Split(';')[2]);
            e.estado = linea.Split(';')[3];
            return e;
        }
    }
}
