using System;
using System.Collections.Generic;
using Importacao.Core;
namespace Importacao.Produtos {
    public class ImportacaoProdutos : ImportadorBase {
        protected override List<string> ValidarRegistro(Registro r) {
            var erros = new List<string>();
            if (r.Campos.Length < 4) {
                erros.Add($"Linha inválida (campos insuficientes): {r.Linha}");
                return erros;
            }
            var sku = r.Campos[0];
            var descricao = r.Campos[1];
            if (string.IsNullOrWhiteSpace(sku)) erros.Add($"SKU vazio: {r.Linha}");
            if (string.IsNullOrWhiteSpace(descricao)) erros.Add($"Descrição vazia: {r.Linha}");
            // validar preço
            if (!decimal.TryParse(r.Campos[2], out var preco) || preco < 0) erros.Add($"Preço inválido: {r.Linha}");
            // categoria
            return erros;
        }
    }
}
