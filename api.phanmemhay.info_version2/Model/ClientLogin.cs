using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.phanmemhay.info_version2.Model
{
    public class ClientLogin
    {
        public string LicenseKey { get; set; }
        public string MaDichVu { get; set; }
        public string TenThietBi { get; set; }
        public string Mac { get; set; }
        public string Uuid { get; set; }
    }
}
