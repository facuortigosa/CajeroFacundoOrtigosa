using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intento3
{
    public class Retiro : Transaccion
    {
        private int numeroCuenta;
        private decimal monto;
        private Teclado teclado;
        private DispensadorEfectivo dispensadorEfectivo;

        private const int CANCELO = 6;
        public Retiro(int numeroCuentaUsuario, Pantalla pantallaCajero, BaseDatosBanco baseDatosCajero, Teclado tecladoCajero, DispensadorEfectivo dispensadorEfectivoCajero)
            : base(numeroCuentaUsuario, pantallaCajero, baseDatosCajero)
        {
            teclado = tecladoCajero;
            dispensadorEfectivo = dispensadorEfectivoCajero;

        }

        public override void Ejecutar()
        {
            bool efectivoDispensado = false;
            bool transaccionCancelada = false;

            do
            {
                int seleccion = MostrarMenuDeMontos();

                if (seleccion != CANCELO)
                {
                    monto = seleccion;
                    decimal saldoDisponible = BaseDatos.GetSaldoDisponible(NumeroCuenta);

                    if (monto <= saldoDisponible)
                    {


                        if (dispensadorEfectivo.HayEfectivoDisponible(monto))
                        {

                            BaseDatos.Cargar(NumeroCuenta, monto);

                            dispensadorEfectivo.DispensarEfectivo(monto);
                            efectivoDispensado = true;


                            PantallaUsuario.MostrarLineaMensaje(
                            "\nPor favor agarre su efectivo.");
                        }
                        else
                            PantallaUsuario.MostrarLineaMensaje(
                            "\nNo hay suficiente efectivo disponible en el Cajero." +
                            "\n\nPor favor elija un monto valido.");

                    }
                    else
                        PantallaUsuario.MostrarLineaMensaje(
                        "\nNo hay suficiente efectivo disponible en su cuenta." +
                        "\n\nPor favor elija otro monto.");

                }
                else
                {
                    PantallaUsuario.MostrarLineaMensaje("\nCancelando la transacción...");
                    transaccionCancelada = true;
                }
            




            } while ((!efectivoDispensado) && (!transaccionCancelada));
        }

    private int MostrarMenuDeMontos()
    {
        int eleccion = 0;
        int[] montos = { 0, 100, 200, 300, 400, 500 };

        while (eleccion == 0)
        {
            PantallaUsuario.MostrarLineaMensaje("\nOpciones de retiro:");
            PantallaUsuario.MostrarLineaMensaje("1 - $100");
            PantallaUsuario.MostrarLineaMensaje("2 - $200");
            PantallaUsuario.MostrarLineaMensaje("3 - $300");
            PantallaUsuario.MostrarLineaMensaje("4 - $400");
            PantallaUsuario.MostrarLineaMensaje("5 - $500");
            PantallaUsuario.MostrarLineaMensaje("6 - Cancelar transacción");
            PantallaUsuario.MostrarMensaje(
            "\nElija una opción de retiro (1-6): ");

            int entrada = teclado.ObtenerEntrada();
            switch (entrada)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    eleccion = montos[entrada];
                    break;
                case CANCELO:
                    eleccion = CANCELO;
                    break;
                default:
                    PantallaUsuario.MostrarLineaMensaje("\nSelección inválida. Intentar de nuevo.");
                    break;

            }
        }
        return eleccion;
    }
}
}



