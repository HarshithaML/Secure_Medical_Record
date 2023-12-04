<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.Master" AutoEventWireup="true" CodeBehind="AddPatientClinical.aspx.cs" Inherits="SecureMedicalRecord.AddPatientClinical" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="page-wrapper">
        <div class="main-page">
            <div class="forms">
                <h2 class="title1">
                   </h2>
                <div class="form-grids row widget-shadow" data-example-id="basic-forms">
                    <div class="form-title">
                        <h4>
                            Patient Clinical Details:</h4>
                    </div>
                    <div class="form-body">
   
                                <div class="form-group">
                                    <label>
                                        Medical History</label>
                                    <asp:TextBox ID="txtMedicalHistory" class="form-control" runat="server" placeholder="Medical History"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Medical History"
                                        ControlToValidate="txtMedicalHistory" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Patient Allergies</label>
                                    <asp:TextBox ID="txtPatientAllergies" class="form-control" runat="server" placeholder="Patient Allergies"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Patient Allergies"
                                        ControlToValidate="txtPatientAllergies" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Social History</label>
                                    <asp:TextBox ID="txtSocialHistory" class="form-control" runat="server" placeholder="Social History"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Social History"
                                        ControlToValidate="txtSocialHistory" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
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
