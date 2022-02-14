using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaleFashion
{
    public partial class _Default : Page
    {
        private string modul = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["modul"] != null)
            {
                modul = Request.QueryString["modul"];
            }
        }
        protected string DanhDau(string tenModul)
        {
            string s = "";

            /*Lấy giá trị querystring modul, modulphu, thaotac*/
            string modul = "";
            if (Request.QueryString["modul"] != null)
                modul = Request.QueryString["modul"];

            /*So sánh nếu querystring bằng tên modul truyền vào thì trả về active --> đánh dấu là menu hiện tại*/
            if (modul == tenModul )
                s = "active";
            return s;
        }
    }
}