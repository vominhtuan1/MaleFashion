using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace MaleFashion.App_Code.Database
{
    public class SanPham
    {
        /// <summary>
        /// Hàm lấy 8 sp đầu tiên trong danh sách
        /// </summary>
        /// <returns></returns>
        public static DataTable ThongTin_RanDom_Sp_Ten_GiaBan_TrangThai_DanhGia_HinhAnh()
        {
            OleDbCommand cmd = new OleDbCommand("ThongTin_RanDom_Sp_Ten_GiaBan_TrangThai_DanhGia_HinhAnh");
            cmd.CommandType = CommandType.StoredProcedure;
            return SQLDatabase.GetData(cmd);
        }

        /// <summary>
        /// hàm lấy số lượng sản phẩm 
        /// </summary>
        /// <returns></returns>
        public static DataTable ThongTin_SL_SanPham(string loaisanphamID, string giadau, string giacuoi)
        {
            string sql = "select COUNT(*) as soluong from sanpham where 1 = 1 ";
            if(loaisanphamID != "")
            {
                sql += " and loaisanphamID=" + loaisanphamID;
            }
            if(giadau != "" && giacuoi != "")
            {
                sql += " and giaban between " + giadau + " and " + giacuoi;
            }
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        /// <summary>
        /// lấy thông tin sản phẩm không có bộ lọc về giá và loại và phân trang
        /// </summary>
        /// <param name="tuhang"></param>
        /// <param name="denhang"></param>
        /// <returns></returns>
        public static DataTable ThongTin_Loc_SanPham_Paginate(string loaisanphamID,string giatu, string giaden,string tuhang, string denhang, string order)
        {
            string dieukien = "";
            if(loaisanphamID != "")
            {
                dieukien += @" and loaisanphamID=" + loaisanphamID;
            }
            if (giatu != "" && giaden != "")
            {
                dieukien += @" and (giaban between " + giatu + " and " + giaden + ") ";
            }
            string sql = @"
            select * from(
                select ROW_NUMBER() OVER(
                       ORDER BY ten) AS RowNum,ten, giaban, trangthai, danhgia, hinhanh
                from sanpham , hinhanh
                where (hinhanh.hinhanh like '%hdd.jpg'or hinhanh.hinhanh like '%hdd.png') and sanpham.sanphamID = hinhanh.sanphamID "+ dieukien +@"
                )
            as p where p.RowNum between "+ tuhang + @" and " + denhang + @"";
            if(order != "")
            {
                sql += @"order by giaban" + order;
            }
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
        /// <summary>
        /// hàm lấy thông tin theo loại sản phẩm và phân trang
        /// </summary>
        /// <param name="loaispID"></param>
        /// <param name="tuhang"></param>
        /// <param name="denhang"></param>
        /// <returns></returns>
        public static DataTable ThongTin_Loc_SanPham_TheoLoai_Paginate(string loaispID,string tuhang, string denhang)
        {
            OleDbCommand cmd = new OleDbCommand("ThongTin_Loc_SanPham_TheoLoai_Paginate");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@loaisanphamID", loaispID);
            cmd.Parameters.AddWithValue("@tuhang", tuhang);
            cmd.Parameters.AddWithValue("@denhang", denhang);
            return SQLDatabase.GetData(cmd);
        }
    }
}