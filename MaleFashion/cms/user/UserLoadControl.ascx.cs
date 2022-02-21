using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaleFashion.cms.user
{
    public partial class UserLoadControl : System.Web.UI.UserControl
    {
        private string modul = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["modul"] != null)
            {
                modul = Request.QueryString["modul"];
            }
            switch (modul)
            {
                case "TrangChu":
                    plLoadControl.Controls.Add(LoadControl("TrangChu/TrangChuLoadControl.ascx"));
                    break;

                case "SanPham":
                    plLoadControl.Controls.Add(LoadControl("SanPham/SanPhamLoadControl.ascx"));
                    break;

                case "TrangCaNhan":
                    plLoadControl.Controls.Add(LoadControl("TrangCaNhan/TrangCaNhaLoadControl.ascx"));
                    break;

                case "DonHang":
                    plLoadControl.Controls.Add(LoadControl("TrangCaNhan/ChiTietDonHangLoadControl.ascx"));
                    break;

                case "ChiTietSanPham":
                    plLoadControl.Controls.Add(LoadControl("SanPham/ChiTietSanPham.ascx"));
                    break;

                case "GioHang":
                    plLoadControl.Controls.Add(LoadControl("SanPham/GioHang.ascx"));
                    break;

                case "ThanhToan":
                    plLoadControl.Controls.Add(LoadControl("SanPham/ThanhToan.ascx"));
                    break;

                default:
                    plLoadControl.Controls.Add(LoadControl("TrangChu/TrangChuLoadControl.ascx"));
                    break;
            }
        }
    }
}