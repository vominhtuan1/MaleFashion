using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace MaleFashion.App_Code.Database
{
    public class GioHang
    {
        /// <summary>
        /// Hàm tạo mới giỏ hàng
        /// </summary>
        /// <param name="idKhachHang"></param>
        public static void Tao_GioHang(string idKhachHang)
        {
            DataTable dt = LayIDGioHang_ByIdKhachHang(idKhachHang);
            if (dt.Rows.Count == 0)
            {
                string sql = "insert into giohang (customerID) values (" + idKhachHang + ")";
                OleDbCommand cmd = new OleDbCommand(sql);
                cmd.CommandType = CommandType.Text;
                SQLDatabase.ExecuteNoneQuery(cmd);
            }
        }
        /// <summary>
        /// Hàm thêm sản phẩm vào giỏ
        /// </summary>
        /// <param name="giohangID"></param>
        /// <param name="chitetspID"></param>
        /// <param name="soluong"></param>
        public static void Them_SanPham_VaoGio(string giohangID, string chitetspID, string soluong)
        {
            DataTable dt = KiemTra_SanPhamDaCo_TrongGio(giohangID, chitetspID);
            string sql = "";
            if (dt.Rows.Count > 0)
            {
                int sl = int.Parse(soluong) + int.Parse(dt.Rows[0]["soluong"].ToString());

                sql = @"update chitietgiohang 
                        set soluong = " + sl.ToString() + @"
                        where giohangID = " + giohangID + @" and chitietspID = " + chitetspID + "";
            }
            else
            {
                sql = "insert into chitietgiohang(giohangID,chitietspID,soluong) values (" + giohangID + "," + chitetspID + "," + soluong + ")";
            }
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }
        /// <summary>
        /// hàm lấy id giỏ hàng bằng id khách hàng
        /// </summary>
        /// <param name="idKhachHang"></param>
        /// <returns></returns>
        public static DataTable LayIDGioHang_ByIdKhachHang(string idKhachHang)
        {
            string sql = "select giohangID from giohang where customerID = " + idKhachHang + "";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idKhachHang"></param>
        /// <returns></returns>
        public static DataTable DemSoLuong_SanPham_TrongGio(string idgiohang)
        {
            string sql = "select sum(soluong) as sosanpham from chitietgiohang where giohangID = " + idgiohang + "";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable KiemTra_SanPhamDaCo_TrongGio(string idgiohang, string chitietspID)
        {
            string sql = "select * from chitietgiohang where giohangID = " + idgiohang + " and chitietspID = " + chitietspID + "";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
        /// <summary>
        /// Lấy sản phẩm trong giỏ hàng
        /// </summary>
        /// <param name="idgiohang"></param>
        /// <returns></returns>
        public static DataTable Lay_SanPham_TrongGio(string idgiohang)
        {
            string sql = @"select q.sanphamID, p.soluong, r.ten, r.giaban, q.size, p.chitietspID, p.giohangID
                            from chitietgiohang as p, chitietSP as q, sanpham as r
                            where p.chitietspID = q.chitietspID and q.sanphamID = r.sanphamID and p.giohangID = " + idgiohang + "";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
        /// <summary>
        /// cập nhập số lượng cho sản phẩm trong giỏ hàng
        /// </summary>
        /// <param name="idgiohang"></param>
        /// <param name="chitietspID"></param>
        /// <param name="soluong"></param>
        public static void CapNhap_SoLuong_TrongGio(string idgiohang, string chitietspID, string soluong)
        {
            string sql = @"update chitietgiohang 
                        set soluong = " + soluong + @"
                        where giohangID = " + idgiohang + @" and chitietspID = " + chitietspID + "";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }
        public static DataTable TinhTongTien(string idgiohang)
        {
            string sql = @"select sum(r.giaban*p.soluong) as tongtien
                            from chitietgiohang as p, chitietSP as q, sanpham as r
                            where p.chitietspID = q.chitietspID and q.sanphamID = r.sanphamID and p.giohangID = " + idgiohang + "";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
        public static void Delete_ChiTietGioHang(string idgiohang)
        {
            string sql = "delete from chitietgiohang where giohangID = " + idgiohang + "";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }
        public static DataTable Lay_ChiTietGioHang_ByIDKhachHang(string idkhachhang)
        {
            string sql = @"select p.giohangID, p.chitietspID, p.soluong from chitietgiohang as p, giohang as q
                        where p.giohangID = q.giohangID and q.customerID = " + idkhachhang + "";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
        public static void Xoa_SanPham_TrongGio(string idgiohang, string chitietspid)
        {
            string sql = "delete from chitietgiohang where chitietspID = " + chitietspid + " and giohangID = " + idgiohang + "";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }
    }
}