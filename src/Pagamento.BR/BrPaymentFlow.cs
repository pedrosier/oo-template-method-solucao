using System;
using Pagamento.Core;
namespace Pagamento.BR {
    public sealed class BrPaymentFlow : PaymentFlow {
        protected override decimal CalcularImpostos(PagamentoPedido p) {
            // exemplo: 12% de impostos
            return p.Subtotal * 0.12m;
        }

        protected override string FormatarRecibo(ResultadoPagamento resultado) {
            return $"RECIBO BR - Total: {resultado.Total:C} - Obrigado!";
        }
    }
}
