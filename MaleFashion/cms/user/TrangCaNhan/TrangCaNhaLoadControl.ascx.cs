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
                LayDanhSachDonHang();
            }
        }

        private void LayDanhSachDonHang()
        {
            DataTable dt = MaleFashion.App_Code.Database.HoaDon.ThongTin_DanhSach_DonHang_ByIDKhachHang(idKhachHang);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataTable dt1 = MaleFashion.App_Code.Database.HoaDon.ThongTin_TenSPDauTienCuaDonHang_ByIDHoaDon(dt.Rows[i]["hoadonID"].ToString());
                    DataTable dt2 = MaleFashion.App_Code.Database.HoaDon.SoSanPham_CuaDonHang_ByHoaDonID(dt.Rows[i]["hoadonID"].ToString());
                    DataTable dt3 = MaleFashion.App_Code.Database.HoaDon.ThongTin_TongTien_ByIDHoaDon(dt.Rows[i]["hoadonID"].ToString());

                    ltrDanhDachDonHang.Text += @"
                        <div class='checkout__input'>
                            <div>
                                <h5>" + (i + 1) + @".  <span>MF" + dt.Rows[i]["hoadonID"] + @" ngày </span>" + FormatDate(dt.Rows[i]["ngaythanhtoan"].ToString()) + @"
                                </h5>
                                <p>
                                    <span>" + dt1.Rows[0]["ten"] + @"";
                    if((int.Parse(dt2.Rows[0]["soluong"].ToString()) - 1) != 0)
                    {
                        ltrDanhDachDonHang.Text += @"... và " + (int.Parse(dt2.Rows[0]["soluong"].ToString()) - 1) + @" sản phẩm khác";
                    }
                    ltrDanhDachDonHang.Text += @"</span>
                                </p>
                                <p class='mb-0'>
                                    Tổng hóa đơn: <b>" + MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(dt3.Rows[0]["tongtien"]) + @" đ</b> / Thành tiền: <b>"; 
                    if(dt.Rows[i]["giamgiaID"].ToString() == "")
                    {
                        ltrDanhDachDonHang.Text += MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(dt3.Rows[0]["tongtien"]);
                    } else
                    {
                        //xử lý sau
                    }
                    
                    ltrDanhDachDonHang.Text += @" đ</b>
                                </p>
                                <p class='mb-0'>Phương thức thanh toán: <b>" + dt.Rows[i]["ptthanhtoan"] + @"</b></p>
                                <p class='font-weight-light mb-2'>Tình trạng đơn hàng: <mark>" + dt.Rows[i]["trangthai"] + @"</mark></p>
                                <div class='alert alert-primary' role='alert'>
                                    <a href='/Default.aspx?modul=DonHang&idKhachHang=" + idKhachHang + @"&idDonHang=" + dt.Rows[i]["hoadonID"] + @"'>Xem chi tiết</a>
                                </div>

                            </div>
                        </div>";
                }
            } else
            {
                ltrDanhDachDonHang.Text = "<p>Bạn chưa có đơn hàng nào. Hãy tiếp tục mua sắm.</p>";
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

        private string FormatDate(string date1)
        {
            string[] arrListStr = date1.Split(' ');
            string[] arrListStr1 = arrListStr[0].Split('/');
            return arrListStr1[1] + "/" + arrListStr1[0] + "/" + arrListStr1[2];
        }
    }
}