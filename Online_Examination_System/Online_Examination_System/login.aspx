<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Login - Online exam sytem</title>
    <!-- Bootstrap core CSS-->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom fonts for login-->
    <!-- <link href="assets/css/custom.css" rel="stylesheet"> -->
    <script>
		addEventListener("load", function () {
			setTimeout(hideURLbar, 0);
		}, false);

		function hideURLbar() {
			window.scrollTo(0, 1);
		}
	</script>
    <link href="assets/css/Mylogin.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Amiri:400,400i,700,700i" rel="stylesheet">
</head>

<body>
    <!--  particles  -->
	<div id="particles-js"></div>
	<!-- //particles -->
    <div class=" w3ls-pos">
        <h1>Login</h1>
        <div class=" w3ls-login box">
           <!-- <div class="card-header">Login</div> -->
            
                <form runat="server" id="formlogin">
                    <asp:Panel ID="pnl_warning" runat="server" Visible="false">
                    <div class="form-group card-header text-center">
                        <div class="alert-danger">
                        <asp:Label ID="lbl_warning" runat="server" Text="Label" CssClass="col-form-label text-center"></asp:Label>
                        </div>
                    </div>
                    </asp:Panel>
                    <div class="my-login">
                        <label for="exampleInputEmail1">Email address</label>
                        <asp:TextBox ID="txt_email" runat="server" CssClass="form-control" placeholder="Enter email" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqr_emil" runat="server" ErrorMessage="Enter email" ControlToValidate="txt_email" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rqrexpre_email" runat="server" ErrorMessage="Enter validate email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txt_email" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                    <div class="my-login">
                        <div class="form-row">
                            <div class="col-md-6">
                                <label for="exampleInputPassword1">Password</label>
                                <asp:TextBox ID="txt_pass" runat="server" CssClass="form-control" placeholder="Enter password" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqr_pass" runat="server" ErrorMessage="Enter password" ControlToValidate="txt_pass" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-6">
                                <label for="exampleConfirmPassword">Confirm password</label>
                                <asp:TextBox ID="txt_repass" runat="server" CssClass="form-control" placeholder="Re-type password" TextMode="Password"></asp:TextBox>
                                <asp:CompareValidator ID="rqrcopm_pass" runat="server" ErrorMessage="Password do not match" ControlToValidate="txt_repass" Display="Dynamic" ForeColor="Red" ControlToCompare="txt_pass"></asp:CompareValidator>
                            </div>
                        </div>
                    </div>
                    <div class="checking">
                        <div class="form-check">
                            <label class="form-check-label">
                                <asp:CheckBox ID="chk_remember" runat="server" CssClass="form-check-input remembermecustom" />
                                Remember Password</label>
                        </div>
                    </div>
                    <asp:Button ID="btn_login" runat="server" Text="Log In" CssClass="btn btn-primary btn-block" OnClick="btn_login_Click" />
                    <div class="form-group text-center">
                        <a class="d-block small mt-3 additional" href="register.aspx">Register an Account</a>
                        <a class="d-block small additional" href="admin/login.aspx">Login as Admin</a>
                    </div>
                </form>

            
        </div>
   </div>
    <script src='assets/js/Myparticles.min.js'></script>
	<script src="assets/js/Myindex.js"></script>
</body>

</html>

