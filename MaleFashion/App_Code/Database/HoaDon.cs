using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace MaleFashion.App_Code.Database
{
    public class HoaDon
    {
        /// <summary>
        /// Hàm đếm có bao nhiêu sản phẩm của 1 đơn hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable SoSanPham_CuaDonHang_ByHoaDonID(string id)
        {
            string sql = @"select count(*) as soluong from chitiethoadon where hoadonID = " + id + "";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
        /// <summary>
        /// Hàm lấy thông tin danh sach đơn hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable ThongTin_DanhSach_DonHang_ByIDKhachHang(string id)
        {
            string sql = @"select *  from hoadon where customerID = " + id + " order by ngaythanhtoan DESC";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
        /// <summary>
        /// Hàm lây tên sản phẩm đầu tiên của đơn hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable ThongTin_TenSPDauTienCuaDonHang_ByIDHoaDon(string id)
        {
            string sql = @"
                select ten 
                from sanpham as m,chitietSP as q, (select top(1) *  from chitiethoadon where hoadonID = " + id + @") as p 
                where q.chitietspID = p.chitietspID and m.sanphamID = q.sanphamID";

            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
        /// <summary>
        /// Hàm tính tổng tiền của đơn hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable ThongTin_TongTien_ByIDHoaDon(string id)
        {
            string sql = @"
                select sum(soluong*giaSP) as tongtien from chitiethoadon where hoadonID = " + id + "";

            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
        /// <summary>
        /// hàm lấy thông tin người nhận của hóa đơn theo id hóa đơn
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable ThongTin_DonHang_ByIDHoaDon(string id)
        {
            string sql = @"select * from hoadon where hoadonID = " + id + "";

            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
        public static DataTable ThongTin_SanPham_CuaDonHang_ByIDHoaDon(string id)
        {
            string sql = @"
                select q.sanphamID, p.giaSP, p.soluong from 
                chitiethoadon as p, chitietSP as q 
                where p.chitietspID = q.chitietspID and p.hoadonID = " + id + "";

            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
    }
}