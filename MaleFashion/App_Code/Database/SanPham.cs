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
        public static DataTable ThongTin_RanDom_Sp_Ten_GiaBan_TrangThai_DanhGia_HinhAnh()
        {
            OleDbCommand cmd = new OleDbCommand("ThongTin_RanDom_Sp_Ten_GiaBan_TrangThai_DanhGia_HinhAnh");
            cmd.CommandType = CommandType.StoredProcedure;
            return SQLDatabase.GetData(cmd);
        }
    }
}