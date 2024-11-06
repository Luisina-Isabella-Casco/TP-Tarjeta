using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*namespace TP_Tarjeta
{
    public class Tarjeta
    {
        protected int Saldo { get; set; }
        private const int LimiteSaldo = 9900;

        public Tarjeta(int Saldoinicial)
        {
            Saldo = Saldoinicial;
        }

        public int saldoPublico
        {
            get { return Saldo; }
           set { Saldo = value; }
        }
        public bool CargaSaldo(int monto)
        {
       
            if (monto % 1000 == 0 && monto >= 2000 && monto <= 9000 && Saldo + monto <= LimiteSaldo)

            {
                Saldo += monto;
                Console.WriteLine("Carga realizada con éxito");
                return true;
            }
            else
            {
                Console.WriteLine("No se pudo realizar la carga");
                return false;
            }
        }

     



     
    }

} 
*/

namespace TP_Tarjeta
{
    public class Tarjeta
    {
        protected int Saldo { get; set; }
        private const int LimiteSaldo = 36000;
        protected int SaldoPendiente { get; set; } // Variable para almacenar el saldo pendiente de acreditación

        public int saldoPublico
        {
            get { return Saldo; }
            set { Saldo = value; }
        }
        public int saldoPendientePublico
        {
            get { return SaldoPendiente; }
            set { SaldoPendiente = value; }
        }

        public Tarjeta(int saldoInicial)
        {
            Saldo = saldoInicial;
            SaldoPendiente = 0; // Al inicio no hay saldo pendiente
        }

        public bool CargaSaldo(int monto)
        {
            if (monto % 1000 == 0 && monto >= 2000 && monto <= 9000)
            {
                // Si la carga supera el límite de 36,000, se realiza solo hasta el límite
                if (Saldo + monto > LimiteSaldo)
                {
                    int cargaParcial = LimiteSaldo - Saldo;
                    Saldo = LimiteSaldo; // Se ajusta al límite máximo
                    SaldoPendiente += monto - cargaParcial; // El exceso se acumula en el saldo pendiente
                    Console.WriteLine($"Carga realizada con éxito. El saldo pendiente es {SaldoPendiente}.");
                }
                else
                {
                    Saldo += monto;
                    Console.WriteLine("Carga realizada con éxito.");
                }
                return true;
            }
            else
            {
                Console.WriteLine("No se pudo realizar la carga.");
                return false;
            }
        }

        // Método para recargar el saldo pendiente si el saldo es usado
        public void RecargarSaldoPendiente()
        {
            if (SaldoPendiente > 0)
            {
                int espacioDisponible = LimiteSaldo - Saldo;
                if (espacioDisponible > 0)
                {
                    if (SaldoPendiente <= espacioDisponible)
                    {
                        Saldo += SaldoPendiente;
                        SaldoPendiente = 0; // Se acreditó todo el saldo pendiente
                    }
                    else
                    {
                        Saldo = LimiteSaldo; // Se llena hasta el límite
                        SaldoPendiente -= espacioDisponible; // Se mantiene el exceso
                    }
                    Console.WriteLine($"Saldo recargado. Saldo actual: {Saldo}. Saldo pendiente: {SaldoPendiente}.");
                }
                else
                {
                    Console.WriteLine("No hay espacio para recargar el saldo pendiente.");
                }
            }
        }

        // Método para verificar si hay saldo pendiente
        public int ObtenerSaldoPendiente()
        {
            return SaldoPendiente;
        }
    }
}

