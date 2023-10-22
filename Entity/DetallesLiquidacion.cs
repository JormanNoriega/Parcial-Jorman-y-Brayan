using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DetallesLiquidacion
    {
        public int idDetalle { get; set; }
        public Liquidacion idLiquidacion { get; set; }
        public Empleado idEmpleado { get; set; }

        public DetallesLiquidacion()
        {
        }

        public DetallesLiquidacion(int idDetalle, Liquidacion idLiquidacion, Empleado empleado)
        {
            this.idDetalle = idDetalle;
            this.idLiquidacion = idLiquidacion;
            this.idEmpleado = empleado;
        }

        public override string ToString()
        {
            return $"{idDetalle};{idLiquidacion.idLiquidacion};{idLiquidacion.año};{idLiquidacion.mes};{idEmpleado.nombre};{idEmpleado.salario};{salud()};{pension()};{auxiolioTransporte()};{salarioDevengado()}";
        }

        public double pension()
        {
            return idEmpleado.salario * 0.04;
        }
        public double salud()
        {
            return idEmpleado.salario * 0.04;
        }
        public double auxiolioTransporte()
        {
            double auxTransporte = 0;
            if (idEmpleado.salario < 1160000 * 2)//salario minimo (Usted no especifica el salario minimo)
            {
                auxTransporte = 106454;
            }
            return auxTransporte;
        }

        public double salarioDevengado()
        {
            double devengado = idEmpleado.salario - salud() - pension() + auxiolioTransporte();
            return devengado;
        }




    }
}
