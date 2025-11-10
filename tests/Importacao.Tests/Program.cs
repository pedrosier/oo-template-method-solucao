using System;
using System.IO;
using Importacao.Alunos;
using Importacao.Produtos;
namespace Importacao.Tests {
    class Program {
        static void Main() {
            Directory.CreateDirectory("tmp");
            File.WriteAllLines("tmp/alunos.csv", new[]{ "João;123;Engenharia", ";;" });
            var imp = new ImportacaoAlunos();
            var rel = imp.Executar("tmp/alunos.csv");
            Console.WriteLine($"Alunos lidos: {rel.RegistrosLidos}, Erros: {rel.Erros.Count}");
            File.WriteAllLines("tmp/produtos.csv", new[]{ "SKU1;Caneta;1.5;Material", "SKU2;;-5;Material" });
            var prod = new ImportacaoProdutos();
            var r2 = prod.Executar("tmp/produtos.csv");
            Console.WriteLine($"Produtos lidos: {r2.RegistrosLidos}, Erros: {r2.Erros.Count}");
        }
    }
}
