using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaleFashion.cms.user.TrangCaNhan
{
    public partial class ChiTietDonHangLoadControl : System.Web.UI.UserControl
    {
        private string idKhachHang = "";
        private string idDonHang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idKhachHang"] != "")
            {
                idKhachHang = Request.QueryString["idKhachHang"];
            }
            if (Request.QueryString["idDonHang"] != "")
            {
                idDonHang = Request.QueryString["idDonHang"];
            }
            if (!IsPostBack)
            {
                LayThongTinNguoiNhan();
                LayThongTinDonHang();
                LayThongTinTongTien();
            }
            ltrTrangCaNhan.Text = "<a href='/Default.aspx?modul=TrangCaNhan&idKhachHang=" + idKhachHang + "'>Trang cá nhân</a>";
        }

        private void LayThongTinTongTien()
        {
            DataTable dt = MaleFashion.App_Code.Database.HoaDon.ThongTin_TongTien_ByIDHoaDon(idDonHang);
            DataTable dt1 = MaleFashion.App_Code.Database.HoaDon.ThongTin_DonHang_ByIDHoaDon(idDonHang);

            if (dt1.Rows[0]["giamgiaID"].ToString() == "")
            {
                ltrTongTien.Text = @"
                    <li>Tổng giá trị sản phẩm <span>" + MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(dt.Rows[0]["tongtien"].ToString()) + @" đ</span></li>
                    <li>Giảm giá <span>0 đ</span></li>
                    <li>Thành tiền <span>" + MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(dt.Rows[0]["tongtien"]) + @" đ</span></li>
                ";
            }
            else
            {
                DataTable dt4 = MaleFashion.App_Code.Database.GiamGiaDonHang.ThongTin_GiamGia_ChoDonHang_ByID(dt1.Rows[0]["giamgiaID"].ToString());
                if (dt4.Rows[0]["tien"].ToString() != "")
                {
                    int thanhtien = int.Parse(dt.Rows[0]["tongtien"].ToString()) - int.Parse(dt4.Rows[0]["tien"].ToString());
                    ltrTongTien.Text = @"
                    <li>Tổng giá trị sản phẩm <span>" + MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(dt.Rows[0]["tongtien"].ToString()) + @" đ</span></li>
                    <li>Giảm giá <span>" + MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(dt4.Rows[0]["tien"]) + @" đ</span></li>
                    <li>Thành tiền <span>" + MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(thanhtien) + @" đ</span></li>
                ";
                }
                else
                {
                    int tongtien = int.Parse(dt.Rows[0]["tongtien"].ToString());
                    int thanhtien = int.Parse(dt.Rows[0]["tongtien"].ToString()) * (100 - int.Parse(dt4.Rows[0]["phantram"].ToString())) / 100;
                    int giamgia = tongtien - thanhtien;
                    ltrTongTien.Text = @"
                    <li>Tổng giá trị sản phẩm <span>" + MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(dt.Rows[0]["tongtien"].ToString()) + @" đ</span></li>
                    <li>Giảm giá <span>"+ MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(giamgia) + @" đ</span></li>
                    <li>Thành tiền <span>" + MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(thanhtien) + @" đ</span></li>
                ";
                }
            }
        }

        private void LayThongTinDonHang()
        {
            DataTable dt = MaleFashion.App_Code.Database.HoaDon.ThongTin_SanPham_CuaDonHang_ByIDHoaDon(idDonHang);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dt1 = MaleFashion.App_Code.Database.HinhAnh.ThongTin_AnhDaiDien_ByIDSanPham(dt.Rows[i]["sanphamID"].ToString());
                DataTable dt2 = MaleFashion.App_Code.Database.SanPham.ThongTin_TenSP_ByID(dt.Rows[i]["sanphamID"].ToString());


                ltrSanPhamCuaDonHang.Text += @"
                    <tr>
                        <td class='product__cart__item'>
                            <div class='product__cart__item__pic'>
                                <img src='img/product/" + dt1.Rows[0]["hinhanh"] + @"' alt='' style='max-width:90px; max-height:90px'>
                            </div>
                            <div class='product__cart__item__text'>
                                <h6>" + dt2.Rows[0]["ten"] + @"</h6>
                                <h5>" + MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(dt.Rows[i]["giaSP"]) + @" đ</h5>
                            </div>
                        </td>
                        <td class='cart__price'>" + dt.Rows[i]["soluong"] + @"</td>
                        <td class='cart__price'>" +
                            MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(int.Parse(dt.Rows[i]["giaSP"].ToString()) * int.Parse(dt.Rows[i]["soluong"].ToString()))
                            + @" đ</td> ";


                ltrSanPhamCuaDonHang.Text += CheckTrangThai(dt.Rows[0]["sanphamID"]);

                ltrSanPhamCuaDonHang.Text += @" </tr>";
            }
        }

        public string CheckTrangThai(object sanphamid)
        {
            string result = "";
            DataTable dt = MaleFashion.App_Code.Database.HoaDon.ThongTin_DonHang_ByIDHoaDon(idDonHang);
            if(dt.Rows[0]["trangthai"].ToString() == "Đã giao hàng")
            {
                ltrCotDanhGia.Text = " <th></th> ";
                result = @" <td class='cart__price'>
                            <div class='continue__btn'>
                                <a href='javascript:DanhGiaSanPham(" + idKhachHang + @", " + sanphamid + @")' style='cursor:pointer;padding: 10px 10px;text-transform: none;'>Đánh giá</a>
                            </div>
                        </td> ";
            } else
            {
                ltrCotDanhGia.Text = "";
            }
            return result;
        }

        private void LayThongTinNguoiNhan()
        {
            DataTable dt = MaleFashion.App_Code.Database.HoaDon.ThongTin_DonHang_ByIDHoaDon(idDonHang);
            DataTable dt1 = MaleFashion.App_Code.Database.KhachHang.ThongTin_KhachHang_ByID(idKhachHang);

            ltrThongTinCaNhan.Text = @"
                <div class='row'>
                    <div class='col-lg-4'>
                        <p>Mã đơn hàng</p>
                    </div>
                    <div class='col-lg-8'>
                        <p>: MF" + dt.Rows[0]["hoadonID"] + @"</p>
                    </div>
                </div>
                <div class='row'>
                    <div class='col-lg-4'>
                        <p>Họ và tên</p>
                    </div>
                    <div class='col-lg-8'>
                        <p>: " + dt1.Rows[0]["ten"] + @"</p>
                    </div>
                </div>
                <div class='row'>
                    <div class='col-lg-4'>
                        <p>Điện thoại</p>
                    </div>
                    <div class='col-lg-8'>
                        <p>: " + dt.Rows[0]["std"] + @"</p>
                    </div>
                </div>
                <div class='row'>
                    <div class='col-lg-4'>
                        <p>Địa chỉ</p>
                    </div>
                    <div class='col-lg-8'>
                        <p>: " + dt.Rows[0]["diachi"] + @"</p>
                    </div>
                </div>
                <div class='row'>
                    <div class='col-lg-4'>
                        <p>Ghi chú</p>
                    </div>
                    <div class='col-lg-8'>
                        <p>: " + dt.Rows[0]["ghichu"] + @"</p>
                    </div>
                </div>
            ";
        }
    }
}