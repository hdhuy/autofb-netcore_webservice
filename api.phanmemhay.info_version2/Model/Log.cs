using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.phanmemhay.info_version2.Model
{
    public class Log
    {
        public int Id { get; set; }
        public string KetQua { get; set; }
        public string Loai { get; set; }
        public string NoiDung { get; set; }
        public string Mac { get; set; }
        public string Ip { get; set; }
        public string Uuid { get; set; }
        public string TenThietBi { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public int? NhanVienID { get; set; }
    }
}
