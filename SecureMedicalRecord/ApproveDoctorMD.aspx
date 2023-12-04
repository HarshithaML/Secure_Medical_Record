<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor.Master" AutoEventWireup="true" CodeBehind="ApproveDoctorMD.aspx.cs" Inherits="SecureMedicalRecord.ApproveDoctorMD" %>
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
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
