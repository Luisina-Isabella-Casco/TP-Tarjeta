using NUnit.Framework;
using TP_Tarjeta;


namespace Test_TP_Tarjeta
{
    public class TarjetaTest
    {
        private Tarjeta tarjeta;

        [SetUp]
        public void Setup()
        {
            tarjeta = new Tarjeta(5000); 
        }

        [Test]
        public void CargaSaldo_Exitosa()
        {

            bool resultado = tarjeta.CargaSaldo(2000);


            Assert.IsTrue(resultado, "La carga de saldo deber�a ser exitosa.");
            Assert.AreEqual(7000, tarjeta.saldoPublico, "El saldo deber�a ser 7000 despu�s de cargar 2000.");
        }

        [Test]
        public void CargaSaldo_MontoExcedeLimite()
        {
    
            tarjeta = new Tarjeta(30000); 

            bool resultado = tarjeta.CargaSaldo(9000);

            Assert.IsTrue(resultado, "La carga de saldo deber�a fallar porque excede el l�mite.");
            Assert.AreEqual(36000, tarjeta.saldoPublico, "El saldo deber�a seguir siendo 9000.");
        }

        [Test]
        public void CargaSaldo_MontoInv�lido()
        {

            bool resultado = tarjeta.CargaSaldo(1500);

            Assert.IsFalse(resultado, "La carga de saldo deber�a fallar porque el monto no es v�lido.");
            Assert.AreEqual(5000, tarjeta.saldoPublico, "El saldo deber�a seguir siendo 5000.");
        }
    }
}

