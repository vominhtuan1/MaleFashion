using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace MaleFashion.App_Code.Database
{
    public class ChiTietSanPham
    {
        /// <summary>
        /// Hàm lấy chi tiet san phẩm bằng idsanpham và tên size
        /// </summary>
        /// <param name="idsanpham"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static DataTable LayIDChiTietSP_ByIDSanPham_VaSize(string idsanpham, string size)
        {
            string sql = "select chitietspID from chitietSP where sanphamID = " + idsanpham + " and size = '" + size + "'";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
    }
}