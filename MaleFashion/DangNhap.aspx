<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="MaleFashion.DangNhap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trang đang nhập</title>
    <link href="css/LoginCss.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Nunito+Sans:wght@300;400;600;700;800;900&display=swap"
        rel="stylesheet"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" integrity="sha512-9usAa10IRO0HhonpyAIVpjrylPvoDwiPUiKdWk5t3PyolY1cOd4DSE0Ga+ri4AuTroPR5aQvXU9xC6qOPnzFeg==" crossorigin="anonymous" referrerpolicy="no-referrer" />
</head>
<body>
    <div class="login_body" style="margin-top: 100px">
        <div class="login_container" id="container">
            <div class="form-container sign-up-container">
                <div class="login_form" runat="server">
                    <h1 class="h1_title">Đăng ký</h1>
                    <input id="tendangnhap_dangky" class="login_input" type="text" placeholder="Tên đăng nhập" />
                    <input id="matkhau_dangky" class="login_input" type="password" placeholder="Mật khẩu" />
                    <input id="hoten" class="login_input" type="text" placeholder="Họ và tên" />
                    <input id="sodienthoai" class="login_input" type="text" placeholder="Số điện thoại" />
                    <textarea id="diachi" class="login_input" type="text" placeholder="Địa chỉ"></textarea>
                    <a href="javascript:DangKy()" class="login_button">Đăng ký</a>
                </div>
            </div>
            <div class="form-container sign-in-container">
                <div class="login_form" runat="server">
                    <h1 class="h1_title">Đăng nhập</h1>
                    <input id="tendangnhap" class="login_input" type="email" placeholder="Tên tài khoản" runat="server" />
                    <input id="matkhau" class="login_input" type="password" placeholder="Mật khẩu" runat="server" />
                    <a href="javascript:DangNhap()" class="login_button">Đăng nhập</a>
                </div>
            </div>
            <div class="overlay-container">
                <div class="overlay">
                    <div class="overlay-panel overlay-left">
                        <h1 class="h1_title">Mừng trở lại!</h1>
                        <p class="login_text">Để giữ liên lạc với chúng tôi hãy đăng nhập bằng thông tin các nhân của bạn</p>
                        <button class="ghost login_button" id="signIn">Đăng nhập</button>
                    </div>
                    <div class="overlay-panel overlay-right">
                        <h1 class="h1_title">Hello, Friend!</h1>
                        <p class="login_text">Nhập thông tin cá nhân của bạn và bắt đầu mua sắm với chúng tôi</p>
                        <button class="ghost login_button" id="signUp">Đăng ký</button>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/LoginScript.js"></script>
    <script type="text/javascript">
        function DangNhap() {
            var tendangnhap = $("#tendangnhap").val();
            var matkhau = $("#matkhau").val();
            if (tendangnhap == "" || matkhau == "") {
                alert("Vui lòng nhập đầy đủ thông tin.");
            } else {
                $.post("Ajax/DangNhapDangKy.aspx",
                    {
                        "ThaoTac": "DangNhap",
                        "taikhoan": tendangnhap,
                        "matkhau": matkhau
                    },
                    function (data, status) {
                        if (data == "1") {
                            $(location).attr('href', "Default.aspx?modul=TrangChu");
                        } else {
                            alert("Sai tài khoản hoặc mật khẩu.")
                        }
                    }
                );
            }
        }
        function DangKy() {
            var taikhoan = $("#tendangnhap_dangky").val();
            var matkhau = $("#matkhau_dangky").val();
            var hoten = $("#hoten").val();
            var sodienthoai = $("#sodienthoai").val();
            var diachi = $("#diachi").val();
            if (taikhoan == "" || matkhau == "" || hoten == "" || sodienthoai == "" || diachi == "") {
                alert("Vui lòng nhập đầy đủ thông tin");
            } else {
                $.post("Ajax/DangNhapDangKy.aspx",
                    {
                        "ThaoTac": "DangKy",
                        "taikhoan": taikhoan,
                        "matkhau": matkhau,
                        "hoten": hoten,
                        "sdt": sodienthoai,
                        "diachi": diachi
                    },
                    function (data, status) {
                        if (data == "1") {
                            $(location).attr('href', "Default.aspx?modul=TrangChu");
                        } else {
                            alert("Tên đăng nhập này đã được sử dụng.")
                        }
                    }
                );
            }
        }
    </script>
</body>
</html>
