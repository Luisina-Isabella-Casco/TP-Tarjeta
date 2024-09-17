using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Tarjeta
{
    public class Colectivo 
    {
        private const int TarifaBasica = 940;

        public Boleto PagarCon (Tarjeta tarjeta)
        {
            if (tarjeta.DescontarSaldo(TarifaBasica))
            {
           
                return new Boleto(TarifaBasica);
            }
            return null;
        }
    }
}
