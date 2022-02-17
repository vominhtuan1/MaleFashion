using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace MaleFashion.App_Code.Database
{
    public class DanhGia
    {
        /// <summary>
        /// Hàm thêm mới đánh giá
        /// </summary>
        /// <param name="sanphamID"></param>
        /// <param name="khachhangID"></param>
        /// <param name="rate"></param>
        /// <param name="noidung"></param>
        public static void Them_DanhGia_SanPham(string sanphamID, string khachhangID, string rate, string noidung)
        {
            DateTime time = DateTime.Now;
            string sql = @"insert into vote(sanphamID,customerID,rate,noidung,ngaydanhgia)
                            values (" + sanphamID + @", " + khachhangID + @", " + rate + @", N'" + noidung + @"','" + time.ToString("yyyy-MM-dd hh:mm:ss") + @"')";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }
        /// <summary>
        /// Hàm tính số sao trung bình cho sản phẩm theo id sản phẩm
        /// </summary>
        /// <param name="sanphamID"></param>
        /// <returns></returns>
        public static DataTable Tinh_Sao_DanhGia_CuaSanPham(string sanphamID)
        {
            string sql = @"select sum(sosao/soluong) as sao 
                            from (
	                            select count(*) as soluong, sum(rate) as sosao from vote where sanphamID = " + sanphamID + @") as p";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
        /// <summary>
        /// Hàm đếm số bình luận của 1 sản phẩm
        /// </summary>
        /// <param name="sanphamID"></param>
        /// <returns></returns>
        public static DataTable Dem_So_BinhLuan_CuaMotSanPham(string sanphamID)
        {
            string sql = @"select count(*) as soluong from vote where sanphamID = " + sanphamID + "";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
        /// <summary>
        /// Lấy danh sách bình luận của sản phẩm 
        /// </summary>
        /// <param name="sanphamID"></param>
        /// <returns></returns>
        public static DataTable DanhSach_BinhLuan_CuaSanPham_ByID(string sanphamID)
        {
            string sql = @"select * from vote where sanphamID = " + sanphamID + " order by ngaydanhgia DESC";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
    }
}