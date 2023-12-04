<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.Master" AutoEventWireup="true" CodeBehind="AddPatient.aspx.cs" Inherits="SecureMedicalRecord.AddPatient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="main-page">
            <div class="forms">
                <h2 class="title1">
                   </h2>
                <div class="form-grids row widget-shadow" data-example-id="basic-forms">
                    <div class="form-title">
                        <h4>
                            Patient Details:</h4>
                    </div>
                    <div class="form-body">
                        
                                <div class="form-group">
                                    <label>
                                        Patient Name</label>
                                    <asp:TextBox ID="txtPatientName" class="form-control" runat="server" placeholder="Patient Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Patient Name"
                                        ControlToValidate="txtPatientName" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Select Gender</label>
                                    <asp:DropDownList ID="ddlGender" runat="server" class="form-control" >
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddlGender"
                                        ForeColor="#FF3300" ValidationGroup="A" InitialValue="--Select--" runat="server"
                                        ErrorMessage="Please Select Gender"></asp:RequiredFieldValidator>
                                </div>
                                 <div class="form-group">
                                    <label>
                                      Enter Age</label>
                                    <asp:TextBox ID="txtAge" class="form-control" runat="server" placeholder="Enter Age"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Age"
                                        ControlToValidate="txtAge" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Reason</label>
                                    <asp:TextBox ID="txtReason" class="form-control" runat="server" placeholder="Reason"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Reason"
                                        ControlToValidate="txtReason" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Mobile No</label>
                                    <asp:TextBox ID="txtMobileNo" class="form-control" runat="server" placeholder="Mobile No"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Mobile No"
                                        ControlToValidate="txtMobileNo" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMobileNo"
                                        ErrorMessage="Only 10 Digits" ForeColor="#FF3300" ValidationExpression="[0-9]{10}"
                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Address</label>
                                    <asp:TextBox ID="txtAddress" class="form-control" runat="server" placeholder="Address Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Address Name"
                                        ControlToValidate="txtAddress" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                               
                                 
                         <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
                         <div class="pull-right">
                                    <asp:Button ID="btnSubmit" class="btn btn-default" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                        ValidationGroup="A" />
                                    
                                </div><br />
                       
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
