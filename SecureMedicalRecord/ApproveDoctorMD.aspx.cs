using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureMedicalRecord
{
    public partial class ApproveDoctorMD : System.Web.UI.Page
    {
        SecureMedicalRecord.BLL.SecureMedicalRecordBLL objSecureMedicalRecordBLL = null;
        SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
                objSecureMedicalRecordDTO = new DTO.SecureMedicalRecordDTO();
                objSecureMedicalRecordDTO.DoctorId = int.Parse(Session["UserId"].ToString());
                DataTable tab = new DataTable();
                tab = objSecureMedicalRecordBLL.Approve_DoctorData(objSecureMedicalRecordDTO);
                if (tab.Rows.Count > 0)
                {
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
                        lblRecordName.Text = tab.Rows[i]["DRecordName"].ToString();

                        TableCell RecordName = new TableCell();
                        RecordName.Controls.Add(lblRecordName);

                        Label lblDoctorName = new Label();
                        lblDoctorName.Text = tab.Rows[i]["DoctorName"].ToString();

                        TableCell DoctorName = new TableCell();
                        DoctorName.Controls.Add(lblDoctorName);

                        LinkButton lnk = new LinkButton();
                        lnk.ID = "lnk" + i.ToString();
                        lnk.Text = "Approve";
                        lnk.CommandArgument = tab.Rows[i]["RDDId"] + "," + tab.Rows[i]["EmailId"] + "," + tab.Rows[i]["DRecordName"];
                        lnk.Click += Lnk_Click;

                        TableCell lnkview = new TableCell();
                        lnkview.Controls.Add(lnk);

                        LinkButton lnkR = new LinkButton();
                        lnkR.ID = "lnkR" + i.ToString();
                        lnkR.Text = "Reject";
                        lnkR.CommandArgument = tab.Rows[i]["RDDId"] + "," + tab.Rows[i]["EmailId"] + "," + tab.Rows[i]["DRecordName"];
                        lnkR.Click += LnkR_Click;

                        TableCell lnkRview = new TableCell();
                        lnkRview.Controls.Add(lnkR);

                        row.Controls.Add(RecordName);
                        row.Controls.Add(DoctorName);
                        row.Controls.Add(lnkview);
                        row.Controls.Add(lnkRview);

                        Table1.Controls.Add(row);
                    }
                }
            }
            catch
            { }
        }

        private void LnkR_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
            objSecureMedicalRecordDTO = new DTO.SecureMedicalRecordDTO();
            objSecureMedicalRecordDTO.RDDId = int.Parse(lnk.CommandArgument.ToString().Split(',')[0]);
            Random rnd = new Random();
            objSecureMedicalRecordDTO.AccessKey = "0";
            int res = objSecureMedicalRecordBLL.Reject_DoctorData(objSecureMedicalRecordDTO);
            if (res == 1)
            {
                string message = "RecordName:" + lnk.CommandArgument.ToString().Split(',')[2] + " & Medical Record Request Rejected,Contact Doctor.";
                string Sub = "Medical Record Request Reject";
                SendEmail.Send(lnk.CommandArgument.ToString().Split(',')[1], message, Sub);
            }
        }

        private void Lnk_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
            objSecureMedicalRecordDTO = new DTO.SecureMedicalRecordDTO();
            objSecureMedicalRecordDTO.RDDId = int.Parse(lnk.CommandArgument.ToString().Split(',')[0]);
            Random rnd = new Random();
            objSecureMedicalRecordDTO.AccessKey = rnd.Next(10000, 99999).ToString();
            int res = objSecureMedicalRecordBLL.UpdateApprove_DoctorData(objSecureMedicalRecordDTO);
            if (res == 1)
            {
                //string message = "RecordName:" + lnk.CommandArgument.ToString().Split(',')[2] + " & AccessKey:" + objSecureMedicalRecordDTO.AccessKey;
                //string Sub = "Access Key Credentials";
                //SendEmail.Send(lnk.CommandArgument.ToString().Split(',')[1], message, Sub);
            }
        }
    }
}