using System;
namespace Pagamento.Core {
    public abstract class PaymentFlow {
        public ResultadoPagamento Processar(PagamentoPedido p) {
            ValidarPedido(p);
            var impostos = CalcularImpostos(p);
            AntesDeRegistrar(p, p.Subtotal, impostos);
            var total = p.Subtotal + impostos;
            var resultado = RegistrarPagamento(p, total);
            AposRegistrar(resultado);
            resultado.Recibo = FormatarRecibo(resultado);
            return resultado;
        }

        protected virtual void ValidarPedido(PagamentoPedido p) {
            if (p == null) throw new ArgumentNullException(nameof(p));
            if (p.Subtotal < 0) throw new ArgumentException("Subtotal inválido");
        }

        protected virtual ResultadoPagamento RegistrarPagamento(PagamentoPedido p, decimal total) {
            // Simula transação
            return new ResultadoPagamento { Sucesso = true, Total = total };
        }

        protected abstract decimal CalcularImpostos(PagamentoPedido p);
        protected abstract string FormatarRecibo(ResultadoPagamento resultado);
        protected virtual void AntesDeRegistrar(PagamentoPedido p, decimal subtotal, decimal impostos) { /* no-op */ }
        protected virtual void AposRegistrar(ResultadoPagamento resultado) { /* no-op */ }
    }
}
