using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intento3
{
    public abstract class Transaccion
    {
        private int numeroCuenta;
        private Pantalla pantallaUsuario;
        private BaseDatosBanco baseDatos;

        public Transaccion(int cuentaUsuario, Pantalla pantalla, BaseDatosBanco baseDatosBanco)
        {
            numeroCuenta = cuentaUsuario;
            pantallaUsuario = pantalla;
            baseDatos = baseDatosBanco;
        }

        public int NumeroCuenta {
            get {
                return numeroCuenta; }
            
        }
        public BaseDatosBanco BaseDatos
        {
            get
            {
                return baseDatos;
            }
        }
        public Pantalla PantallaUsuario
        {
            get
            {
                return pantallaUsuario;
            }
        }

        public abstract void Ejecutar();
    }
}