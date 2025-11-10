using System;
using Sync.Core;
namespace Sync.Marketplace {
    public class SyncMarketplaceFlow : SyncProcessor {
        protected override DataSet ColetarBruto(Scope escopo) {
            var ds = new DataSet();
            ds.Rows.Add(new System.Collections.Generic.Dictionary<string,string>{{"sku","MP-1"},{"name","Produto MP"}});
            return ds;
        }

        protected override string GerarRelatorio(SyncStatus status) {
            return $"Marketplace Sync - Inseridos: {status.Inseridos}";
        }

        protected override void PosAplicacao(SyncStatus status) {
            base.PosAplicacao(status);
            // Simula envio de métricas
            status.Logs.Add("Métricas enviadas para analytics");
        }
    }
}
