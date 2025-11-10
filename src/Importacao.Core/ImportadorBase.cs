using System;
using System.Collections.Generic;
using System.IO;
namespace Importacao.Core {
    public abstract class ImportadorBase {
        // máximo 3 ganchos: ValidarRegistro (abstract), PosConsolidacao (virtual), (we keep only these)
        public Relatorio Executar(string caminho) {
            var rel = new Relatorio();
            using(var sr = new StreamReader(caminho)) {
                string linha;
                while((linha = sr.ReadLine()) != null) {
                    rel.RegistrosLidos++;
                    var reg = new Registro(linha);
                    var erros = ValidarRegistro(reg);
                    if (erros != null && erros.Count>0) rel.Erros.AddRange(erros);
                }
            }
            Consolidar(rel);
            PosConsolidacao(rel);
            return rel;
        }

        protected virtual void Consolidar(Relatorio rel) {
            // default simple pass-through. concrete may rely on TotaisPorCategoria being updated in PosConsolidacao
        }

        protected abstract List<string> ValidarRegistro(Registro r);
        protected virtual void PosConsolidacao(Relatorio rel) { /* no-op by default */ }
    }
}
