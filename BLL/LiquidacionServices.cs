using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LiquidacionServices
    {
        private string filename = "liquidacion.txt";
        LiquidacionesRepositoy liquidacionesRepositoy;
        private List<Liquidacion> liquidacionesList;

        LiquidacionServices()
        {
            liquidacionesRepositoy= new LiquidacionesRepositoy(filename);
            RefrescarLista();
        }

        void RefrescarLista()
        {
            liquidacionesList = liquidacionesRepositoy.ConsultarTodos();
        }

        public string Guardar(Liquidacion liquidacion)
        {
            if (liquidacion == null)
            {
                return "no se puede agregar empleados nulos o sin informacion";
            }
            var msg = liquidacionesRepositoy.Guardar(liquidacion.ToString());
            RefrescarLista();
            return msg;
        }

        public List<Liquidacion> ConsultarTodos()
        {
            return liquidacionesList;
        }




    }
}
