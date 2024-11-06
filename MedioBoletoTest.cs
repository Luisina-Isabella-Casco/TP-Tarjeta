using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TP_Tarjeta;
using static TP_Tarjeta.Tarjeta;

/*namespace Test_TP_Tarjeta
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

namespace Test_TP_Tarjeta
{
    public class MedioBoletoTest
    {
        private MedioBoleto medioBoleto;

        [SetUp]
        public void Setup()
        {
            medioBoleto = new MedioBoleto(5000); // Crear una tarjeta MedioBoleto con saldo inicial de 5000
        }

        [Test]
        public void PagarConMedioBoleto_DeberiaRealizarPagoCorrectamente_DespuesDe5Minutos()
        {
            // Arrange: Simulamos que ya ha pasado más de 5 minutos desde el último viaje
            medioBoleto.PagarConMedioBoleto(); // Realizamos un primer viaje
            System.Threading.Thread.Sleep(6000); // Esperamos 6 segundos (simula el paso de tiempo)

            // Act: Intentamos realizar un segundo viaje después de 6 segundos
            bool resultado = medioBoleto.PagarConMedioBoleto();

            // Assert: El pago debería realizarse correctamente
            Assert.IsTrue(resultado);
        }

        [Test]
        public void PagarConMedioBoleto_NoDeberiaRealizarPago_AntesDe5Minutos()
        {
            // Arrange: Realizamos un primer viaje
            medioBoleto.PagarConMedioBoleto();

            // Act: Intentamos realizar otro viaje inmediatamente
            bool resultado = medioBoleto.PagarConMedioBoleto();

            // Assert: No se debería permitir el segundo viaje, ya que no han pasado 5 minutos
            Assert.IsFalse(resultado);
        }

        [Test]
        public void PagarConMedioBoleto_NoDeberiaRealizarMasDe4Viajes()
        {
            // Arrange: Simulamos 4 viajes previos
            for (int i = 0; i < 4; i++)
            {
                medioBoleto.PagarConMedioBoleto(); // Realizamos 4 viajes
            }

            // Act: Intentamos realizar el 5to viaje
            bool resultado = medioBoleto.PagarConMedioBoleto();

            // Assert: El pago no debería ser permitido ya que se han realizado más de 4 viajes
            Assert.IsFalse(resultado);
        }

        [Test]
        public void PagarConMedioBoleto_DeberiaPermitirPrimerViaje()
        {
            // Act: Intentamos realizar el primer viaje
            bool resultado = medioBoleto.PagarConMedioBoleto();

            // Assert: El primer viaje debe permitirse
            Assert.IsTrue(resultado);
        }
    }
}

