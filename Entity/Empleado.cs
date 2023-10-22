using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Empleado
    {
        public int idEmpleado {get; set;}
        public string nombre {get; set;}
        public double salario { get; set;}
        public string estado {get; set;}

        public Empleado()
        {
        }

        public Empleado(int idEmpleado, string nombre, double salario, string estado)
        {
            this.idEmpleado= idEmpleado;
            this.nombre = nombre;
            this.salario = salario;
            this.estado = estado;
        }

        public override string ToString()
        {
            return $"{idEmpleado};{nombre};{salario};{estado}";
        }
    }
}
