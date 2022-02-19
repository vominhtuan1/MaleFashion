using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace MaleFashion.App_Code.Database
{
    public class GiamGiaDonHang
    {
        public static DataTable ThongTin_GiamGia_ChoDonHang_ByID(string id)
        {
            string sql = @"select * from codegiamgia where giamgiaID = " + id + "";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
    }
}