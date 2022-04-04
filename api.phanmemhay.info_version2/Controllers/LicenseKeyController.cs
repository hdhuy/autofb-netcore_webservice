using api.phanmemhay.info_version2.Data;
using api.phanmemhay.info_version2.Extensions;
using api.phanmemhay.info_version2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.phanmemhay.info_version2.Controllers
{
    [ApiController]
    public class LicenseKeyController : Controller
    {
        public ISqlTransacter _SqlTransacter { get; set; }
        public IJsonCache _JsonCache { get; set; }
        public LicenseKeyController(ISqlTransacter SqlTransacter, IJsonCache JsonCache)
        {
            this._SqlTransacter = SqlTransacter;
            this._JsonCache = JsonCache;
        }
        [HttpPost]
        [Route("v1/[controller]/checklicensekey")]
        public APIResult CheckLicenseKey(ClientLogin client)
        {
            APIResult result = new APIResult(false, "Đăng nhập thất bại !");
            try
            {
                if (string.IsNullOrEmpty(client.LicenseKey))
                {
                    return result;
                }
                //string guidStr = EncodeExt.Decrypt(client.LicenseKey);
                Guid ClientGuid = ConvertExt.ConvertStringToGuid(client.LicenseKey);
                if (ClientGuid == Guid.Empty || ClientGuid == null || ClientGuid.ToString() == string.Empty)
                {
                    result.ThongBao = $"LicenseKey sai định dạng !";
                    return result;
                }
                string query =
                    $"SELECT d.MaDichVu, d.Khoa as KhoaDichVu, L.* FROM LicenseKey L "
                    + " JOIN DichVu d on L.DichVuID = d.Id "
                    + $" where l.LicenseKey ='{ClientGuid}'";
                Dictionary<string, object> data = _SqlTransacter.QueryForObject(query);
                if (data == null)
                {
                    result.ThongBao = $"LicenseKey sai !";
                    return result;
                }
                DateTime HanDung = (DateTime)data["HanDung"];
                if (HanDung.Date < DateTime.Now.Date)
                {
                    result.ThongBao = $"LicenseKey đã hết hạn sử dụng ({HanDung.Date.ToString("dd-MM-yyyy")})! Hãy liên hệ với admin";
                    return result;
                }
                if (data["KhoaDichVu"] != null && (bool)data["KhoaDichVu"] == true)
                {
                    result.ThongBao = $"Dịch vụ này tạm thời ngừng cung cấp !";
                    return result;
                }
                string MaDichVu = data["MaDichVu"].ToString();
                if (MaDichVu != client.MaDichVu)
                {
                    result.ThongBao = $"Sai dịch vụ !";
                    return result;
                }
                if (data["Khoa"] != null && (bool)data["Khoa"] == true)
                {
                    result.ThongBao = $"LicenseKey đã bị khóa hoặc chưa được duyệt ! Hãy liên hệ với admin";
                    return result;
                }

                if (data["Uuid"] == null || data["Uuid"].ToString() == string.Empty)
                {
                    string updateUuid = $"update LicenseKey set Uuid='{client.Uuid}' "
                        + $", TenThietBi = N'{client.TenThietBi}'"
                        + $", Mac = '{client.Mac}'"
                        + $", LanDungDau = getdate()"
                        +
                        $" where LicenseKey = '{ClientGuid}'";

                    _SqlTransacter.Query(updateUuid);
                }
                else
                {
                    string Uuid = data["Uuid"].ToString();
                    if (client.Uuid != Uuid)
                    {
                        result.ThongBao = $"Thiết bị chưa được đăng ký";
                        return result;
                    }
                }
                string TenKhachHang = string.Empty;
                if (data["TenKhachHang"] != null)
                {
                    TenKhachHang = data["TenKhachHang"].ToString();
                }

                //dang nhap thanh cong
                result = DangNhapThanhCong(MaDichVu, HanDung, TenKhachHang);
            }
            catch (Exception ex)
            {
                result.ThongBao = $"Lỗi dữ liệu !";
                LogExt.WriteLog(ex.ToString());
            }
            finally
            {
                LogHanhDong(result, client, "Post Đăng nhập LicenseKey");
            }
            return result;
        }
        private APIResult DangNhapThanhCong(string MaDichVu, DateTime HanDung, string TenKhachHang)
        {
            APIResult result = new APIResult(true, "Đăng nhập thành công !");
            result.DuLieu = _JsonCache.GetJson(MaDichVu);
            result.HanDung = HanDung;
            result.TenKhachHang = TenKhachHang;
            return result;
        }
        private void LogHanhDong(APIResult result, ClientLogin client, string loai)
        {
            try
            {
                string ketqua = string.Empty;
                if (result.Ok)
                {
                    ketqua = "Thành công";
                }
                else
                {
                    ketqua = "Thất bại";
                }

                string sql = " INSERT INTO[dbo].[LogAction]"
                  + " ([KetQua]"
                  + " ,[Loai]"
                  + " ,[NoiDung]"
                  + " ,[Mac]"
                  + " ,[Ip]"
                  + " ,[Uuid]"
                  + " ,[TenThietBi]"
                  + " ,[ThoiGianTao]"
                  + ",[NhanVienID])"
                  + "VALUES("
                  + $"   N'{ketqua}'"
                  + $" , N'{loai}'"
                  + $" , N'{result.ThongBao}'"
                  + $" , '{client.Mac}'"
                  + $" , null"
                  + $" , '{client.Uuid}'"
                  + $" , N'{client.TenThietBi}'"
                  + $" , getdate()"
                  + $" , null )";

                _SqlTransacter.Query(sql);
            }
            catch
            {

            }
        }
    }
}
