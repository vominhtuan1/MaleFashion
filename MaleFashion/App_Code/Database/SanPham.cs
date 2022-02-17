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
            if (loaisanphamID != "")
            {
                sql += " and loaisanphamID=" + loaisanphamID;
            }
            if (giadau != "" && giacuoi != "")
            {
                sql += " and giaban between " + giadau + " and " + giacuoi;
            }
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
        public static DataTable Lay_Thong_Tin_San_Pham(string idsanpham)
        {
            OleDbCommand cmd = new OleDbCommand("Lay_Thong_Tin_San_Pham");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Int16.Parse(idsanpham));
            return SQLDatabase.GetData(cmd);

        }
        public static DataTable Lay_Size_San_Pham(string idsanpham)
        {
            OleDbCommand cmd = new OleDbCommand("Lay_Size_San_Pham");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Int16.Parse(idsanpham));
            return SQLDatabase.GetData(cmd);

        }
        /// <summary>
        /// lấy thông tin sản phẩm không có bộ lọc về giá và loại và phân trang
        /// </summary>
        /// <param name="tuhang"></param>
        /// <param name="denhang"></param>
        /// <returns></returns>
        public static DataTable ThongTin_Loc_SanPham_Paginate(string loaisanphamID, string giatu, string giaden, string tuhang, string denhang, string order)
        {
            string dieukien = "";
            if (loaisanphamID != "")
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
                       ORDER BY giaban " + order + @") AS RowNum,ten, giaban, trangthai, danhgia, hinhanh, sanpham.sanphamID
                from sanpham , hinhanh
                where (hinhanh.hinhanh like '%hdd.jpg'or hinhanh.hinhanh like '%hdd.png') and sanpham.sanphamID = hinhanh.sanphamID " + dieukien + @"
                )
            as p where p.RowNum between " + tuhang + @" and " + denhang + @"";

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
        public static DataTable ThongTin_Loc_SanPham_TheoLoai_Paginate(string loaispID, string tuhang, string denhang)
        {
            OleDbCommand cmd = new OleDbCommand("ThongTin_Loc_SanPham_TheoLoai_Paginate");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@loaisanphamID", loaispID);
            cmd.Parameters.AddWithValue("@tuhang", tuhang);
            cmd.Parameters.AddWithValue("@denhang", denhang);
            return SQLDatabase.GetData(cmd);
        }
        /// <summary>
        /// Hàm lấy tên sản phẩm theo id sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable ThongTin_TenSP_ByID(string id)
        {
            string sql = "select ten from sanpham where sanphamID = " + id + "";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
        /// <summary>
        /// Hàm update sao cho sản phẩm
        /// </summary>
        /// <param name="sanphamID"></param>
        public static void CapNhap_Sao_ChoSanPham(string sanphamID)
        {
            DataTable dt = DanhGia.Tinh_Sao_DanhGia_CuaSanPham(sanphamID);
            string sql = @"update sanpham set danhgia = " + dt.Rows[0]["sao"] + @" where sanphamID = " + sanphamID + @"";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }
        /// <summary>
        /// Lấy 4 sản phẩm liên quan
        /// </summary>
        /// <param name="sanphamID"></param>
        public static DataTable Lay_SanPham_LienQuan(string sanphamID, string loaisanphamID)
        {
            string sql = @"select top(4) * from sanpham where sanphamID <> " + sanphamID + " and loaisanphamID = " + loaisanphamID + "";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
        public static DataTable ThongTin_SanPham_ByID(string sanphamID)
        {
            string sql = @"select * from sanpham where sanphamID = " + sanphamID + "";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
    }
}