<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TrangCaNhaLoadControl.ascx.cs" Inherits="MaleFashion.cms.user.TrangCaNhan.WebUserControl1" %>
<!-- Breadcrumb Section Begin -->
<section class="breadcrumb-option">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="breadcrumb__text">
                    <h4>Trang cá nhân</h4>
                    <div class="breadcrumb__links">
                        <a href="/Default.aspx?modul=TrangChu">Trang chủ</a>
                        <span>Trang cá nhân</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- Breadcrumb Section End -->
<section class="checkout spad">
    <div class="container">
        <div class="checkout__form">
            <form runat="server">
                <div class="row">
                    <div class="col">
                        <h6 class="checkout__title">Thông tin cá nhân</h6>

                        <div class="checkout__input">
                            <p>Họ và Tên<span>*</span></p>
                            <asp:TextBox ID="tbxHoTen" runat="server" Style="margin-bottom: 0; color:#111111"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxHoTen" ForeColor="red"
                                SetFocusOnError="true" ErrorMessage="Địa chỉ không được bỏ trống"></asp:RequiredFieldValidator>
                        </div>
                        <div class="checkout__input">
                            <p>Địa chỉ<span>*</span></p>
                            <asp:TextBox ID="tbxDiaChi" runat="server" Style="margin-bottom: 0; color:#111111"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxDiaChi" ForeColor="red"
                                SetFocusOnError="true" ErrorMessage="Địa chỉ không được bỏ trống"></asp:RequiredFieldValidator>
                        </div>
                        <div class="checkout__input">
                            <p>Số điện thoại<span>*</span></p>
                            <asp:TextBox ID="tbxSoDienThoai" runat="server" Style="margin-bottom: 0; color:#111111"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbxSoDienThoai" ForeColor="red"
                                SetFocusOnError="true" ErrorMessage="Số điện thoại không được bỏ trống"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbxSoDienThoai"
                                ErrorMessage="Số điện thoại phải là kiểu số" SetFocusOnError="True" ValidationExpression="(\d)*" ForeColor="Red"></asp:RegularExpressionValidator>
                        </div>
                        <asp:Literal ID="ltrNutCapNhap" runat="server"></asp:Literal>

                        <div style="height: 50px"></div>
                        <h6 class="checkout__title">Đơn hàng của tôi</h6>
                        <asp:Literal ID="ltrDanhDachDonHang" runat="server"></asp:Literal>
                    </div>
                </div>
            </form>
        </div>
    </div>
</section>
<!-- Checkout Section End -->
<script type="text/javascript">
    function CapNhapThongTin(idKhachHang) {
        var ten = $("#UserLoadControl_ctl00_tbxHoTen").val();
        var sdt = $("#UserLoadControl_ctl00_tbxSoDienThoai").val();
        var diachi = $("#UserLoadControl_ctl00_tbxDiaChi").val();
        $.post("cms/user/TrangCaNhan/Ajax/ThongTinCaNhan.aspx",
            {
                "ThaoTac": "LuuThongTinCaNhan",
                "id": idKhachHang,
                "ten": ten,
                "sdt": sdt,
                "diachi": diachi
            },
            function (data, status) {
                if (data == "1") {
                    alert("Cập nhập thông tin thành công")
                } else {
                    alert("Đã xảy ra lỗi. Vui lòng thử lại.")
                }
            }
        );
    }
</script>
