using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intento3
{
    public class Cuenta
    {
        private int contraseña;
        private int nroCuenta;
        private decimal saldoDisponible;
        private decimal saldoTotal;

        public int NumeroCuenta
        {
            get
            {
                return nroCuenta;
            }
        }

        public decimal SaldoDisponible
        {
            get
            {
                return saldoDisponible;
            }
        }

        public decimal SaldoTotal
        {
            get 
            {
                return saldoTotal;
            }
        }
        public Cuenta(int numeroCuenta, int pw, decimal saldodisp, decimal saldototal)
        {
            nroCuenta = numeroCuenta;
            contraseña = pw;
            saldoDisponible = saldodisp;
            saldoTotal = saldototal;

        }
        public bool ValidarContraseña(int pwUsuario)
        {
            return (pwUsuario == contraseña);
        }
        public void Abonar(decimal monto)
        {
            saldoTotal += monto;
        }

        public void Cargar(decimal monto)
        {
            saldoDisponible -= monto;
            saldoTotal -= monto;
        }


    }
}