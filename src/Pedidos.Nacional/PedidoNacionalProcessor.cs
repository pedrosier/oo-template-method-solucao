using System;
using Pedidos.Core;
namespace Pedidos.Nacional {
    public class PedidoNacionalProcessor : PedidoProcessor {
        protected override decimal CalcularFrete(Pedido p) {
            // frete fixo por item
            decimal baseFrete = 5m;
            int totalQuantidade = 0;
            foreach(var it in p.Itens) totalQuantidade += it.Quantidade;
            return baseFrete * totalQuantidade;
        }

        protected override string GerarConfirmacao(ResultadoProcessamento resultado) {
            return $"CONFIRMAÇÃO NACIONAL - Total: {resultado.Total:C} - Frete: {resultado.Frete:C}";
        }
    }
}
