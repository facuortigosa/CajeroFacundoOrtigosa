using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intento3
{
    public class Cajero
    {
        private bool usuarioAutenticado;
        private int numeroCuentaActual;
        private Pantalla pantalla;
        private Teclado teclado;
        private DispensadorEfectivo dispensadorEfectivo;
        private RanuraDeposito ranuraDeposito;
        private BaseDatosBanco baseDatosBanco;

        private enum OpcionMenu
        {
            SOLICITUD_SALDO = 1,
            RETIRO = 2,
            DEPOSITO = 3,
            SALIR_CAJERO = 4
        }
        public Cajero()
        {
            usuarioAutenticado = false;
            numeroCuentaActual = 0;
            pantalla = new Pantalla();
            teclado = new Teclado();
            dispensadorEfectivo = new DispensadorEfectivo();
            ranuraDeposito = new RanuraDeposito();
            baseDatosBanco = new BaseDatosBanco();
        }

        public void Ejecutar()
        {

            while (true)
            {

                while (!usuarioAutenticado)
                {
                    pantalla.MostrarLineaMensaje("\n¡Bienvenido!");
                    AutenticarUsuario();
                }

                RealizarTransacciones();
                usuarioAutenticado = false;

                numeroCuentaActual = 0;
                pantalla.MostrarLineaMensaje("\n Gracias ");
            }
        }


        private void AutenticarUsuario()
        {

            pantalla.MostrarMensaje("\nIntroduzca su número de cuenta: ");
            int numeroCuenta = teclado.ObtenerEntrada();


            pantalla.MostrarMensaje("\nIntroduzca su contraseña: ");
            int pin = teclado.ObtenerEntrada();


            usuarioAutenticado =
            baseDatosBanco.VerificarCuenta(numeroCuenta, pin);


            if (usuarioAutenticado)
                numeroCuentaActual = numeroCuenta;
            else
                pantalla.MostrarLineaMensaje(
                "Número de cuenta o Contraseña inválido. Intente de nuevo.");
        }


        private void RealizarTransacciones()
        {
            Transaccion transaccionActual;
            bool usuarioSalio = false;


            while (!usuarioSalio)
            {

                int seleccionMenuPrincipal = MostrarMenuPrincipal();


                switch ((OpcionMenu)seleccionMenuPrincipal)
                {
                    case OpcionMenu.SOLICITUD_SALDO:
                    case OpcionMenu.RETIRO:
                    case OpcionMenu.DEPOSITO:

                        transaccionActual =
                        CrearTransaccion(seleccionMenuPrincipal);
                        transaccionActual.Ejecutar();
                        break;
                    case OpcionMenu.SALIR_CAJERO:
                        pantalla.MostrarLineaMensaje("\nSaliendo del sistema...");
                        usuarioSalio = true;
                        break;
                    default:
                        pantalla.MostrarLineaMensaje(
                        "\nNo introdujo una selección válida. Intente de nuevo.");
                        break;
                }
            }
        }
    


    private int MostrarMenuPrincipal()
    {
        pantalla.MostrarLineaMensaje("\nMenú principal:");
        pantalla.MostrarLineaMensaje("1 - Ver mi saldo");
        pantalla.MostrarLineaMensaje("2 - Retirar efectivo");
        pantalla.MostrarLineaMensaje("3 - Depositar ");
        pantalla.MostrarLineaMensaje("4 - Salir\n");
        pantalla.MostrarMensaje("Introduzca una opción: ");
        return teclado.ObtenerEntrada();
    }
    private Transaccion CrearTransaccion(int tipo)
    {
        Transaccion temp = null;


        switch ((OpcionMenu)tipo)
        {

            case OpcionMenu.SOLICITUD_SALDO:
                temp = new SolicitudSaldo(numeroCuentaActual,
                pantalla, baseDatosBanco);
                break;
            case OpcionMenu.RETIRO:
                temp = new Retiro(numeroCuentaActual, pantalla,
                baseDatosBanco, teclado, dispensadorEfectivo);
                break;
            case OpcionMenu.DEPOSITO:
                temp = new Deposito(numeroCuentaActual, pantalla,
                baseDatosBanco, teclado, ranuraDeposito);
                break;
        }

        return temp;
    }


}
}