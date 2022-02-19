using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaleFashion.cms.user.SanPham
{
    public partial class ChiTietSanPham : System.Web.UI.UserControl
    {
        private string image1 = "";
        private string image2 = "";
        private string image3 = "";
        private string sanphamID = "";
        private string tensanpham = "";
        public string giasanpham = "";
        public string rating = "";
        public string cRating = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idSanPham"] != null)
            {
                sanphamID = Request.QueryString["idSanPham"];
            }
            DataTable dt = new DataTable();
            dt = MaleFashion.App_Code.Database.SanPham.Lay_Thong_Tin_San_Pham(sanphamID);
            this.image1 = dt.Rows[0]["hinhanh"].ToString();
            this.image2 = dt.Rows[1]["hinhanh"].ToString();
            this.image3 = dt.Rows[2]["hinhanh"].ToString();
            this.tensanpham = dt.Rows[0]["ten"].ToString();
            this.giasanpham = dt.Rows[0]["giaban"].ToString();
            this.firstImage.Text += @"<div class='product__thumb__pic set-bg' data-setbg='img/product/" + image1 + @"'> </div>";
            this.secImage.Text += @"<div class='product__thumb__pic set-bg' data-setbg='img/product/" + image2 + @"'> </div>";
            this.thirstImage.Text += @"<div class='product__thumb__pic set-bg' data-setbg='img/product/" + image3 + @"'> </div>";
            this.productName.Text = "";
            this.productName.Text += @"<h4>" +tensanpham+ " </h4>";
        
            this.descript.Text=  dt.Rows[0]["mota"].ToString() ;
           dt = MaleFashion.App_Code.Database.SanPham.Lay_Size_San_Pham(sanphamID);
            this.fimage1.Text = @" <img src='img/product/" + image1 + "' alt=''>";
            this.fimage2.Text = @" <img src='img/product/" + image2 + "' alt=''>";
            this.fimage3.Text = @" <img src='img/product/" + image3 + "' alt=''>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string size = dt.Rows[i]["size"].ToString();
                this.sizeLiteral.Text += @" <label for='" + size + "'>" + size + "<input type='radio' id='" + size + "'></label> ";

            }

            HienThiSanPhamLienQuan();
            HienThiSaoVaSoBinhLuan();
            HienThiGiaSanPham();
            HienThiBinhLuan();
        }

        private void HienThiBinhLuan()
        {
            DataTable dt = MaleFashion.App_Code.Database.DanhGia.DanhSach_BinhLuan_CuaSanPham_ByID(sanphamID);
            if(dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataTable dt1 = MaleFashion.App_Code.Database.KhachHang.ThongTin_KhachHang_ByID(dt.Rows[i]["customerID"].ToString());

                    ltrBinhLuan.Text += @"
                    <div class='row'>
                        <img width='60' height='60' class='round' avatar='" + FormatName(dt1.Rows[0]["ten"]) + @"'>
                        <div class='col'>
                            <p style='font-weight:bold'>" + dt1.Rows[0]["ten"] + @" <span style='font-weight:normal'>  - " + FormatDate(dt.Rows[i]["ngaydanhgia"].ToString()) + @"</span></p>
                        <div class='rating'> ";
                    ltrBinhLuan.Text += HienThiSaoDanhGia(dt.Rows[0]["rate"]);

                    ltrBinhLuan.Text += @"           
                            <span>- Đã mua hàng</span>
                        </div>
                        <p>" + dt.Rows[0]["noidung"] + @"</p>
                        </div>
                    </div>
                    <div style='height:10px'></div>
                ";
                }
            } else
            {
                ltrBinhLuan.Text = " <p>Sản phẩm chưa có bình luận nào.</p> ";
            }
        }

        private void HienThiGiaSanPham()
        {
            DataTable dt = MaleFashion.App_Code.Database.GiamGiaSP.ThongTin_GiamGiaSanPham_ByIDSanPham(sanphamID);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["tien"].ToString() != "")
                {
                    int giamgia = int.Parse(dt.Rows[0]["tien"].ToString());
                    int giamoi = int.Parse(giasanpham) - giamgia;
                    price.Text += @"<h3>" + MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(giamoi) + " đ <span>" + MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(giasanpham) + " đ</span></h3>";
                }
            }
            else
            {
                price.Text += @"<h3>" + MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(giasanpham) + " đ</h3>";
            }
            dt = MaleFashion.App_Code.Database.DanhGia.Lay_Danh_Gia(sanphamID);
            if (dt.Rows[0]["danhgiaTB"] == null || dt.Rows[0]["danhgiaTB"].ToString() == "") {
                this.cRating = "0";
                this.rating = "0";
            }
                
           
        }

        private void HienThiSaoVaSoBinhLuan()
        {
            DataTable dt1 = MaleFashion.App_Code.Database.SanPham.ThongTin_SanPham_ByID(sanphamID);
            DataTable dt = MaleFashion.App_Code.Database.DanhGia.Dem_So_BinhLuan_CuaMotSanPham(sanphamID);

            ltrSaoDanhGia.Text += HienThiSaoDanhGia(dt1.Rows[0]["danhgia"]);
            ltrSaoDanhGia.Text += " <span>- " + dt.Rows[0]["soluong"] + " Bình luận</span> ";
        }

        private void HienThiSanPhamLienQuan()
        {
            DataTable dt1 = MaleFashion.App_Code.Database.SanPham.ThongTin_SanPham_ByID(sanphamID);
            DataTable dt = MaleFashion.App_Code.Database.SanPham.Lay_SanPham_LienQuan(sanphamID, dt1.Rows[0]["loaisanphamID"].ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dt2 = MaleFashion.App_Code.Database.HinhAnh.ThongTin_AnhDaiDien_ByIDSanPham(dt.Rows[i]["sanphamID"].ToString());

                ltrSanPhamLienQuan.Text += @"
                <div class='col-lg-3 col-md-6 col-sm-6 col-sm-6'>
                    <div class='product__item'>
                        <a href='/Default.aspx?modul=SanPham&modulphu=ChiTietSanPham&idSanPham=" + dt.Rows[i]["sanphamID"] + @"'>
                            <div class='product__item__pic set-bg' data-setbg='img/product/" + dt2.Rows[0]["hinhanh"] + @"'>
                            </div>
                        </a>
                        <div class='product__item__text'>
                            <h6>" + dt.Rows[i]["ten"] + @"</h6>
                            <a href = '/Default.aspx?modul=SanPham&modulphu=ChiTietSanPham&idSanPham=" + dt.Rows[i]["sanphamID"] + @"' class='add-cart'>+ Xem chi tiết</a>
                            <div class='rating'> ";
                ltrSanPhamLienQuan.Text += HienThiSaoDanhGia(dt.Rows[i]["danhgia"]);
                ltrSanPhamLienQuan.Text += @"
                            </div> ";
                ltrSanPhamLienQuan.Text += HienThiGia(dt.Rows[i]["giaban"], dt.Rows[i]["sanphamID"]);
                ltrSanPhamLienQuan.Text += @"
                        </div>
                    </div>
                </div> ";
            }
        }

        private string HienThiSaoDanhGia(object star)
        {
            string result = "";
            int n = int.Parse(star.ToString());
            for (int i = 1; i <= 5; i++)
            {
                if (i <= n)
                {
                    result += @"<i class='fa fa-star yellowstar'></i> ";
                }
                else
                {
                    result += @"<i class='fa fa-star-o yellowstar'></i> ";
                }
            }
            return result;
        }

        private string FormatDate(string date1)
        {
            string[] arrListStr = date1.Split(' ');
            string[] arrListStr1 = arrListStr[0].Split('/');
            return arrListStr1[1] + "/" + arrListStr1[0] + "/" + arrListStr1[2];
        }

        private string FormatName(object name)
        {
            string n = name.ToString();
            string[] arrListStr = n.Split(' ');
            if (arrListStr.Length > 2)
            {
                return arrListStr[1] + " " + arrListStr[2];
            }
            return name.ToString();
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