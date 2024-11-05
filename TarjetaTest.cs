using NUnit.Framework;
using TP_Tarjeta;

namespace Test_TP_Tarjeta
{
    public class TarjetaTest
    {
        public Tarjeta tarjeta;

        protected const int TarifaBasica = 940;

        [SetUp]
        public void Setup()
        {
            tarjeta = new Tarjeta(40);
        }

        [Test]
        [TestCase(2000)]
        [TestCase(6000)]
        [TestCase(3000)]
        [TestCase(4000)]
        [TestCase(10000)]
        [TestCase(182)]

        public void CargarSaldoTest(int carga)
        {
            Assert.That(tarjeta.CargaSaldo(carga), Is.EqualTo(true));
        }


    }

    
}