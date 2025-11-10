using System.Collections.Generic;
namespace Sync.Core {
    public class Scope {
        public string Name { get; set; }
    }
    public class SyncStatus {
        public int Inseridos { get; set; }
        public int Atualizados { get; set; }
        public List<string> Logs { get; } = new List<string>();
    }
    public class DataSet {
        public List<Dictionary<string,string>> Rows { get; } = new List<Dictionary<string,string>>();
    }
}
