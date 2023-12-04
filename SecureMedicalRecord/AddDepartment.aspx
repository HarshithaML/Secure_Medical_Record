<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddDepartment.aspx.cs" Inherits="SecureMedicalRecord.AddDepartment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="main-page">
            <div class="forms">
                <h2 class="title1">
                   </h2>
                <div class="form-grids row widget-shadow" data-example-id="basic-forms">
                    <div class="form-title">
                        <h4>
                            Department Details:</h4>
                    </div>
                    <div class="form-body">
                        
                                <div class="form-group">
                                    <label>
                                        Department Name</label>
                                    <asp:TextBox ID="txtDepartmentName" class="form-control" runat="server" placeholder="Department Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Department Name"
                                        ControlToValidate="txtDepartmentName" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                                
                                <div class="form-group">
                                    <label>
                                        Description</label>
                                    <asp:TextBox ID="txtDescp" class="form-control" runat="server" placeholder="Description"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Description"
                                        ControlToValidate="txtDescp" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                 
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
