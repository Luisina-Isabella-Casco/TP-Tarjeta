using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Tarjeta
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

        /*public int DescontarMedioBoleto()
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
        }

    }

