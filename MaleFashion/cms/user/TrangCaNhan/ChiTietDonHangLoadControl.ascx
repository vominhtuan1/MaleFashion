<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChiTietDonHangLoadControl.ascx.cs" Inherits="MaleFashion.cms.user.TrangCaNhan.ChiTietDonHangLoadControl" %>
<script src="../../../js/jquery-3.3.1.min.js"></script>
<section class="breadcrumb-option">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="breadcrumb__text">
                    <h4>Chi tiết đơn hàng</h4>
                    <div class="breadcrumb__links">
                        <a href="/Default.aspx?modul=TrangChu">Trang chủ</a>
                        <asp:Literal ID="ltrTrangCaNhan" runat="server"></asp:Literal>
                        <span>Chi tiết đơn hàng</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- Shopping Cart Section Begin -->
<section class="shopping-cart spad">
    <div class="container">
        <div class="row">
            <div class="col">
                <h6 class="checkout__title">Thông tin người nhận</h6>
                <asp:Literal ID="ltrThongTinCaNhan" runat="server"></asp:Literal>
                <div style="height: 50px"></div>
                <h6 class="checkout__title">Thông tin đơn hàng</h6>
                <div class="row">
                    <div class="col-lg-8">
                        <div class="shopping__cart__table">
                            <table>
                                <thead>
                                    <tr>
                                        <th>Sản phẩm</th>
                                        <th>Số lượng</th>
                                        <th>Tổng</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Literal ID="ltrSanPhamCuaDonHang" runat="server"></asp:Literal>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="cart__total" style="padding: 20px 20px;">
                            <ul style="margin-bottom: 0;">
                                <asp:Literal ID="ltrTongTien" runat="server"></asp:Literal>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<div class="modal fade" tabindex="-1" id="myModal">
    <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">Đánh giá sản phẩm</h5>
                <button type="button" class="btn-close" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="col-12">
                    <div class="row">
                        <div class="col-8">
                            <label for="inputEmail4" class="form-label">Nhấn vào 1 ngôi sao để xếp hạng</label>
                        </div>
                        <div class="col-4">
                            <div class='rating'>
                                <i class='fa fa-star-o' id="star1" style="cursor: pointer"></i>
                                <i class='fa fa-star-o' id="star2" style="cursor: pointer"></i>
                                <i class='fa fa-star-o' id="star3" style="cursor: pointer"></i>
                                <i class='fa fa-star-o' id="star4" style="cursor: pointer"></i>
                                <i class='fa fa-star-o' id="star5" style="cursor: pointer"></i>
                            </div>
                        </div>
                    </div>
                    <label for="inputEmail4" class="form-label">Bình luận</label>
                    <textarea class="form-control" placeholder="Để lại 1 bình luận tại đây" id="Textarea1"></textarea>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" id="btnClose">Đóng</button>
                <button type="button" class="btn btn-primary" id="btnDanhGia">Gửi đánh giá</button>
            </div>
        </div>
    </div>
</div>
<!-- Shopping Cart Section End -->
<script type="text/javascript">
    var idKH = "";
    var idSP = "";
    var star = 0;
    $(document).ready(function () {
        $("#btnClose").click(function () {
            $('#myModal').modal('hide');
            ClearModal();

        });

        $(".btn-close").click(function () {
            $('#myModal').modal('hide');
            ClearModal();
        });

        $("div.rating i").each(function (i, object) {
            $(this).click(function () {
                star = i + 1;
                for (var j = 0; j < 5; j++) {
                    var id = "star" + (j + 1).toString();
                    if (j <= i) {
                        var element = document.getElementById(id);
                        element.classList.remove("fa-star-o");
                        element.classList.add("fa-star");
                        element.classList.add("yellowstar");
                    } else {
                        var element = document.getElementById(id);
                        element.classList.remove("fa-star");
                        element.classList.remove("yellowstar");
                        element.classList.add("fa-star-o");
                    }
                }
            })
        })

        $("#btnDanhGia").click(function () {
            var binhluan = $("#Textarea1").val();
            $('#myModal').modal('hide');
            ClearModal();

            $.post("cms/user/TrangCaNhan/Ajax/ThongTinCaNhan.aspx",
                {
                    "ThaoTac": "DanhGiaSanPham",
                    "idKhachHang": idKH,
                    "idSanPham": idSP,
                    "star": star,
                    "binhluan": binhluan
                },
                function (data, status) {
                    if (data == "1") {
                        alert("Bạn đã bình luận thành công.")
                    } else {
                        alert("Đã xảy ra lỗi. Vui lòng thử lại.")
                    }
                }
            );
        })
    });

    function DanhGiaSanPham(idKhachHang, idSanPham) {
        idKH = idKhachHang;
        idSP = idSanPham;
        $('#myModal').modal('show');
    }

    function ClearModal() {
        $(document).ready(function () {
            $("div.rating i").each(function (i, object) {
                var id = "star" + (i + 1).toString();
                var element = document.getElementById(id);
                element.classList.remove("fa-star");
                element.classList.remove("yellowstar");
                element.classList.add("fa-star-o");
            })
            $("#Textarea1").val("");
        })
    }
</script>
