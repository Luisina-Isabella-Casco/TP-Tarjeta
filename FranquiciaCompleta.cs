using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Tarjeta
{
    public class FranquiciaCompleta : Tarjeta
    {
        public FranquiciaCompleta(int saldoInicial) : base(saldoInicial) { }

        // Método especial que siempre permite el pago sin descontar saldo
        public bool PagarBoletoGratuito()
        {
            // Siempre devuelve true indicando que el pago es exitoso
            return true;
        }
    }

}