using System;
using System.Collections.Generic;

namespace MaquinaCafe
{
    public class MaquinaCafe
    {
        // Propiedad solo para que compile, siempre devuelve 0
        public int Saldo => 0;

        // Método vacío (no hace nada)
        public void InsertarMoneda(int monto) { }

        // Siempre devuelve false (para que fallen los tests de selección exitosa)
        public bool SeleccionarBebida(string bebida)
        {
            // Lanzamos excepción para forzar que el TC-05 (bebida inexistente) falle también
            // o simplemente devolvemos false. Como necesitamos que falle TC-02, devolvemos false.
            return false;
        }

        // Siempre devuelve 0
        public int ObtenerCambio() => 0;

        // Vacío
        public void DevolverMonedas() { }

        // Devuelve un diccionario vacío (para que TC-06 falle al contar 0 vs 3)
        public Dictionary<string, int> ObtenerMenu() => new Dictionary<string, int>();
    }
}