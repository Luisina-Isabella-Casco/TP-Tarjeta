using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Tarjeta
{
    public class FranquiciaCompleta : Tarjeta
    {

        protected const int TarifaBasica = 940;

        private const decimal LimiteNegativo = -480;

        private List<DateTime> viajesHechos;
        public FranquiciaCompleta(int saldoInicial) : base(saldoInicial)
        {
            viajesHechos = new List<DateTime>();
        }


        // siempre se permite el pago sin descontar saldo
        public bool PagarBoletoGratuito()
        {
            DateTime ahora = DateTime.Now;

            if (viajesHechos.Count < 2)
            {
                viajesHechos.Add(ahora);

                // Siempre devuelve true indicando un pago exitoso
                return true;
            }

            else
            {
                Console.WriteLine("Ya se han realizado 2 viajes en el día.");
                if (saldoPublico - TarifaBasica < LimiteNegativo)
                {
                    saldoPublico -= TarifaBasica;
                    Colectivo.PagarCon(this);
                }
                return true;
            }
        }
    }

}