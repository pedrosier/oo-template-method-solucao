using System;
using Pedidos.Core;
namespace Pedidos.Internacional {
    public sealed class PedidoInternacionalProcessor : PedidoProcessor {
        protected override decimal CalcularFrete(Pedido p) {
            // frete proporcional ao subtotal
            decimal subtotal = 0;
            foreach(var it in p.Itens) subtotal += it.Preco * it.Quantidade;
            return Math.Max(20m, subtotal * 0.15m);
        }

        protected override string GerarConfirmacao(ResultadoProcessamento resultado) {
            return $"INTERNATIONAL CONFIRMATION - Total: {resultado.Total} USD - Shipping: {resultado.Frete} USD";
        }

        protected override void AposReservaEstoque(Pedido p) {
            base.AposReservaEstoque(p);
            // adicionar rastreamento para internacional
            // Simulação: adiciona informação de rastreamento no destino (não exposta)
        }
    }
}
