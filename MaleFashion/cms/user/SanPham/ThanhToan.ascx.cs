using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaleFashion.cms.user.SanPham
{
    public partial class ThanhToan : System.Web.UI.UserControl
    {
        private string idKhachHang = "";
        private string codegiamgia = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdKhachHang"] == null)
            {
                Response.Redirect("/DangNhap.aspx");
            } else
            {
                idKhachHang = Session["IdKhachHang"].ToString();
            }
            if(Request.QueryString["codegiamgia"] != null)
            {
                codegiamgia = Request.QueryString["codegiamgia"];
            }
            LayThongTinKhachHang();
        }

        private void LayThongTinKhachHang()
        {
            DataTable dt = MaleFashion.App_Code.Database.KhachHang.ThongTin_KhachHang_ByID(idKhachHang);
            tbxHoTen.Text = dt.Rows[0]["ten"].ToString();
            tbxSoDienThoai.Text = dt.Rows[0]["sdt"].ToString();
            tbxDiaChi.Text = dt.Rows[0]["diachi"].ToString();
        }
    }
}