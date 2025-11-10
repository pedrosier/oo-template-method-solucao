namespace Pagamento.Core {
    public class PagamentoPedido {
        public string Id { get; set; }
        public decimal Subtotal { get; set; }
        public string ClienteDocumento { get; set; }
    }
    public class ResultadoPagamento {
        public bool Sucesso { get; set; }
        public decimal Total { get; set; }
        public string Recibo { get; set; }
    }
}
