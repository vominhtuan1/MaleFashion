<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DanhSachCacSanPham.ascx.cs" Inherits="MaleFashion.cms.user.SanPham.DanhSachCacSanPham" %>
<script src="../../../Scripts/jquery-3.4.1.min.js"></script>
<!-- Breadcrumb Section Begin -->
<section class="breadcrumb-option">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="breadcrumb__text">
                    <h4>Shop</h4>
                    <div class="breadcrumb__links">
                        <a href="./index.html">Home</a>
                        <span>Shop</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- Breadcrumb Section End -->

<!-- Shop Section Begin -->
<section class="shop spad">
    <div class="container">
        <div class="row">
            <div class="col-lg-3">
                <div class="shop__sidebar">
                    <div class="shop__sidebar__search">
                        
                    </div>
                    <div class="shop__sidebar__accordion">
                        <div class="accordion" id="accordionExample">
                            <div class="card">
                                <div class="card-heading">
                                    <a data-toggle="collapse" data-target="#collapseOne">Categories</a>
                                </div>
                                <div id="collapseOne" class="collapse show" data-parent="#accordionExample">
                                    <div class="card-body">
                                        <div class="shop__sidebar__categories">
                                            <ul class="nice-scroll">
                                                <asp:Literal ID="ltrCategories" runat="server"></asp:Literal>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card">
                                <div class="card-heading">
                                    <a data-toggle="collapse" data-target="#collapseThree">Filter Price</a>
                                </div>
                                <div id="collapseThree" class="collapse show" data-parent="#accordionExample">
                                    <div class="card-body">
                                        <div class="shop__sidebar__price">
                                            <ul>
                                                <asp:Literal ID="ltrFilterPrice" runat="server"></asp:Literal>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="continue__btn">
                                <a href="/Default.aspx?modul=SanPham" style="cursor:pointer">Xóa bộ lọc</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-9">
                <div class="shop__product__option">
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="shop__product__option__left">
                                <p></p>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="shop__product__option__right">
                                <p>Sort by Price:</p>
                                <asp:Literal ID="ltrSelection" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <asp:Literal ID="ltrProducts" runat="server"></asp:Literal>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="product__pagination">
                            <asp:Literal ID="ltrPaginate" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- Shop Section End -->

<script type="text/javascript">
    $(document).ready(function () {
        $("ul.list li").each(function (i, obj) {
            $(this).click(function () {
                if ($(this).text() == "thấp đến cao") {
                    var a = $(location).attr('href')
                    var b = a.toString();
                    if (b.includes("ASC")) {
                        $(location).attr('href', a)
                    } else if (b.includes("DESC")) {
                        b = b.replace("DESC", "ASC")
                        $(location).attr('href', b)
                    } else {
                        a += "&sapxep=ASC"
                        $(location).attr('href', a)
                    }
                } else {
                    var a = $(location).attr('href')
                    var b = a.toString();
                    if (b.includes("DESC")) {
                        $(location).attr('href', a)
                    } else if (b.includes("ASC")) {
                        b = b.replace("ASC", "DESC")
                        $(location).attr('href', b)
                    } else {
                        a += "&sapxep=DESC"
                        $(location).attr('href', a)
                    }
                }
            })
        })
    });
</script>
