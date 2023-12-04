<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor.Master" AutoEventWireup="true" CodeBehind="AddPatientTreatment.aspx.cs" Inherits="SecureMedicalRecord.AddPatientTreatment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="main-page">
            <div class="forms">
                <h2 class="title1">
                   </h2>
                <div class="form-grids row widget-shadow" data-example-id="basic-forms">
                    <div class="form-title">
                        <h4>
                            Patient Treatment:</h4>
                    </div>
                    <div class="form-body">
                        
                                <div class="form-group">
                                    <label>
                                        Enter Patient Id</label>
                                    <asp:TextBox ID="txtPatientId" class="form-control" runat="server" placeholder="Patient Id"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Patient Id"
                                        ControlToValidate="txtPatientId" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                                
                                <div class="form-group">
                                    <label>
                                        Enter Problem Title</label>
                                    <asp:TextBox ID="txtProblem" class="form-control" runat="server" placeholder="Problem Title"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Problem Title"
                                        ControlToValidate="txtProblem" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                 
                                </div>
                                 <div class="form-group">
                                    <label>
                                        Enter Treatment Description</label>
                                    <asp:TextBox ID="txtDesp" class="form-control" runat="server" placeholder="Treatment Description"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Treatment Description"
                                        ControlToValidate="txtDesp" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                 
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
