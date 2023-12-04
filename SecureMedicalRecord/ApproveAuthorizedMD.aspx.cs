using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SecureMedicalRecord
{
    public partial class ApproveAuthorizedMD : System.Web.UI.Page
    {
        SecureMedicalRecord.BLL.SecureMedicalRecordBLL objSecureMedicalRecordBLL = null;
        SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
                DataTable tab = new DataTable();
                tab = objSecureMedicalRecordBLL.GetDeptDetails();
                ddlDept.DataSource = tab;
                ddlDept.DataTextField = "DeptName";
                ddlDept.DataValueField = "DeptId";
                ddlDept.DataBind();
                ddlDept.Items.Insert(0, "--Select--");
            }
            LoadData();
        }

        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch
            {

            }
        }
        private void LoadData()
        {
            try
            {
                objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
                objSecureMedicalRecordDTO = new DTO.SecureMedicalRecordDTO();
                objSecureMedicalRecordDTO.DeptId = int.Parse(ddlDept.SelectedItem.Value);
                objSecureMedicalRecordDTO.AccessType = "Authorized";
                DataTable tab = new DataTable();
                tab = objSecureMedicalRecordBLL.GetDoctor_BS_AMRR(objSecureMedicalRecordDTO);
                if (tab.Rows.Count > 0)
                {
                    lblMsg.Text = "";
                    Table1.Controls.Clear();
                    TableRow hr = new TableRow();

                    TableHeaderCell hc1 = new TableHeaderCell();
                    hc1.Text = "Record Name";

                    TableHeaderCell hc2 = new TableHeaderCell();
                    hc2.Text = "Doctor Name";

                    TableHeaderCell hc3 = new TableHeaderCell();
                    hc3.Text = "";

                    TableHeaderCell hc4 = new TableHeaderCell();
                    hc4.Text = "";


                    hr.Cells.Add(hc1);
                    hr.Cells.Add(hc2);
                    hr.Cells.Add(hc3);
                    hr.Cells.Add(hc4);

                    Table1.Rows.Add(hr);
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        Label lblRecordName = new Label();
                        lblRecordName.Text = tab.Rows[i]["RecordName"].ToString();

                        TableCell RecordName = new TableCell();
                        RecordName.Controls.Add(lblRecordName);

                        Label lblDoctorName = new Label();
                        lblDoctorName.Text = tab.Rows[i]["DoctorName"].ToString();

                        TableCell DoctorName = new TableCell();
                        DoctorName.Controls.Add(lblDoctorName);

                        LinkButton lnk = new LinkButton();
                        lnk.ID = "lnk" + i.ToString();
                        lnk.Text = "Approve";
                        lnk.CommandArgument = tab.Rows[i]["ReqId"] + "," + tab.Rows[i]["EmailId"] + "," + tab.Rows[i]["RecordName"];
                        lnk.Click += new EventHandler(lnk_Click);

                        TableCell lnkview = new TableCell();
                        lnkview.Controls.Add(lnk);

                        LinkButton lnkR = new LinkButton();
                        lnkR.ID = "lnkR" + i.ToString();
                        lnkR.Text = "Reject";
                        lnkR.CommandArgument = tab.Rows[i]["ReqId"] + "," + tab.Rows[i]["EmailId"] + "," + tab.Rows[i]["RecordName"];
                        lnkR.Click += new EventHandler(lnkR_Click);

                        TableCell lnkRview = new TableCell();
                        lnkRview.Controls.Add(lnkR);

                        row.Controls.Add(RecordName);
                        row.Controls.Add(DoctorName);
                        row.Controls.Add(lnkview);
                        row.Controls.Add(lnkRview);

                        Table1.Controls.Add(row);
                    }
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "No Record Found";
                }
            }
            catch
            { }
        }

        void lnkR_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
            objSecureMedicalRecordDTO = new DTO.SecureMedicalRecordDTO();
            objSecureMedicalRecordDTO.ReqId = int.Parse(lnk.CommandArgument.ToString().Split(',')[0]);
            Random rnd = new Random();
            objSecureMedicalRecordDTO.AccessKey = rnd.Next(10000, 99999).ToString();
            int res = objSecureMedicalRecordBLL.DoctorReq_RDA_Reject(objSecureMedicalRecordDTO);
            if (res == 1)
            {
                string message = "RecordName:" + lnk.CommandArgument.ToString().Split(',')[2] + " & Medical Record Request Rejected,Contact Base Station.";
                string Sub = "Medical Record Request Reject";
                SendEmail.Send(lnk.CommandArgument.ToString().Split(',')[1], message, Sub);
                Response.Redirect("AdminHome.aspx");
            }
        }

        void lnk_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
            objSecureMedicalRecordDTO = new DTO.SecureMedicalRecordDTO();
            objSecureMedicalRecordDTO.ReqId = int.Parse(lnk.CommandArgument.ToString().Split(',')[0]);
            Random rnd = new Random();
            objSecureMedicalRecordDTO.AccessKey = rnd.Next(10000, 99999).ToString();
            int res = objSecureMedicalRecordBLL.DoctorReq_RDA_Approve(objSecureMedicalRecordDTO);
            if (res == 1)
            {
                string message = "RecordName:" + lnk.CommandArgument.ToString().Split(',')[2] + " & AccessKey:" + objSecureMedicalRecordDTO.AccessKey;
                string Sub = "Access Key Credentials";
                SendEmail.Send(lnk.CommandArgument.ToString().Split(',')[1], message, Sub);
                Response.Redirect("AdminHome.aspx");
            }
        }
    }
}