using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Tarjeta
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

