using System;
using System.Linq;
namespace Pedidos.Core {
    public abstract class PedidoProcessor {
        public ResultadoProcessamento Processar(Pedido p) {
            ValidarItens(p);
            ReservarEstoque(p);
            var frete = CalcularFrete(p);
            var total = CalcularTotal(p, frete);
            PersistirPedido(p, total);
            var resultado = new ResultadoProcessamento { Total = total, Frete = frete };
            resultado.Confirmacao = GerarConfirmacao(resultado);
            return resultado;
        }

        protected virtual void ValidarItens(Pedido p) {
            if (p == null) throw new ArgumentNullException(nameof(p));
            if (p.Itens == null || p.Itens.Count==0) throw new InvalidOperationException("Pedido sem itens");
        }

        protected virtual void ReservarEstoque(Pedido p) {
            // default: no-op reservation simulation
        }

        protected decimal CalcularTotal(Pedido p, decimal frete) {
            decimal subtotal = p.Itens.Sum(i => i.Preco * i.Quantidade);
            return subtotal + frete;
        }

        protected virtual void PersistirPedido(Pedido p, decimal total) {
            // no-op: persist simulation
        }

        protected abstract decimal CalcularFrete(Pedido p);
        protected abstract string GerarConfirmacao(ResultadoProcessamento resultado);
        protected virtual void AposReservaEstoque(Pedido p) { /* no-op */ }
    }
}
