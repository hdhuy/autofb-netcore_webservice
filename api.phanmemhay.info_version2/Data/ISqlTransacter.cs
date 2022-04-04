using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.phanmemhay.info_version2.Data
{
    public interface ISqlTransacter
    {
        public int Insert(Dictionary<string, object> dic, string action = "insert");
        public int Update(Dictionary<string, object> dic, string action = "update");
        public bool Delete(int Id);
        public Dictionary<string, object> QueryForObject(string query);
        public List<Dictionary<string, object>> QueryForList(string query);
        public bool Query(string query);
    }
}
