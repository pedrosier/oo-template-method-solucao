using System;
using Pedidos.Core;
using Pedidos.Nacional;
using Pedidos.Internacional;
using Xunit;

namespace Pedidos.Tests {
    public class PedidosTests {
        [Fact]
        public void Fluxo_Processar_Tem_Orquestrador_Publico() {
            var p = new Pedido { Id = "1" };
            p.Itens.Add(new PedidoItem { Sku = "A", Quantidade = 2, Preco = 10m });
            var proc = new PedidoNacionalProcessor();
            var res = proc.Processar(p);
            Assert.NotNull(res);
            Assert.Contains("CONFIRMAÇÃO", res.Confirmacao.ToUpper());
        }

        [Fact]
        public void Internacional_Eh_Sealed_Nacional_Nao() {
            Assert.True(typeof(PedidoInternacionalProcessor).IsSealed);
            Assert.False(typeof(PedidoNacionalProcessor).IsSealed);
        }
    }
}
