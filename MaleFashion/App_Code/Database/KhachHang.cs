using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace MaleFashion.App_Code.Database
{
    public class KhachHang
    {
        /// <summary>
        /// Hàm lấy thông tin khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable ThongTin_KhachHang_ByID(string id)
        {
            string sql = "select * from customer where customerID = " + id + "";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
        /// <summary>
        /// Hàm cập nhập thông tin khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static void CapNhap_ThongTin_KhachHang(string id,string ten, string sdt, string diachi)
        {
            string sql = @"
                update customer
                set ten = N'"+ ten +@"', sdt = '"+ sdt +@"', diachi = N'"+ diachi +@"'
                where customerID = "+ id +"";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
             SQLDatabase.ExecuteNoneQuery(cmd);
        }
    }
}