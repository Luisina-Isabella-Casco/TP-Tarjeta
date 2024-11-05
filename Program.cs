using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Tarjeta
{
    public class TestTarjeta
    {
        public static void Main(string[] args)
        {
            Tarjeta tarjeta = new Tarjeta(0);

            //Prueba de carga de saldo
            Console.WriteLine(tarjeta.CargaSaldo(2000));

            //Prueba de pago 
            Colectivo colectivo = new Colectivo();
            Boleto boleto = colectivo.PagarCon(tarjeta);
            Console.WriteLine(boleto != null);
            Console.WriteLine(tarjeta.saldoPublico);

            //Prueba de saldo insuficiente 
            Colectivo.DescontarSaldo(tarjeta);
            boleto = colectivo.PagarCon(tarjeta);
            Console.WriteLine(boleto == null);
        }
    }
}
