<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SecureMedicalRecord.Login" %>

<!DOCTYPE html>

<html>

<head>
	<title>Secure Medical Record</title>
	<!-- Meta-Tags -->
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<meta charset="utf-8">
	<meta name="keywords" content="Elite login Form a Responsive Web Template, Bootstrap Web Templates, Flat Web Templates, Android Compatible Web Template, Smartphone Compatible Web Template, Free Webdesigns for Nokia, Samsung, LG, Sony Ericsson, Motorola Web Design">
	<script>
	    addEventListener("load", function () {
	        setTimeout(hideURLbar, 0);
	    }, false);

	    function hideURLbar() {
	        window.scrollTo(0, 1);
	    }
	</script>
	<!-- //Meta-Tags -->
	<!-- Stylesheets -->
	<link href="css/font-awesome.css" rel="stylesheet">
	<link href="css/style_css.css" rel='stylesheet' type='text/css' />
	<!--// Stylesheets -->
	<!--fonts-->
	<link href="//fonts.googleapis.com/css?family=Source+Sans+Pro:200,200i,300,300i,400,400i,600,600i,700,700i,900,900i" rel="stylesheet">
	<!--//fonts-->
</head>

<body>
	<h1>login Form </h1>
	<div class="w3ls-login">
		<!-- form starts here -->
		<form id="form1" runat="server">
        <div class="agile-field-txt">
				<label>
					<i class="fa fa-user" aria-hidden="true"></i> Select User Type :</label>
				
                            <asp:DropDownList ID="ddlUserType" runat="server">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="1">Admin</asp:ListItem>
                            <asp:ListItem Value="2">Receptionist</asp:ListItem>
                            <asp:ListItem Value="3">Doctor</asp:ListItem>
                            <asp:ListItem Value="4">Patient</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select User Type" InitialValue="--Select--" ValidationGroup="A" ControlToValidate="ddlUserType" ForeColor="#fb0b57"></asp:RequiredFieldValidator>
			</div>
			<div class="agile-field-txt">
				<label>
					<i class="fa fa-user" aria-hidden="true"></i>Enter User Id :</label>
				<asp:TextBox ID="txtUserId" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter User Id" ValidationGroup="A" ControlToValidate="txtUserId" ForeColor="#fb0b57"></asp:RequiredFieldValidator>
			</div>
			<div class="agile-field-txt">
				<label>
					<i class="fa fa-lock" aria-hidden="true"></i> password :</label>
				
				<asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Password" ValidationGroup="A" ControlToValidate="txtPassword" ForeColor="#fb0b57"></asp:RequiredFieldValidator>
				
			</div>
		
			<!-- //script for show password -->
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
			<div class="w3ls-login  w3l-sub">
				<br />
                            <asp:Button ID="btnLogin" runat="server" Text="Login" 
                                onclick="btnLogin_Click" ValidationGroup="A"/>
                            <asp:Button ID="btnHome" runat="server" Text="Home" onclick="btnHome_Click" />
			</div>
		</form>
	</div>
	<!-- //form ends here -->
	<!--copyright-->
	<div class="copy-wthree">
		<p>© 2020 Secure Medical Record . All Rights Reserved | Design by
			Secure Medical Record
		</p>
	</div>
	<!--//copyright-->
</body>

</html>
