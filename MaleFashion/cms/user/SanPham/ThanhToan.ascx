<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThanhToan.ascx.cs" Inherits="MaleFashion.cms.user.SanPham.ThanhToan" %>
<!-- Breadcrumb Section Begin -->
<section class="breadcrumb-option">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="breadcrumb__text">
                    <h4>Thanh toán</h4>
                    <div class="breadcrumb__links">
                        <a href="./index.html">Trang chủ</a>
                        <a href="./shop.html">Sản phẩm</a>
                        <span>thanh toán</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- Breadcrumb Section End -->

<!-- Checkout Section Begin -->
<section class="checkout spad">
    <div class="container">
        <div class="checkout__form">
            <form runat="server">
                <div class="row">
                    <div class="col">
                        <h6 class="checkout__title">Thông tin người nhận</h6>
                        <div class="checkout__input">
                            <p>Tên người nhận<span>*</span></p>
                            <asp:TextBox ID="tbxHoTen" runat="server" Style="margin-bottom: 0; color:#111111" ></asp:TextBox>
                        </div>
                        <div class="checkout__input">
                            <p>Số điện thoại nhận hàng<span>*</span></p>
                            <asp:TextBox ID="tbxSoDienThoai" runat="server" Style="margin-bottom: 0; color:#111111"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxSoDienThoai" ForeColor="red"
                                SetFocusOnError="true" ErrorMessage="Số điện thoại không được bỏ trống"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbxSoDienThoai"
                                ErrorMessage="Số điện thoại phải là kiểu số" SetFocusOnError="True"
                                ValidationExpression="(\d)*" ForeColor="Red"></asp:RegularExpressionValidator>
                        </div>
                        <div class="checkout__input">
                            <p>Địa chỉ nhận hàng<span>*</span></p>
                            <asp:TextBox ID="tbxDiaChi" runat="server" Style="margin-bottom: 0; color:#111111"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbxDiaChi" ForeColor="red"
                                SetFocusOnError="true" ErrorMessage="Địa chỉ không được bỏ trống"></asp:RequiredFieldValidator>
                        </div>
                        <div class="checkout__input">
                            <p>Ghi chú cho đơn hàng</p>
                            <asp:TextBox ID="tbxGhiChu" runat="server" Style="color:#111111"></asp:TextBox>
                        </div>
                        <div class='continue__btn'>
                            <a  href="javascript:ThanhToan()" style='cursor: pointer'>Xác nhận</a>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
</section>
<!-- Checkout Section End -->
<script>
    function ThanhToan() {
        var sdt = $("#UserLoadControl_ctl00_tbxSoDienThoai").val();
        var diachi = $("#UserLoadControl_ctl00_tbxDiaChi").val();
        var ghichu = $("#UserLoadControl_ctl00_tbxGhiChu").val();
        var codegiamgia = GetQueryStringParams("codegiamgia")
        $.post("cms/user/SanPham/Ajax/SanPham.aspx",
            {
                "ThaoTac": "ThanhToan",
                "ghichu": ghichu,
                "sdt": sdt,
                "diachi": diachi,
                "codegiamgia": codegiamgia
            },
            function (data, status) {
                if (data == "1") {
                    alert("Đặt hàng thành công");
                    $(location).attr('href', "Default.aspx?modul=TrangCaNhan");
                } else {
                    alert("Đã xảy ra lỗi. Vui lòng thử lại.")
                }
            }
        );
    }
    function GetQueryStringParams(sParam) {
        var sPageURL = window.location.search.substring(1);
        var sURLVariables = sPageURL.split('&');
        for (var i = 0; i < sURLVariables.length; i++) {
            var sParameterName = sURLVariables[i].split('=');
            if (sParameterName[0] == sParam) {
                return sParameterName[1];
            }
        }
    }
</script>