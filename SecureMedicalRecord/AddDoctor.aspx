<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.Master" AutoEventWireup="true" CodeBehind="AddDoctor.aspx.cs" Inherits="SecureMedicalRecord.AddDoctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="main-page">
            <div class="forms">
                <h2 class="title1">
                   </h2>
                <div class="form-grids row widget-shadow" data-example-id="basic-forms">
                    <div class="form-title">
                        <h4>
                            Doctor Details:</h4>
                    </div>
                    <div class="form-body">
                         <div class="form-group">
                                    <label>
                                        Select Department</label>
                                    <asp:DropDownList ID="ddlDept" runat="server" class="form-control">
                                        
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlDept"
                                        ForeColor="#FF3300" ValidationGroup="A" InitialValue="--Select--" runat="server"
                                        ErrorMessage="Please Select Department Type"></asp:RequiredFieldValidator>
                                </div>

                                <div class="form-group">
                                    <label>
                                        Doctor Name</label>
                                    <asp:TextBox ID="txtDoctorName" class="form-control" runat="server" placeholder="Doctor Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Doctor Name"
                                        ControlToValidate="txtDoctorName" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
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
                                        Email Id</label>
                                    <asp:TextBox ID="txtEmailId" class="form-control" runat="server" placeholder="Email Id"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Email Id"
                                        ControlToValidate="txtEmailId" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmailId"
                                        ErrorMessage="Email ID Incorrect" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
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
