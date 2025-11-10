using System;
using Pedidos.Core;
using Pedidos.Nacional;
using Pedidos.Internacional;
namespace Pedidos.Tests {
    class Program {
        static void Main() {
            var p = new Pedido { Id = "1", Destino="BR" };
            p.Itens.Add(new PedidoItem{Sku="A", Quantidade=2, Preco=10});
            var proc = new PedidoNacionalProcessor();
            var res = proc.Processar(p);
            Console.WriteLine(res.Confirmacao);
            var pi = new Pedido { Id="2" };
            pi.Itens.Add(new PedidoItem{Sku="X", Quantidade=1, Preco=200});
            var intl = new PedidoInternacionalProcessor();
            var r2 = intl.Processar(pi);
            Console.WriteLine(r2.Confirmacao);
        }
    }
}
