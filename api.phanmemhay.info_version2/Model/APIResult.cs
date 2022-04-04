using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.phanmemhay.info_version2.Model
{
    public class APIResult
    {
        public APIResult(bool Ok,string ThongBao)
        {
            this.Ok = Ok;
            this.ThongBao = ThongBao;
        }
        public bool Ok { get; set; }
        public string ThongBao { get; set; }
        public string TenKhachHang { get; set; }
        public DateTime HanDung { get; set; }
        public string DuLieu { get; set; }
    }
}
