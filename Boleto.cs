using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Tarjeta
{
    public class Boleto
    {
        public int Tarifa { get; private set; }
        public DateTime Fecha { get; private set; }
        public string TipoTarjeta { get; private set; }
        public string LineaColectivo { get; private set; }
        public int TotalAbonado { get; private set; }
        public int SaldoRestante { get; private set; }
        public string IdTarjeta { get; private set; }

        public Boleto(int tarifa, string tipoTarjeta, string lineaColectivo, int totalAbonado, int saldoRestante, string idTarjeta)
        {
            Tarifa = tarifa;
            Fecha = DateTime.Now;
            TipoTarjeta = tipoTarjeta;
            LineaColectivo = lineaColectivo;
            TotalAbonado = totalAbonado;
            SaldoRestante = saldoRestante;
            IdTarjeta = idTarjeta;
        }

        public string DescripcionSaldo()
        {
            return $"Abona saldo: {SaldoRestante}";
        }
    }
}

