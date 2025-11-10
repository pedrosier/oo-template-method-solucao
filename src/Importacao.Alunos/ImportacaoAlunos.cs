using System;
using System.Collections.Generic;
using Importacao.Core;
namespace Importacao.Alunos {
    public class ImportacaoAlunos : ImportadorBase {
        protected override List<string> ValidarRegistro(Registro r) {
            var erros = new List<string>();
            if (r.Campos.Length < 3) {
                erros.Add($"Linha inválida (campos insuficientes): {r.Linha}");
                return erros;
            }
            var nome = r.Campos[0];
            var matricula = r.Campos[1];
            var curso = r.Campos[2];
            if (string.IsNullOrWhiteSpace(nome)) erros.Add($"Nome vazio: {r.Linha}");
            if (string.IsNullOrWhiteSpace(matricula)) erros.Add($"Matrícula vazia: {r.Linha}");
            // curso optional
            return erros;
        }

        protected override void PosConsolidacao(Relatorio rel) {
            base.PosConsolidacao(rel);
            // Exemplo: contabiliza número de registros por categoria fictícia "Alunos"
            rel.TotaisPorCategoria["AlunosLidos"] = rel.RegistrosLidos;
        }
    }
}
