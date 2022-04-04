using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.phanmemhay.info_version2.JsonFile
{
    public class Xpath
    {
        public string txt_dadangnhap = "//*[contains(@name,'query')]";
        public string txt_name = "//*[contains(@name,'email')]";
        public string txt_pass = "//*[contains(@name,'pass')]";
        public string btn_dangnhap = "//*[contains(@name,'login')]";
        public string btn_dangnhap_luumk = "//button[contains(@data-sigil,'touchable password_login_button')]";
        public string btn_dangnhap_cosan = "//*[contains(@class,'_mDeviceLoginHomepage__userNameAndBadge')]";
        public string btn_DangNhap1Lan = "//button[contains(@class,'_54k8 _56bs _26vk _56b_ _56bw _56bu')]";

        public string article = "article";
        public string data_ft = "data-ft";
        public string top_level_post_id = "top_level_post_id";
        public string page_id = "page_id";
        public string group_id = "group_id";
        public string adid = "adid";
        public string a = "a";
        public string img = "img";
        public string src = "src";
        public string href = "href";
        public string data_gt = "data-gt";
        public string rel = "rel";
        public string content_owner_id_new = "content_owner_id_new";
        public string original_content_id = "original_content_id";
        public string txt_PhanBienImgVaEmoticon = "photo.php";
        public string viewfullsize = "photo/view_full_size/";
        public string aria_label = "aria-label";
        public string btn_dongthoigian = "//a[text()='Dòng thời gian']";
        public string btn_khac = "//a[text()='Khác']";
        public string btn_XemKichThuocDayDu = "//*[contains(@class,'sec')]";
        public string img_anhbia = "//*[contains(@id,'profile_cover_photo_container')]";
        public string btn_hienthithem_trang_mbasic = "//*[contains(@class,'i')]//a[text()='Hiển thị thêm']";
        public string btn_hienthithem_nhom_mbasic = "//*[contains(@id,'m_group_stories_container')]//div//a//span[text()='Xem thêm bài viết']";
        public string btn_hienthithem_user_mbasic = "//*[contains(@id,'structured_composer_async_container')]//div//a//span[text()='Xem tin khác']";
        public string btn_xemdaydu = "//a[@class='sec' and contains(text(),'Xem kích thước đầy đủ')]";
        public string txt_tatCaNoidungPost_mbasic = "//div[contains(@data-ft,'{\"tn\":\"*s\"}')]";
        public string div_HopChuaDSAnh_mbasic = "//div[contains(@data-ft,'{\"tn\":\"H\"}')]";
        public string div_LinkDinhKemNoiDungPost = "//a[contains(@rel,'noopener')]";

        public string div_anhbia_nhom_mfb = "//*[contains(@id,'groupMallNotices')]";
        public string div_anhbia_trang_mfb = "//*[contains(@id,'msite-pages-header-contents')]";
        public string div_anhbia_user_mfb = "//*[contains(@id,'m-timeline-cover-section')]";
        public string div_ghim_mfb = ".//*[contains(@class,'img _4q4l img _2sxw')]";
        //tự động comment
        public string div_form_comment = "//form[contains(@method,'post')]";
        public string txt_comment = "//*[contains(@name,'comment_text')]";
        public string img_comment = "//input[contains(@name,'photo')]";
        public string btn_comment = "//input[contains(@name,'post')]";
        public string div_comment_in_post = "//*[contains(@class,'dz')]";
        //tự động post
        public string txt_autopost_textbox = "//*[contains(@name,'xc_message')]";
        public string txt_autopost_img = "//input[contains(@name,'view_photo')]";
        public string txt_autopost_file1 = "//input[contains(@name,'file1')]";
        public string btn_autopost_addImg = "//*[contains(@name,'add_photo_done')]";
        public string btn_autopost_submit_1 = "//*[contains(@name,'view_post')]";
        public string btn_autopost_submit_2 = "//*[contains(@name,'view_post')]";
        //rep comment
        public string div_rep_comment = "//*[contains(@class,'_2a_i')]";
        public string div_rep_comment_url = "//a[contains(@class,'_2b0a')]";
        public string btn_rep_submit = "//*[contains(@name,'post')]";
        public string img_rep = "//input[contains(@name,'photo')]";
        public string txt_rep = "//*[contains(@name,'comment_text')]";
        //quet commemt
        public string div_cmt_body = "//*[contains(@data-sigil,'comment-body')]";
        public string class_name_nguoicmt = "_4kk6";
        public string class_name_replie = "_2b0a";
    }
}
