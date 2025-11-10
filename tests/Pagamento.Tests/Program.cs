using System;
using Pagamento.Core;
using Pagamento.BR;
using Pagamento.US;
namespace Pagamento.Tests {
    class Program {
        static void Main() {
            var p = new PagamentoPedido { Id="p1", Subtotal=100m };
            var br = new BrPaymentFlow();
            var r = br.Processar(p);
            Console.WriteLine(r.Recibo);
            var us = new UsPaymentFlow();
            var r2 = us.Processar(p);
            Console.WriteLine(r2.Recibo);
        }
    }
}
