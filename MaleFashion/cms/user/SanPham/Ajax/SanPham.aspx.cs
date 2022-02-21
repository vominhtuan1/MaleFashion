using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaleFashion.cms.user.SanPham.Ajax
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string thaotac = "";
        private string idKhachHang = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ThaoTac"] != null)
            {
                thaotac = Request.Params["ThaoTac"];
            }
            if (Session["IdKhachHang"] == null)
            {
                Response.Redirect("/DangNhap.aspx");
            }
            else
            {
                idKhachHang = Session["IdKhachHang"].ToString();

                switch (thaotac)
                {
                    case "ThemVaoGioHang":
                        ThemVaoGioHang();
                        break;
                    case "CapNhapSoLuongVaoGio":
                        CapNhapSoLuongVaoGio();
                        break;
                    case "LayTongTien":
                        LayTongTien();
                        break;
                    case "ApDungGiamGia":
                        ApDungGiamGia();
                        break;
                    case "ThanhToan":
                        ThanhToan();
                        break;
                    case "XoaSanPhamTrongGio":
                        XoaSanPhamTrongGio();
                        break;
                }

            }
        }

        private void XoaSanPhamTrongGio()
        {
            string giohangID = "";
            string chitietspID = "";
            if (Request.Params["giohangID"] != null)
            {
                giohangID = Request.Params["giohangID"];
            }
            if (Request.Params["chitietspID"] != null)
            {
                chitietspID = Request.Params["chitietspID"];
            }
            MaleFashion.App_Code.Database.GioHang.Xoa_SanPham_TrongGio(giohangID, chitietspID);
            Response.Write("1");
        }

        private void ThanhToan()
        {
            string ghichu = "";
            string sdt = "";
            string diachi = "";
            string codegiamgia = "";
            string idgiamgia = "";
            if (Request.Params["ghichu"] != null)
            {
                ghichu = Request.Params["ghichu"];
            }
            if (Request.Params["sdt"] != null)
            {
                sdt = Request.Params["sdt"];
            }
            if (Request.Params["diachi"] != null)
            {
                diachi = Request.Params["diachi"];
            }
            if (Request.Params["codegiamgia"] != null)
            {
                codegiamgia = Request.Params["codegiamgia"];
            }
            string baygio = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DataTable dt = MaleFashion.App_Code.Database.GiamGiaDonHang.ThongTin_GiamGia_ChoDonHang_ByCode(codegiamgia);
            if (dt.Rows.Count > 0)
            {
                idgiamgia = dt.Rows[0]["giamgiaID"].ToString();
            }
            MaleFashion.App_Code.Database.HoaDon.Tao_DonHang(idKhachHang, baygio, sdt, ghichu, diachi, idgiamgia);
            DataTable dt1 = MaleFashion.App_Code.Database.HoaDon.LayIDHoaDon(idKhachHang, baygio);
            DataTable dt2 = MaleFashion.App_Code.Database.GioHang.Lay_ChiTietGioHang_ByIDKhachHang(idKhachHang);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                int gia = 0;
                DataTable dt3 = MaleFashion.App_Code.Database.SanPham.LayIDSanPham_ByIDChiTietSP(dt2.Rows[i]["chitietspID"].ToString());
                DataTable dt4 = MaleFashion.App_Code.Database.GiamGiaSP.ThongTin_GiamGiaSanPham_ByIDSanPham(dt3.Rows[0]["sanphamID"].ToString());
                if (dt4.Rows.Count > 0)
                {
                    if (dt4.Rows[0]["tien"] != null)
                    {
                        gia = int.Parse(dt3.Rows[0]["giaban"].ToString()) - int.Parse(dt4.Rows[0]["tien"].ToString());
                    }
                    else
                    {
                        gia = int.Parse(dt3.Rows[0]["giaban"].ToString()) * (100 - int.Parse(dt4.Rows[0]["phantram"].ToString())) / 100;
                    }
                }
                MaleFashion.App_Code.Database.ChiTietDonHang.Them_ChiTietDonHang(dt1.Rows[0]["hoadonID"].ToString(), dt2.Rows[i]["chitietspID"].ToString(),
                    dt2.Rows[i]["soluong"].ToString(), gia.ToString());
            }
            MaleFashion.App_Code.Database.GioHang.Delete_ChiTietGioHang(dt2.Rows[0]["giohangID"].ToString());
            Response.Write("1");
        }

        private void ApDungGiamGia()
        {
            string code = "";
            if (Request.Params["code"] != null)
            {
                code = Request.Params["code"];
            }
            DataTable dt = MaleFashion.App_Code.Database.GiamGiaDonHang.ThongTin_GiamGia_ChoDonHang_ByCode(code);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["tien"].ToString() != "")
                {
                    Response.Write(MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(dt.Rows[0]["tien"].ToString()));
                }
                else
                {
                    DataTable dt1 = MaleFashion.App_Code.Database.GioHang.LayIDGioHang_ByIdKhachHang(idKhachHang);
                    DataTable dt2 = MaleFashion.App_Code.Database.GioHang.TinhTongTien(dt1.Rows[0]["giohangID"].ToString());
                    int giamgia = int.Parse(dt2.Rows[0]["tongtien"].ToString()) * int.Parse(dt.Rows[0]["phantram"].ToString()) / 100;
                    Response.Write(MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(giamgia));
                }
            }
            else
            {
                Response.Write("Mã giảm giá không tồn tại.");
            }


        }

        private void LayTongTien()
        {
            DataTable dt = MaleFashion.App_Code.Database.GioHang.LayIDGioHang_ByIdKhachHang(idKhachHang);
            DataTable dt1 = MaleFashion.App_Code.Database.GioHang.TinhTongTien(dt.Rows[0]["giohangID"].ToString());
            string tongtien = MaleFashion.App_Code.FormatNumber.ConvertTonVietNamCurrency(dt1.Rows[0]["tongtien"]);
            Response.Write(tongtien);
        }

        private void CapNhapSoLuongVaoGio()
        {
            string idsp = "";
            string sl = "";
            string size = "";
            if (Request.Params["idsp"] != null)
            {
                idsp = Request.Params["idsp"];
            }
            if (Request.Params["sl"] != null)
            {
                sl = Request.Params["sl"];
            }
            if (Request.Params["size"] != null)
            {
                size = Request.Params["size"];
            }

            switch (size)
            {
                case "1":
                    size = "M";
                    break;
                case "2":
                    size = "L";
                    break;
                case "3":
                    size = "XL";
                    break;
                case "4":
                    size = "2XL";
                    break;
                case "5":
                    size = "3XL";
                    break;
                default:

                    break;
            }

            DataTable dt = MaleFashion.App_Code.Database.ChiTietSanPham.LayIDChiTietSP_ByIDSanPham_VaSize(idsp, size);
            DataTable dt1 = MaleFashion.App_Code.Database.GioHang.LayIDGioHang_ByIdKhachHang(idKhachHang);
            MaleFashion.App_Code.Database.GioHang.CapNhap_SoLuong_TrongGio(dt1.Rows[0]["giohangID"].ToString(), dt.Rows[0]["chitietspID"].ToString(), sl);
            Response.Write("1");
        }

        private void ThemVaoGioHang()
        {
            string idSanPham = "";
            string qty = "";
            string size = "";
            if (Request.Params["idSanPham"] != null)
            {
                idSanPham = Request.Params["idSanPham"];
            }
            if (Request.Params["qty"] != null)
            {
                qty = Request.Params["qty"];
            }
            if (Request.Params["size"] != null)
            {
                size = Request.Params["size"];
            }
            DataTable dt = MaleFashion.App_Code.Database.ChiTietSanPham.LayIDChiTietSP_ByIDSanPham_VaSize(idSanPham, size);
            MaleFashion.App_Code.Database.GioHang.Tao_GioHang(idKhachHang);
            DataTable dt1 = MaleFashion.App_Code.Database.GioHang.LayIDGioHang_ByIdKhachHang(idKhachHang);
            MaleFashion.App_Code.Database.GioHang.Them_SanPham_VaoGio(dt1.Rows[0]["giohangID"].ToString(), dt.Rows[0]["chitietspID"].ToString(), qty);
            DataTable dt2 = MaleFashion.App_Code.Database.GioHang.DemSoLuong_SanPham_TrongGio(dt1.Rows[0]["giohangID"].ToString());
            Response.Write(dt2.Rows[0]["sosanpham"].ToString());

        }
    }
}