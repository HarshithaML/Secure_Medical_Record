<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.Master" AutoEventWireup="true" CodeBehind="DoctorTimings.aspx.cs" Inherits="SecureMedicalRecord.DoctorTimings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="page-wrapper">
        <div class="main-page">
            <div class="forms">
                <h2 class="title1">
                   </h2>
                <div class="form-grids row widget-shadow" data-example-id="basic-forms">
                    <div class="form-title">
                        <h4>
                            Doctor Timing Details:</h4>
                    </div>
                    <div class="form-body">
                         <%--<div class="form-group">
                                    <label>
                                        Select Doctor</label>
                                    <asp:DropDownList ID="ddlDoctor" runat="server" class="form-control">
                                        
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlDoctor"
                                        ForeColor="#FF3300" ValidationGroup="A" InitialValue="--Select--" runat="server"
                                        ErrorMessage="Please Select Doctor Type"></asp:RequiredFieldValidator>
                                </div>--%>

                                <div class="form-group">
                                    <label>
                                        Doctor Timings</label>
                                    <asp:TextBox ID="txtDoctorTimings" class="form-control" runat="server" placeholder="Doctor Timings"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Doctor Timings"
                                        ControlToValidate="txtDoctorTimings" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
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
