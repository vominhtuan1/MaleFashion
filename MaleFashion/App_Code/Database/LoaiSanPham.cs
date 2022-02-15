using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace MaleFashion.App_Code.Database
{
    public class LoaiSanPham
    {
        /// <summary>
        /// Lấy danh sách loại sản phẩm
        /// </summary>
        /// <returns></returns>
        public static DataTable ThongTin_LoaiSanPham()
        {
            OleDbCommand cmd = new OleDbCommand("ThongTin_LoaiSanPham");
            cmd.CommandType = CommandType.StoredProcedure;
            return SQLDatabase.GetData(cmd);
        }
    }
}