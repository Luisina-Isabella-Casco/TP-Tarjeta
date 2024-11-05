using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace TP_Tarjeta
    {
        public class Colectivo
        {
            protected const int TarifaBasica = 940; // Definimos tarifa básica en Colectivo

            private const decimal LimiteNegativo = -480;

        public static bool DescontarSaldo(Tarjeta tarjeta)
        {
            // Caso FranquiciaCompleta: siempre permite el pago sin descontar saldo
            if (tarjeta is FranquiciaCompleta franquicia)
            {
                return franquicia.PagarBoletoGratuito();
            }

            // Caso MedioBoleto: intenta descontar la mitad de la tarifa
            if (tarjeta is MedioBoleto)
            {
                int tarifaMedio = TarifaBasica / 2;
                if (tarjeta.saldoPublico - tarifaMedio >= LimiteNegativo)
                {
                    tarjeta.saldoPublico -= tarifaMedio;
                    return true;
                }
                else
                {
                    Console.WriteLine("Saldo insuficiente para medio boleto");
                    return false;
                }
            }

            // Caso Tarjeta regular: intenta descontar la tarifa completa
            if (tarjeta.saldoPublico - TarifaBasica >= LimiteNegativo)
            {
                tarjeta.saldoPublico -= TarifaBasica;
                return true;
            }

            // Si no se cumple ninguna condición de saldo suficiente
            Console.WriteLine("Saldo insuficiente");
            return false;
        }


        public Boleto PagarCon(Tarjeta tarjeta)
            {
                if (DescontarSaldo(tarjeta))
                {
                    return new Boleto(TarifaBasica);
                }
                return null;
            }
        }
    }

