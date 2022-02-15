using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaleFashion.cms.user.SanPham
{
    public partial class DanhSachCacSanPham : System.Web.UI.UserControl
    {
        int sotrang = 0;
        int soSptrongbang = 0;
        private string loaispID = "";
        private string giadau = "";
        private string giacuoi = "";
        private string tranghientai = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["loaispID"] != null)
            {
                loaispID = Request.QueryString["loaispID"];
            }
            if (Request.QueryString["giadau"] != null)
            {
                giadau = Request.QueryString["giadau"];
            }
            if (Request.QueryString["giacuoi"] != null)
            {
                giacuoi = Request.QueryString["giacuoi"];
            }
            if (Request.QueryString["tranghientai"] != null)
            {
                tranghientai = Request.QueryString["tranghientai"];
            }
            if (!IsPostBack)
            {
                LayLoaiSanPham();
                LayPaginate();
                LayFilterPrice();
                LaySanPham();
                LaySelect();
            }
        }

        private void LaySelect()
        {

        }

        private void LayFilterPrice()
        {
            string link = "/Default.aspx?modul=SanPham";
            if (loaispID != "")
            {
                link += "&loaispID=" + loaispID;
            }
            ltrFilterPrice.Text += @"
                <li><a href='" + link + @"&giadau=0&giacuoi=200000'>0 - 200.000đ</a></li>
                <li><a href='" + link + @"&giadau=200000&giacuoi=300000'>200.000đ - 300.000đ</a></li>
                <li><a href='" + link + @"&giadau=300000&giacuoi=400000'>300.000đ - 400.000đ</a></li>
                <li><a href='" + link + @"&giadau=400000&giacuoi=500000'>400.000đ - 500.000đ</a></li>
                ";
        }

        private void LaySanPham()
        {
            DataTable dt = new DataTable();
            

            if (tranghientai == "")
            {
                dt = MaleFashion.App_Code.Database.SanPham.ThongTin_Loc_SanPham_Paginate(loaispID, giadau, giacuoi, "1", "9", "");
            }
            else
            {
                int tudong = ((int.Parse(tranghientai) - 1) * 9) + 1;
                int dendong = 0;
                if (tranghientai == sotrang.ToString())
                {
                    dendong = soSptrongbang;
                }
                else
                {
                    dendong = tudong + 8;
                }
                dt = MaleFashion.App_Code.Database.SanPham.ThongTin_Loc_SanPham_Paginate(loaispID, giadau, giacuoi, tudong.ToString(), dendong.ToString(), "");
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ltrProducts.Text += @"
                       <div class='col-lg-4 col-md-6 col-sm-6'>
                          <div class='product__item'>
                            <div class='product__item__pic set-bg' data-setbg='img/product/" + dt.Rows[i]["hinhanh"] + @"'>
                            </div>
                            <div class='product__item__text'>
                                <h6>" + dt.Rows[i]["ten"] + @"</h6>
                                <a href='#' class='add-cart'>+ Add To Cart</a>
                                <div class='rating'>
                                    <i class='fa fa-star-o'></i>
                                    <i class='fa fa-star-o'></i>
                                    <i class='fa fa-star-o'></i>
                                    <i class='fa fa-star-o'></i>
                                    <i class='fa fa-star-o'></i>
                                </div>
                                <h5>" + dt.Rows[i]["giaban"] + @"</h5>
                            </div>
                        </div>
                    </div>";
            }
        }

        private void LayPaginate()
        {
            DataTable dt = new DataTable();
            dt = MaleFashion.App_Code.Database.SanPham.ThongTin_SL_SanPham(loaispID, giadau, giacuoi);
            soSptrongbang = 0;
            soSptrongbang = (int)dt.Rows[0]["soluong"];
            sotrang = soSptrongbang / 9;
            if (soSptrongbang % 9 != 0)
            {
                sotrang += 1;
            }
            string link = "/Default.aspx?modul=SanPham";
            if (loaispID != "")
            {
                link += "&loaispID=" + loaispID;
            }
            if (giadau != "" && giacuoi != "")
            {
                link += "&giadau=" + giadau + "&giacuoi=" + giacuoi;
            }

            for (int i = 0; i < sotrang; i++)
            {
                if (i == 0)
                {
                    if (tranghientai == "")
                    {
                        ltrPaginate.Text += @"<a class='active' href='" + link + "'>1</a>";
                    }
                    else
                    {
                        ltrPaginate.Text += @"<a href='" + link + "'>1</a>";
                    }
                }
                else
                {
                    if (tranghientai != "" && i + 1 == int.Parse(tranghientai))
                    {
                        ltrPaginate.Text += @"<a class='active' href='" + link + "&tranghientai=" + (i + 1) + "'>" + (i + 1) + "</a>";
                    }
                    else
                    {
                        ltrPaginate.Text += @"<a href='" + link + "&tranghientai=" + (i + 1) + "'>" + (i + 1) + "</a>";
                    }
                }
            }
        }

        private void LayLoaiSanPham()
        {
            DataTable dt = new DataTable();
            dt = MaleFashion.App_Code.Database.LoaiSanPham.ThongTin_LoaiSanPham();
            if (dt.Rows.Count > 0)
            {
                string link = "/Default.aspx?modul=SanPham";

                if (giadau != "" && giacuoi != "")
                {
                    link += "&giadau=" + giadau + "&giacuoi=" + giacuoi;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ltrCategories.Text += @"<li><a href='" + link + "&loaispID=" + dt.Rows[i]["loaisanphamID"] + @"'>" + dt.Rows[i]["tenloaisp"] + @"</a></li>";
                }
            }
        }

    }
}