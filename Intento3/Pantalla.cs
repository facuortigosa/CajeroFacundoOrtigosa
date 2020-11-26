using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intento3
{
    public class Pantalla
    {
        public void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
        public void MostrarLineaMensaje (string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        public void MostrarMontoEnDolares(decimal monto)
        {
            Console.Write("{0:C}", monto);
        }

    }
}
