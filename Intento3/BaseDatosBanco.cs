using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intento3
{
    public class BaseDatosBanco
    {
        private Cuenta[] cuentas;

        public BaseDatosBanco()
        {
            cuentas = new Cuenta[2];
            cuentas[0] = new Cuenta(11111, 22222, 1200.00M, 2000.00M);
            cuentas[1] = new Cuenta(88888, 99999, 200.00M, 200.00M);
        }
        public bool VerificarCuenta(int numeroCuentaUsuario, int pwUsuario)
        {
            Cuenta CuentaUsuario = GetCuenta(numeroCuentaUsuario);
            if (CuentaUsuario != null) return CuentaUsuario.ValidarContraseña(pwUsuario);
            else return false;
        }
        public void AgregarCuenta()
        {
            throw new System.NotImplementedException();
        }

        public void BorrarCuenta()
        {
            throw new System.NotImplementedException();
        }
        private Cuenta GetCuenta(int numeroCuenta)
        {
            foreach (Cuenta cuentaActual in cuentas)
            
                {
                    if (cuentaActual.NumeroCuenta == numeroCuenta) return cuentaActual;
                }

                return null;

            
        }

        public decimal GetSaldoDisponible(int NumeroCuentaUsuario)
        {
            Cuenta cuentausuario = GetCuenta(NumeroCuentaUsuario);
            return cuentausuario.SaldoDisponible;
        }
        public decimal GetSaldoTotal(int NumeroCuentaUsuario)
        {
            Cuenta cuentausuario = GetCuenta(NumeroCuentaUsuario);
            return cuentausuario.SaldoTotal;
        }
        public void Abonar(int numerocuentausuario, decimal monto)
        {
            Cuenta cuentausuario = GetCuenta(numerocuentausuario);
            cuentausuario.Abonar(monto);

        }
        public void Cargar(int numerocuentausuario, decimal monto)
        {
            Cuenta cuentausuario = GetCuenta(numerocuentausuario);
            cuentausuario.Cargar(monto);

        }

    }
}