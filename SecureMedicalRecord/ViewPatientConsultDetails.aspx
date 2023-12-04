<%@ Page Title="" Language="C#" MasterPageFile="~/Patient.Master" AutoEventWireup="true" CodeBehind="ViewPatientConsultDetails.aspx.cs" Inherits="SecureMedicalRecord.ViewPatientConsultDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Patient Consultation Details</h3>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                               <%-- <form id="Form1" role="form" runat="server">--%>
                                <div class="form-group">
                                    <label>
                                        Patient Id</label>
                                    <asp:TextBox ID="txtPatientId" class="form-control" runat="server" placeholder="Enter Patient Id"></asp:TextBox>
                                    
                                </div>
                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
                               
                                <br />
                                <br />
                                <div class="panel-group" id="accordion">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Patient Basic
                                                    Details</a>
                                            </h4>
                                        </div>
                                        <div id="collapseOne" class="panel-collapse collapse in">
                                            <div class="panel-body">
                                                <div class="row">
                                                   
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label>
                                                                Patient First Name</label>
                                                            <asp:TextBox ID="txtPatientFirstName" class="form-control" runat="server" placeholder="Patient First Name"
                                                                ReadOnly="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                   
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label>
                                                                Gender</label>
                                                            <asp:TextBox ID="txtGender" class="form-control" runat="server" placeholder="Patient Gender"
                                                                ReadOnly="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label>
                                                               Patient Age</label>
                                                            <asp:TextBox ID="txtAge" class="form-control" runat="server" placeholder="Patient Age"
                                                                ReadOnly="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label>
                                                                Reason</label>
                                                            <asp:TextBox ID="txtReason" class="form-control" runat="server" placeholder="Reason"
                                                                ReadOnly="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label>
                                                                Mobile No</label>
                                                            <asp:TextBox ID="txtMobileNo" class="form-control" runat="server" placeholder="Mobile No"
                                                                ReadOnly="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label>
                                                                Address</label>
                                                            <asp:TextBox ID="txtAddress" class="form-control" runat="server" placeholder="Address"
                                                                ReadOnly="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">Patient Clinical
                                                    Details</a>
                                            </h4>
                                        </div>
                                        <div id="collapseTwo" class="panel-collapse collapse">
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <div class="form-group">
                                                            <label>
                                                                Medical History</label>
                                                            <asp:TextBox ID="txtMedicalHistory" class="form-control" runat="server" placeholder="Medical History"
                                                                ReadOnly="True"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>
                                                                Patient Allergies</label>
                                                            <asp:TextBox ID="txtPatientAllergies" class="form-control" runat="server" placeholder="Patient Allergies"
                                                                ReadOnly="True"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>
                                                                Social History</label>
                                                            <asp:TextBox ID="txtSocialHistory" class="form-control" runat="server" placeholder="Social History"
                                                                ReadOnly="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <!-- /.col-lg-6 (nested) -->
                                                    <!-- /.col-lg-6 (nested) -->
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree">Patient Past
                                                    Consultation</a>
                                            </h4>
                                        </div>
                                        <div id="collapseThree" class="panel-collapse collapse">
                                            <div class="panel-body">
                                                 <div class="tables">
                <div class="table-responsive bs-example widget-shadow">
                    <asp:Table ID="Table1" runat="server" class="table table-bordered">
                    </asp:Table>
					</div>
          </div>
                                            </div>
                                        </div>
                                    </div>
                                    
                                    <br />
                                    <br />
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
                                    
                                </div>
                                
                             <%--   </form>--%>
                            </div>
                            <!-- /.col-lg-6 (nested) -->
                            <!-- /.col-lg-6 (nested) -->
                        </div>
                        <!-- /.row (nested) -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
    </div>
</asp:Content>
