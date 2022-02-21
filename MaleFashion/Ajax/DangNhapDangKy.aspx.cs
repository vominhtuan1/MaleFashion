using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaleFashion.Ajax
{
    public partial class DangNhapDangKy : System.Web.UI.Page
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
                case "DangNhap":
                    DangNhap();
                    break;
                case "DangKy":
                    DangKy();
                    break;
            }
        }

        private void DangKy()
        {
            string taikhoan = "";
            string matkhau = "";
            string hoten = "";
            string sdt = "";
            string diachi = "";
            if (Request.Params["taikhoan"] != null)
            {
                taikhoan = Request.Params["taikhoan"];
            }
            if (Request.Params["matkhau"] != null)
            {
                matkhau = Request.Params["matkhau"];
            }
            if (Request.Params["hoten"] != null)
            {
                hoten = Request.Params["hoten"];
            }
            if (Request.Params["sdt"] != null)
            {
                sdt = Request.Params["sdt"];
            }
            if (Request.Params["diachi"] != null)
            {
                diachi = Request.Params["diachi"];
            }
            DataTable dt = MaleFashion.App_Code.Database.KhachHang.LayThongTin_KhachHang_ByTaiKhoan(taikhoan);
            if(dt.Rows.Count > 0)
            {
                Response.Write("2");
            } else
            {
                MaleFashion.App_Code.Database.KhachHang.Tao_KhachHang(taikhoan, matkhau, hoten, sdt, diachi);
                DataTable dt1 = MaleFashion.App_Code.Database.KhachHang.LayThongTin_KhachHang_ByTaiKhoan(taikhoan);
                Session["IdKhachHang"] = dt1.Rows[0]["customerID"].ToString();
                Response.Write("1");
            }
        }

        private void DangNhap()
        {
            string taikhoan = "";
            string matkhau = "";
            if (Request.Params["taikhoan"] != null)
            {
                taikhoan = Request.Params["taikhoan"];
            }
            if (Request.Params["matkhau"] != null)
            {
                matkhau = Request.Params["matkhau"];
            }
            DataTable dt = MaleFashion.App_Code.Database.KhachHang.LayThongTin_KhachHang_ByTaiKhoan_MatKhau(taikhoan, matkhau);
            if(dt.Rows.Count > 0)
            {
                Session["IdKhachHang"] = dt.Rows[0]["customerID"].ToString();
                Response.Write("1");
            }
            else
            {
                Response.Write("2");
            }
        }
    }
}