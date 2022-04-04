using api.phanmemhay.info_version2.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace api.phanmemhay.info_version2.Data
{
    public class JsonCache : IJsonCache
    {
        private Dictionary<string, string> jsons = new Dictionary<string, string>();
        public string GetJson(string madichvu)
        {
            if (jsons.ContainsKey(madichvu))
            {
                return jsons[madichvu];
            }
            string currFolder = Directory.GetCurrentDirectory();
            string path = Path.Combine(currFolder, "JsonFile", madichvu + ".json");
            string jsonData = FileExt.LoadFile(path);
            if (jsonData != null)
            {
                jsons.Add(madichvu, jsonData);
            }
            return jsonData;
        }
    }
}
