using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace MaleFashion.App_Code.Database
{
    public class HinhAnh
    {
        /// <summary>
        /// Hàm lấy ảnh đại điện theo id sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable ThongTin_AnhDaiDien_ByIDSanPham(string id)
        {
            string sql = "select hinhanh from hinhanh where sanphamID = " + id + " and (hinhanh like '%-hdd.jpg' or hinhanh like '%-hdd.png')";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
    }
}