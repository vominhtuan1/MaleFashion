using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaleFashion.cms.user.SanPham
{
    public partial class GioHang : System.Web.UI.UserControl
    {
        string idKhachHang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdKhachHang"] == null)
            {
                Response.Redirect("/DangNhap.aspx");
            }
            else
            {
                idKhachHang = Session["IdKhachHang"].ToString();
                ltrthanhtien.Text = "0 đ";
                ltrtongtien.Text = "0 đ";
                LayThongTinGioHang();
                
            }
        }

        private void LayThongTinGioHang()
        {
            int tongtien = 0;
            DataTable dt = MaleFashion.App_Code.Database.GioHang.LayIDGioHang_ByIdKhachHang(idKhachHang);
            if (dt.Rows.Count > 0)
            {
                DataTable dt1 = MaleFashion.App_Code.Database.GioHang.Lay_SanPham_TrongGio(dt.Rows[0]["giohangID"].ToString());
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        DataTable dt2 = MaleFashion.App_Code.Database.HinhAnh.ThongTin_AnhDaiDien_ByIDSanPham(dt1.Rows[i]["sanphamID"].ToString());
                        DataTable dt3 = MaleFashion.App_Code.Database.GiamGiaSP.ThongTin_GiamGiaSanPham_ByIDSanPham(dt1.Rows[i]["sanphamID"].ToString());
                        string idinput = "sanpham_" + dt1.Rows[i]["sanphamID"].ToString() + "_" + dt1.Rows[i]["size"].ToString().Trim();
                        int giasp = 0;

                        if (dt3.Rows.Count > 0)
                        {
                            if (dt3.Rows[0]["tien"] != null)
                            {
                                giasp = int.Parse(dt1.Rows[i]["giaban"].ToString()) - int.Parse(dt3.Rows[0]["tien"].ToString());
                            }
                            else
                            {
                                giasp = int.Parse(dt1.Rows[i]["giaban"].ToString()) * (100 - int.Parse(dt3.Rows[0]["phantram"].ToString())) / 100;
                            }
                        }
                        else
                        {
                            giasp = int.Parse(dt1.Rows[i]["giaban"].ToString());
                        }

                        ltrSanPham.Text += @"
                            <tr >
                                <td class='product__cart__item'>
                                    <div class='product__cart__item__pic'>
                                        <img src = 'img/product/" + dt2.Rows[0]["hinhanh"] + @"' alt='' style='max-width:90px; max-height:90px'>
                                    </div>
                                    <div class='product__cart__item__text'>
                                        <h6>" + dt1.Rows[i]["ten"] + @"</h6>
                                        <h5>" + MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(giasp) + @" đ</h5>
                                    </div>
                                </td>
                                <td class='quantity__item'>
                                    <div class='quantity'>
                                        <div class='pro-qty-2'>
                                            <input type='text' value='" + dt1.Rows[i]["soluong"] + @"'  id='" + idinput + @"'>
                                        </div>
                                    </div>
                                </td>
                                <td class='cart__price'>" + dt1.Rows[i]["size"] + @"</td>
                                <td class='cart__price'>" + MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(int.Parse(dt1.Rows[i]["soluong"].ToString()) * giasp) + @" đ</td>
                                <td class='cart__close'><a href='javascript:XoaSanPham(" + dt1.Rows[i]["giohangID"] + @"," + dt1.Rows[i]["chitietspID"] + @")'><i class='fa fa-close'></i></a></td>
                                <td class='cart__close'><a href='javascript:CapNhapSoLuongVaoGioHang(" + dt1.Rows[i]["sanphamID"].ToString() + @"," + ConvertSizeM_L_XLtoInt(dt1.Rows[i]["size"]) + @")'><i class='fa fa-spinner'></i></a></td>
                            </tr>
                        ";
                        tongtien = int.Parse(dt1.Rows[i]["soluong"].ToString()) * giasp;
                    }
                    ltrtongtien.Text = MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(tongtien) + " đ";
                    ltrthanhtien.Text = ltrtongtien.Text;
                }
                else
                {
                    ltrtongtien.Text = "0 đ";
                    ltrthanhtien.Text = "0 đ";
                }
            }
        }
        private int ConvertSizeM_L_XLtoInt(object size)
        {
            int result = 0;
            string s = size.ToString().Trim();
            switch (s)
            {
                case "M":
                    result = 1;
                    break;
                case "L":
                    result = 2;
                    break;
                case "XL":
                    result = 3;
                    break;
                case "2XL":
                    result = 4;
                    break;
                case "3XL":
                    result = 5;
                    break;
            }
            return result;
        }
    }
}