<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DangNhap.ascx.cs" Inherits="MaleFashion.cms.user.DangNhap.WebUserControl1" %>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" integrity="sha512-9usAa10IRO0HhonpyAIVpjrylPvoDwiPUiKdWk5t3PyolY1cOd4DSE0Ga+ri4AuTroPR5aQvXU9xC6qOPnzFeg==" crossorigin="anonymous" referrerpolicy="no-referrer" />
<div class ="login_body">
<div class="login_container" id="container">
	<div class="form-container sign-up-container">
		<form class ="login_form" action="#">
			<h1 class="h1_title">Sign Up</h1>
			<div class="social-container">
				<a href="#" class="social"><i class="login_a fa-brands fa-facebook-f"></i></a>
				<a href="#" class="social"><i class="login_a fab fa-google-plus-g"></i></a>
				<a href="#" class="social"><i class="login_a fab fa-linkedin-in"></i></a>
			</div>
			<span class="login_span">or use your email for registration</span>
			<input class ="login_input" type="text" placeholder="Name" />
			<input class ="login_input" type="email" placeholder="Email" />
			<input class ="login_input" type="password" placeholder="Password" />
			<button class="login_button">Sign Up</button>
		</form>
	</div>
	<div class="form-container sign-in-container">
		<form class ="login_form" action="#">
			<h1 class="h1_title">Sign in</h1>
			<div class="social-container">
				<a href="#" class="social"><i class="login_a fab fa-facebook-f"></i></a>
				<a href="#" class="social"><i class="login_a fab fa-google-plus-g"></i></a>
				<a href="#" class="social"><i class="login_a fab fa-linkedin-in"></i></a>
			</div>
			<span class="login_span">or use your account</span>
			<input class ="login_input" type="email" placeholder="Email" />
			<input class ="login_input" type="password" placeholder="Password" />
			<a class = "login_a" href="#">Forgot your password?</a>
			<button class="login_button">Sign In</button>
		</form>
	</div>
	<div class="overlay-container">
		<div class="overlay">
			<div class="overlay-panel overlay-left">
				<h1 class="h1_title">Welcome Back!</h1>
				<p class="login_text">To keep connected with us please login with your personal info</p>
				<button class="ghost login_button" id="signIn">Sign In</button>
			</div>
			<div class="overlay-panel overlay-right">
				<h1 class="h1_title">Hello, Friend!</h1>
				<p class="login_text">Enter your personal details and start journey with us</p>
				<button class="ghost login_button" id="signUp">Sign Up</button>
			</div>
		</div>
	</div>
</div>
</div>

<footer class ="login_footer">
	<p class="login_text">
		Created with <i class="fa fa-heart"></i> by
		<a target="_blank" href="https://florin-pop.com">Florin Pop</a>
		- Read how I created this and how you can join the challenge
		<a target="_blank" href="https://www.florin-pop.com/blog/2019/03/double-slider-sign-in-up-form/">here</a>.
	</p>
</footer>