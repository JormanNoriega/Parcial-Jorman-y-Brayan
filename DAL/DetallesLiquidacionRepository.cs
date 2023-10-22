using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DetallesLiquidacionRepository : Archivo
    {
        public DetallesLiquidacionRepository(string fileName) : base(fileName)
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

        

        private DetallesLiquidacion Map(string linea)
        {
            var d = new DetallesLiquidacion();
            d.idDetalle = int.Parse(linea.Split(';')[0]);
            d.idLiquidacion = new Liquidacion
            {
                idLiquidacion = int.Parse(linea.Split(';')[1]),
                año = int.Parse(linea.Split(';')[1]),
                mes = int.Parse(linea.Split(';')[1])
            };
            d.idEmpleado = new Empleado
            {
                idEmpleado = int.Parse(linea.Split(';')[2]),
                nombre = linea.Split(';')[2],
                salario = double.Parse(linea.Split(';')[2]),
                estado = linea.Split(';')[2]
            };
         
            return d;
        }


    }
}
