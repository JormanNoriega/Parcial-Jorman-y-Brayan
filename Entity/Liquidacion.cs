using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Liquidacion
    {
        public int idLiquidacion {get; set;}
        public int año { get; set; }
        public int mes { get; set; }

        public Liquidacion()
        {
        }

        public Liquidacion(int idLiquidacion, int año, int mes)
        {
            this.idLiquidacion = idLiquidacion;
            this.año = año;
            this.mes = mes;
        }
        public override string ToString()
        {
            return $"{idLiquidacion};{año};{mes}";
        }
    }
}
