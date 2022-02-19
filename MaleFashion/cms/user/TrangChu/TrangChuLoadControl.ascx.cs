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
                    ltrSanPham.Text += @"
                        <div class='col-lg-3 col-md-6 col-sm-6 col-md-6 col-sm-6 mix " + a + @"'>
                            <div class='product__item'>
                                    <a href='/Default.aspx?modul=SanPham&modulphu=ChiTietSanPham&idSanPham=" + dt.Rows[i]["sanphamID"] + @"'>
                                    <div class='product__item__pic set-bg' data-setbg='img/product/" + dt.Rows[i]["hinhanh"] + @"'>
                                            <span class='label'>New</span>
                                    </div>
                                    </a>
                   
                                <div class='product__item__text'>
                                    <h6>" + dt.Rows[i]["ten"] + @"</h6>
                                    <a href='#' class='add-cart'>+ Xem chi tiết</a>
                                    <div class='rating'> ";
                                    ltrSanPham.Text += HienThiSaoDanhGia(dt.Rows[i]["danhgia"]);
                                ltrSanPham.Text += @"
                                    </div> ";
                                ltrSanPham.Text += HienThiGia(dt.Rows[i]["giaban"], dt.Rows[i]["sanphamID"]);
                                ltrSanPham.Text += @"
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
        private string HienThiGia(object gia, object sanphamID)
        {
            string result = "";
            DataTable dt = MaleFashion.App_Code.Database.GiamGiaSP.ThongTin_GiamGiaSanPham_ByIDSanPham(sanphamID.ToString());
            if (dt.Rows.Count == 0)
            {
                result = @" <h5>" + MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(gia) + @" đ</h5> ";
            }
            else
            {
                int giamoi = int.Parse(gia.ToString());
                if (dt.Rows[0]["phantram"].ToString() != "")
                {
                    int phantram = int.Parse(dt.Rows[0]["phamtram"].ToString());
                    giamoi = giamoi * (100 - phantram) / 100;
                }
                else
                {
                    int tien = int.Parse(dt.Rows[0]["tien"].ToString());
                    giamoi = giamoi - tien;
                }
                result = @"
                    <div class='row' style='margin:0'>
                        <h5 style='text-decoration: line-through; font-size:13px; margin-right:10px; align-self:flex-end; padding-bottom:1px'>" + MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(gia) + @" đ</h5>
                        <h5>" + MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(giamoi) + @" đ</h5>
                    </div>
                ";
            }
            return result;
        }
    }
}