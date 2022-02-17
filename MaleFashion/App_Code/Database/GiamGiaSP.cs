using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace MaleFashion.App_Code.Database
{
    public class GiamGiaSP
    {
        /// <summary>
        /// Hàm lấy thông tin giảm giá của sản phẩm theo id sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable ThongTin_GiamGiaSanPham_ByIDSanPham(string id)
        {
            string sql = @"
                select top(1) * from (
                select *,GETDATE() as datenow from giamgiaSP where sanphamID = " + id + @" ) as p
                where p.datenow between ngayBD and ngayKT";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

    }
}