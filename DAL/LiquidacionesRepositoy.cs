using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LiquidacionesRepositoy : Archivo
    {
        public LiquidacionesRepositoy(string fileName) : base(fileName)
        {
        }

        public List<Liquidacion> ConsultarTodos()
        {
            var liquidacionList = new List<Liquidacion>();
            try
            {
                StreamReader lector = new StreamReader(fileName);
                while (!lector.EndOfStream)
                {
                    liquidacionList.Add(Map(lector.ReadLine()));
                }
                lector.Close();
                return liquidacionList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Liquidacion BuscarId(int id)
        {
            var liquidacionList = ConsultarTodos();
            foreach (var item in liquidacionList)
            {
                if (item.idLiquidacion == id)
                {
                    return item;
                }
            }
            return null;
        }

        private Liquidacion Map(string linea)
        {
            var l = new Liquidacion();
            l.idLiquidacion = int.Parse(linea.Split(';')[0]);
            l.año = int.Parse(linea.Split(';')[1]);
            l.mes = int.Parse(linea.Split(';')[1]);
            return l;
        }
    }
}
