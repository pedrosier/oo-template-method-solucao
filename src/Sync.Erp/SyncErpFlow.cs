using System;
using Sync.Core;
namespace Sync.Erp {
    public sealed class SyncErpFlow : SyncProcessor {
        protected override DataSet ColetarBruto(Scope escopo) {
            var ds = new DataSet();
            ds.Rows.Add(new System.Collections.Generic.Dictionary<string,string>{{"sku","ERP-1"},{"name","Produto ERP"}});
            return ds;
        }

        protected override string GerarRelatorio(SyncStatus status) {
            return $"ERP Sync - Inseridos: {status.Inseridos}";
        }
    }
}
