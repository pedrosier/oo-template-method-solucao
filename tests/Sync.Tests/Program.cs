using System;
using Sync.Core;
using Sync.Erp;
using Sync.Marketplace;
namespace Sync.Tests {
    class Program {
        static void Main() {
            var erp = new SyncErpFlow();
            var s = erp.Executar(new Scope { Name = "erp" });
            Console.WriteLine(string.Join(" | ", s.Logs));
            var mp = new SyncMarketplaceFlow();
            var s2 = mp.Executar(new Scope { Name = "mp" });
            Console.WriteLine(string.Join(" | ", s2.Logs));
        }
    }
}
