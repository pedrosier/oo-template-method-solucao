using System.Collections.Generic;
namespace Importacao.Core {
    public class Registro {
        public string Linha { get; }
        public string[] Campos { get; }
        public Registro(string linha) {
            Linha = linha;
            Campos = linha?.Split(';') ?? new string[0];
        }
    }
}
