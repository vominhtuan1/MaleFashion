using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace MaleFashion.App_Code.Database
{
    public class ChiTietDonHang
    {
        public static void Them_ChiTietDonHang(string hoadonid, string chitietspid, string soluong, string giasp)
        {
            string sql = @"insert into chitiethoadon(hoadonID,chitietspID,soluong,giaSP)
                        values (" + hoadonid + "," + chitietspid + "," + soluong + "," + giasp + ")";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }
    }
}