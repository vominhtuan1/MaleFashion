<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChiTietSanPham.ascx.cs" Inherits="MaleFashion.cms.user.SanPham.ChiTietSanPham" %>
<!-- Shop Details Section Begin -->
<section class="shop-details">
    <div class="product__details__pic">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="product__details__breadcrumb">
                        <a href="/Default.aspx?modul=TrangChu">Trang chủ</a>
                        <a href="/Default.aspx?modul=SanPham">Sản phẩm</a>
                        <span>Chi tiết sản phẩm</span>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-md-3">
                    <ul class="nav nav-tabs" role="tablist">
                        <li class="nav-item">
                            <a class="nav-link active" data-toggle="tab" href="#tabs-1" role="tab">
                                <%-- <div class="product__thumb__pic set-bg" data-setbg="img/shop-details/thumb-1.png"> </div>--%>
                                <asp:Literal ID="firstImage" runat="server"></asp:Literal>
                            </a>
                        </li>

                        <li class="nav-item">
                            <a class="nav-link" data-toggle="tab" href="#tabs-2" role="tab">
                                <%--  <div class="product__thumb__pic set-bg" data-setbg="img/shop-details/thumb-2.png">
                                </div>--%>
                                <asp:Literal ID="secImage" runat="server"></asp:Literal>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="tab" href="#tabs-3" role="tab">
                                <%--<div class="product__thumb__pic set-bg" data-setbg="img/shop-details/thumb-3.png">
                                </div>--%>
                                <asp:Literal ID="thirstImage" runat="server"></asp:Literal>
                            </a>
                        </li>

                    </ul>
                </div>
                <div class="col-lg-6 col-md-9">
                    <div class="tab-content">
                        <div class="tab-pane active" id="tabs-1" role="tabpanel">
                            <div class="product__details__pic__item">
                                <%-- <img src="img/shop-details/product-big-2.png" alt="">--%>
                                <asp:Literal ID="fimage1" runat="server"></asp:Literal>

                            </div>
                        </div>
                        <div class="tab-pane" id="tabs-2" role="tabpanel">
                            <div class="product__details__pic__item">
                                <%-- <img src="img/shop-details/product-big-3.png" alt="">--%>
                                <asp:Literal ID="fimage2" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="tab-pane" id="tabs-3" role="tabpanel">
                            <div class="product__details__pic__item">
                                <%-- <img src="img/shop-details/product-big.png" alt="">--%>
                                <asp:Literal ID="fimage3" runat="server"></asp:Literal>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="product__details__content">
        <div class="container">
            <div class="row d-flex justify-content-center">
                <div class="col-lg-8">
                    <div class="product__details__text">
                        <asp:Label ID="productName" runat="server" Text="Label"></asp:Label>

                        <div class="rating">
                            <asp:Literal ID="ltrSaoDanhGia" runat="server"></asp:Literal>
                        </div>

                        <asp:Label ID="price" runat="server" Text=""></asp:Label>

                        <div class="product__details__option">
                            <div class="product__details__option__size">
                                <span>Size:</span>
                                <asp:Literal ID="sizeLiteral" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="product__details__cart__option">
                            <div class="quantity">
                                <div class="pro-qty">
                                    <input type="text" value="1">
                                </div>
                            </div>
                            <a href="#" class="primary-btn">add to cart</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="product__details__tab">
                        <ul class="nav nav-tabs" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link active" data-toggle="tab" href="#tabs-5"
                                    role="tab">Mô tả sản phẩm</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" data-toggle="tab" href="#tabs-6" role="tab">Đánh giá của khách hàng</a>
                            </li>
                        </ul>
                        <div class="tab-content">
                            <div class="tab-pane active" id="tabs-5" role="tabpanel">
                                <div class="product__details__tab__content">
                                    <asp:Literal ID="descript" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div class="tab-pane" id="tabs-6" role="tabpanel">
                                <div class="product__details__tab__content">
                                    <div class="product__details__tab__content__item">
                                        <asp:Literal ID="ltrBinhLuan" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- Shop Details Section End -->

<!-- Related Section Begin -->
<section class="related spad">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="related-title">Sản phẩm liên quan</h3>
            </div>
        </div>
        <div class="row">
            <asp:Literal ID="ltrSanPhamLienQuan" runat="server"></asp:Literal>
        </div>
    </div>
</section>
<!-- Related Section End -->
<script src="../../../js/LetterAvatar.js"></script>
