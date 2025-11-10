using System;
using Sync.Core;
using Sync.Erp;
using Sync.Marketplace;
using Xunit;

namespace Sync.Tests {
    public class SyncTests {
        [Fact]
        public void Executar_Retorna_Logs_Erp() {
            var erp = new SyncErpFlow();
            var s = erp.Executar(new Scope { Name = "erp" });
            Assert.Contains("ERP Sync", s.Logs[0]);
        }

        [Fact]
        public void Marketplace_Adiciona_Metricas() {
            var mp = new SyncMarketplaceFlow();
            var s2 = mp.Executar(new Scope { Name = "mp" });
            Assert.Contains("Métricas enviadas", string.Join(" | ", s2.Logs));
        }
    }
}
