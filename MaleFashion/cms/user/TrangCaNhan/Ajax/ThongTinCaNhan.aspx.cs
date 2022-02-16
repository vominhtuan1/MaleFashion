using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaleFashion.cms.user.TrangCaNhan.Ajax
{
    public partial class ThongTinCaNha : System.Web.UI.Page
    {
        private string thaotac = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ThaoTac"] != null)
            {
                thaotac = Request.Params["ThaoTac"];
            }
            switch (thaotac)
            {
                case "LuuThongTinCaNhan":
                    LuuThongTinCaNhan();
                    break;
                case "DanhGiaSanPham":
                    DanhGiaSanPham();
                    break;
            }
        }

        private void DanhGiaSanPham()
        {
            string idKhachHang = "";
            string idSanPham = "";
            string star = "";
            string binhluan = "";
            if (Request.Params["idKhachHang"] != null)
            {
                idKhachHang = Request.Params["idKhachHang"];
            }
            if (Request.Params["idSanPham"] != null)
            {
                idSanPham = Request.Params["idSanPham"];
            }
            if (Request.Params["star"] != null)
            {
                star = Request.Params["star"];
            }
            if (Request.Params["binhluan"] != null)
            {
                binhluan = Request.Params["binhluan"];
            }
            MaleFashion.App_Code.Database.DanhGia.Them_DanhGia_SanPham(idSanPham, idKhachHang, star, binhluan);
            MaleFashion.App_Code.Database.SanPham.CapNhap_Sao_ChoSanPham(idSanPham);
            Response.Write("1");

        }

        private void LuuThongTinCaNhan()
        {
            string id = "";
            string ten = "";
            string sdt = "";
            string diachi = "";
            if (Request.Params["id"] != null)
            {
                id = Request.Params["id"];
            }
            if (Request.Params["ten"] != null)
            {
                ten = Request.Params["ten"];
            }
            if (Request.Params["sdt"] != null)
            {
                sdt = Request.Params["sdt"];
            }
            if (Request.Params["diachi"] != null)
            {
                diachi = Request.Params["diachi"];
            }
            MaleFashion.App_Code.Database.KhachHang.CapNhap_ThongTin_KhachHang(id, ten, sdt, diachi);
            Response.Write("1");
        }
    }
}