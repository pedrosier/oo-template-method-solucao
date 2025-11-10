using System.Collections.Generic;
namespace Importacao.Core {
    public class Relatorio {
        public List<string> Erros { get; } = new List<string>();
        public int RegistrosLidos { get; set; }
        public Dictionary<string,int> TotaisPorCategoria { get; } = new Dictionary<string,int>();
    }
}
