using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intento3
{
    public class SolicitudSaldo : Transaccion
    {
        public SolicitudSaldo(int numeroCuentaUsuaro, Pantalla pantallaCajero, BaseDatosBanco BaseDatosCajero)
            : base(numeroCuentaUsuaro, pantallaCajero, BaseDatosCajero) { }

        public override void Ejecutar()
        {
            decimal saldoDisponible = BaseDatos.GetSaldoDisponible(NumeroCuenta);
            decimal saldoTotal = BaseDatos.GetSaldoDisponible(NumeroCuenta);

            PantallaUsuario.MostrarLineaMensaje("\nInformacion del Saldo: ");
            PantallaUsuario.MostrarMensaje(" - Saldo Disponible: ");

            PantallaUsuario.MostrarMontoEnDolares(saldoDisponible);
            PantallaUsuario.MostrarMensaje("\n - Saldo total: ");
            PantallaUsuario.MostrarMontoEnDolares(saldoTotal);
            PantallaUsuario.MostrarLineaMensaje("");
        }
    }
}
