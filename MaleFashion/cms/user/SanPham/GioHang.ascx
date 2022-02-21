<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GioHang.ascx.cs" Inherits="MaleFashion.cms.user.SanPham.GioHang" %>

<!-- Breadcrumb Section Begin -->
<section class="breadcrumb-option">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="breadcrumb__text">
                    <h4>Giỏ hàng</h4>
                    <div class="breadcrumb__links">
                        <a href="./index.html">Trong chủ</a>
                        <a href="./shop.html">Sản phẩm</a>
                        <span>Giỏ hàng</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- Breadcrumb Section End -->

<!-- Shopping Cart Section Begin -->
<section class="shopping-cart spad">
    <div class="container">
        <div class="row">
            <div class="col-lg-8">
                <div class="shopping__cart__table">
                    <table>
                        <thead>
                            <tr>
                                <th>Sản phẩm</th>
                                <th>Số lượng</th>
                                <th>Size</th>
                                <th>Tổng</th>
                                <th></th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Literal ID="ltrSanPham" runat="server"></asp:Literal>
                        </tbody>
                    </table>
                </div>
                <div class="row">
                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <div class="continue__btn">
                            <a href="#">Tiếp tục mua săm</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="cart__discount">
                    <h6>Discount codes</h6>
                    <form action="#">
                        <input id="maGiamGia" type="text" placeholder="Coupon code">
                        <a href="javascript:ApDungGiamGia()" class="primary-btn">Áp dụng</a>
                    </form>
                </div>
                <div class="cart__total">
                    <h6>Tổng giỏ hàng</h6>
                    <ul>
                        <li>Giá trị sản phẩm <span id="giatri">
                            <asp:Literal ID="ltrtongtien" runat="server"></asp:Literal></span></li>
                        <li>Giảm giá <span id="giamgia">0 đ</span></li>
                        <li>Thành tiền <span id="thanhtien">
                            <asp:Literal ID="ltrthanhtien" runat="server"></asp:Literal></span></li>
                    </ul>
                    <a href="javascript:ChuyenTrangThanhToan()" class="primary-btn">Tiến hành thanh toán</a>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- Shopping Cart Section End -->
<script src="../../../js/jquery-3.3.1.min.js"></script>
<script type="text/javascript">
    var codegiamgia = "";
    //function LayTongTien() {
    //    $.post("cms/user/SanPham/Ajax/SanPham.aspx",
    //        {
    //            "ThaoTac": "LayTongTien",
    //        },
    //        function (data, status) {
    //            $("#giatri").text(data + " đ");
    //            $("#thanhtien").text(data + " đ");
    //        }
    //    );
    //}
    //$(document).ready(function () {
    //    LayTongTien();
    //})
    function ApDungGiamGia() {
        $.post("cms/user/SanPham/Ajax/SanPham.aspx",
            {
                "ThaoTac": "ApDungGiamGia",
                "code": $("#maGiamGia").val()
            },
            function (data, status) {
                if (data == "Mã giảm giá không tồn tại.") {
                    $("#giamgia").text("0 đ");
                    $("#thanhtien").text($("#giatri").text());
                    codegiamgia = "";
                    alert(data);
                } else {
                    codegiamgia = $("#maGiamGia").val();
                    var tongtien = $("#giatri").text();
                    tongtien = tongtien.trim();
                    tongtien = tongtien.replace(",", "");
                    tongtien = tongtien.replace("đ", "");

                    var giamgia = data.trim();
                    giamgia = giamgia.replace(",", "");
                    giamgia = giamgia.replace("đ", "");

                    var thanhtien = parseInt(tongtien) - parseInt(giamgia);
                    let dollarUSLocale = Intl.NumberFormat('en-US');
                    $("#giamgia").text(data + " đ");
                    $("#thanhtien").text(dollarUSLocale.format(thanhtien) + " đ");
                }
            }
        );
    }
    function CapNhapSoLuongVaoGioHang(idsp, size) {
        var idinput = "#sanpham_" + idsp + "_";
        switch (size) {
            case 1:
                idinput += "M";
                break;
            case 2:
                idinput += "L";
                break;
            case 3:
                idinput += "XL";
                break;
            case 4:
                idinput += "2XL";
                break;
            case 5:
                idinput += "3XL";
                break;
            default:
                idinput += size;
                break;
        }
        var sl = $(idinput).val();
        $.post("cms/user/SanPham/Ajax/SanPham.aspx",
            {
                "ThaoTac": "CapNhapSoLuongVaoGio",
                "idsp": idsp,
                "size": size,
                "sl": sl
            },
            function (data, status) {
                if (data == "1") {
                    $(location).attr('href', "Default.aspx?modul=GioHang");
                } else {
                    alert("Đã xảy ra lỗi. Vui lòng thử lại.")
                }
            }
        );
    }
    function ChuyenTrangThanhToan() {
        if (codegiamgia == "") {
            $(location).attr('href', "Default.aspx?modul=ThanhToan&codegiamgia=0");
        } else {
            $(location).attr('href', "Default.aspx?modul=ThanhToan&codegiamgia=" + codegiamgia);
        }
    }
    function XoaSanPham(giohangID, chitietspID) {
        $.post("cms/user/SanPham/Ajax/SanPham.aspx",
            {
                "ThaoTac": "XoaSanPhamTrongGio",
                "giohangID": giohangID,
                "chitietspID": chitietspID
            },
            function (data, status) {
                if (data == "1") {
                    $(location).attr('href', "Default.aspx?modul=GioHang");
                } else {
                    alert("Đã xảy ra lỗi. Vui lòng thử lại.")
                }
            }
        );
    }
</script>
