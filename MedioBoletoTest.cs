/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TP_Tarjeta;
using static TP_Tarjeta.Tarjeta;

namespace Test_TP_Tarjeta
{
    [TestFixture]
    public class MedioBoletoTests
    {

        protected const int TarifaBasica = 940;

        [Test]
        public void DescontarMedioBoleto_SaldoSuficiente_DecrementaSaldo()
        {
            // Arrange
            int saldoInicial = 2000; // Saldo suficiente para un viaje con medio boleto
            MedioBoleto tarjeta = new MedioBoleto(saldoInicial);

            // Act
            int saldoDespuesDeDescuento = tarjeta.DescontarMedioBoleto();

            // Assert
            int saldoEsperado = saldoInicial - (TarifaBasica / 2);
            Assert.AreEqual(saldoEsperado, saldoDespuesDeDescuento);
        }

        [Test]
        public void DescontarMedioBoleto_SaldoExacto_DecrementaSaldo()
        {
            // Arrange
            int saldoInicial = TarifaBasica / 2; // Saldo exacto para un viaje con medio boleto
            MedioBoleto tarjeta = new MedioBoleto(saldoInicial);

            // Act
            int saldoDespuesDeDescuento = tarjeta.DescontarMedioBoleto();

            // Assert
            Assert.AreEqual(0, saldoDespuesDeDescuento);
        }

        [Test]
        public void DescontarMedioBoleto_SaldoInsuficiente_NoDecrementaSaldo()
        {
            // Arrange
            int saldoInicial = (TarifaBasica / 2) - 100; // Saldo insuficiente
            MedioBoleto tarjeta = new MedioBoleto(saldoInicial);

            // Act
            int saldoDespuesDeDescuento = tarjeta.DescontarMedioBoleto();

            // Assert
            Assert.AreEqual(saldoInicial, saldoDespuesDeDescuento);
        }
    }
}

*/