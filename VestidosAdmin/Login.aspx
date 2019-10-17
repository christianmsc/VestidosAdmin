<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VestidosAdmin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>amei seu vestido!</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="icon" type="image/png" href="img/icons/favicon.png"/>
	<link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
	<link rel="stylesheet" type="text/css" href="fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
	<link rel="stylesheet" type="text/css" href="fonts/iconic/css/material-design-iconic-font.min.css">
	<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
	<link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
	<link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">
	<link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
	<link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css">
	<link rel="stylesheet" type="text/css" href="css/util.css">
	<link rel="stylesheet" type="text/css" href="css/main.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="limiter">
		<div class="container-login100">
			<div class="login100-more" style="background-image: url('img/bg-01.jpg');"></div>

			<div class="wrap-login100 p-l-50 p-r-50 p-t-72 p-b-50">
				<form class="login100-form validate-form">
					<span class="login100-form-title p-b-59">
						amei seu vestido!
					</span>

					<div class="wrap-input100 validate-input" data-validate = "e-mail é obrigatório">
						<span class="label-input100">e-mail</span>
                        <asp:TextBox ID="txbEmail" CssClass="input100" name="email" placeholder="digite seu e-mail" runat="server" />  
						<%--<input class="input100" type="text" name="email" placeholder="digite seu e-mail">--%>
						<span class="focus-input100"></span>
					</div>

					<div class="wrap-input100 validate-input" data-validate = "senha é obrigatória">
						<span class="label-input100">senha</span>
                        <asp:TextBox ID="txbSenha" CssClass="input100" type="password" name="pass" placeholder="digite sua senha" runat="server" />
						<%--<input class="input100" type="password" name="pass" placeholder="*************">--%>
						<span class="focus-input100"></span>
					</div>

					<div class="flex-m w-full p-b-33">
						<div class="contact100-form-checkbox">
                            <asp:CheckBox ID="ckb1" type="checkbox" name="remember-me" runat="server" AutoPostBack="True" />
							<%--<input class="input-checkbox100" id="ckb1" type="checkbox" name="remember-me">--%>
							<label for="ckb1">
								<span class="txt1">
									não me esquecer
									<a href="#" class="txt2 hov1">
										=)
									</a>
								</span>
							</label>
						</div>

						
					</div>

					<div class="container-login100-form-btn d-flex align-items-center justify-content-center">
						<div class="wrap-login100-form-btn">
							<div class="login100-form-bgbtn"></div>
                            <asp:Button ID="btnEntrar" CssClass="login100-form-btn btn-asp" Text="entrar" runat="server" OnClick="btnEntrar_Click"></asp:Button>
						</div>
					</div>

				</form>
			</div>
		</div>
	</div>
    </form>
   <script src="vendor/jquery/jquery-3.2.1.min.js"></script>
	<script src="vendor/animsition/js/animsition.min.js"></script>
	<script src="vendor/bootstrap/js/popper.js"></script>
	<script src="vendor/bootstrap/js/bootstrap.min.js"></script>
	<script src="vendor/select2/select2.min.js"></script>
	<script src="vendor/daterangepicker/moment.min.js"></script>
	<script src="vendor/daterangepicker/daterangepicker.js"></script>
	<script src="vendor/countdowntime/countdowntime.js"></script>
	<script src="js/main.js"></script>
</body>
</html>
