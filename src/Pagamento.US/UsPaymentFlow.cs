using System;
using Pagamento.Core;
namespace Pagamento.US {
    public class UsPaymentFlow : PaymentFlow {
        protected override decimal CalcularImpostos(PagamentoPedido p) {
            // exemplo: 8% imposto
            return p.Subtotal * 0.08m;
        }

        protected override string FormatarRecibo(ResultadoPagamento resultado) {
            return $"RECEIPT US - Total: {resultado.Total} USD";
        }

        protected override void AntesDeRegistrar(PagamentoPedido p, decimal subtotal, decimal impostos) {
            base.AntesDeRegistrar(p, subtotal, impostos);
            // log de compliance (simulado)
        }
    }
}
