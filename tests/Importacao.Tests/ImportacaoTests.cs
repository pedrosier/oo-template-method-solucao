using System;
using System.IO;
using Importacao.Alunos;
using Xunit;

namespace Importacao.Tests {
    public class ImportacaoTests {
        [Fact]
        public void Fluxo_TemplateMethod_Executar_Publico() {
            var imp = new ImportacaoAlunos();
            // cria arquivo temporário
            File.WriteAllLines("tmp_alunos.csv", new[]{ "Ana;1;CS", "Bob;2;EE" });
            var rel = imp.Executar("tmp_alunos.csv");
            Assert.Equal(2, rel.RegistrosLidos);
            Assert.True(rel.TotaisPorCategoria.ContainsKey("AlunosLidos"));
            Assert.Equal(rel.RegistrosLidos, rel.TotaisPorCategoria["AlunosLidos"]);
        }

        [Fact]
        public void Ganchos_Protected_Quantidade_Valida() {
            var t = typeof(Importacao.Core.ImportadorBase);
            var methods = t.GetMethods(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            int hooks = 0;
            foreach(var m in methods) {
                if(m.IsFamily && (m.IsAbstract || m.IsVirtual)) hooks++;
            }
            Assert.InRange(hooks, 1, 3); // espera entre 1 e 3 hooks
        }
    }
}
