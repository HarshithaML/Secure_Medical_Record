<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UploadMedicalRecord.aspx.cs" Inherits="SecureMedicalRecord.UploadMedicalRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="page-wrapper">
        <div class="main-page">
            <div class="forms">
                <h2 class="title1">
                   </h2>
                <div class="form-grids row widget-shadow" data-example-id="basic-forms">
                    <div class="form-title">
                        <h4>
                            Upload Medical Record:</h4>
                    </div>
                    <div class="form-body">
                         <div class="form-group">
                                    <label>
                                        Select Department</label>
                                    <asp:DropDownList ID="ddlDept" runat="server" class="form-control">
                                        
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlDept"
                                        ForeColor="#FF3300" ValidationGroup="A" InitialValue="--Select--" runat="server"
                                        ErrorMessage="Please Select Department Type"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Record Name</label>
                                    <asp:TextBox ID="txtRecordName" class="form-control" runat="server" placeholder="Record Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Record Name"
                                        ControlToValidate="txtRecordName" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Select Access Type</label>
                                    <asp:DropDownList ID="ddlAccessType" runat="server" class="form-control">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem>General</asp:ListItem>
                                        <asp:ListItem>Authorized</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddlAccessType"
                                        ForeColor="#FF3300" ValidationGroup="A" InitialValue="--Select--" runat="server"
                                        ErrorMessage="Please Select Access Type"></asp:RequiredFieldValidator>
                                </div>
                                
                                <div class="form-group">
                                    <label>
                                        Record Data</label>
                                    <asp:TextBox ID="txtRecordData" class="form-control" runat="server" placeholder="Record Data"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Record Data"
                                        ControlToValidate="txtRecordData" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        
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
