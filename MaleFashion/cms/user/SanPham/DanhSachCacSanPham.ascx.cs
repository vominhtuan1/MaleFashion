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
        private string sapxep = "";
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
            if (Request.QueryString["sapxep"] != null)
            {
                sapxep = Request.QueryString["sapxep"];
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
            if (sapxep == "ASC" || sapxep == "")
            {
                ltrSelection.Text = @"
                    <select>
                        <option>thấp đến cao</option>
                        <option>cao xuống thấp</option>
                    </select>";
            }
            else
            {
                ltrSelection.Text = @"
                    <select>
                        <option>cao xuống thấp</option>
                        <option>thấp đến cao</option>
                    </select>";
            }
        }

        private void LayFilterPrice()
        {
            
            string link = "/Default.aspx?modul=SanPham";
            if (loaispID != "")
            {
                link += "&loaispID=" + loaispID;
            }
            if (sapxep != "")
            {
                link += "&sapxep=" + sapxep;
            }
            
            if(giadau == "")
            {
                ltrFilterPrice.Text += @"
                <li><a href='" + link + @"&giadau=0&giacuoi=200000'>0 - 200.000đ</a></li>
                <li><a href='" + link + @"&giadau=200000&giacuoi=300000'>200.000đ - 300.000đ</a></li>
                <li><a href='" + link + @"&giadau=300000&giacuoi=400000'>300.000đ - 400.000đ</a></li>
                <li><a href='" + link + @"&giadau=400000&giacuoi=500000'>400.000đ - 500.000đ</a></li>
                ";
            } else if( giadau == "0")
            {
                ltrFilterPrice.Text += @"
                <li><a href='" + link + @"&giadau=0&giacuoi=200000' style='color:black'>0 - 200.000đ</a></li>
                <li><a href='" + link + @"&giadau=200000&giacuoi=300000'>200.000đ - 300.000đ</a></li>
                <li><a href='" + link + @"&giadau=300000&giacuoi=400000'>300.000đ - 400.000đ</a></li>
                <li><a href='" + link + @"&giadau=400000&giacuoi=500000'>400.000đ - 500.000đ</a></li>
                ";
            } else if(giadau == "200000")
            {
                ltrFilterPrice.Text += @"
                <li><a href='" + link + @"&giadau=0&giacuoi=200000' >0 - 200.000đ</a></li>
                <li><a href='" + link + @"&giadau=200000&giacuoi=300000' style='color:black'>200.000đ - 300.000đ</a></li>
                <li><a href='" + link + @"&giadau=300000&giacuoi=400000'>300.000đ - 400.000đ</a></li>
                <li><a href='" + link + @"&giadau=400000&giacuoi=500000'>400.000đ - 500.000đ</a></li>
                ";
            } else if (giadau == "300000")
            {
                ltrFilterPrice.Text += @"
                <li><a href='" + link + @"&giadau=0&giacuoi=200000' >0 - 200.000đ</a></li>
                <li><a href='" + link + @"&giadau=200000&giacuoi=300000'>200.000đ - 300.000đ</a></li>
                <li><a href='" + link + @"&giadau=300000&giacuoi=400000' style='color:black'>300.000đ - 400.000đ</a></li>
                <li><a href='" + link + @"&giadau=400000&giacuoi=500000'>400.000đ - 500.000đ</a></li>
                ";
            }
            else if (giadau == "400000")
            {
                ltrFilterPrice.Text += @"
                <li><a href='" + link + @"&giadau=0&giacuoi=200000' >0 - 200.000đ</a></li>
                <li><a href='" + link + @"&giadau=200000&giacuoi=300000'>200.000đ - 300.000đ</a></li>
                <li><a href='" + link + @"&giadau=300000&giacuoi=400000'>300.000đ - 400.000đ</a></li>
                <li><a href='" + link + @"&giadau=400000&giacuoi=500000' style='color:black'>400.000đ - 500.000đ</a></li>
                ";
            }


        }

        private void LaySanPham()
        {
            DataTable dt = new DataTable();


            if (tranghientai == "")
            {
                dt = MaleFashion.App_Code.Database.SanPham.ThongTin_Loc_SanPham_Paginate(loaispID, giadau, giacuoi, "1", "9", sapxep);
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
                dt = MaleFashion.App_Code.Database.SanPham.ThongTin_Loc_SanPham_Paginate(loaispID, giadau, giacuoi, tudong.ToString(), dendong.ToString(), sapxep);
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
                                <a href='/Default.aspx?modul=ChiTietSanPham&idSP=" + dt.Rows[i]["sanphamID"] + @"' class='add-cart'>+ Xem chi tiết</a>
                                <div class='rating'> ";
                                ltrProducts.Text += HienThiSaoDanhGia(dt.Rows[i]["danhgia"]);
                ltrProducts.Text += @"
                                </div> ";
                ltrProducts.Text += HienThiGia(dt.Rows[i]["giaban"], dt.Rows[i]["sanphamID"]);

                ltrProducts.Text += @"</div>
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
            if (sapxep != "")
            {
                link += "&sapxep=" + sapxep;
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
                if (sapxep != "")
                {
                    link += "&sapxep=" + sapxep;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (loaispID != "" && int.Parse(loaispID) == i + 1)
                    {
                        ltrCategories.Text += @"<li><a href='" + link + "&loaispID=" + dt.Rows[i]["loaisanphamID"] + @"' style='color:black'>" + dt.Rows[i]["tenloaisp"] + @"</a></li>";
                    }
                    else
                    {
                        ltrCategories.Text += @"<li><a href='" + link + "&loaispID=" + dt.Rows[i]["loaisanphamID"] + @"'>" + dt.Rows[i]["tenloaisp"] + @"</a></li>";
                    }
                }
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
                    result += @"<i class='fa fa-star-o'></i> ";
                }
            }
            return result;
        }
        private string HienThiGia( object gia, object sanphamID)
        {
            string result = "";
            DataTable dt = MaleFashion.App_Code.Database.GiamGiaSP.ThongTin_GiamGiaSanPham_ByIDSanPham(sanphamID.ToString());
            if(dt.Rows.Count == 0)
            {
                result = @" <h5>" + MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(gia) + @" đ</h5> ";
            } else
            {
                int giamoi = int.Parse(gia.ToString());
                if(dt.Rows[0]["phantram"].ToString() != "") 
                {
                    int phantram = int.Parse(dt.Rows[0]["phamtram"].ToString());
                    giamoi = giamoi * (100 - phantram) / 100;
                } else
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