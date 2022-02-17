using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaleFashion.App_Code
{
    /// <summary>
    /// class thực hiện nhiệm vụ convert chuỗi sang tiền tệ
    /// </summary>
    public class FormatNumber
    {
        /// <summary>
        /// chuyển object sang việt nam đồng
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static string ConvertTonVietNamCurrency(Object a)
        {
            return int.Parse(a.ToString()).ToString("#,##0");
        }
    }
}