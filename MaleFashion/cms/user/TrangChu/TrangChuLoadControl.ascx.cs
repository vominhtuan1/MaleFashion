using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaleFashion.cms.user.Home
{
    public partial class HomeLoadControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LaySaPham();
            }
        }

        private void LaySaPham()
        {
            DataTable dt = new DataTable();
            dt = MaleFashion.App_Code.Database.SanPham.ThongTin_RanDom_Sp_Ten_GiaBan_TrangThai_DanhGia_HinhAnh();
            if(dt.Rows.Count > 0)
            {
                string a = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if(i % 2 == 0)
                    {
                        a = "new-arrivals";
                    }
                    else
                    {
                        a = "hot-sales";
                    }
                    ltrSanPham.Text += @"<div class='col-lg-3 col-md-6 col-sm-6 col-md-6 col-sm-6 mix " + a + @"'>
                <div class='product__item'>
                    <div class='product__item__pic set-bg' data-setbg='img/product/" + dt.Rows[i]["hinhanh"] + @"'>
                             <span class='label'>New</span>
                    </div>
                    <div class='product__item__text'>
                        <h6>" + dt.Rows[i]["ten"] + @"</h6>
                        <a href='#' class='add-cart'>+ Xem chi tiết</a>
                        <div class='rating'> ";
                        ltrSanPham.Text += HienThiSaoDanhGia(dt.Rows[i]["danhgia"]);
                        ltrSanPham.Text += @"
                        </div>
                        <h5>" + MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(dt.Rows[i]["giaban"]) + @" đ</h5>
                    </div>
                </div>
            </div>";
                }
            }
        }
        private string HienThiSaoDanhGia(object star)
        {
            string result = "";
            int n = int.Parse(star.ToString());
            for(int i = 1; i<=5; i++)
            {
                if(i <= n)
                {
                    result += @"<i class='fa fa-star yellowstar'></i> ";
                } else
                {
                    result += @"<i class='fa fa-star-o'></i> ";
                }
            }
            return result;
        }
    }
}