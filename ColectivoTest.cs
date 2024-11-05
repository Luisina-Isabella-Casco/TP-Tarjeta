using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TP_Tarjeta;

namespace Test_TP_Tarjeta
{
    public class ColectivoTest
    {
        private Colectivo colectivo;

        [SetUp]
        public void Setup()
        {
            colectivo = new Colectivo();
        }

        [Test]
        public void DescontarSaldo_FranquiciaCompleta()
        {
            // Arrange
            Tarjeta franquicia = new FranquiciaCompleta(0);

            // Act
            bool resultado = Colectivo.DescontarSaldo(franquicia);

            // Assert
            Assert.IsTrue(resultado);  // Verifica que siempre permite el pago
            Assert.AreEqual(0, franquicia.saldoPublico);  // Verifica que el saldo no se descuenta
        }

        [Test]
        public void DescontarSaldo_MedioBoleto()
        {
            // Arrange
            Tarjeta medioBoleto = new MedioBoleto(2000);

            // Act
            bool resultado = Colectivo.DescontarSaldo(medioBoleto);

            // Assert
            Assert.IsTrue(resultado);  // Verifica que permite el pago
            Assert.AreEqual(1530, medioBoleto.saldoPublico);  // Verifica que descuenta la mitad de la tarifa
        }

        [Test]
        public void Descontar_MedioBoleto() //Saldo insuficiente
        {
            // Arrange
            Tarjeta medioBoleto = new MedioBoleto(-300);

            // Act
            bool resultado = Colectivo.DescontarSaldo(medioBoleto);

            // Assert
            Assert.IsFalse(resultado);  // Verifica que no permite el pago
            Assert.AreEqual(-300, medioBoleto.saldoPublico);  // Verifica que el saldo no se descuenta
        }

        [Test]
        public void DescontarSaldo_TarjetaRegular()
        {
            // Arrange
            Tarjeta tarjetaRegular = new Tarjeta(2000);

            // Act
            bool resultado = Colectivo.DescontarSaldo(tarjetaRegular);

            // Assert
            Assert.IsTrue(resultado);  // Verifica que permite el pago
            Assert.AreEqual(1060, tarjetaRegular.saldoPublico);  // Verifica que descuenta la tarifa completa
        }

        [Test]
        public void Descontar_TarjetaRegular() //saldo insuficiente
        {
            // Arrange
            Tarjeta tarjetaRegular = new Tarjeta(100);

            // Act
            bool resultado = Colectivo.DescontarSaldo(tarjetaRegular);

            // Assert
            Assert.IsFalse(resultado);  // Verifica que no permite el pago
            Assert.AreEqual(100, tarjetaRegular.saldoPublico);  // Verifica que el saldo no se descuenta
        }

        [Test]
        public void PagarCon_FranquiciaCompleta()
        {
            // Arrange
            Tarjeta franquicia = new FranquiciaCompleta(0);

            // Act
            Boleto boleto = colectivo.PagarCon(franquicia);

            // Assert
            Assert.IsNotNull(boleto);  // Verifica que se genera un boleto
            Assert.AreEqual(940, boleto.Tarifa);  // Verifica la tarifa en el boleto
            Assert.AreEqual(0, franquicia.saldoPublico);  // Verifica que el saldo no se descuenta
        }

        [Test]
        public void PagarCon_MedioBoleto()
        {
            // Arrange
            Tarjeta medioBoleto = new MedioBoleto(2000);

            // Act
            Boleto boleto = colectivo.PagarCon(medioBoleto);

            // Assert
            Assert.IsNotNull(boleto);  // Verifica que se genera un boleto
            Assert.AreEqual(940, boleto.Tarifa);  // Verifica la tarifa en el boleto
            Assert.AreEqual(1530, medioBoleto.saldoPublico);  // Verifica que descuenta la mitad de la tarifa
        }

        [Test]
        public void PagarCon_TarjetaRegular()
        {
            // Arrange
            Tarjeta tarjetaRegular = new Tarjeta(2000);

            // Act
            Boleto boleto = colectivo.PagarCon(tarjetaRegular);

            // Assert
            Assert.IsNotNull(boleto);  // Verifica que se genera un boleto
            Assert.AreEqual(940, boleto.Tarifa);  // Verifica la tarifa en el boleto
            Assert.AreEqual(1060, tarjetaRegular.saldoPublico);  // Verifica que descuenta la tarifa completa
        }

        [Test]
        public void PagarConTarjetaRegular() //saldo insuficiente
        {
            // Arrange
            Tarjeta tarjetaRegular = new Tarjeta(100);

            // Act
            Boleto boleto = colectivo.PagarCon(tarjetaRegular);

            // Assert
            Assert.IsNull(boleto);  // Verifica que no se genera un boleto
            Assert.AreEqual(100, tarjetaRegular.saldoPublico);  // Verifica que el saldo no se descuenta
        }
    }
}
