<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor.Master" AutoEventWireup="true" CodeBehind="ViewDoctorMD.aspx.cs" Inherits="SecureMedicalRecord.ViewDoctorMD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="main-page">
            <div class="forms">
                <h2 class="title1">
                   </h2>
                <div class="form-grids row widget-shadow" data-example-id="basic-forms">
                    <div class="form-title">
                        <h4>
                            Medical Record Details:</h4>
                    </div>
                    <div class="form-body">
                        
                         <div class="tables">
                <div class="table-responsive bs-example widget-shadow">
						<h4>Medical Details</h4>
                    <asp:Table ID="Table1" runat="server" class="table table-bordered">
                    </asp:Table>
					</div>
          </div>
          <br />
          <div class="form-group">
                                    <label>
                                        Enter Access Key</label>
                                    <asp:TextBox ID="txtKey" class="form-control" runat="server" placeholder="Enter Access Key"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Access Key"
                                        ControlToValidate="txtKey" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                                
                    <br />
                     <div class="form-group">
                                    <label>
                                        Medical Data</label>
                                    <asp:TextBox ID="txtMedicalData" class="form-control" runat="server" TextMode="MultiLine" ReadOnly=true></asp:TextBox>
                                    
                                </div>   
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
