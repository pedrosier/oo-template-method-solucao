using System;
namespace Sync.Core {
    public abstract class SyncProcessor {
        public SyncStatus Executar(Scope s) {
            var status = new SyncStatus();
            var bruto = ColetarBruto(s);
            var reconciliado = Normalizar(bruto);
            AplicarDiferencas(reconciliado, status);
            PosAplicacao(status);
            status.Logs.Add(GerarRelatorio(status));
            return status;
        }

        protected virtual DataSet Normalizar(DataSet bruto) {
            // simples passagem
            return bruto;
        }

        protected virtual void AplicarDiferencas(DataSet ds, SyncStatus status) {
            // simula aplicação
            status.Inseridos += ds.Rows.Count;
        }

        protected abstract DataSet ColetarBruto(Scope escopo);
        protected abstract string GerarRelatorio(SyncStatus status);
        protected virtual void PosAplicacao(SyncStatus status) { /* no-op */ }
    }
}
