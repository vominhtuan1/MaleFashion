using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaleFashion.cms.user.TrangCaNhan
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        private string idKhachHang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idKhachHang"] != null)
            {
                idKhachHang = Request.QueryString["idKhachHang"];
            }
            if (!IsPostBack)
            {
                LayThongTinKhachHang();
                LayNutCapNhap();
            }
        }

        private void LayNutCapNhap()
        {
            ltrNutCapNhap.Text = @"
                <div class='continue__btn'>
                    <a href='javascript:CapNhapThongTin(" + idKhachHang + @")' style='cursor: pointer'>Lưu thay đổi</a>
                </div>";
        }

        private void LayThongTinKhachHang()
        {
            DataTable dt = MaleFashion.App_Code.Database.KhachHang.ThongTin_KhachHang_ByID(idKhachHang);
            tbxHoTen.Text = dt.Rows[0]["ten"].ToString();
            tbxDiaChi.Text = dt.Rows[0]["diachi"].ToString();
            tbxSoDienThoai.Text = dt.Rows[0]["sdt"].ToString();
        }

    }
}