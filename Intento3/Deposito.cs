using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intento3
{
    public class Deposito : Transaccion
    {
        private decimal monto;
        private Teclado teclado;
        private RanuraDeposito ranuraDeposito;


        private const int CANCELO = 0;



        public Deposito(int numeroCuentaUsuario, Pantalla pantallaCajero,
        BaseDatosBanco baseDatosBancoCajero, Teclado tecladoCajero,
        RanuraDeposito ranuraDepositoCajero)
        : base(numeroCuentaUsuario, pantallaCajero, baseDatosBancoCajero)
        {
            teclado = tecladoCajero;
            ranuraDeposito = ranuraDepositoCajero;

        }

        public override void Ejecutar()
        {
            monto = PedirMontoADepositar();


            if (monto != CANCELO)
            {

                PantallaUsuario.MostrarMensaje(
                "\nIntroduzca un depósito que contenga ");
                PantallaUsuario.MostrarMontoEnDolares(monto);
                PantallaUsuario.MostrarLineaMensaje(" en la ranura para depósitos.");


                bool sobreRecibido = ranuraDeposito.DepositoRecibido();


                if (sobreRecibido)
                {
                    PantallaUsuario.MostrarLineaMensaje(
                    "\nSe recibió su deposito.\n"
);


                    BaseDatos.Abonar(NumeroCuenta, monto);
                }
                else
                    PantallaUsuario.MostrarLineaMensaje(
                    "\nNo insertó un deposito  " +
                    "cancelo su transacción.");
            }
            else
                PantallaUsuario.MostrarLineaMensaje("\nCancelando la transacción...");
        }


        private decimal PedirMontoADepositar()
        {

            PantallaUsuario.MostrarMensaje(
             "\nIntroduzca un monto a depositar (o 0 para cancelar): ");
            int entrada = teclado.ObtenerEntrada();


            if (entrada == CANCELO)
                return CANCELO;
            else
                return entrada;
        }
    }
}
