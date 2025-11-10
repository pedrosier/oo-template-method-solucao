using System;
using Pagamento.Core;
using Pagamento.BR;
using Pagamento.US;
using Xunit;

namespace Pagamento.Tests {
    public class PagamentoTests {
        [Fact]
        public void Br_PaymentFlow_Recibo_Contain_Br() {
            var p = new PagamentoPedido { Id = "p1", Subtotal = 100m };
            var br = new BrPaymentFlow();
            var r = br.Processar(p);
            Assert.True(r.Sucesso);
            Assert.Contains("RECIBO", r.Recibo.ToUpper());
        }

        [Fact]
        public void Br_Eh_Sealed() {
            Assert.True(typeof(BrPaymentFlow).IsSealed);
        }
    }
}
