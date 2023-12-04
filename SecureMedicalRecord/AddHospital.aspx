<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddHospital.aspx.cs" Inherits="SecureMedicalRecord.AddHospital" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="main-page">
            <div class="forms">
                <h2 class="title1">
                   </h2>
                <div class="form-grids row widget-shadow" data-example-id="basic-forms">
                    <div class="form-title">
                        <h4>
                            Hospital Details:</h4>
                    </div>
                    <div class="form-body">
                        
                                <div class="form-group">
                                    <label>
                                        Hospital Name</label>
                                    <asp:TextBox ID="txtHospitalName" class="form-control" runat="server" placeholder="Hospital Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Hospital Name"
                                        ControlToValidate="txtHospitalName" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Contact Person</label>
                                    <asp:TextBox ID="txtContactPerson" class="form-control" runat="server" placeholder="Contact Person"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Contact Person"
                                        ControlToValidate="txtContactPerson" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
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
