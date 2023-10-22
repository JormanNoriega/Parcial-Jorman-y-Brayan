using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Archivo
    {
        protected string fileName;
        public Archivo(string fileName)
        {
            this.fileName = fileName;
        }
        public String Guardar(string datos)
        {
            var write = new StreamWriter(fileName, true);
            write.WriteLine(datos.ToString());
            write.Close();
            return $"Registro almacenado";
        }
    }
}
