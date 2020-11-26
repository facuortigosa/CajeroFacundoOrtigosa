using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intento3
{
    public class DispensadorEfectivo
    {
        private const int Cuenta_Inicial = 5000;
        private int cuentaBilletes;

        public DispensadorEfectivo()
        {
            cuentaBilletes = Cuenta_Inicial;
        }

        public void DispensarEfectivo(decimal monto)
        {
            int billetesRequeridos = ((int)monto)/100;
            cuentaBilletes -= billetesRequeridos;

        }

        public bool HayEfectivoDisponible(decimal monto)
        {
            int billetesRequeridos = ((int)monto) / 100;
            return (cuentaBilletes >= billetesRequeridos);
        }
    }
}
