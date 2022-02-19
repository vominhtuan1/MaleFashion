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
            this.price.Text += @"<h3>"+giasanpham+"</h3>";
            this.descript.Text=  dt.Rows[0]["mota"].ToString() ;
           dt = MaleFashion.App_Code.Database.SanPham.Lay_Size_San_Pham(sanphamID);
            this.fimage1.Text = @" <img src='img/product/" + image1 + "' alt=''>";
            this.fimage2.Text = @" <img src='img/product/" + image2 + "' alt=''>";
            this.fimage3.Text = @" <img src='img/product/" + image3 + "' alt=''>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string size = dt.Rows[i]["size"].ToString();
                this.sizeLiteral.Text += @" <label for='"+size+"'>"+size+"<input type='radio' id='"+size+"'></label> ";

            }
            dt = MaleFashion.App_Code.Database.DanhGia.Lay_Danh_Gia(sanphamID);
            if (dt.Rows[0]["danhgiaTB"] == null || dt.Rows[0]["danhgiaTB"].ToString() == "") {
                this.cRating = "0";
                this.rating = "0";
            }
                
            this.coutRating.Text = @" <span>- "+this.cRating+" Reviews</span>";
            float vote = float.Parse(rating);
            this.displayStar.Text = "";
            if (vote > 1) this.displayStar.Text += @" <i class='fa fa-star''></i>";
            else this.displayStar.Text += @" <i class='fa fa-star-o''></i>";
            if (vote > 2) this.displayStar.Text += @" <i class='fa fa-star''></i>";
            else this.displayStar.Text += @" <i class='fa fa-star-o''></i>";
            if (vote > 3) this.displayStar.Text += @" <i class='fa fa-star''></i>";
            else this.displayStar.Text += @" <i class='fa fa-star-o''></i>";
            if (vote > 4) this.displayStar.Text += @" <i class='fa fa-star''></i>";
            else this.displayStar.Text += @" <i class='fa fa-star-o''></i>";
            if (vote > 5) this.displayStar.Text += @" <i class='fa fa-star''></i>";
            else this.displayStar.Text += @" <i class='fa fa-star-o''></i>";


        }
    }
}