using System;
using System.Collections.Generic;
// CAMBIO REALIZADO: Se agregó el uso de records para
// la clase Bebida y se reemplazó la actualización del stock en el diccionario
// por una nueva instancia de Bebida con el stock actualizado.

namespace MaquinaCafe
{
    public record Bebida(string Nombre, int Precio, int Stock);

    public class MaquinaCafe
    {
        private int _saldo;
        private readonly Dictionary<string, Bebida> _menu;

        public int Saldo => _saldo;

        public MaquinaCafe()
        {
            _menu = new()
            {
                ["Cafe"] = new Bebida("Cafe", 100, 10),
                ["Te"] = new Bebida("Te", 75, 10),
                ["Agua"] = new Bebida("Agua", 50, 10)
            };
        }

        public void InsertarMoneda(int monto) => _saldo += monto;

        public bool SeleccionarBebida(string nombre)
        {
            var bebida = ObtenerBebida(nombre);

            if (_saldo < bebida.Precio || bebida.Stock == 0)
                return false;

            _saldo -= bebida.Precio;
            // Actualizar el stock reemplazando la bebida en el diccionario
            _menu[nombre] = bebida with { Stock = bebida.Stock - 1 };
            return true;
        }

        private Bebida ObtenerBebida(string nombre)
        {
            if (_menu.TryGetValue(nombre, out var bebida))
                return bebida;
            throw new ArgumentException($"No existe {nombre}");
        }

        public int ObtenerCambio()
        {
            var cambio = _saldo;
            _saldo = 0;
            return cambio;
        }

        public void DevolverMonedas() => _saldo = 0;

        public Dictionary<string, Bebida> ObtenerMenu() => _menu;
    }
}