using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

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
        public static DataTable Lay_Danh_Gia( String sanphamID)
        {
            OleDbCommand cmd = new OleDbCommand("Lay_Danh_Gia");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Int16.Parse(sanphamID));
            return SQLDatabase.GetData(cmd);
        }
    }
}