using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*namespace TP_Tarjeta
{
    public class MedioBoleto : Tarjeta
    {

        protected const int TarifaBasica = 940;

        public int TarifaPublica
        {
            get { return TarifaBasica; }
            set { TarifaPublica = TarifaBasica; }
        }

        public MedioBoleto(int saldoInicial) : base(saldoInicial) { }
        }

    }

  public int DescontarMedioBoleto()
      {
          int tarifaMedioBoleto = TarifaBasica / 2;

          if (saldoPublico >= tarifaMedioBoleto)
          {
              saldoPublico -= tarifaMedioBoleto;
              return saldoPublico;
          }

          else
          {
              Console.WriteLine("Saldo insuficiente");
              return saldoPublico;
          }*/

namespace TP_Tarjeta
{
    public class MedioBoleto : Tarjeta
    {
       protected const int TarifaBasica = 940;
       
        private const decimal LimiteNegativo = -480;

        private List<DateTime> viajesRealizados; //lista de fecha y hora de viajes realizados

        public MedioBoleto(int saldoInicial) : base(saldoInicial)
        {
            viajesRealizados = new List<DateTime>();
        }

        public bool PagarConMedioBoleto()
        {
            DateTime ahora = DateTime.Now;

            if (viajesRealizados.Count < 4) {

                if ((ahora - viajesRealizados.Last()).TotalMinutes < 5)
                {
                    Console.WriteLine("Debe esperar 5 minutos entre viajes.");
                    return false;
                }
                else
                {
                    viajesRealizados.Add(ahora);
                    Colectivo.DescontarSaldo(this); // 'this': instancia actual de la tarjeta
                    Colectivo.PagarCon(this);
                    return true;
                }
            }

            else
            {
                Console.WriteLine("Ya se han realizado 4 viajes en el día.");
                if(saldoPublico - TarifaBasica < LimiteNegativo)
                {
                    saldoPublico -= TarifaBasica;
                    Colectivo.PagarCon(this);
                }
                return true;
            }
        }
    }
}
