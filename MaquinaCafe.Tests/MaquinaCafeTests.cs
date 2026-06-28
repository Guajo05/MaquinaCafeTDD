using NUnit.Framework;
using System;

namespace MaquinaCafe.Tests
{
    [TestFixture]
    public class MaquinaCafeTests
    {
        // TC-01
        [Test]
        public void InsertarMoneda_MontoValido_IncrementaSaldo()
        {
            var maquina = new MaquinaCafe();
            maquina.InsertarMoneda(25);
            Assert.AreEqual(25, maquina.Saldo);
        }

        // TC-02
        [Test]
        public void SeleccionarBebida_SaldoSuficiente_RetornaTrue()
        {
            var maquina = new MaquinaCafe();
            maquina.InsertarMoneda(100);
            var resultado = maquina.SeleccionarBebida("Cafe");
            Assert.IsTrue(resultado);
        }

        // TC-03
        [Test]
        public void SeleccionarBebida_SaldoInsuficiente_RetornaFalse()
        {
            var maquina = new MaquinaCafe();
            maquina.InsertarMoneda(50);
            var resultado = maquina.SeleccionarBebida("Cafe");
            Assert.IsFalse(resultado);
        }

        // TC-04
        [Test]
        public void ObtenerCambio_DespuesDeCompra_DevuelveSaldoRestante()
        {
            var maquina = new MaquinaCafe();
            maquina.InsertarMoneda(150);
            maquina.SeleccionarBebida("Cafe");
            var cambio = maquina.ObtenerCambio();
            Assert.AreEqual(50, cambio);
            Assert.AreEqual(0, maquina.Saldo);
        }

        // TC-05
        [Test]
        public void SeleccionarBebida_BebidaInexistente_LanzaArgumentException()
        {
            var maquina = new MaquinaCafe();
            Assert.Throws<ArgumentException>(() => maquina.SeleccionarBebida("Jugo"));
        }

        // TC-06
        [Test]
        public void ObtenerMenu_RetornaDiccionarioConTresBebidas()
        {
            var maquina = new MaquinaCafe();
            var menu = maquina.ObtenerMenu();
            Assert.AreEqual(3, menu.Count);
            Assert.AreEqual(100, menu["Cafe"].Precio);
            Assert.AreEqual(75, menu["Te"].Precio);
            Assert.AreEqual(50, menu["Agua"].Precio);
        }

        // TC-07
        [Test]
        public void DevolverMonedas_ReiniciaSaldoACero()
        {
            var maquina = new MaquinaCafe();
            maquina.InsertarMoneda(100);
            maquina.DevolverMonedas();
            Assert.AreEqual(0, maquina.Saldo);
        }

        // TC-08 (Este fallará hasta que implementemos stock en el Refactor)
        [Test]
        public void SeleccionarBebida_StockAgotado_RetornaFalse()
        {
            var maquina = new MaquinaCafe();
            maquina.InsertarMoneda(1100); // Para 11 cafés
            for (int i = 0; i < 10; i++) maquina.SeleccionarBebida("Cafe");
            var resultado = maquina.SeleccionarBebida("Cafe");
            Assert.IsFalse(resultado);
        }
    }
}