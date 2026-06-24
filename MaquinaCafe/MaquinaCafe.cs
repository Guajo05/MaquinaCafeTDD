using System;
using System.Collections.Generic;

namespace MaquinaCafe
{
    public class MaquinaCafe
    {
        public int Saldo { get; private set; }

        private readonly Dictionary<string, int> _menu = new()
        {
            { "Cafe", 100 },
            { "Te", 75 },
            { "Agua", 50 }
        };

        public void InsertarMoneda(int monto) => Saldo += monto;

        public bool SeleccionarBebida(string bebida)
        {
            if (!_menu.ContainsKey(bebida))
                throw new ArgumentException("No existe");

            if (Saldo < _menu[bebida])
                return false;

            Saldo -= _menu[bebida];
            return true;
        }

        public int ObtenerCambio()
        {
            var cambio = Saldo;
            Saldo = 0;
            return cambio;
        }

        public void DevolverMonedas() => Saldo = 0;

        public Dictionary<string, int> ObtenerMenu() => _menu;
    }
}