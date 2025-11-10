using System.Collections.Generic;
namespace Pedidos.Core {
    public class Pedido {
        public string Id { get; set; }
        public List<PedidoItem> Itens { get; } = new List<PedidoItem>();
        public string Destino { get; set; } // ex: "BR" ou "US"
    }
    public class PedidoItem {
        public string Sku { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }
    public class ResultadoProcessamento {
        public decimal Total { get; set; }
        public decimal Frete { get; set; }
        public string Confirmacao { get; set; }
    }
}
