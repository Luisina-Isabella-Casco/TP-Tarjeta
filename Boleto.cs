using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Tarjeta
{
    public class Boleto 
    {
        public int Tarifa { get; private set;  }
        public Boleto(int tarifa)
        {
            Tarifa = tarifa; 
        }
    }
}
